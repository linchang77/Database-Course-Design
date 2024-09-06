<template>
  <div>
    <el-button type="primary" @click="showAddTicketForm">新增票务信息</el-button>
    <el-button type="danger" @click="showDeleteTicketForm">删除票务信息</el-button>
    <el-button type="primary" @click="showModifyTicketForm">修改票务信息</el-button>

    <!-- 新增票务信息的对话框 -->
    <el-dialog v-model="addTicketFormVisible" title="新增票务信息" :before-close="handleCloseAddTicketForm">
      <el-form :model="ticketToAdd" label-width="120px">
        <el-form-item label="景点id">
          <el-input v-model="ticketToAdd.scenicSpotId" placeholder="请输入景点id"></el-input>
        </el-form-item>
        <el-form-item label="票种">
          <el-input v-model="ticketToAdd.ticketType" placeholder="请输入票种"></el-input>
        </el-form-item>
        <el-form-item label="价格">
          <el-input v-model="ticketToAdd.ticketPrice" placeholder="请输入价格"></el-input>
        </el-form-item>
        <el-form-item label="剩余票数">
          <el-input v-model="ticketToAdd.ticketRemaining" placeholder="请输入剩余票数"></el-input>
        </el-form-item>
        <el-form-item label="日期">
          <el-date-picker
            v-model="ticketToAdd.ticketDate"
            type="datetime"
            placeholder="选择日期"
            value-format="YYYY-MM-DD HH:mm:ss"
          ></el-date-picker>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="addTicket">添加</el-button>
          <el-button @click="addTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 删除票务信息的对话框 -->
    <el-dialog v-model="deleteTicketFormVisible" title="删除票务信息" :before-close="handleCloseDeleteTicketForm">
      <el-form :model="ticketToDelete" label-width="120px">
        <el-form-item label="景点id">
          <el-input v-model="ticketToDelete.scenicSpotId" placeholder="请输入景点id"></el-input>
        </el-form-item>
        <el-form-item label="票种">
          <el-input v-model="ticketToDelete.ticketType" placeholder="请输入票种"></el-input>
        </el-form-item>
        <el-form-item label="日期">
          <el-date-picker
            v-model="ticketToDelete.ticketDate"
            type="date"
            placeholder="选择日期"
            value-format="YYYY-MM-DD HH:mm:ss"
          ></el-date-picker>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="deleteTicket">删除</el-button>
          <el-button @click="deleteTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 修改票务信息的对话框 -->
    <el-dialog v-model="modifyTicketFormVisible" title="修改票务信息" :before-close="handleCloseModifyTicketForm">
      <el-form :model="ticketToModify" label-width="120px">
        <el-form-item label="景点id">
          <el-input v-model="ticketToModify.scenicSpotId" placeholder="请输入景点id"></el-input>
        </el-form-item>
        <el-form-item label="票种">
          <el-input v-model="ticketToModify.ticketType" placeholder="请输入票种"></el-input>
        </el-form-item>
        <el-form-item label="日期">
          <el-date-picker
            v-model="ticketToModify.ticketDate"
            type="datetime"
            placeholder="选择日期"
            value-format="YYYY-MM-DD HH:mm:ss"
          ></el-date-picker>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchTicket">查询</el-button>
          <el-button @click="modifyTicketFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 显示查询结果的卡片 -->
    <el-card v-if="ticket" shadow="hover" class="modify-ticket-card">
      <template #header>
        <div>票务信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="ticket" label-width="80px">
            <el-form-item label="景点id">
              <el-input v-model="ticket.scenicSpotId" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="票种">
              <el-input v-model="ticket.ticketType" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="价格">
              <el-input v-model="ticket.ticketPrice" :disabled="!isEditingTicket"></el-input>
            </el-form-item>
            <el-form-item label="剩余票数">
              <el-input v-model="ticket.ticketRemaining" :disabled="!isEditingTicket"></el-input>
            </el-form-item>
            <el-form-item label="日期">
              <el-input v-model="ticket.ticketDate" :disabled="true"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4" class="edit-button-col">
          <el-button type="primary" @click="editTicket" v-if="!isEditingTicket">编辑</el-button>
          <el-button type="success" @click="updateTicket" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

// 新增票务表单是否可见
const addTicketFormVisible = ref(false);

// 删除票务表单是否可见
const deleteTicketFormVisible = ref(false);

// 修改票务表单是否可见
const modifyTicketFormVisible = ref(false);

// 票务数据
const ticket = ref(null);

// 是否正在编辑状态
const isEditingTicket = ref(false);

// 显示新增票务表单
function showAddTicketForm() {
  addTicketFormVisible.value = true;
}

