<script lang="ts" setup>
import { reactive, ref, onMounted } from "vue";
import axios from "axios";
import { ElMessage, ElMessageBox } from "element-plus";
import { CirclePlus, Search, Refresh } from "@element-plus/icons-vue";

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

// Search form data
const searchData = reactive({
  hotelId: "",
  hotelName: ""
});

// Fetch hotels (Read)
const getTableData = async (queryParams: any = {}) => {
  loading.value = true;
  try {
    const response = await axios.get("https://123.60.14.84/api/Hotel/detail/all", { params: queryParams });
    tableData.value = response.data;
  } catch (error) {
    ElMessage.error("获取酒店数据失败");
  } finally {
    loading.value = false;
  }
};

//#region 增
const DEFAULT_FORM_DATA: Partial<Hotel> = {
  hotelId: undefined,
  hotelName: "",
  cityName: "",
  hotelGrade: "",
  hotelLocation: "",
  hotelIntroduction: "",
};
const dialogVisible = ref<boolean>(false);
const formData = ref<Partial<Hotel>>(DEFAULT_FORM_DATA);

const handleCreateOrUpdate = () => {
  if (!formData.value.hotelId) {
    // Create hotel
    axios.post("https://123.60.14.84/api/Hotel/detail/", formData.value)
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
    // Update hotel
    axios.put(`https://123.60.14.84/api/Hotel/detail/${formData.value.hotelId}`, formData.value)
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
  }
};

const resetForm = () => {
  formData.value = DEFAULT_FORM_DATA;
};
//#endregion

//#region 删
const handleDelete = (row: Hotel) => {
  ElMessageBox.confirm(`正在删除酒店：${row.hotelName}，确认删除？`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning"
  }).then(() => {
    axios.delete(`https://123.60.14.84/api/Hotel/detail/${row.hotelId}`)
      .then(() => {
        ElMessage.success("删除成功");
        getTableData();
      })
      .catch(() => {
        ElMessage.error("删除失败");
      });
  });
};
//#endregion

//#region 改
const handleUpdate = (row: Hotel) => {
  dialogVisible.value = true;
  formData.value = { ...row };
};
//#endregion

// Search and reset
const handleSearch = () => {
  getTableData(searchData);
};

const resetSearch = () => {
  searchData.hotelId = "";
  searchData.hotelName = "";
  getTableData(); // Fetch data without query parameters
};

// Initialize table data
onMounted(() => getTableData());
</script>

<template>
  <div class="app-container">
    <el-card v-loading="loading" shadow="never" class="search-wrapper">
      <el-form ref="searchFormRef" :inline="true" :model="searchData">
        <el-form-item prop="hotelId" label="酒店Id">
          <el-input v-model="searchData.hotelId" placeholder="请输入" />
        </el-form-item>
        <el-form-item prop="hotelName" label="酒店名称">
          <el-input v-model="searchData.hotelName" placeholder="请输入" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" :icon="Search" @click="handleSearch">查询</el-button>
          <el-button :icon="Refresh" @click="resetSearch">重置</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <el-card v-loading="loading" shadow="never">
      <div class="toolbar-wrapper">
        <div>
          <el-button type="primary" :icon="CirclePlus" @click="dialogVisible = true">新增酒店</el-button>
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
              <el-button type="primary" text bg size="small" @click="handleUpdate(scope.row)">修改</el-button>
              <el-button type="danger" text bg size="small" @click="handleDelete(scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </el-card>

    <!-- 新增/修改 -->
    <el-dialog
      v-model="dialogVisible"
      :title="formData.hotelId === undefined ? '新增酒店' : '修改酒店'"
      @closed="resetForm"
      width="30%"
    >
      <el-form ref="formRef" :model="formData" label-width="100px" label-position="left">
        <el-form-item prop="hotelId" label="酒店Id">
          <el-input v-model="formData.hotelId" placeholder="请输入酒店Id" />
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
        <el-button type="primary" @click="handleCreateOrUpdate" :loading="loading">确认</el-button>
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
