<!-- eslint-disable prettier/prettier -->
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
    <div class="overlay">
      <img src="~@/assets/login/bg3.jpg" alt="bg" />
    </div>

    <div class="login-card">
      <!-- Logo -->
      <div class="logo">
        <img src="~@/assets/layouts/logo-text-2.png" alt="e行天下" />
        <div class="name">e行天下</div>
      </div>
      <!-- 角色选择 -->
      <div class="role-selection">
        <button :class="{ selected: selectedRole === 'user' }" @click="selectRole('user')">游客</button>
        <!-- 仅在登录模式下显示管理员和导游 -->
        <button v-if="isLogin" :class="{ selected: selectedRole === 'guide' }" @click="selectRole('guide')">
          导游
        </button>
        <button v-if="isLogin" :class="{ selected: selectedRole === 'admin' }" @click="selectRole('admin')">
          管理员
        </button>
      </div>
      <div class="title">{{ isLogin ? "登录" : "注册" }}</div>
      <div class="content">
        <el-form ref="loginFormRef" :model="loginFormData" :rules="loginFormRules" @keyup.enter="handleLoginOrRegister">
          <el-form-item prop="username">
            <el-input v-model.trim="loginFormData.username" placeholder="用户名" type="text" size="large" />
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
          <el-button :loading="loading" type="primary" size="large" @click.prevent="handleLoginOrRegister">
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
  justify-content: center;
  align-items: center;
  width: 100vw;
  height: 100vh;
  position: relative;
  overflow: hidden;
}

.overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
}

.overlay img {
  width: 100%;
  height: 100%;
  object-fit: cover; /* 这个属性可以确保图片在容器内以合理方式缩放 */
}

.login-card {
  position: relative;
  z-index: 10;
  width: 400px;
  padding: 30px;
  border-radius: 15px;
  background: rgba(255, 255, 255, 0.311); /* 半透明背景 */
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(10px); /* 背景模糊效果 */
  text-align: center;

  .logo {
    display: flex;
    justify-content: center;
    align-items: center; // 使img和name垂直居中对齐
    margin-top: -15px;
    margin-bottom: 0px;

    img {
      width: 170px;
      margin-right: 10px; // 给img和name之间添加一些间距
    }

    .name {
      font-size: 28px;
      color: #409eff;
      font-weight: bolder;
      margin-left: -20px;
      margin-bottom: -5px;
    }
  }

  .role-selection {
    display: flex;
    justify-content: space-between;
    margin-bottom: 20px;
    button {
      flex: 1;
      padding: 10px;
      background-color: #fffdfdad;
      border-radius: 5px;
      margin-left: 2px;
      margin-right: 2px;
      border: none;
      color: #000;
      font-size: 16px;
      cursor: pointer;
      transition: background-color 0.3s ease;
      cursor: pointer;
      &.selected {
        background-color: #409eff;
        color: #fff;
      }

      &:hover {
        background-color: #d0d0d0d5;
      }
    }
  }

  .title {
    font-size: 20px;
    font-weight: bold;
    color: #333333e2;
    margin-bottom: 20px;
  }

  .content {
    border-radius: 5px;
    .el-input,
    .el-button {
      margin-bottom: 15px;
      border-radius: 5px;
    }

    .el-button {
      width: 100%;
      padding: 10px;
      border-radius: 5px;
    }

    .switch-link {
      font-size: 14px;
      color: #fafafacc;
      cursor: pointer;
      margin-top: 20px;

      &:hover {
        text-decoration: underline;
      }
    }
  }
}
</style>
