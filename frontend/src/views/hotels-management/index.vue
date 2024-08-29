<script lang="ts" setup>
import { reactive, ref, watch } from "vue"
import { type CreateOrUpdateTableRequestData, type GetTableData } from "@/api/table/types/table"
import { type FormInstance, type FormRules, ElMessage, ElMessageBox } from "element-plus"
import { Search, Refresh, CirclePlus, Delete, Download, RefreshRight } from "@element-plus/icons-vue"
import { usePagination } from "@/hooks/usePagination"
import { cloneDeep } from "lodash-es"
import axios from 'axios';

interface Hotel {
  id: number;
  name: string;
  grade: string;
  location: string;
  description: string;
  roomType: string;
  roomLeft: number;
  roomPrice: number;
  imageUrl: string; 
}

defineOptions({
  name: "Hotel-management"
})

const loading = ref<boolean>(false)
const { paginationData, handleCurrentChange, handleSizeChange } = usePagination()

// const mockData: GetTableData[] = [
//   {
//     id: "1",
//     username: "user1",
//     roles: "admin",
//     phone: "12345678901",
//     email: "user1@example.com",
//     status: true,
//     createTime: "2024-08-01 10:00:00",
//   },
//   {
//     id: "2",
//     username: "user2",
//     roles: "user",
//     phone: "19876543210",
//     email: "user2@example.com",
//     status: false,
//     createTime: "2024-08-02 12:30:00",
//   },
//   {
//     id: "3",
//     username: "user3",
//     roles: "user",
//     phone: "12312312345",
//     email: "user3@example.com",
//     status: true,
//     createTime: "2024-08-03 09:15:00",
//   },
// ];

//#region 增
const DEFAULT_FORM_DATA: CreateOrUpdateTableRequestData = {
  id: undefined,
  username: "",
  password: ""
}
const dialogVisible = ref<boolean>(false)
const formRef = ref<FormInstance | null>(null)
const formData = ref<CreateOrUpdateTableRequestData>(cloneDeep(DEFAULT_FORM_DATA))
const formRules: FormRules<CreateOrUpdateTableRequestData> = {
  username: [{ required: true, trigger: "blur", message: "请输入用户名" }],
  password: [{ required: true, trigger: "blur", message: "请输入密码" }]
}

const handleCreateOrUpdate = () => {
  formRef.value?.validate((valid: boolean, fields) => {
    if (!valid) return console.error("表单校验不通过", fields)
    loading.value = true

    // if (formData.value.id === undefined) {
    //   // 新增用户
    //   formData.value.id = String(mockData.length + 1);
    //   mockData.push(cloneDeep(formData.value as GetTableData));
    // } else {
    //   // 更新用户
    //   const index = mockData.findIndex(item => item.id === formData.value.id);
    //   if (index !== -1) mockData[index] = cloneDeep(formData.value as GetTableData);
    // }

    // ElMessage.success("操作成功");
    // dialogVisible.value = false;
    // getTableData();
    // loading.value = false;
    
    const apiUrl = formData.value.id === undefined ? '/api/table/create' : `/api/table/update/${formData.value.id}`;
    const apiMethod = formData.value.id === undefined ? 'post' : 'put';

    axios({
      method: apiMethod,
      url: apiUrl,
      data: formData.value,
    })
    .then(() => {
      ElMessage.success("操作成功")
      dialogVisible.value = false
      getTableData()
    })
    .finally(() => {
      loading.value = false
    })
  })
}

const resetForm = () => {
  formRef.value?.clearValidate()
  formData.value = cloneDeep(DEFAULT_FORM_DATA)
}
//#endregion

//#region 删
const handleDelete = (row: Hotel) => {
  ElMessageBox.confirm(`正在删除用户：${row.name}，确认删除？`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning"
  }).then(() => {
    // const index = mockData.findIndex(item => item.id === row.id);
    // if (index !== -1) mockData.splice(index, 1);
    // ElMessage.success("删除成功");
    // getTableData();
    axios.delete(`/api/table/delete/${row.id}`)
      .then(() => {
        ElMessage.success("删除成功")
        getTableData()
      })
  })
}
//#endregion

//#region 改
const handleUpdate = (row: Hotel) => {
  dialogVisible.value = true
  formData.value = cloneDeep(row)
}
//#endregion

