<template>
  <div>
    <el-button @click="showModifyScheduleForm">修改行程</el-button>
    <!--<el-button @click="showModifyVehicleTicketsForm">修改某列车的车票</el-button>-->
    <el-button @click="showModifySpecificTicketForm">修改某张特定车票</el-button>

    <!-- 修改行程的对话框 -->
    <el-dialog v-model="modifyScheduleFormVisible" title="修改行程" :before-close="handleCloseModifyScheduleForm">
      <el-form :model="vehicleScheduleData" label-width="120px">
        <el-form-item label="班次ID">
          <el-input v-model="vehicleScheduleData.vehicleId" placeholder="请输入班次ID"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchVehicleSchedule">查询</el-button>
          <el-button @click="modifyScheduleFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 修改某列车的车票的对话框 -->
     <!--
    <el-dialog v-model="modifyVehicleTicketsFormVisible" title="修改某列车的车票" :before-close="handleCloseModifyVehicleTicketsForm">
      <el-form :model="vehicleTicketData" label-width="120px">
        <el-form-item label="班次ID">
          <el-input v-model="vehicleTicketData.VehicleId" placeholder="请输入班次ID"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchVehicleTickets">查询</el-button>
          <el-button @click="modifyVehicleTicketsFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>
-->
    <!-- 修改某张特定车票的对话框 -->
    <el-dialog v-model="modifySpecificTicketFormVisible" title="修改某张特定车票" :before-close="handleCloseModifySpecificTicketForm">
      <el-form :model="vehicleTicketData" label-width="120px">
        <el-form-item label="车票ID">
          <el-input v-model="vehicleTicketData.ticketId" placeholder="请输入车票ID"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchSpecificTicket">查询</el-button>
          <el-button @click="modifySpecificTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 显示查询结果的卡片 -->
    <el-card v-if="vehicleScheduleData" shadow="hover">
      <template #header>
        <div>行程信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="vehicleScheduleData" label-width="120px">
            <el-form-item label="班次ID">
              <el-input v-model="vehicleScheduleData.vehicleId" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="出发城市">
              <el-input v-model="vehicleScheduleData.departureCity" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="到达城市">
              <el-input v-model="vehicleScheduleData.arrivalCity" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="出发车站">
              <el-input v-model="vehicleScheduleData.departureStation" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="到达车站">
              <el-input v-model="vehicleScheduleData.arrivalStation" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="出发时间">
              <el-date-picker
                v-model="vehicleScheduleData.departureTime"
                type="datetime"
                placeholder="选择日期时间"
                :disabled="!isEditingVehicleSchedule"
              ></el-date-picker>
            </el-form-item>
            <el-form-item label="到达时间">
              <el-date-picker
                v-model="vehicleScheduleData.arrivalTime"
                type="datetime"
                placeholder="选择日期时间"
                :disabled="!isEditingVehicleSchedule"
              ></el-date-picker>
            </el-form-item>
            <el-form-item label="交通工具类型">
              <el-input v-model="vehicleScheduleData.vehicleType" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="交通工具型号">
              <el-input v-model="vehicleScheduleData.vehicleModel" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editVehicleSchedule" v-if="!isEditingVehicleSchedule">编辑</el-button>
          <el-button type="success" @click="updateVehicleSchedule" v-else>完成</el-button>
        </el-col>

      </el-row>
    </el-card>
<!--
    <el-card v-if="vehicleTickets" shadow="hover">
      <template #header>
        <div>车票列表</div>
      </template>
      <el-row v-for="ticket in vehicleTickets" :key="ticket.TicketId">
        <el-col :span="12">
          <el-form :model="ticket" label-width="80px">
            <el-form-item label="车票ID">
              <el-input v-model="ticket.TicketId" :disabled="!isEditingVehicleTicket"></el-input>
            </el-form-item>
            <el-form-item label="票价">
              <el-input v-model="ticket.TicketPrice" :disabled="!isEditingVehicleTicket"></el-input>
            </el-form-item>

          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editVehicleTicket(ticket)" v-if="!isEditingVehicleTicket">编辑</el-button>
          <el-button type="success" @click="updateVehicleTicket(ticket)" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>
  -->
    <el-card v-if="vehicleTicketData" shadow="hover">
      <template #header>
        <div>特定车票信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="vehicleTicketData" label-width="80px">
            <el-form-item label="票ID">
              <el-input v-model="vehicleTicketData.ticketId" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="车次号">
              <el-input v-model="vehicleTicketData.vehicleId" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="票类型">
              <el-input v-model="vehicleTicketData.ticketType" :disabled="!isEditingSpecificTicket"></el-input>
            </el-form-item>
            <el-form-item label="票价">
              <el-input v-model="vehicleTicketData.ticketPrice" :disabled="!isEditingSpecificTicket"></el-input>
            </el-form-item>
            <el-form-item label="出发时间">
              <el-date-picker
                v-model="vehicleTicketData.ticketDepartureTime"
                type="datetime"
                placeholder="选择出发时间"
                :disabled="!isEditingSpecificTicket"
              ></el-date-picker>
            </el-form-item>
            <el-form-item label="到达时间">
              <el-date-picker
                v-model="vehicleTicketData.ticketArrivalTime"
                type="datetime"
                placeholder="选择到达时间"
                :disabled="!isEditingSpecificTicket"
              ></el-date-picker>
            </el-form-item>
            <el-form-item label="出发城市">
              <el-input v-model="vehicleTicketData.ticketDepartureCity" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="到达城市">
              <el-input v-model="vehicleTicketData.ticketArrivalCity" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="出发站点">
              <el-input v-model="vehicleTicketData.ticketDepartureStation" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="到达站点">
              <el-input v-model="vehicleTicketData.ticketArrivalStation" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="剩余票数">
              <el-input v-model="vehicleTicketData.ticketRemaining" :disabled="!isEditingSpecificTicket"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editSpecificTicket" v-if="!isEditingSpecificTicket">编辑</el-button>
          <el-button type="success" @click="updateSpecificTicket" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';


