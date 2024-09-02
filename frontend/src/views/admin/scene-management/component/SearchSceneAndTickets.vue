<template>
  <div>
    <el-select v-model="searchType" placeholder="请选择搜索类型" style="width: 120px;" @change="onSearchAll">
      <el-option label="搜索景点" value="spots"></el-option>
      <el-option label="搜索票" value="tickets"></el-option>
    </el-select>
    <el-input
      placeholder="请输入景区名称"
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
      <el-table :data="searchResults" border-style="width: 100%;">
        <template v-if="searchType === 'spots'">
          <el-table-column prop="scenicSpotId" label="ID" width="80"></el-table-column>
          <el-table-column prop="scenicSpotName" label="景点名称" width="200"></el-table-column>
          <el-table-column prop="cityName" label="城市" width="100"></el-table-column>
          <el-table-column prop="scenicSpotGrade" label="等级" width="80"></el-table-column>
          <el-table-column prop="scenicSpotIntroduction" label="简介" :show-overflow-tooltip="true"></el-table-column>
          <el-table-column prop="scenicSpotLocation" label="位置" :show-overflow-tooltip="true"></el-table-column>
        </template>
        <template v-if="searchType === 'tickets'">
          <el-table-column prop="scenicSpotId" label="景点ID" ></el-table-column>
          <el-table-column prop="ticketType" label="票种" ></el-table-column>
          <el-table-column prop="ticketPrice" label="价格(元)" ></el-table-column>
          <el-table-column prop="ticketRemaining" label="剩余票数" ></el-table-column>
          <el-table-column prop="ticketDate" label="日期" ></el-table-column>
        </template>
      </el-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

// 搜索类型
const searchType = ref('spots');

// 搜索关键词
const searchKeyword = ref('');

// 搜索结果
const searchResults = ref([]);

// 获取所有景点
const getAllSpots = async () => {
  try {
    const response = await axios.get('https://123.60.14.84/api/ScenicSpot/all/spots');
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('获取景点失败');
  }
};

// 获取所有票
const getAllTickets = async () => {
  try {
    const response = await axios.get('https://123.60.14.84/api/ScenicSpot/all/tickets');
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('获取票务信息失败');
  }
};

// 按名称搜索景点
const getSpotsByName = async (keyword: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/ScenicSpot/name/${keyword}`);
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('搜索景点失败');
  }
};

// 按名称搜索票
const getTicketsBySpotName = async (keyword: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/ScenicSpot/ticket/${keyword}`);
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('搜索票务信息失败');
  }
};

// 搜索事件处理器
const onSearch = async () => {
  searchResults.value = [];
  if (searchType.value === 'spots') {
    if (searchKeyword.value.trim() === '') {
      await getAllSpots();
    } else {
      await getSpotsByName(searchKeyword.value);
    }
  } else if (searchType.value === 'tickets') {
    if (searchKeyword.value.trim() === '') {
      await getAllTickets();
    } else {
      await getTicketsBySpotName(searchKeyword.value);
    }
  }
  searchKeyword.value = '';
};

// 在搜索类型改变时自动触发搜索
const onSearchAll = async () => {
  if (searchType.value === 'spots') {
    await getAllSpots();
  } else if (searchType.value === 'tickets') {
    await getAllTickets();
  }
};

// 初始化加载所有景点
onMounted(async () => {
  await getAllSpots();
});
</script>

<style scoped>
.el-table {
  margin-top: 10px;
}
</style>
