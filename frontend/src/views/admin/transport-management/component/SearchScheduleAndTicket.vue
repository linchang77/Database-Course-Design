<template>
  <div class="search-container">
    <el-select v-model="searchType" placeholder="请选择搜索类型" @change="onSearch" style="width: 100px;">
      <el-option label="搜索行程" value="schedule"></el-option>
      <el-option label="搜索票务" value="ticket"></el-option>
    </el-select>
    <el-input
      placeholder="请输入交通工具ID或票据编号"
      v-model="searchKeyword"
      clearable
      style="width: 500px; margin-left: 10px;"
      @keyup.enter="onSearch"
    >
      <template #append>
        <el-button type="primary" :icon="Search" @click="onSearch" style="background-color: #409eff; color: #fff; border: none; padding: 5px 10px; border-radius: 4px;">搜索</el-button>
      </template>
    </el-input>

    <!-- 展示搜索结果 -->
    <div v-if="searchResults.length > 0">
      <el-table :data="searchResults" border style="width: 100%;margin-top: 10px;">
        <template v-if="searchType === 'schedule'">
          <el-table-column prop="vehicleId" label="交通工具ID" width="100"></el-table-column>
          <el-table-column prop="vehicleType" label="交通工具类型" width="120">
            <template #default="{ row }">
              {{ getVehicleTypeLabel(row.vehicleType) }}
            </template>
          </el-table-column>
          <el-table-column prop="departureTime" label="出发时间" width="180"></el-table-column>
          <el-table-column prop="arrivalTime" label="到达时间" width="180"></el-table-column>
          <el-table-column prop="departureStation" label="出发站" width="140"></el-table-column>
          <el-table-column prop="arrivalStation" label="到达站" width="140"></el-table-column>
          <el-table-column prop="vehicleModel" label="交通工具型号" width="140"></el-table-column>
          <el-table-column prop="departureCity" label="出发城市" width="130"></el-table-column>
          <el-table-column prop="arrivalCity" label="到达城市" width="130"></el-table-column>
        </template>

        <template v-else-if="searchType === 'ticket'">
          <el-table-column prop="vehicleId" label="交通工具ID" width="130"></el-table-column>
          <el-table-column prop="ticketId" label="车票编号" width="100"></el-table-column>
          <el-table-column prop="ticketType" label="票种" width="100"></el-table-column>
          <el-table-column prop="ticketPrice" label="票价" width="80"></el-table-column>
          <el-table-column prop="ticketDepartureTime" label="出发时间" width="180"></el-table-column>
          <el-table-column prop="ticketArrivalTime" label="到达时间" width="180"></el-table-column>
          <el-table-column prop="ticketDepartureStation" label="出发站" width="160"></el-table-column>
          <el-table-column prop="ticketArrivalStation" label="到达站" width="160"></el-table-column>
          <el-table-column prop="ticketDepartureCity" label="出发城市" width="100"></el-table-column>
          <el-table-column prop="ticketArrivalCity" label="到达城市" width="100"></el-table-column>
          <el-table-column prop="ticketRemaining" label="剩余票数" width="100"></el-table-column>
        </template>
        <el-table-column label="操作" fixed="right" >
          <template #default="{ row }">
            <!--
            <el-button @click="showModifyForm(row)" type="text" size="small">修改</el-button>
            -->
            <el-button @click="onDelete(row)" type="text" size="small" style="color: red;">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>

    <!-- 修改记录的对话框 -->
    <el-dialog v-model="modifyFormVisible" title="修改记录" :before-close="handleCloseModifyForm">
      <el-form :model="recordToModify" label-width="120px">
        <el-form-item label="班次ID">
          <el-input v-model="recordToModify.vehicleId" placeholder="请输入班次ID" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="出发城市">
          <el-input v-model="recordToModify.departureCity" ></el-input>
        </el-form-item>
        <el-form-item label="到达城市">
          <el-input v-model="recordToModify.arrivalCity" ></el-input>
        </el-form-item>
        <el-form-item label="出发车站">
          <el-input v-model="recordToModify.departureStation" ></el-input>
        </el-form-item>
        <el-form-item label="到达车站">
          <el-input v-model="recordToModify.arrivalStation" ></el-input>
        </el-form-item>
        <el-form-item label="出发时间">
          <el-date-picker
            v-model="recordToModify.departureTime"
            type="datetime"
            placeholder="选择日期时间"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="到达时间">
          <el-date-picker
            v-model="recordToModify.arrivalTime"
            type="datetime"
            placeholder="选择日期时间"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="交通工具类型">
          <div>
            <el-select v-model="recordToModify.vehicleType" style="width: 200%;"   :filterable="true"  placeholder="请选择交通工具类型" >
              <el-option
                v-for="item in vehicleTypes" :key="item.value" :label="item.label" :value="item.value">
              </el-option>
            </el-select>
          </div>
        </el-form-item>
        <el-form-item label="交通工具型号">
          <el-input v-model="recordToModify.vehicleModel" ></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="modifyRecord">修改</el-button>
          <el-button @click="modifyFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <el-dialog v-model="modifySpecificTicketFormVisible" title="修改某张特定车票" :before-close="handleCloseModifySpecificTicketForm">
      <el-form :model="recordToModify" label-width="120px">
        <el-form-item label="车票ID">
          <el-input v-model="recordToModify.ticketId" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="车次号">
          <el-input v-model="recordToModify.vehicleId" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="票类型">
          <el-input v-model="recordToModify.ticketType" ></el-input>
        </el-form-item>
        <el-form-item label="票价">
          <el-input v-model="recordToModify.ticketPrice" ></el-input>
        </el-form-item>
        <el-form-item label="出发时间">
          <el-date-picker
            v-model="recordToModify.ticketDepartureTime"
            type="datetime"
            placeholder="选择出发时间"
            :disabled="true"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="到达时间">
          <el-date-picker
            v-model="recordToModify.ticketArrivalTime"
            type="datetime"
            placeholder="选择到达时间"
            :disabled="true"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="剩余票数">
          <el-input v-model="recordToModify.ticketRemaining" ></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="updateSpecificTicket">修改</el-button>
          <el-button @click="modifySpecificTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage, ElMessageBox } from 'element-plus';