// 显示删除票务表单
function showDeleteTicketForm() {
  deleteTicketFormVisible.value = true;
}

// 显示修改票务表单
function showModifyTicketForm() {
  modifyTicketFormVisible.value = true;
}

// 关闭新增票务表单
function handleCloseAddTicketForm(done: () => void) {
  try {
    addTicketFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the add ticket form:', error);
  }
}

// 关闭删除票务表单
function handleCloseDeleteTicketForm(done: () => void) {
  try {
    deleteTicketFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the delete ticket form:', error);
  }
}

// 关闭修改票务表单
function handleCloseModifyTicketForm(done: () => void) {
  try {
    modifyTicketFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the modify ticket form:', error);
  }
}

// 新增票务
async function addTicket() {
  const ticketToAdd1 = ticketToAdd;
  console.log(ticketToAdd1);
  if (!ticketToAdd1.scenicSpotId || !ticketToAdd1.ticketType || !ticketToAdd1.ticketPrice || !ticketToAdd1.ticketRemaining || !ticketToAdd1.ticketDate) {
    ElMessage.error('请输入完整信息');
    return;
  }

  const Time = new Date(ticketToAdd1.ticketDate);

  const mTime = new Date(Time.getTime() + 8 * 60 * 60 * 1000);

  ticketToAdd1.ticketDate =mTime
  ticketToAdd1.ticketPrice = parseFloat(ticketToAdd1.ticketPrice)
  ticketToAdd1.ticketRemaining = parseInt(ticketToAdd1.ticketRemaining)
  console.log(ticketToAdd1);
  try {
    await axios.post('https://123.60.14.84/api/ScenicSpot/ticket', ticketToAdd1);
    ElMessage.success('票务信息添加成功');
    addTicketFormVisible.value = false;
    ticket.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('添加失败');
  }
}

// 删除票务
async function deleteTicket() {
  const scenicSpotId = ticketToDelete.scenicSpotId;
  const ticketType = ticketToDelete.ticketType;
  const ticketDate = ticketToDelete.ticketDate.split(' ')[0]+'T00:00:00';
  if (!scenicSpotId || !ticketType || !ticketDate) {
    ElMessage.error('请输入景点id、票种和日期');
    return;
  }

  try {
    await axios.delete(`https://123.60.14.84/api/ScenicSpot/${scenicSpotId}/${ticketType},${ticketDate}`);
    ElMessage.success('票务信息删除成功');
    deleteTicketFormVisible.value = false;
    ticket.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('删除失败');
  }
}

// 查询并显示票务信息
async function fetchTicket() {
  const scenicSpotId = ticketToModify.scenicSpotId;
  const ticketType = ticketToModify.ticketType;
  const ticketDate = ticketToModify.ticketDate.split(' ')[0]+'T00:00:00';
  if (!scenicSpotId || !ticketType || !ticketDate) {
    ElMessage.error('请输入景点id、票种和日期');
    return;
  }
  console.log(scenicSpotId);
  console.log(ticketType);
  console.log(ticketDate);
  try {
    const response = await axios.get(`https://123.60.14.84/api/ScenicSpot/ticket/${scenicSpotId},${ticketType},${ticketDate}`);
    ticket.value = response.data;
    isEditingTicket.value = false;
    modifyTicketFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 编辑票务信息
function editTicket() {
  isEditingTicket.value = true;
}

// 更新票务信息
async function updateTicket() {
  try {
    ticket.value.ticketPrice = parseFloat(ticket.value.ticketPrice);
    ticket.value.ticketRemaining = parseInt(ticket.value.ticketRemaining);
    const Time = new Date(ticket.value.ticketDate);
    const mTime = new Date(Time.getTime() + 8 * 60 * 60 * 1000);
    ticket.value.ticketDate =mTime
    await axios.put('https://123.60.14.84/api/ScenicSpot/ticket/update', ticket.value);
    ElMessage.success('票务信息更新成功');
    isEditingTicket.value = false;
    ticket.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 定义数据模型
const ticketToAdd = reactive({
  scenicSpotId: undefined,
  ticketType: '',
  ticketPrice: undefined,
  ticketRemaining: undefined,
  ticketDate : undefined
});

const ticketToDelete = reactive({
  scenicSpotId: undefined,
  ticketType: '',
  ticketDate: undefined
});

const ticketToModify = reactive({
  scenicSpotId: undefined,
  ticketType: '',
  ticketDate: undefined
});
</script>

<style lang="scss" scoped>
.el-table {
  margin-top: 10px;
}
.modify-ticket-card {
  margin-top: 20px;
  margin-bottom: 20px;
}
.edit-button-col {
  margin-left: 20px;
}
</style>
