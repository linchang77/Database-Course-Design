<script lang="ts" setup>
import { reactive, ref, onMounted, computed } from "vue";
import axios from "axios";
import { ElMessage, ElMessageBox } from "element-plus";
import { CirclePlus } from "@element-plus/icons-vue";

// 用户接口
interface User {
  id: number;
  name: string;
  gender: string;
  phoneNumbers: Array<number>;
  profilePicture: string;
  registrationTime: Date;
  password: string;
}

defineOptions({
  name: "Users-management",
});

const loading = ref<boolean>(false);
const tableData = ref<User[]>([]);

// 加载数据
const getTableData = async () => {
  loading.value = true;
  try {
    const response = await axios.get("https://123.60.14.84/api/Profile/user/all");
    console.log(response.data);
    tableData.value = response.data;
  } catch (error) {
    ElMessage.error("获取用户数据失败");
  } finally {
    loading.value = false;
  }
};

// 空白数据格式
const DEFAULT_FORM_DATA: Partial<User> = {
  id: undefined,
  name: "",
  gender: "",
  phoneNumbers: [],
  profilePicture: "",
  registrationTime: undefined,
  password: "",
};

const option = ref<string>("add");
const dialogVisible = ref<boolean>(false);
const formData = ref<Partial<User>>(DEFAULT_FORM_DATA);

// 动态数据限制要求
const rules = reactive({
  id: [{ required: false, trigger: "blur" }],
  name: [{ required: true, message: "用户名不能为空", trigger: "blur" }],
  password: computed(() => option.value === "add" ? [{ required: true, message: "用户密码不能为空", trigger: "blur" }] : [{ required: false }]),
  gender: [{ required: false, trigger: "blur" }],
  phoneNumbers: [{ required: false, trigger: "blur" }],
  profilePicture: [{ required: false, trigger: "blur" }],
  registrationTime: [{ required: false, trigger: "blur" }],
});

// 提交增加需求
const handleAdd = () => {
  (formRef.value as any).validate((valid: boolean) => {
    if (valid) {
      axios
        .post(`https://123.60.14.84/api/Profile/user/add`, {
          userName: formData.value.name,
          registrationTime: formData.value.registrationTime,
          password: formData.value.password,
          profilePicture: formData.value.profilePicture,
          userGender: formData.value.gender
        })
        .then(() => {
          ElMessage.success("新增用户成功");
          console.log(formData.value.name)
          dialogVisible.value = false;
          getTableData();
          resetForm();
        })
        .catch(() => {
          ElMessage.error("新增用户失败");
        })
        .finally(() => {
          loading.value = false;
        });
    } else {
      ElMessage.error("请填写所有必填项");
    }
  });
};

// 重置表单
const resetForm = () => {
  formData.value = { ...DEFAULT_FORM_DATA };
};

// 提交删除需求
const handleDelete = (row: User) => {
  ElMessageBox.confirm(`正在删除用户：${row.name}，确认删除？`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  }).then(() => {
    axios
      .delete(`https://123.60.14.84/api/Profile/user/del/${row.id}`)
      .then(() => {
        ElMessage.success("删除成功");
        getTableData();
      })
      .catch(() => {
        ElMessage.error("删除失败");
      });
  });
};

// 提交更新需求
const handleUpdate = () => {
  (formRef.value as any).validate((valid: boolean) => {
    if (valid) {
      axios
        .put(`https://123.60.14.84/api/Profile/user/update/${formData.value.id}`, {
          userName: formData.value.name,
          registrationTime: formData.value.registrationTime,
          password: formData.value.password,
          profilePicture: formData.value.profilePicture,
          userGender: formData.value.gender
        })
        .then(() => {
          ElMessage.success("修改用户成功");
          dialogVisible.value = false;
          getTableData();
          resetForm();
        })
        .catch(() => {
          ElMessage.error("修改用户失败");
        })
        .finally(() => {
          loading.value = false;
        });
    } else {
      ElMessage.error("请填写所有必填项");
    }
  });
};

// 进入添加页面
const toAdd = () => {
  resetForm();
  option.value = "add";
  dialogVisible.value = true;
};

// 进入更新页面
const toUpdate = (row: User) => {
  resetForm();
  dialogVisible.value = true;
  formData.value = { ...DEFAULT_FORM_DATA, ...row };
  option.value = "update";
};

onMounted(() => getTableData());

const formRef = ref();
</script>

<template>
  <div class="app-container">
    <el-card v-loading="loading" shadow="never">
      <div class="toolbar-wrapper">
        <div>
          <el-button type="primary" :icon="CirclePlus" @click="toAdd()">新增用户</el-button>
        </div>
      </div>
      <div class="table-wrapper">
        <el-table :data="tableData">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column prop="id" label="用户id" align="center" />
          <el-table-column prop="name" label="用户姓名" align="center"/>
          <el-table-column prop="gender" label="用户性别" align="center" />
          <el-table-column prop="phoneNumbers" label="用户电话" align="center" />
          <el-table-column prop="profilePicture" label="用户头像" align="center"/>
          <el-table-column prop="registrationTime" label="用户注册时间" align="center" />
          <el-table-column fixed="right" label="操作" width="150" align="center">
            <template #default="scope">
              <el-button type="primary" text bg size="small" @click="toUpdate(scope.row)">修改</el-button>
              <el-button type="danger" text bg size="small" @click="handleDelete(scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </el-card>

    <!-- 表单 -->
    <el-dialog
      v-model="dialogVisible"
      :title="option === 'add' ? '新增用户' : '修改用户'"
      @closed="resetForm"
      width="30%"
    >
      <el-form ref="formRef" :model="formData" :rules="rules" label-width="100px" label-position="left">
        <el-form-item prop="id" label="用户id">
          <el-input v-model="formData.id" placeholder="" :disabled=true />
        </el-form-item>
        <el-form-item prop="name" label="用户姓名">
          <el-input v-model="formData.name" placeholder="请输入用户姓名"  />
        </el-form-item>
        <el-form-item prop="password" label="用户密码">
          <el-input v-model="formData.password" placeholder="请输入用户密码" />
        </el-form-item>
        <el-form-item prop="gender" label="用户性别">
          <el-input v-model="formData.gender" placeholder="请输入用户性别" />
        </el-form-item>
        <el-form-item prop="phoneNumbers" label="用户电话">
          <el-input v-model="formData.phoneNumbers" placeholder="请输入用户电话" />
        </el-form-item>
        <el-form-item prop="profilePicture" label="用户头像">
          <el-input v-model="formData.profilePicture" placeholder="请输入用户头像" />
        </el-form-item>
        <el-form-item prop="registrationTime" label="用户注册时间">
          <el-input v-model="formData.registrationTime" placeholder="" :disabled=true />
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button @click="dialogVisible = false">取消</el-button>
        <el-button type="primary" @click="option === 'add' ? handleAdd() : handleUpdate()">确定</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<style scoped>
.search-wrapper {
  margin-bottom: 20px;
  :deep(.el-card__body) {
    padding-bottom: 2px;
  }
}

.toolbar-wrapper {
  display: flex;
  justify-content: space-between;
  margin-bottom: 20px;
}

.table-wrapper {
  margin-bottom: 20px;
}
</style>
