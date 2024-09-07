<template>
  <div>
    <el-input
      placeholder="请输入城市名称"
      v-model="searchKeyword"
      clearable
      style="width: 300px;"
      @keyup.enter="onSearch"
    >
      <template #append>
        <el-button type="primary" :icon="Search" @click="onSearch" style="background-color: #409eff; color: #fff; border: none; padding: 5px 10px; border-radius: 4px;">搜索</el-button>
      </template>
    </el-input>

    <!-- 展示搜索结果 -->
    <div v-if="searchResults.length > 0">
      <el-table :data="searchResults" border style="width: 100%; margin-top: 10px">
        <el-table-column prop="cityName" label="城市名称" width="150"></el-table-column>
        <el-table-column prop="province" label="省份" width="150"></el-table-column>
        <el-table-column prop="cityIntroduction" label="简介" :show-overflow-tooltip="true"></el-table-column>
        <el-table-column label="操作" fixed="right" width="150">
          <template #default="{ row }">
            <el-button @click="showModifyCityForm(row)" type="text" size="small">修改</el-button>
            <el-button @click="onDelete(row)" type="text" size="small" style="color: red;">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>

    <!-- 修改城市的对话框 -->
    <el-dialog v-model="modifyCityFormVisible" title="修改城市" :before-close="handleCloseModifyCityForm">
      <el-form :model="cityToModify" label-width="120px">
        <el-form-item label="城市名称">
          <el-input v-model="cityToModify.cityName" placeholder="请输入城市名称" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="省份">
          <el-input v-model="cityToModify.province" placeholder="请输入省份":disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="城市介绍">
          <el-input v-model="cityToModify.cityIntroduction" placeholder="请输入城市介绍"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="modifyCity">修改</el-button>
          <el-button @click="modifyCityFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage, ElMessageBox } from 'element-plus';
import { Search } from '@element-plus/icons-vue';

// 搜索关键词
const searchKeyword = ref('');

// 搜索结果
const searchResults = ref([]);

// 修改城市表单是否可见
const modifyCityFormVisible = ref(false);

// 城市数据
const cityToModify = ref({
  cityName: '',
  province: '',
  cityIntroduction: '',
  cityId: '', // 假设有一个唯一的标识符用于修改和删除
});

// 获取所有城市信息
const getAllCities = async () => {
  try {
    const response = await axios.get('https://123.60.14.84/api/City'); // 假定API路径
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('获取城市信息失败');
  }
};

// 按名称搜索城市信息
const getCitiesByName = async (keyword: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/City/${keyword}`); // 假定API路径
    searchResults.value = [response.data];
  } catch (error) {
    console.error(error);
    ElMessage.error('搜索城市信息失败');
  }
};

// 搜索事件处理器
const onSearch = async () => {
  searchResults.value = [];
  if (searchKeyword.value.trim() === '') {
    await getAllCities();
  } else {
    await getCitiesByName(searchKeyword.value);
  }
};

// 显示修改城市表单
const showModifyCityForm = (row: any) => {
  cityToModify.value = { ...row };
  modifyCityFormVisible.value = true;
};

// 关闭修改城市表单
function handleCloseModifyCityForm(done: () => void) {
  modifyCityFormVisible.value = false;
  done();
}

// 修改城市
async function modifyCity() {
  if (!cityToModify.value.cityName || !cityToModify.value.province || !cityToModify.value.cityIntroduction) {
    ElMessage.error('请输入完整的城市信息');
    return;
  }

  try {
    await axios.patch(`https://123.60.14.84/api/City/mod/intro/${cityToModify.value.cityName},${cityToModify.value.cityIntroduction}`);

    ElMessage.success('城市修改成功');
    modifyCityFormVisible.value = false;
    await onSearch(); // 刷新列表
  } catch (error) {
    console.error(error);
    ElMessage.error('修改失败');
  }
}

// 删除城市
async function onDelete(row: any) {
  ElMessageBox.confirm(
    '此操作将永久删除该城市信息, 是否继续?',
    '提示',
    {
      confirmButtonText: '确定',
      cancelButtonText: '取消',
      type: 'warning'
    }
  ).then(async () => {
    try {
      console.log(row);
      await axios.delete(`https://123.60.14.84/api/City/del/${row.cityName}`); // 假定API路径
      ElMessage.success('删除成功');
      await onSearch(); // 刷新列表
    } catch (error) {
      console.error(error);
      ElMessage.error('删除失败');
    }
  }).catch(() => {
    ElMessage.info('已取消删除');
  });
}

// 初始化加载所有城市信息
onMounted(async () => {
  await getAllCities();
});
</script>