interface VehicleScheduleRequest {
  vehicleId?: string;
  departureTime?: Date;
  arrivalTime?: Date;
  vehicleType?: string;
  departureCity?: string;
  arrivalCity?: string;
  vehicleModel?: string;
  arrivalStation?: string;
  departureStation?: string;
}

// 定义票务数据结构
interface VehicleTicketRequest {
  vehicleId?: string;
  ticketType?: string;
  ticketPrice?: number;
  ticketDepartureTime?: Date;
  ticketArrivalTime?: Date;
  ticketDepartureCity?: string;
  ticketArrivalCity?: string;
  ticketId?: string;
  ticketRemaining?: number;
  ticketDepartureStation?: string;
  ticketArrivalStation?: string;
}

// 修改行程表单是否可见
const modifyScheduleFormVisible = ref(false);

// 修改某列车的车票表单是否可见
const modifyVehicleTicketsFormVisible = ref(false);

// 修改某张特定车票表单是否可见
const modifySpecificTicketFormVisible = ref(false);

// 行程数据
const vehicleScheduleData = reactive({
  vehicleId: '',
  departureTime: new Date(),
  arrivalTime: new Date(),
  vehicleType: '',
  departureCity: '',
  arrivalCity: '',
  vehicleModel: '',
  arrivalStation: '',
  departureStation: ''
});

function clearVehicleScheduleData() {
  vehicleScheduleData.arrivalCity = '';
  vehicleScheduleData.arrivalTime = new Date();
  vehicleScheduleData.arrivalStation = '';
  vehicleScheduleData.departureCity = '';
  vehicleScheduleData.departureTime = new Date();
  vehicleScheduleData.departureStation = '';
  vehicleScheduleData.vehicleId = '';
  vehicleScheduleData.vehicleModel = '';
  vehicleScheduleData.vehicleType = '';

}

// 票务数据
const vehicleTicketData = reactive({
  vehicleId: '',
  ticketType: '',
  ticketPrice: 0,
  ticketDepartureTime: new Date(),
  ticketArrivalTime: new Date(),
  ticketDepartureCity: '',
  ticketArrivalCity: '',
  ticketId: '',
  ticketRemaining: 0,
  ticketDepartureStation: '',
  ticketArrivalStation: ''
});

function clearVehicleTicketData() {
  vehicleTicketData.ticketType = '';
  vehicleTicketData.ticketPrice = 0;
  vehicleTicketData.ticketDepartureTime = new Date();
  vehicleTicketData.ticketArrivalTime = new Date();
  vehicleTicketData.ticketDepartureCity = '';
  vehicleTicketData.ticketArrivalCity = '';
  vehicleTicketData.ticketId = '';
  vehicleTicketData.ticketRemaining = 0;
  vehicleTicketData.ticketDepartureStation = '';
  vehicleTicketData.ticketArrivalStation = '';
}


// 车票数据
const vehicleTickets = ref([]);


// 是否正在编辑状态
const isEditingVehicleSchedule = ref(false);
const isEditingVehicleTicket = ref(false);
const isEditingSpecificTicket = ref(false);

// 显示修改行程表单
function showModifyScheduleForm() {
  modifyScheduleFormVisible.value = true;
}

// 显示修改某列车的车票表单
function showModifyVehicleTicketsForm() {
  modifyVehicleTicketsFormVisible.value = true;
}

// 显示修改某张特定车票表单
function showModifySpecificTicketForm() {
  modifySpecificTicketFormVisible.value = true;
}

// 关闭修改行程表单
function handleCloseModifyScheduleForm(done: () => void) {
  try {
    modifyScheduleFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the modify schedule form:', error);
  }
}

// 关闭修改某列车的车票表单
function handleCloseModifyVehicleTicketsForm(done: () => void) {
  try {
    modifyVehicleTicketsFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the modify vehicle tickets form:', error);
  }
}

