<template>
  <div>
    <el-button type="primary" @click="showAddScheduleForm">添加行程</el-button>
    <el-button type="primary" @click="showAddTicketForm">添加票务信息</el-button>
    <!-- 删除行程按钮 -->
    <el-button type="danger" @click="showDeleteScheduleForm">删除行程</el-button>
    <!-- 删除车票按钮 -->
    <el-button type="danger" @click="showDeleteTicketForm">删除票务</el-button>

<!-- 删除车票的对话框 -->
    <el-dialog v-model="deleteTicketFormVisible" title="删除车票" :before-close="handleCloseDeleteTicketForm">
      <el-form :model="vehicleTicketData" label-width="120px">
        <el-form-item label="票据ID">
          <el-input v-model="vehicleTicketData.TicketId"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="deleteTicketFormVisible = false">取消</el-button>
          <el-button type="primary" @click="deleteVehicleTicket">确定</el-button>
        </span>
      </template>
    </el-dialog>
    <!-- 删除行程的对话框 -->
    <el-dialog v-model="deleteScheduleFormVisible" title="删除行程" :before-close="handleCloseDeleteScheduleForm">
  <el-form :model="vehicleScheduleData" label-width="120px">
    <el-form-item label="交通工具ID">
      <el-input v-model="vehicleScheduleData.VehicleId"></el-input>
    </el-form-item>
  </el-form>
  <template #footer>
    <span class="dialog-footer">
      <el-button @click="deleteScheduleFormVisible = false">取消</el-button>
      <el-button type="primary" @click="deleteVehicleSchedule">确定</el-button>
    </span>
  </template>
    </el-dialog>

<!-- 添加行程的对话框 -->
    <!-- 添加行程的表单 -->
    <el-dialog v-model="scheduleFormVisible" title="添加行程" :before-close="handleCloseScheduleForm">
      <el-form :model="vehicleScheduleData" label-width="120px">
        <el-form-item label="交通工具ID">
          <el-input v-model="vehicleScheduleData.VehicleId"></el-input>
        </el-form-item>
        <el-form-item label="出发时间">
          <el-date-picker
            v-model="vehicleScheduleData.DepartureTime"
            type="datetime"
            placeholder="选择日期时间"

          ></el-date-picker>
        </el-form-item>
        <el-form-item label="到达时间">
          <el-date-picker
            v-model="vehicleScheduleData.ArrivalTime"
            type="datetime"
            placeholder="选择日期时间"

          ></el-date-picker>
        </el-form-item>
        <el-form-item label="交通类型">
          <div>
            <el-select v-model="vehicleScheduleData.VehicleType" style="width: 200%;"   :filterable="true"  placeholder="请选择交通工具类型">
              <el-option
                v-for="item in vehicleTypes"
                :key="item.value"
                :label="item.label"
                :value="item.value"
              >
              </el-option>
            </el-select>
          </div>
        </el-form-item>
        <el-form-item label="出发城市">
          <el-input v-model="vehicleScheduleData.DepartureCity"></el-input>
        </el-form-item>
        <el-form-item label="到达城市">
          <el-input v-model="vehicleScheduleData.ArrivalCity"></el-input>
        </el-form-item>
        <el-form-item label="交通工具型号">
          <el-input v-model="vehicleScheduleData.VehicleModel"></el-input>
        </el-form-item>
        <el-form-item label="到达机场/站点">
          <el-input v-model="vehicleScheduleData.ArrivalStation"></el-input>
        </el-form-item>
        <el-form-item label="出发机场/站点">
          <el-input v-model="vehicleScheduleData.DepartureStation"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="scheduleFormVisible = false">取消</el-button>
          <el-button type="primary" @click="newSchedule">确定</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 添加票务信息的表单 -->
    <el-dialog v-model="ticketFormVisible" title="添加票务信息" :before-close="handleCloseTicketForm">
      <el-form :model="vehicleTicketData" label-width="120px">
        <el-form-item label="交通工具ID">
          <el-input v-model="vehicleTicketData.VehicleId"></el-input>
        </el-form-item>
        <el-form-item label="座位类型">
          <el-input v-model="vehicleTicketData.TicketType"></el-input>
        </el-form-item>
        <el-form-item label="票价">
          <el-input-number v-model="vehicleTicketData.TicketPrice" :precision="2" :step="1"></el-input-number>
        </el-form-item>
        <el-form-item label="出发时间">
          <el-date-picker
            v-model="vehicleTicketData.TicketDepartureTime"
            type="datetime"
            placeholder="选择日期时间"
            :disabled="true"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="到达时间">
          <el-date-picker
            v-model="vehicleTicketData.TicketArrivalTime"
            type="datetime"
            placeholder="选择日期时间"
            :disabled="true"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="出发城市">
          <el-input v-model="vehicleTicketData.TicketDepartureCity" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="到达城市">
          <el-input v-model="vehicleTicketData.TicketArrivalCity" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="剩余票数">
          <el-input-number v-model="vehicleTicketData.TicketRemaining" :min="0"></el-input-number>
        </el-form-item>
        <el-form-item label="到达站点">
          <el-input v-model="vehicleTicketData.TicketArrivalStation" :disabled="true"></el-input>
        </el-form-item>
        <el-form-item label="出发站点">
          <el-input v-model="vehicleTicketData.TicketDepartureStation" :disabled="true"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="ticketFormVisible = false">取消</el-button>
          <el-button type="primary" @click="addVehicleTicket">确定</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';