import { get } from 'node_modules/axios/index.cjs';
import { Search } from '@element-plus/icons-vue';

const vehicleTypes = [
  { value: 'plane', label: '飞机' },
  { value: 'train', label: '火车' },
  { value: 'car', label: '大巴' },
];
const vehicleTypeMap = {
  plane: '飞机',
  train: '火车',
  car: '大巴',
}

const getVehicleTypeLabel = (type: string) => {
  return vehicleTypeMap[type] || type;
}
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
  id?: string; // 添加一个ID字段用于修改和删除
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
  id?: string; // 添加一个ID字段用于修改和删除
}

// 搜索类型
const searchType = ref<string>('schedule');

// 搜索关键词
const searchKeyword = ref<string>('');

// 搜索结果
const searchResults = ref<any[]>([]);

// 控制修改对话框的显示状态
const modifyFormVisible = ref<boolean>(false);

// 需要修改的记录
const recordToModify = ref<any>({});

// 修改某张特定车票表单是否可见
const modifySpecificTicketFormVisible = ref(false);

// 更新特定车票
async function updateSpecificTicket() {
  const res = await axios.get(`https://123.60.14.84/api/Vehicle/schedule/${recordToModify.value.vehicleId}`);
  console.log("res:", res);
  const schedule = res.data;
  console.log("schedule:", schedule);

  const deTimetobe = new Date(schedule.departureTime);
  const arrTimetobe = new Date(schedule.arrivalTime);

  const deTime = new Date(deTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(arrTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const data = {
    VehicleId: recordToModify.value.vehicleId,
    TicketType: recordToModify.value.ticketType,
    TicketPrice: recordToModify.value.ticketPrice,
    TicketDepartureTime: deTime,
    TicketArrivalTime: arrTime,
    TicketDepartureCity: schedule.departureCity,
    TicketArrivalCity: schedule.arrivalCity,
    TicketId: recordToModify.value.ticketId,
    TicketRemaining: recordToModify.value.ticketRemaining,
    TicketDepartureStation: schedule.departureStation,
    TicketArrivalStation: schedule.arrivalStation
  }

  await axios
    .delete(`https://123.60.14.84/api/Vehicle/ticket/delete/${recordToModify.value.ticketId}`)
    .then((response) => {
      console.log(response);
      ElMessage.success('车票信息删除成功');
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('删除失败');
    });

  await axios
    .post(`https://123.60.14.84/api/Vehicle/ticket`, data)
    .then((response) => {
      console.log(response);
      ElMessage.success('车票信息更新成功');
      modifySpecificTicketFormVisible.value = false;
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('更新失败');
    });
  await onSearch()
}
// 获取所有班次信息
const getAllSchedules = async () => {
  try {
    const response = await axios.get('https://123.60.14.84/api/Vehicle/schedules');
    searchResults.value = response.data.map((item: Schedule) => ({ ...item, id: item.vehicleId }));
  } catch (error) {
    console.error(error);
    ElMessage.error('获取班次信息失败');
  }
};

// 获取指定班号的班次信息
const getScheduleById = async (vehicleId: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/Vehicle/schedule/${vehicleId}`);
    searchResults.value = [response.data];
  } catch (error) {
    console.error(error);
    ElMessage.error('获取指定班号的班次信息失败');
  }
};

// 获取所有车票信息
const getAllTickets = async () => {
  try {
    const response = await axios.get('https://123.60.14.84/api/Vehicle/tickets');
    searchResults.value = response.data.map((item: Ticket) => ({ ...item, id: item.ticketId.toString() }));
  } catch (error) {
    console.error(error);
    ElMessage.error('获取车票信息失败');
  }
};

// 获取指定车票编号的车票信息
const getTicketById = async (ticketId: string) => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/Vehicle/ticket/${ticketId}`);
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

// 删除记录
const onDelete = async (row: any) => {
  ElMessageBox.confirm('此操作将永久删除该记录, 是否继续?', '提示',
    {
      confirmButtonText: '确定',
      cancelButtonText: '取消',
      type: 'warning'
    }
  ).then(async () => {
    try {
      const url = searchType.value === 'schedule' ? `https://123.60.14.84/api/Vehicle/schedule/delete/${row.id}` : `https://123.60.14.84/api/Vehicle/ticket/delete/${row.id}`;
      await axios.delete(url);
      ElMessage.success('删除成功');
      await onSearch(); // 刷新列表
    } catch (error) {
      console.error(error);
      ElMessage.error('删除失败');
    }
  }).catch(() => {
    ElMessage.info('已取消删除');
  });
};

// 显示修改表单
const showModifyForm = (row: any) => {
  recordToModify.value = JSON.parse(JSON.stringify(row)); // 深拷贝原始记录
  console.log(recordToModify.value)
  if(searchType.value === 'schedule') modifyFormVisible.value = true
  else modifySpecificTicketFormVisible.value = true;
};

// 修改记录
const modifyRecord = async () => {
  console.log(recordToModify.value);
  const deTimetobe = new Date(recordToModify.value.departureTime);
  const arrTimetobe = new Date(recordToModify.value.arrivalTime);
  const deTime = new Date(deTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(arrTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const data = {
    vehicleId: recordToModify.value.vehicleId,
    departureTime: deTime,
    arrivalTime: arrTime,
    vehicleType: recordToModify.value.vehicleType,
    departureCity: recordToModify.value.departureCity,
    arrivalCity: recordToModify.value.arrivalCity,
    vehicleModel: recordToModify.value.vehicleModel,
    arrivalStation: recordToModify.value.arrivalStation,
    departureStation: recordToModify.value.departureStation
  }
  console.log("data", data);
  await axios.delete(`https://123.60.14.84/api/Vehicle/schedule/delete/${recordToModify.value.vehicleId}`)
    .then((response) => {
      console.log(response);
      ElMessage.success('行程信息删除成功');
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('删除失败');
    });
    console.log("data", data);
  axios.post(`https://123.60.14.84/api/Vehicle/schedule`, data)
    .then(response => {
      console.log(response);
      ElMessage.success('行程信息更新成功');
      modifyFormVisible.value = false;
    })
    .catch(error => {
      console.error(error);
      ElMessage.error('更新失败');
    });
    console.log("data", data);
  await onSearch()

};

// 关闭修改表单
const handleCloseModifyForm = (done: Function) => {
  modifyFormVisible.value = false;
  done();
};


function handleCloseModifySpecificTicketForm(done) {
  modifySpecificTicketFormVisible.value = false;
  done();
}

// 初始化加载所有班次信息
onMounted(async () => {
  await getAllSchedules();
});
</script>
