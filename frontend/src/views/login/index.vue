<script lang="ts" setup>
import { reactive, ref } from "vue";
import { useRouter } from "vue-router";
import { useUserStore } from "@/store/modules/user";
import { type FormInstance, type FormRules } from "element-plus";

const router = useRouter();

/** 登录表单元素的引用 */
const loginFormRef = ref<FormInstance | null>(null);

/** 登录按钮 Loading */
const loading = ref(false);

/** 页面状态，true 表示登录，false 表示注册 */
const isLogin = ref(true);

/** 角色选中状态 */
const selectedRole = ref("user");


/** 登录/注册表单校验规则 */
const loginFormRules: FormRules = {
  username: [{ required: true, message: "请输入用户名", trigger: "blur" }],
  password: [
    { required: true, message: "请输入密码", trigger: "blur" },
    { min: 6, max: 16, message: "长度在 6 到 16 个字符", trigger: "blur" },
  ],
};

/** 选择角色 */
const selectRole = (role: string) => {
  selectedRole.value = role;
  loginFormData.role = role;
};

/** 切换登录/注册 */
const toggleForm = () => {
  isLogin.value = !isLogin.value;
  if (!isLogin.value) {
    // 在注册模式下，只能选择游客角色
    selectedRole.value = "user";
    loginFormData.role = "user";
  }
};

/** 登录/注册逻辑 */
const loginFormData = reactive({
  username: "",
  password: "",
  role: "user" // 默认为游客角色
});

// 修改登录/注册逻辑
const handleLoginOrRegister = () => {
  loginFormRef.value?.validate((valid: boolean, fields) => {
    if (valid) {
      loading.value = true;

      const userStore = useUserStore();

      if (isLogin.value) {
        // 登录逻辑
        userStore
          .login({
            username: loginFormData.username,
            password: loginFormData.password,
            role: selectedRole.value // 需要动态传递角色
          })
          .then(() => {
            switch(selectedRole.value) {
              case "user":
                router.push({ path: "/dashboard" });
                break;
              case "guide":
                router.push({ path: "/My-orders-for-guide" });
                break;
              case "admin":
                router.push({ path: "/self-center" });
                break;
              default:
                router.push({ path: "/" });
            }
          })
          .catch(() => {
            loginFormData.password = "";
          })
          .finally(() => {
            loading.value = false;
          });
      } else {
        // 注册逻辑
        userStore
          .register({
            username: loginFormData.username,
            password: loginFormData.password,
            role: selectedRole.value // 需要动态传递角色
          })
          .then(() => {
            router.push({ path: "/dashboard" });
          })
          .catch(() => {
            loginFormData.password = "";
          })
          .finally(() => {
            loading.value = false;
          });
      }
    } else {
      console.error("表单校验不通过", fields);
    }
  });
};

</script>

<template>
  <div class="login-container">
    <div class="login-card">
      <div class="role-selection">
        <button
          :class="{ selected: selectedRole === 'user' }"
          @click="selectRole('user')"
        >
          游客
        </button>
        <!-- 仅在登录模式下显示管理员和导游 -->
        <button
          v-if="isLogin"
          :class="{ selected: selectedRole === 'guide' }"
          @click="selectRole('guide')"
        >
          导游
        </button>
        <button
          v-if="isLogin"
          :class="{ selected: selectedRole === 'admin' }"
          @click="selectRole('admin')"
        >
          管理员
        </button>
      </div>
      <div class="title">{{ isLogin ? "登录" : "注册" }}</div>
      <div class="content">
        <el-form
          ref="loginFormRef"
          :model="loginFormData"
          :rules="loginFormRules"
          @keyup.enter="handleLoginOrRegister"
        >
          <el-form-item prop="username">
            <el-input
              v-model.trim="loginFormData.username"
              placeholder="用户名"
              type="text"
              size="large"
            />
          </el-form-item>
          <el-form-item prop="password">
            <el-input
              v-model.trim="loginFormData.password"
              placeholder="密码"
              type="password"
              size="large"
              show-password
            />
          </el-form-item>
          <el-button
            :loading="loading"
            type="primary"
            size="large"
            @click.prevent="handleLoginOrRegister"
          >
            {{ isLogin ? "登 录" : "注 册" }}
          </el-button>
        </el-form>
        <div class="switch-link" @click="toggleForm">
          {{ isLogin ? "没有账号？立即注册" : "已有账号？立即登陆" }}
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.login-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  min-height: 100%;
}

.login-card {
  width: 480px;
  max-width: 90%;
  border-radius: 20px;
  box-shadow: 0 0 10px #dcdfe6;
  background-color: var(--el-bg-color);
  overflow: hidden;
  padding: 20px;

  .role-selection {
    display: flex;
    button {
      flex: 1;
      padding: 10px;
      background-color: #d3d3d3;
      border: none;
      color: #000;
      font-size: 16px;
      cursor: pointer;
      transition: background-color 0.3s ease;

      &.selected {
        background-color: #fff;
      }

      &:hover {
        background-color: #e0e0e0;
      }
    }
  }

  .title {
    text-align: center;
    font-size: 24px;
    margin: 20px 0;
  }

  .content {
    padding: 20px;

    .el-button {
      width: 100%;
      margin-top: 10px;
    }

    .switch-link {
      margin-top: 20px;
      text-align: center;
      color: #409eff;
      cursor: pointer;
    }
  }
}
</style>
