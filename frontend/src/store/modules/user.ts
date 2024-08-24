import { ref } from "vue";
import store from "@/store";
import { defineStore } from "pinia";
import { useTagsViewStore } from "./tags-view";
import { useSettingsStore } from "./settings";
import { getToken, removeToken, setToken } from "@/utils/cache/cookies";
import { resetRouter } from "@/router";
import { loginApi, registerApi, getUserInfoApi } from "@/api/login";
import { type LoginRequestData, type RegisterRequestData } from "@/api/login/types/login";
import routeSettings from "@/config/route";

export const useUserStore = defineStore("user", () => {
  const token = ref<string>(getToken() || "");
  const roles = ref<string[]>([]);
  const username = ref<string>("");

  const tagsViewStore = useTagsViewStore();
  const settingsStore = useSettingsStore();

  /** 登录 */
  const login = async ({ username, password , role}: { username: string, password: string, role: string }) => {
    let apiEndpoint = "";

    // Determine API endpoint based on the role
    switch (role) {
      case "admin":
        apiEndpoint = "login/admin";
        break;
      case "guide":
        apiEndpoint = "login/guide";
        break;
      default:
        apiEndpoint = "login/user";
        break;
    }
    console.log("1");
    const { data } = await loginApi({ username, password }, apiEndpoint);
    setToken(data.token);
    token.value = data.token;
  };

  /** 注册 */
  const register = async ({ username, password, role }: { username: string, password: string, role: string }) => {
    let apiEndpoint = "";

    // Determine API endpoint based on the role
    switch (role) {
      case "admin":
        apiEndpoint = "register/admin";
        break;
      case "guide":
        apiEndpoint = "register/guide";
        break;
      default:
        apiEndpoint = "register/user";
        break;
    }

    const { data } = await registerApi({ username, password }, apiEndpoint);
    setToken(data.token);
    token.value = data.token;
  };

  /** 获取用户详情 */
  const getInfo = async () => {
    const { data } = await getUserInfoApi();
    username.value = data.username;
    roles.value = data.roles?.length > 0 ? data.roles : routeSettings.defaultRoles;
  };

  /** 模拟角色变化 */
  const changeRoles = async (role: string) => {
    const newToken = "token-" + role;
    token.value = newToken;
    setToken(newToken);
    window.location.reload();
  };

  /** 登出 */
  const logout = () => {
    removeToken();
    token.value = "";
    roles.value = [];
    resetRouter();
    _resetTagsView();
  };

  /** 重置 Token */
  const resetToken = () => {
    removeToken();
    token.value = "";
    roles.value = [];
  };

  /** 重置 Visited Views 和 Cached Views */
  const _resetTagsView = () => {
    if (!settingsStore.cacheTagsView) {
      tagsViewStore.delAllVisitedViews();
      tagsViewStore.delAllCachedViews();
    }
  };

  return { token, roles, username, login, register, getInfo, changeRoles, logout, resetToken };
});

/** 在 setup 外使用 */
export function useUserStoreHook() {
  return useUserStore(store);
}
