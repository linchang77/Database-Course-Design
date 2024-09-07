<template>
  <div>
    <el-button type="primary" icon="EditPen" @click="showModifyScheduleForm">修改行程</el-button>
    <el-button type="primary" icon="EditPen" @click="showModifySpecificTicketForm">修改某张特定车/机票</el-button>

    <!-- 修改行程的对话框 -->
    <el-dialog v-model="modifyScheduleFormVisible" title="修改行程" :before-close="handleCloseModifyScheduleForm">
      <el-form :model="vehicleScheduleData" label-width="120px">
        <el-form-item label="交通工具ID">
          <el-input v-model="vehicleScheduleData.vehicleId" placeholder="请输入交通工具ID"></el-input>
          <div style="font-size: 12px; color: #909399">请输入交通工具ID后点击右下方查询按钮</div>
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
          <div>
            <el-select v-model="vehicleScheduleData.vehicleType" style="width: 200%;"   :filterable="true"  placeholder="请选择交通工具类型" :disabled="!isEditingVehicleSchedule">
              <el-option
                v-for="item in vehicleTypes" :key="item.value" :label="item.label" :value="item.value">
              </el-option>
            </el-select>
          </div>
        </el-form-item>
        <el-form-item label="交通工具型号">
          <el-input v-model="vehicleScheduleData.vehicleModel" :disabled="!isEditingVehicleSchedule"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="editVehicleSchedule" v-if="!isEditingVehicleSchedule">编辑</el-button>
          <el-button type="success" @click="updateVehicleSchedule" v-else>完成</el-button>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchVehicleSchedule">查询</el-button>
          <el-button @click="modifyScheduleFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 修改某张特定车票的对话框 -->
    <el-dialog v-model="modifySpecificTicketFormVisible" title="修改某张特定车/机票" :before-close="handleCloseModifySpecificTicketForm">
      <el-form :model="vehicleTicketData" label-width="120px">
        <el-form-item label="票据ID">
          <el-input v-model="vehicleTicketData.ticketId" placeholder="请输入票据ID"></el-input>
          <div style="font-size: 12px; color: #909399">请输入票据ID后点击右下方查询按钮</div>
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
        <el-form-item label="剩余票数">
          <el-input v-model="vehicleTicketData.ticketRemaining" :disabled="!isEditingSpecificTicket"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="editSpecificTicket" v-if="!isEditingSpecificTicket">编辑</el-button>
          <el-button type="success" @click="updateSpecificTicket" v-else>完成</el-button>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchSpecificTicket">查询</el-button>
          <el-button @click="modifySpecificTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>
<script setup lang="ts">
import { ref, reactive } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

const vehicleTypes = [
  { value: 'plane', label: '飞机' },
  { value: 'train', label: '火车' },
  { value: 'car', label: '大巴' },
];

interface VehicleSchedule {
  vehicleId: string;
  departureTime: Date;
  arrivalTime: Date;
  vehicleType: string;
  departureCity: string;
  arrivalCity: string;
  vehicleModel: string;
  arrivalStation: string;
  departureStation: string;
}

// 定义票务数据结构
interface VehicleTicket {
  vehicleId: string;
  ticketId: string;
  ticketType: string;
  ticketPrice: number;
  ticketDepartureTime: Date;
  ticketArrivalTime: Date;
  ticketDepartureCity: string;
  ticketArrivalCity: string;
  ticketDepartureStation: string;
  ticketArrivalStation: string;
  ticketRemaining: number;
}

// 修改行程表单是否可见
const modifyScheduleFormVisible = ref(false);

// 修改某张特定车票表单是否可见
const modifySpecificTicketFormVisible = ref(false);

// 行程数据
const vehicleScheduleData = reactive<VehicleSchedule>({
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

// 特定车票数据
const vehicleTicketData = reactive<VehicleTicket>({
  vehicleId: '',
  ticketId: '',
  ticketType: '',
  ticketPrice: 0,
  ticketDepartureTime: new Date(),
  ticketArrivalTime: new Date(),
  ticketDepartureCity: '',
  ticketArrivalCity: '',
  ticketDepartureStation: '',
  ticketArrivalStation: '',
  ticketRemaining: 0
});

// 是否正在编辑状态
const isEditingVehicleSchedule = ref(false);
const isEditingSpecificTicket = ref(false);

// 显示修改行程表单
function showModifyScheduleForm() {
  modifyScheduleFormVisible.value = true;
}

// 显示修改某张特定车票表单
function showModifySpecificTicketForm() {
  modifySpecificTicketFormVisible.value = true;
}

// 查询行程信息
async function fetchVehicleSchedule() {
  try {
    const response = await axios.get<VehicleSchedule>(`https://123.60.14.84/api/Vehicle/schedule/${vehicleScheduleData.vehicleId}`);
    Object.assign(vehicleScheduleData, response.data);
  } catch (error) {
    console.error(error);
    ElMessage.error('查询行程信息失败');
  }
}

// 查询特定车票信息
async function fetchSpecificTicket() {
  try {
    const response = await axios.get<VehicleTicket>(`https://123.60.14.84/api/Vehicle/ticket/${vehicleTicketData.ticketId}`);
    Object.assign(vehicleTicketData, response.data);
  } catch (error) {
    console.error(error);
    ElMessage.error('查询特定车票信息失败');
  }
}

// 编辑行程
function editVehicleSchedule() {
  isEditingVehicleSchedule.value = true;
}

// 更新行程
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
  await axios.delete(`https://123.60.14.84/api/Vehicle/schedule/delete/${vehicleScheduleData.vehicleId}`)
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

// 编辑特定车票
function editSpecificTicket() {
  isEditingSpecificTicket.value = true;
}

// 更新特定车票
async function updateSpecificTicket() {
  console.log("vehicleTicketData:", vehicleTicketData);
  const res = await axios.get(`https://123.60.14.84/api/Vehicle/schedule/${vehicleTicketData.vehicleId}`);
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

// 关闭对话框时清除数据
function handleCloseModifyScheduleForm(done) {
  modifyScheduleFormVisible.value = false;
  done();
  clearVehicleScheduleData();
}

function handleCloseModifySpecificTicketForm(done) {
  modifySpecificTicketFormVisible.value = false;
  done();
  clearVehicleTicketData();
}

function clearVehicleScheduleData() {
  vehicleScheduleData.vehicleId = '';
  vehicleScheduleData.departureTime = new Date();
  vehicleScheduleData.arrivalTime = new Date();
  vehicleScheduleData.vehicleType = '';
  vehicleScheduleData.departureCity = '';
  vehicleScheduleData.arrivalCity = '';
  vehicleScheduleData.vehicleModel = '';
  vehicleScheduleData.arrivalStation = '';
  vehicleScheduleData.departureStation = '';
}

function clearVehicleTicketData() {
  vehicleTicketData.vehicleId = '';
  vehicleTicketData.ticketId = '';
  vehicleTicketData.ticketType = '';
  vehicleTicketData.ticketPrice = 0;
  vehicleTicketData.ticketDepartureTime = new Date();
  vehicleTicketData.ticketArrivalTime = new Date();
  vehicleTicketData.ticketDepartureCity = '';
  vehicleTicketData.ticketArrivalCity = '';
  vehicleTicketData.ticketDepartureStation = '';
  vehicleTicketData.ticketArrivalStation = '';
  vehicleTicketData.ticketRemaining = 0;
}


</script>
