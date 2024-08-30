<template>
  <div>
    <el-button @click="showModifyScheduleForm">修改行程</el-button>
    <el-button @click="showModifyVehicleTicketsForm">修改某列车的车票</el-button>
    <el-button @click="showModifySpecificTicketForm">修改某张特定车票</el-button>

    <!-- 修改行程的对话框 -->
    <el-dialog v-model="modifyScheduleFormVisible" title="修改行程" :before-close="handleCloseModifyScheduleForm">
      <el-form :model="vehicleScheduleData" label-width="120px">
        <el-form-item label="班次ID">
          <el-input v-model="vehicleScheduleData.VehicleId" placeholder="请输入班次ID"></el-input>
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

    <!-- 修改某张特定车票的对话框 -->
    <el-dialog v-model="modifySpecificTicketFormVisible" title="修改某张特定车票" :before-close="handleCloseModifySpecificTicketForm">
      <el-form :model="specificTicketData" label-width="120px">
        <el-form-item label="车票ID">
          <el-input v-model="specificTicketData.TicketId" placeholder="请输入车票ID"></el-input>
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
    <el-card v-if="vehicleSchedule" shadow="hover">
      <template #header>
        <div>行程信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="vehicleSchedule" label-width="80px">
            <el-form-item label="班次ID">
              <el-input v-model="vehicleSchedule.VehicleId" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="出发时间">
              <el-input v-model="vehicleSchedule.DepartureTime" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <el-form-item label="到达时间">
              <el-input v-model="vehicleSchedule.ArrivalTime" :disabled="!isEditingVehicleSchedule"></el-input>
            </el-form-item>
            <!-- 其他字段... -->
          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editVehicleSchedule" v-if="!isEditingVehicleSchedule">编辑</el-button>
          <el-button type="success" @click="updateVehicleSchedule" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>

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
            <!-- 其他字段... -->
          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editVehicleTicket(ticket)" v-if="!isEditingVehicleTicket">编辑</el-button>
          <el-button type="success" @click="updateVehicleTicket(ticket)" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>

    <el-card v-if="specificTicket" shadow="hover">
      <template #header>
        <div>特定车票信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="specificTicket" label-width="80px">
            <el-form-item label="车票ID">
              <el-input v-model="specificTicket.TicketId" :disabled="!isEditingSpecificTicket"></el-input>
            </el-form-item>
            <el-form-item label="票价">
              <el-input v-model="specificTicket.TicketPrice" :disabled="!isEditingSpecificTicket"></el-input>
            </el-form-item>
            <!-- 其他字段... -->
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

// 修改行程表单是否可见
const modifyScheduleFormVisible = ref(false);

// 修改某列车的车票表单是否可见
const modifyVehicleTicketsFormVisible = ref(false);

// 修改某张特定车票表单是否可见
const modifySpecificTicketFormVisible = ref(false);

// 行程数据
const vehicleSchedule = ref(null);

// 车票数据
const vehicleTickets = ref([]);

// 特定车票数据
const specificTicket = ref(null);

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
  const vehicleId = vehicleScheduleData.value.VehicleId;
  if (!vehicleId) {
    ElMessage.error('请输入班次ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/schedule/${vehicleId}`);
    vehicleSchedule.value = response.data;
    isEditingVehicleSchedule.value = false;
    modifyScheduleFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 查询并显示某列车的车票信息
async function fetchVehicleTickets() {
  const vehicleId = vehicleTicketData.value.VehicleId;
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
  const ticketId = specificTicketData.value.TicketId;
  if (!ticketId) {
    ElMessage.error('请输入车票ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Vehicle/ticket/${ticketId}`);
    specificTicket.value = response.data;
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
  try {
    await axios.put(`https://123.60.14.84:11000/api/Vehicle/schedule/${vehicleSchedule.value.VehicleId}`, vehicleSchedule.value);
    ElMessage.success('行程信息更新成功');
    isEditingVehicleSchedule.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
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
  try {
    await axios.put(`https://123.60.14.84:11000/api/Vehicle/ticket/${specificTicket.value.TicketId}`, specificTicket.value);
    ElMessage.success('特定车票信息更新成功');
    isEditingSpecificTicket.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 定义数据模型
const vehicleScheduleData = reactive({
  VehicleId: '',
});

const vehicleTicketData = reactive({
  VehicleId: '',
});

const specificTicketData = reactive({
  TicketId: '',
});
</script>