//#region 查
const tableData = ref<Hotel[]>([])
const searchFormRef = ref<FormInstance | null>(null)
const searchData = reactive({
  name: "",
  location: ""
})

const getTableData = () => {
  loading.value = true;

  // // 模拟分页和搜索功能
  // const filteredData = mockData.filter(item => {
  //   return (
  //     (!searchData.username || item.username.includes(searchData.username)) &&
  //     (!searchData.phone || item.phone.includes(searchData.phone))
  //   );
  // });

  // paginationData.total = filteredData.length;
  // tableData.value = filteredData.slice(
  //   (paginationData.currentPage - 1) * paginationData.pageSize,
  //   paginationData.currentPage * paginationData.pageSize
  // );

  // loading.value = false;
  axios.get('/api/table', {
    params: {
      currentPage: paginationData.currentPage,
      size: paginationData.pageSize,
      username: searchData.name || undefined,
      phone: searchData.location || undefined,
    },
  })
    .then(response => {
      const data = response.data;
      paginationData.total = data.total;
      tableData.value = data.list;
    })
    .catch(() => {
      tableData.value = [];
    })
    .finally(() => {
      loading.value = false;
    });
};

const handleSearch = () => {
  paginationData.currentPage === 1 ? getTableData() : (paginationData.currentPage = 1)
}

const resetSearch = () => {
  searchFormRef.value?.resetFields()
  handleSearch()
}
//#endregion

/** 监听分页参数的变化 */
watch([() => paginationData.currentPage, () => paginationData.pageSize], getTableData, { immediate: true })
</script>


<template>
  <div class="app-container">
    <el-card v-loading="loading" shadow="never" class="search-wrapper">
      <el-form ref="searchFormRef" :inline="true" :model="searchData">
        <el-form-item prop="username" label="酒店名">
          <el-input v-model="searchData.name" placeholder="请输入" />
        </el-form-item>
        <el-form-item prop="phone" label="酒店位置">
          <el-input v-model="searchData.location" placeholder="请输入" />
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
          <el-button type="danger" :icon="Delete">批量删除</el-button>
        </div>
      </div>
      <div class="table-wrapper">
        <el-table :data="tableData">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column prop="username" label="用户名" align="center" />
          <el-table-column prop="roles" label="角色" align="center">
            <template #default="scope">
              <el-tag v-if="scope.row.roles === 'admin'" type="primary" effect="plain">admin</el-tag>
              <el-tag v-else type="warning" effect="plain">{{ scope.row.roles }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="phone" label="手机号" align="center" />
          <el-table-column prop="email" label="邮箱" align="center" />
          <el-table-column prop="status" label="状态" align="center">
            <template #default="scope">
              <el-tag v-if="scope.row.status" type="success" effect="plain">启用</el-tag>
              <el-tag v-else type="danger" effect="plain">禁用</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="createTime" label="创建时间" align="center" />
          <el-table-column fixed="right" label="操作" width="150" align="center">
            <template #default="scope">
              <el-button type="primary" text bg size="small" @click="handleUpdate(scope.row)">修改</el-button>
              <el-button type="danger" text bg size="small" @click="handleDelete(scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
      </div>
      <div class="pager-wrapper">
        <el-pagination
          background
          :layout="paginationData.layout"
          :page-sizes="paginationData.pageSizes"
          :total="paginationData.total"
          :page-size="paginationData.pageSize"
          :currentPage="paginationData.currentPage"
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
        />
      </div>
    </el-card>
    <!-- 新增/修改 -->
    <el-dialog
      v-model="dialogVisible"
      :title="formData.id === undefined ? '新增用户' : '修改用户'"
      @closed="resetForm"
      width="30%"
    >
      <el-form ref="formRef" :model="formData" :rules="formRules" label-width="100px" label-position="left">
        <el-form-item prop="username" label="用户名">
          <el-input v-model="formData.username" placeholder="请输入" />
        </el-form-item>
        <el-form-item prop="password" label="密码" v-if="formData.id === undefined">
          <el-input v-model="formData.password" placeholder="请输入" />
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

.pager-wrapper {
  display: flex;
  justify-content: flex-end;
}
</style>

