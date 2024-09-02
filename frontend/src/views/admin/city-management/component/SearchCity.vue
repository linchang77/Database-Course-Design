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
        <el-button @click="onSearch" >更新</el-button>
      </template>
    </el-input>

    <!-- 展示搜索结果 -->
    <div v-if="searchResults.length > 0">
      <el-table :data="searchResults" border style="width: 100%;">
        <el-table-column prop="cityName" label="城市名称" width="200"></el-table-column>
        <el-table-column prop="province" label="省份" width="150"></el-table-column>
        <el-table-column prop="cityIntroduction" label="简介" :show-overflow-tooltip="true"></el-table-column>
      </el-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

// 搜索关键词
const searchKeyword = ref('');

// 搜索结果
const searchResults = ref([]);

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
    console.log(response.data);
    searchResults.value[0] = response.data;
    console.log(searchResults.value);
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

// 初始化加载所有城市信息
onMounted(async () => {
  await getAllCities();
});
</script>

<style scoped>
.el-table {
  margin-top: 10px;
}
</style>