import { visualHiddenProps } from 'element-plus/es/components/visual-hidden/index.mjs';


const vehicleTypes = [
  { value: 'plane', label: '飞机' },
  { value: 'train', label: '火车' },
  { value: 'car', label: '大巴' },
];

// 定义行程数据结构
interface VehicleScheduleRequest {
  VehicleId?: string;
  DepartureTime?: Date;
  ArrivalTime?: Date;
  VehicleType?: string;
  DepartureCity?: string;
  ArrivalCity?: string;
  VehicleModel?: string;
  ArrivalStation?: string;
  DepartureStation?: string;
}

// 定义票务数据结构
interface VehicleTicketRequest {
  VehicleId?: string;
  TicketType?: string;
  TicketPrice?: number;
  TicketDepartureTime?: Date;
  TicketArrivalTime?: Date;
  TicketDepartureCity?: string;
  TicketArrivalCity?: string;
  TicketId?: string;
  TicketRemaining?: number;
  TicketDepartureStation?: string;
  TicketArrivalStation?: string;
}

// 行程表单是否可见
const scheduleFormVisible = ref(false);

// 票务表单是否可见
const ticketFormVisible = ref(false);

// 行程数据
const vehicleScheduleData = ref<Partial<VehicleScheduleRequest>>({
  VehicleId: '',
  DepartureTime: undefined,
  ArrivalTime: undefined,
  VehicleType: 'plane',
  DepartureCity: '',
  ArrivalCity: '',
  VehicleModel: '',
  ArrivalStation: '',
  DepartureStation: ''
});

// 票务数据
const vehicleTicketData = ref<Partial<VehicleTicketRequest>>({
  VehicleId: '',
  TicketType: '',
  TicketPrice: undefined,
  TicketDepartureTime: undefined,
  TicketArrivalTime: undefined,
  TicketDepartureCity: '',
  TicketArrivalCity: '',
  TicketId: '',
  TicketRemaining: undefined,
  TicketDepartureStation: '',
  TicketArrivalStation: ''
});
// 显示添加行程表单
function showAddScheduleForm() {
  scheduleFormVisible.value = true;
}

// 显示添加票务信息表单
function showAddTicketForm() {
  ticketFormVisible.value = true;
}

function clearScheduleForm() {
  vehicleScheduleData.value = {
    VehicleId: '',
    DepartureTime: undefined,
    ArrivalTime: undefined,
    VehicleType: 'plane',
    DepartureCity: '',
    ArrivalCity: '',
    VehicleModel: '',
    ArrivalStation: '',
    DepartureStation: ''
  };
}

function clearTicketForm() {
  vehicleTicketData.value = {
    VehicleId: '',
    TicketType: '',
    TicketPrice: undefined, // 已经设置为 undefined
    TicketDepartureTime: undefined, // 已经设置为 undefined
    TicketArrivalTime: undefined, // 已经设置为 undefined
    TicketDepartureCity: '',
    TicketArrivalCity: '',
    TicketId: '',
    TicketRemaining: undefined,
    TicketDepartureStation: '',
    TicketArrivalStation: ''
  };
}
function handleCloseAddScheduleForm() {
  clearScheduleForm()
  scheduleFormVisible.value = false;
}

function handleCloseAddTicketForm() {
  clearTicketForm()
  ticketFormVisible.value = false;
}

