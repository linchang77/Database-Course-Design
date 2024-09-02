<template>
  <div class="search-container">
    <el-select v-model="searchType" placeholder="请选择搜索类型" @change="onSearch" style="width: 100px;">
      <el-option label="搜索行程" value="schedule"></el-option>
      <el-option label="搜索票务" value="ticket"></el-option>
    </el-select>
    <el-input
      placeholder="请输入班号或车票编号"
      v-model="searchKeyword"
      clearable
      style="width: 500px; margin-left: 10px;"
      @keyup.enter="onSearch"
    >
      <template #append>
        <el-button @click="onSearch" >更新</el-button>
      </template>
    </el-input>

    <!-- 展示搜索结果 -->
    <div v-if="searchResults.length > 0">
      <el-table :data="searchResults" border style="width: 100%;">
        <template v-if="searchType === 'schedule'">
          <el-table-column prop="vehicleId" label="班号" width="180"></el-table-column>
          <el-table-column prop="vehicleType" label="车型" width="180"></el-table-column>
          <el-table-column prop="departureTime" label="出发时间" width="180"></el-table-column>
          <el-table-column prop="arrivalTime" label="到达时间" width="180"></el-table-column>
          <el-table-column prop="departureStation" label="出发站" width="180"></el-table-column>
          <el-table-column prop="arrivalStation" label="到达站" width="180"></el-table-column>
          <el-table-column prop="vehicleModel" label="机型" width="180"></el-table-column>
          <el-table-column prop="departureCity" label="出发城市" width="180"></el-table-column>
          <el-table-column prop="arrivalCity" label="到达城市" width="180"></el-table-column>
        </template>

        <template v-else-if="searchType === 'ticket'">
          <el-table-column prop="ticketId" label="车票编号" width="180"></el-table-column>
          <el-table-column prop="ticketType" label="票种" width="180"></el-table-column>
          <el-table-column prop="ticketPrice" label="票价" width="180"></el-table-column>
          <el-table-column prop="ticketDepartureTime" label="出发时间" width="180"></el-table-column>
          <el-table-column prop="ticketArrivalTime" label="到达时间" width="180"></el-table-column>
          <el-table-column prop="ticketDepartureStation" label="出发站" width="180"></el-table-column>
          <el-table-column prop="ticketArrivalStation" label="到达站" width="180"></el-table-column>
          <el-table-column prop="ticketDepartureCity" label="出发城市" width="180"></el-table-column>
          <el-table-column prop="ticketArrivalCity" label="到达城市" width="180"></el-table-column>
          <el-table-column prop="ticketRemaining" label="剩余票数" width="180"></el-table-column>
        </template>
      </el-table>
    </div>
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

// 定义行程数据模型
interface Schedule {
  vehicleId: string;
  vehicleType: string;
  departureTime: string;
  arrivalTime: string;
  departureStation: string;
  arrivalStation: string;
  vehicleModel: string;
  departureCity: string;
  arrivalCity: string;
}

// 定义车票数据模型
interface Ticket {
  ticketId: number;
  ticketType: string;
  ticketPrice: number;
  ticketDepartureTime: string;
  ticketArrivalTime: string;
  ticketDepartureStation: string;
  ticketArrivalStation: string;
  ticketDepartureCity: string;
  ticketArrivalCity: string;
  ticketRemaining: number;
}

// 搜索类型
const searchType = ref<string>('schedule');

// 搜索关键词
const searchKeyword = ref<string>('');

// 搜索结果
const searchResults = ref<any[]>([]);

// 获取所有班次信息
const getAllSchedules = async () => {
  try {
    const response = await axios.get('https://123.60.14.84:11000/api/Vehicle/schedules');
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('获取班次信息失败');
  }
};

// 获取指定班号的班次信息
const getScheduleById = async (vehicleId: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/schedule/${vehicleId}`);
    searchResults.value = [response.data];
  } catch (error) {
    console.error(error);
    ElMessage.error('获取指定班号的班次信息失败');
  }
};

// 获取所有车票信息
const getAllTickets = async () => {
  try {
    const response = await axios.get('https://123.60.14.84:11000/api/Vehicle/tickets');
    searchResults.value = response.data;
  } catch (error) {
    console.error(error);
    ElMessage.error('获取车票信息失败');
  }
};

// 获取指定车票编号的车票信息
const getTicketById = async (ticketId: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/ticket/${ticketId}`);
    searchResults.value = [response.data];
  } catch (error) {
    console.error(error);
    ElMessage.error('获取指定车票编号的车票信息失败');
  }
};

// 搜索事件处理器
const onSearch = async () => {
  searchResults.value = [];
  if (searchKeyword.value.trim() === '') {
    if (searchType.value === 'schedule') {
      await getAllSchedules();
    } else if (searchType.value === 'ticket') {
      await getAllTickets();
    }
  } else {
    if (searchType.value === 'schedule') {
      await getScheduleById(searchKeyword.value);
    } else if (searchType.value === 'ticket') {
      await getTicketById(searchKeyword.value);
    }
  }
};

// 初始化加载所有班次信息
onMounted(async () => {
  await getAllSchedules();
});
</script>

<style scoped>
.el-table {
  margin-top: 10px;
}
</style>
<style scoped>
.search-container {

  align-items: center;
  margin-bottom: 10px;
}

.el-table {
  margin-top: 10px;
}
</style>
