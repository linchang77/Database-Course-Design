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
      <el-table :data="searchResults" border style="width: 100%;">
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
        <el-table-column label="操作" fixed="right" width="150">
          <template #default="{ row }">
            <el-button @click="showModifyForm(row)" type="text" size="small">修改</el-button>
            <el-button @click="onDelete(row)" type="text" size="small" style="color: red;">删除</el-button>
          </template>
        </el-table-column>
      </el-table>

      <!-- 修改景点信息的对话框 -->
      <el-dialog v-model="modifySpotFormVisible" title="修改景点信息" :before-close="handleCloseModifySpotForm">
        <el-form :model="spotToModify" label-width="120px">
          <el-form-item label="ID">
            <el-input v-model="spotToModify.scenicSpotId" disabled></el-input>
          </el-form-item>
          <el-form-item label="景点名称">
            <el-input v-model="spotToModify.scenicSpotName"></el-input>
          </el-form-item>
          <el-form-item label="城市">
            <el-input v-model="spotToModify.cityName"></el-input>
          </el-form-item>
          <el-form-item label="等级">
            <el-input v-model="spotToModify.scenicSpotGrade"></el-input>
          </el-form-item>
          <el-form-item label="简介">
            <el-input type="textarea" v-model="spotToModify.scenicSpotIntroduction"></el-input>
          </el-form-item>
          <el-form-item label="位置">
            <el-input v-model="spotToModify.scenicSpotLocation"></el-input>
          </el-form-item>
        </el-form>
        <template #footer>
          <span class="dialog-footer">
            <el-button @click="modifySpot">完成</el-button>
            <el-button @click="modifySpotFormVisible = false">取消</el-button>
          </span>
        </template>
      </el-dialog>

      <!-- 修改票务信息的对话框 -->
      <el-dialog v-model="modifyTicketFormVisible" title="修改票务信息" :before-close="handleCloseModifyTicketForm">
        <el-form :model="ticketToModify" label-width="120px">
          <el-form-item label="景点ID">
            <el-input v-model="ticketToModify.scenicSpotId" disabled></el-input>
          </el-form-item>
          <el-form-item label="票种">
            <el-input v-model="ticketToModify.ticketType"></el-input>
          </el-form-item>
          <el-form-item label="价格(元)">
            <el-input v-model.number="ticketToModify.ticketPrice"></el-input>
          </el-form-item>
          <el-form-item label="剩余票数">
            <el-input v-model.number="ticketToModify.ticketRemaining"></el-input>
          </el-form-item>
          <el-form-item label="日期">
            <el-date-picker v-model="ticketToModify.ticketDate" type="date" placeholder="选择日期"></el-date-picker>
          </el-form-item>
        </el-form>
        <template #footer>
          <span class="dialog-footer">
            <el-button @click="modifyTicket">完成</el-button>
            <el-button @click="modifyTicketFormVisible = false">取消</el-button>
          </span>
        </template>
      </el-dialog>
    </div>
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { ElMessage, ElMessageBox } from 'element-plus';

// 搜索类型
const searchType = ref('spots');

// 搜索关键词
const searchKeyword = ref('');

// 搜索结果
const searchResults = ref([]);

// 控制修改景点对话框的显示状态
const modifySpotFormVisible = ref(false);

// 控制修改票务对话框的显示状态
const modifyTicketFormVisible = ref(false);

// 需要修改的景点记录
const spotToModify = ref<any>({});

// 需要修改的票务记录
const ticketToModify = ref<any>({});

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

// 显示修改景点表单
const showModifySpotForm = (row: any) => {
  spotToModify.value = JSON.parse(JSON.stringify(row)); // 深拷贝原始记录
  modifySpotFormVisible.value = true;
};

// 显示修改票务表单
const showModifyTicketForm = (row: any) => {
  ticketToModify.value = JSON.parse(JSON.stringify(row)); // 深拷贝原始记录
  modifyTicketFormVisible.value = true;
};

// 修改景点
const modifySpot = async () => {
  try {
    const response = await axios.put(`https://123.60.14.84/api/ScenicSpot/${spotToModify.value.scenicSpotId}/update`, spotToModify.value);
    console.log(response);
    ElMessage.success('景点信息更新成功');
    await onSearch(); // 刷新列表
    modifySpotFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新景点信息失败');
  }
};

// 修改票务
const modifyTicket = async () => {
  try {
    const response = await axios.put(`https://123.60.14.84/api/ScenicSpot/ticket/update`, ticketToModify.value);
    console.log(response);
    ElMessage.success('票务信息更新成功');
    await onSearch(); // 刷新列表
    modifyTicketFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新票务信息失败');
  }
};

// 删除记录
const onDelete = async (row: any) => {
  ElMessageBox.confirm(
    '此操作将永久删除该记录, 是否继续?',
    '提示',
    {
      confirmButtonText: '确定',
      cancelButtonText: '取消',
      type: 'warning'
    }
  ).then(async () => {
    try {
      const url = searchType.value === 'spots' ? `https://123.60.14.84/api/ScenicSpot/${row.scenicSpotId}` : `https://123.60.14.84/api/ScenicSpot/${row.scenicSpotId}/${row.ticketType},${row.ticketDate}`;
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
  if (searchType.value === 'spots') {
    showModifySpotForm(row);
  } else if (searchType.value === 'tickets') {
    showModifyTicketForm(row);
  }
};

// 关闭修改景点对话框
const handleCloseModifySpotForm = (done: Function) => {
  done();
  spotToModify.value = {}; // 清空表单数据
};

// 关闭修改票务对话框
const handleCloseModifyTicketForm = (done: Function) => {
  done();
  ticketToModify.value = {}; // 清空表单数据
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