// 添加行程的函数
async function newSchedule() {
  console.log("vehicleScheduleData:", vehicleScheduleData.value);
  const deTime = new Date(vehicleScheduleData.value.DepartureTime.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(vehicleScheduleData.value.ArrivalTime.getTime() + 8 * 60 * 60 * 1000);
  const data={
    vehicleId: vehicleScheduleData.value.VehicleId,
    departureTime: deTime,
    arrivalTime: arrTime,
    vehicleType: vehicleScheduleData.value.VehicleType,
    departureCity: vehicleScheduleData.value.DepartureCity,
    arrivalCity: vehicleScheduleData.value.ArrivalCity,
    vehicleModel: vehicleScheduleData.value.VehicleModel,
    arrivalStation: vehicleScheduleData.value.ArrivalStation,
    departureStation: vehicleScheduleData.value.DepartureStation
  }
  console.log("data:", data);
  const url = "https://123.60.14.84:11000/api/Vehicle/schedule";
  console.log("url:", url);

  axios
    .post(url, data)
    .then((response) => {
      console.log("response:", response);
      ElMessage.success('行程添加成功');
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('行程添加失败');
    });
  handleCloseAddScheduleForm()
}

// 添加票务信息的函数
async function addVehicleTicket() {
  console.log("vehicleTicketData:", vehicleTicketData.value);
  const res = await axios.get(`https://123.60.14.84/api/Vehicle/schedule/${vehicleTicketData.value.VehicleId}`);
  console.log("res:", res);
  const schedule = res.data;
  console.log("schedule:", schedule);

  const deTimetobe = new Date(schedule.departureTime);
  const arrTimetobe = new Date(schedule.arrivalTime);

  const deTime = new Date(deTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const arrTime = new Date(arrTimetobe.getTime() + 8 * 60 * 60 * 1000);
  const data = {
    VehicleId: vehicleTicketData.value.VehicleId,
    TicketType: vehicleTicketData.value.TicketType,
    TicketPrice: vehicleTicketData.value.TicketPrice,
    TicketDepartureTime: deTime,
    TicketArrivalTime: arrTime,
    TicketDepartureCity: schedule.departureCity,
    TicketArrivalCity: schedule.arrivalCity,
    TicketId: vehicleTicketData.value.TicketId,
    TicketRemaining: vehicleTicketData.value.TicketRemaining,
    TicketDepartureStation: schedule.departureStation,
    TicketArrivalStation: schedule.arrivalStation
  }
  const url = "https://123.60.14.84/api/Vehicle/ticket";
  console.log("url:", url);

  axios
    .post(url, data)
    .then((response) => {
      console.log("response:", response);
      ElMessage.success('票务信息添加成功');

    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('票务信息添加失败');
    });
    handleCloseAddTicketForm()
}

// 删除行程表单是否可见
const deleteScheduleFormVisible = ref(false);

// 删除车票表单是否可见
const deleteTicketFormVisible = ref(false);

// 显示删除行程表单
function showDeleteScheduleForm() {
  deleteScheduleFormVisible.value = true;
}

// 显示删除车票表单
function showDeleteTicketForm() {
  deleteTicketFormVisible.value = true;
}

function handleCloseDeleteScheduleForm() {
  clearScheduleForm()
  deleteScheduleFormVisible.value = false;
}

function handleCloseDeleteTicketForm() {
  clearTicketForm()
  deleteTicketFormVisible.value = false;
}

// 删除行程的函数
async function deleteVehicleSchedule() {
  const url = `https://123.60.14.84:11000/api/Vehicle/schedule/delete/${vehicleScheduleData.value.VehicleId}`;
  console.log("url:", url);
  axios
    .delete(url)
    .then((response) => {
      console.log("response:", response);
      ElMessage.success('行程删除成功');
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('行程删除失败');
    });
    handleCloseDeleteScheduleForm()
}

// 删除车票的函数
async function deleteVehicleTicket() {
  const url = `https://123.60.14.84/api/Vehicle/ticket/delete/${vehicleTicketData.value.TicketId}`;
  console.log("url:", url);
  axios
    .delete(url)
    .then((response) => {
      console.log("response:", response);
      ElMessage.success('车票删除成功');
      handleCloseDeleteTicketForm();
    })
    .catch((error) => {
      console.error(error);
      ElMessage.error('车票删除失败');
    });
    handleCloseDeleteTicketForm()
}
</script>