// 关闭修改某张特定车票表单
function handleCloseModifySpecificTicketForm(done: () => void) {
  try {
    modifySpecificTicketFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the modify specific ticket form:', error);
  }
}

// 查询并显示行程信息
async function fetchVehicleSchedule() {
  const vehicleId = vehicleScheduleData.value.vehicleId;
  if (!vehicleId) {
    ElMessage.error('请输入班次ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/schedule/${vehicleId}`);
    vehicleScheduleData.value = response.data;
    isEditingVehicleSchedule.value = false;
    modifyScheduleFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 查询并显示某列车的车票信息
async function fetchVehicleTickets() {
  const vehicleId = vehicleTicketData.VehicleId;
  if (!vehicleId) {
    ElMessage.error('请输入班次ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/tickets/${vehicleId}`);
    vehicleTickets.value = response.data;
    isEditingVehicleTicket.value = false;
    modifyVehicleTicketsFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 查询并显示某张特定车票信息
async function fetchSpecificTicket() {
  const ticketId = vehicleTicketData.ticketId;
  if (!ticketId) {
    ElMessage.error('请输入车票ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/ticket/${ticketId}`);
    console.log(response.data);
    vehicleTicketData.value = response.data;
    isEditingSpecificTicket.value = false;
    modifySpecificTicketFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 编辑行程信息
function editVehicleSchedule() {
  isEditingVehicleSchedule.value = true;
}

// 更新行程信息
async function updateVehicleSchedule() {
  console.log(vehicleScheduleData);
  const deTimetobe = new Date(vehicleScheduleData.departureTime);
  const arrTimetobe = new Date(vehicleScheduleData.arrivalTime);
  const deTime = new Date(deTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(arrTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const data = {
    vehicleId: vehicleScheduleData.vehicleId,
    departureTime: deTime,
    arrivalTime: arrTime,
    vehicleType: vehicleScheduleData.vehicleType,
    departureCity: vehicleScheduleData.departureCity,
    arrivalCity: vehicleScheduleData.arrivalCity,
    vehicleModel: vehicleScheduleData.vehicleModel,
    arrivalStation: vehicleScheduleData.arrivalStation,
    departureStation: vehicleScheduleData.departureStation
  }
  console.log("data", data);
  await axios.delete(`https://123.60.14.84/api/Vehicle/schedule/delete/${vehicleScheduleData.value.vehicleId}`)
    .then(response => {
      console.log(response);
      ElMessage.success('行程信息删除成功');
    })
    .catch(error => {
      console.error(error);
      ElMessage.error('删除失败');
    });
    console.log("data", data);
  axios.post(`https://123.60.14.84/api/Vehicle/schedule`, data)
    .then(response => {
      console.log(response);
      ElMessage.success('行程信息更新成功');
      isEditingVehicleSchedule.value = false;
    })
    .catch(error => {
      console.error(error);
      ElMessage.error('更新失败');
    });
    console.log("data", data);
  clearVehicleScheduleData();
}

// 编辑车票信息
function editVehicleTicket(ticket) {
  isEditingVehicleTicket.value = true;
}

// 更新车票信息
async function updateVehicleTicket(ticket) {
  try {
    await axios.put(`https://123.60.14.84:11000/api/Vehicle/ticket/${ticket.TicketId}`, ticket);
    ElMessage.success('车票信息更新成功');
    isEditingVehicleTicket.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 编辑特定车票信息
function editSpecificTicket() {
  isEditingSpecificTicket.value = true;
}

// 更新特定车票信息
async function updateSpecificTicket() {
  console.log("vehicleTicketData:", vehicleTicketData);
  const res = await axios.get(`https://123.60.14.84/api/Vehicle/schedule/${vehicleTicketData.value.vehicleId}`);
  console.log("res:", res);
  const schedule = res.data;
  console.log("schedule:", schedule);

  const deTimetobe = new Date(vehicleTicketData.ticketDepartureTime);
  const arrTimetobe = new Date(vehicleTicketData.ticketArrivalTime);

  const deTime = new Date(deTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(arrTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const data = {
    VehicleId: vehicleTicketData.vehicleId,
    TicketType: vehicleTicketData.ticketType,
    TicketPrice: vehicleTicketData.ticketPrice,
    TicketDepartureTime: deTime,
    TicketArrivalTime: arrTime,
    TicketDepartureCity: schedule.departureCity,
    TicketArrivalCity: schedule.arrivalCity,
    TicketId: vehicleTicketData.ticketId,
    TicketRemaining: vehicleTicketData.ticketRemaining,
    TicketDepartureStation: schedule.departureStation,
    TicketArrivalStation: schedule.arrivalStation
  }

  await axios
    .delete(`https://123.60.14.84/api/Vehicle/ticket/delete/${vehicleTicketData.ticketId}`)
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
      isEditingSpecificTicket.value = false;
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('更新失败');
    });
  clearVehicleTicketData();
}
</script>
