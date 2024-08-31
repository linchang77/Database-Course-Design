<script lang="ts" setup>
import { reactive, ref, onMounted } from "vue";
import axios from "axios";
import { ElMessage, ElMessageBox } from "element-plus";
import { CirclePlus } from "@element-plus/icons-vue";

// 导游接口
interface Guide {
  guideGender: string;
  guideId: number;
  guideIntroduction: string;
  guideName: string;
  guidePerformanceLevel: string;
  guidePrice: number;
  guideSalary: number;
  guideSeniority: string;
  profilePicture: string;
  guideFree: boolean,
  password: string
}

defineOptions({
  name: "Guide-management"
});

const loading = ref<boolean>(false);
const tableData = ref<Guide[]>([]);

//加载数据
const getTableData = async () => {
  loading.value = true;
  try {
    const response = await axios.get("https://123.60.14.84/api/Guide/all");
    console.log(response.data);
    tableData.value = response.data;
  } catch (error) {
    ElMessage.error("获取导游数据失败");
  } finally {
    loading.value = false;
  }
};

//空白数据格式
const DEFAULT_FORM_DATA: Partial<Guide> = {
  guideGender: "",
  guideId: undefined,
  guideIntroduction: "",
  guideName: "",
  guidePerformanceLevel: "",
  guidePrice: undefined,
  guideSalary: undefined,
  guideSeniority: "",
  profilePicture: "",
  guideFree: true,
  password: "",
};

const option =  ref<string>("add");
const dialogVisible = ref<boolean>(false);
const formData = ref<Partial<Guide>>(DEFAULT_FORM_DATA);

//数据限制要求
const rules = reactive({
  guideGender: [{ required: true, message: "导游性别不能为空", trigger: "blur" }],
  guideId: [{ required: false, trigger: "blur" }],
  guideIntroduction: [{ required: true, message: "导游介绍不能为空", trigger: "blur" }],
  guideName: [{ required: true, message: "导游姓名不能为空", trigger: "blur" }],
  guidePerformanceLevel: [{ required: true, message: "导游表现不能为空", trigger: "blur" }],
  guidePrice: [{ required: true, message: "导游价格不能为空", trigger: "blur" }],
  guideSalary: [{ required: true, message: "导游薪水不能为空", trigger: "blur" }],
  guideSeniority: [{ required: true, message: "导游资历不能为空", trigger: "blur" }],
  profilePicture: [{ required: false,  trigger: "blur" }],
  guideFree: [{ required: false,  trigger: "blur" }],
  password:[{ required: false,  trigger: "blur" }],
});

//提交增加需求
const handleAdd = () => {
  (formRef.value as any).validate((valid: boolean) => {
    if (valid) {
      axios.post(`https://123.60.14.84/api/Guide/add`, formData.value)
        .then(() => {
          ElMessage.success("新增导游成功");
          dialogVisible.value = false;
          getTableData();
          resetForm(); // 重置表单数据
        })
        .catch(() => {
          ElMessage.error("新增导游失败");
        })
        .finally(() => {
          loading.value = false;
        });
    } else {
      ElMessage.error("请填写所有必填项");
    }
  });
};

//重置表单
const resetForm = () => {
  formData.value = { ...DEFAULT_FORM_DATA };
};

//提交删除需求
const handleDelete = (row: Guide) => {
  console.log(row.guideId)
  ElMessageBox.confirm(`正在删除导游：${row.guideName}，确认删除？`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning"
  }).then(() => {
    axios.delete(`https://123.60.14.84/api/Guide/del/${encodeURIComponent(row.guideId)}`)
      .then(() => {
        ElMessage.success("删除成功");
        getTableData();
      })
      .catch(() => {
        ElMessage.error("删除失败");
      });
  });
};

//提交更新需求
const handleUpdate = () => {
  (formRef.value as any).validate((valid: boolean) => {
    console.log(formData.value)
    if (valid) {
      axios.put(`https://123.60.14.84/api/Guide/update/${encodeURIComponent(Number(formData.value.guideId))}`, formData.value)
        .then(() => {
          ElMessage.success("修改导游成功");
          dialogVisible.value = false;
          getTableData();
          resetForm(); // 重置表单数据
        })
        .catch(() => {
          ElMessage.error("修改导游失败");
        })
        .finally(() => {
          loading.value = false;
        });
    } else {
      ElMessage.error("请填写所有必填项");
    }
  });
};

//进入添加页面
const toAdd = () => {
  resetForm();
  option.value = "add";
  dialogVisible.value = true;
};

//进入更新页面
const toUpdate = (row: Guide) => {
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
          <el-button type="primary" :icon="CirclePlus" @click="toAdd()">新增导游</el-button>
        </div>
      </div>
      <div class="table-wrapper">
        <el-table :data="tableData">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column prop="guideGender" label="导游性别" align="center" />
          <el-table-column prop="guideId" label="导游Id" align="center"/>
          <el-table-column prop="guideIntroduction" label="导游介绍" align="center" />
          <el-table-column prop="guideName" label="导游姓名" align="center" />
          <el-table-column prop="guidePerformanceLevel" label="导游表现" align="center"/>
          <el-table-column prop="guidePrice" label="导游价格" align="center" />
          <el-table-column prop="guideSalary" label="导游薪水介绍" align="center" />
          <el-table-column prop="guideSeniority" label="导游资历介绍" align="center" />
          <el-table-column prop="profilePicture" label="导游图片链接" align="center" />
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
      :title="option === 'add' ? '新增导游' : '修改导游'"
      @closed="resetForm"
      width="30%"
    >
      <el-form ref="formRef" :model="formData" :rules="rules" label-width="100px" label-position="left">
        <el-form-item prop="guideId" label="导游Id">
          <el-input v-model="formData.guideId" placeholder="" :disabled=true />
        </el-form-item>
        <el-form-item prop="guideGender" label="导游性别">
          <el-input v-model="formData.guideGender" placeholder="请输入导游性别"  />
        </el-form-item>
        <el-form-item prop="guideIntroduction" label="导游介绍">
          <el-input v-model="formData.guideIntroduction" placeholder="请输入导游介绍" />
        </el-form-item>
        <el-form-item prop="guideName" label="导游姓名">
          <el-input v-model="formData.guideName" placeholder="请输入导游姓名" />
        </el-form-item>
        <el-form-item prop="guidePerformanceLevel" label="导游表现">
          <el-input v-model="formData.guidePerformanceLevel" placeholder="请输入导游表现" />
        </el-form-item>
        <el-form-item prop="guidePrice" label="导游价格">
          <el-input v-model="formData.guidePrice" placeholder="请输入导游价格" />
        </el-form-item>
        <el-form-item prop="guideSalary" label="导游薪水">
          <el-input v-model="formData.guideSalary" placeholder="请输入导游薪水" />
        </el-form-item>
        <el-form-item prop="guideSeniority" label="导游资历">
          <el-input v-model="formData.guideSeniority" placeholder="请输入导游资历" />
        </el-form-item>
        <el-form-item prop="profilePicture" label="导游图片链接">
          <el-input v-model="formData.profilePicture" placeholder="请输入导游图片链接" />
        </el-form-item>
        <el-form-item prop="guideFree" label="导游是否空闲">
          <el-input v-model="formData.guideFree" placeholder="请输入导游是否空闲" />
        </el-form-item>
        <el-form-item prop="password" label="导游密码">
          <el-input v-model="formData.password" placeholder="请输入导游密码" />
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
