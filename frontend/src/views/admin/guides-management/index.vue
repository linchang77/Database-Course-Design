<script lang="ts" setup>
import { reactive, ref, onMounted } from "vue";
import axios from "axios";
import { ElMessage, ElMessageBox } from "element-plus";
import { CirclePlus, Search, Refresh } from "@element-plus/icons-vue";

// 酒店接口
interface Hotel {
  hotelId: number;
  hotelName: string;
  cityName: string;
  hotelGrade: string;
  hotelLocation: string;
  hotelIntroduction: string;
}

defineOptions({
  name: "Hotel-management"
});

const loading = ref<boolean>(false);
const tableData = ref<Hotel[]>([]);

//加载数据
const getTableData = async () => {
  loading.value = true;
  try {
    const response = await axios.get("https://123.60.14.84/api/TourGroup/guide/all");
    console.log(response.data);
    tableData.value = response.data;
  } catch (error) {
    ElMessage.error("获取酒店数据失败");
  } finally {
    loading.value = false;
  }
};

//空白数据格式
const DEFAULT_FORM_DATA: Partial<Hotel> = {
  hotelId: undefined,
  hotelName: "",
  cityName: "",
  hotelGrade: "",
  hotelLocation: "",
  hotelIntroduction: "",
};

const option =  ref<string>("add");
const dialogVisible = ref<boolean>(false);
const formData = ref<Partial<Hotel>>(DEFAULT_FORM_DATA);

//数据限制要求
const rules = reactive({
  hotelId: [{ required: false, trigger: "blur" }],
  hotelName: [{ required: true, message: "酒店名不能为空", trigger: "blur" }],
  cityName: [{ required: true, message: "城市名不能为空", trigger: "blur" }],
  hotelGrade: [{ required: true, message: "酒店类型不能为空", trigger: "blur" }],
  hotelLocation: [{ required: true, message: "酒店地址不能为空", trigger: "blur" }],
  hotelIntroduction: [{ required: true, message: "酒店介绍不能为空", trigger: "blur" }],
});

//提交增加需求
const handleAdd = () => {
  (formRef.value as any).validate((valid: boolean) => {
    if (valid) {
      axios.post(`https://123.60.14.84/api/Hotel/add/hotel`, formData.value)
        .then(() => {
          ElMessage.success("新增酒店成功");
          dialogVisible.value = false;
          getTableData();
        })
        .catch(() => {
          ElMessage.error("新增酒店失败");
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
  formData.value = DEFAULT_FORM_DATA;
};

//提交删除需求
const handleDelete = (row: Hotel) => {
  console.log(row.hotelId)
  ElMessageBox.confirm(`正在删除酒店：${row.hotelName}，确认删除？`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning"
  }).then(() => {
    axios.delete(`https://123.60.14.84/api/Hotel/del/hotel/${encodeURIComponent(row.hotelId)}/`)
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
    if (valid) {
      axios.put(`https://123.60.14.84/api/Hotel/mod/hotel`, formData.value)
        .then(() => {
          ElMessage.success("修改酒店成功");
          dialogVisible.value = false;
          getTableData();
        })
        .catch(() => {
          ElMessage.error("修改酒店失败");
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
const toUpdate = (row: Hotel) => {
  resetForm();
  dialogVisible.value = true;
  formData.value = { ...row };
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
          <el-button type="primary" :icon="CirclePlus" @click="toAdd()">此功能暂不可用，等待接入</el-button>
        </div>
      </div>
      <div class="table-wrapper">
        <el-table :data="tableData">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column prop="hotelId" label="酒店Id" align="center" />
          <el-table-column prop="hotelName" label="酒店名" align="center"/>
          <el-table-column prop="cityName" label="城市" align="center" />
          <el-table-column prop="hotelGrade" label="酒店类型" align="center" />
          <el-table-column prop="hotelLocation" label="酒店地址" align="center"/>
          <el-table-column prop="hotelIntroduction" label="酒店介绍" align="center" />
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
      :title="option === 'add' ? '新增酒店' : '修改酒店'"
      @closed="resetForm"
      width="30%"
    >
      <el-form ref="formRef" :model="formData" :rules="rules" label-width="100px" label-position="left">
        <el-form-item prop="hotelId" label="酒店Id">
          <el-input v-model="formData.hotelId" placeholder="" :disabled=true />
        </el-form-item>
        <el-form-item prop="hotelName" label="酒店名">
          <el-input v-model="formData.hotelName" placeholder="请输入酒店名" />
        </el-form-item>
        <el-form-item prop="cityName" label="城市名">
          <el-input v-model="formData.cityName" placeholder="请输入城市名" />
        </el-form-item>
        <el-form-item prop="hotelGrade" label="酒店类型">
          <el-input v-model="formData.hotelGrade" placeholder="请输入酒店类型" />
        </el-form-item>
        <el-form-item prop="hotelLocation" label="酒店地址">
          <el-input v-model="formData.hotelLocation" placeholder="请输入酒店地址" />
        </el-form-item>
        <el-form-item prop="hotelIntroduction" label="酒店介绍">
          <el-input v-model="formData.hotelIntroduction" placeholder="请输入酒店介绍" />
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button @click="dialogVisible = false">取消</el-button>
        <el-button type="primary" @click="option === 'add' ? handleAdd() : handleUpdate()" :loading="loading">确认</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<style lang="scss" scoped>
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
