<template>
  <div>
    <el-button type="primary" :icon="CirclePlus" @click="showAddScenicForm">新增景区</el-button>
    <el-button type="primary" :icon="EditPen" @click="showModifyScenicForm">修改景区</el-button>
    <el-button type="danger" :icon="Delete" @click="showDeleteScenicForm">删除景区</el-button>


    <!-- 新增景区的对话框 -->
    <el-dialog v-model="addScenicFormVisible" title="新增景区" :before-close="handleCloseAddScenicForm">
      <el-form :model="scenicToAdd" label-width="120px">
        <el-form-item label="景区名称">
          <el-input v-model="scenicToAdd.scenicSpotName" placeholder="请输入景区名称"></el-input>
        </el-form-item>
        <el-form-item label="所在城市">
          <el-input v-model="scenicToAdd.cityName" placeholder="请输入所在城市"></el-input>
        </el-form-item>
        <el-form-item label="景区等级">
          <el-input v-model="scenicToAdd.scenicSpotGrade" placeholder="请输入景区等级"></el-input>
        </el-form-item>
        <el-form-item label="景区简介">
          <el-input v-model="scenicToAdd.scenicSpotIntroduction" type="textarea" placeholder="请输入景区简介"></el-input>
        </el-form-item>
        <el-form-item label="景区位置">
          <el-input v-model="scenicToAdd.scenicSpotLocation" placeholder="请输入景区位置"></el-input>
        </el-form-item>
        <el-form-item label="距离市中心远近">
          <el-input v-model="scenicToAdd.scenicSpotRemoteness" placeholder="请输入距离市中心远近评分"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="addScenic">添加</el-button>
          <el-button @click="addScenicFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 删除景区的对话框 -->
    <el-dialog v-model="deleteScenicFormVisible" title="删除景区" :before-close="handleCloseDeleteScenicForm">
      <el-form :model="scenicToDelete" label-width="120px">
        <el-form-item label="景区ID">
          <el-input v-model="scenicToDelete.scenicSpotId" placeholder="请输入景区ID"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="deleteScenic">删除</el-button>
          <el-button @click="deleteScenicFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 修改景区的对话框 -->
    <el-dialog v-model="modifyScenicFormVisible" title="修改景区" :before-close="handleCloseModifyScenicForm">
      <el-form :model="scenicToModify" label-width="120px">
        <el-form-item label="景区ID">
          <el-input v-model="scenicToModify.scenicSpotId" placeholder="请输入景区ID"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchScenic">查询</el-button>
          <el-button @click="modifyScenicFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 显示查询结果的卡片 -->
    <el-card v-if="scenic" shadow="hover" class="scenic-card">
      <template #header>
        <div>景区信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="scenic" label-width="80px">
            <el-form-item label="景区ID">
              <el-input v-model="scenic.scenicSpotId" :disabled="true"></el-input>
            </el-form-item>
            <el-form-item label="景区名称">
              <el-input v-model="scenic.scenicSpotName" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="所在城市">
              <el-input v-model="scenic.cityName" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区等级">
              <el-input v-model="scenic.scenicSpotGrade" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区简介">
              <el-input v-model="scenic.scenicSpotIntroduction" type="textarea" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区位置">
              <el-input v-model="scenic.scenicSpotLocation" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="距离市中心远近">
              <el-input v-model="scenic.scenicSpotRemoteness" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4" class="edit-button-col">
          <el-button type="primary" @click="editScenic" v-if="!isEditingScenic">编辑</el-button>
          <el-button type="success" @click="updateScenic" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';
import { CirclePlus, Delete, Edit, EditPen } from '@element-plus/icons-vue';

// 新增景区表单是否可见
const addScenicFormVisible = ref(false);

// 删除景区表单是否可见
const deleteScenicFormVisible = ref(false);

// 修改景区表单是否可见
const modifyScenicFormVisible = ref(false);

// 景区数据
const scenic = ref(null);

// 是否正在编辑状态
const isEditingScenic = ref(false);

// 显示新增景区表单
function showAddScenicForm() {
  addScenicFormVisible.value = true;
}

// 显示删除景区表单
function showDeleteScenicForm() {
  deleteScenicFormVisible.value = true;
}

// 显示修改景区表单
function showModifyScenicForm() {
  modifyScenicFormVisible.value = true;
}

// 关闭新增景区表单
function handleCloseAddScenicForm(done: () => void) {
  try {
    addScenicFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the add scenic form:', error);
  }
}

// 关闭删除景区表单
function handleCloseDeleteScenicForm(done: () => void) {
  try {
    deleteScenicFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the delete scenic form:', error);
  }
}

// 关闭修改景区表单
function handleCloseModifyScenicForm(done: () => void) {
  try {
    modifyScenicFormVisible.value = false;
    done(); // 调用 done() 来完成关闭动作
  } catch (error) {
    console.error('Error closing the modify scenic form:', error);
  }
}

// 新增景区
async function addScenic() {
  const scenicToadd = scenicToAdd;
  if (!scenicToadd.scenicSpotName || !scenicToadd.cityName) {
    ElMessage.error('请输入景区名称和所在城市');
    return;
  }

  try {
    await axios.post('https://123.60.14.84/api/ScenicSpot', scenicToadd);
    ElMessage.success('景区添加成功');
    addScenicFormVisible.value = false;
    scenic.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('添加失败');
  }
}

// 删除景区
async function deleteScenic() {
  const scenicId = scenicToDelete.scenicSpotId;
  if (!scenicId) {
    ElMessage.error('请输入景区ID');
    return;
  }

  try {
    await axios.delete(`https://123.60.14.84/api/ScenicSpot/${scenicId}`);
    ElMessage.success('景区删除成功');
    deleteScenicFormVisible.value = false;
    scenic.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('删除失败');
  }
}

// 查询并显示景区信息
async function fetchScenic() {
  const scenicId = scenicToModify.scenicSpotId;
  if (!scenicId) {
    ElMessage.error('请输入景区ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84/api/ScenicSpot/id/${scenicId}`);
    scenic.value = response.data;
    isEditingScenic.value = false;
    modifyScenicFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 编辑景区信息
function editScenic() {
  isEditingScenic.value = true;
}

// 更新景区信息
async function updateScenic() {
  try {
    console.log(scenic.value)
    const scenicToUpdate = {
      scenicSpotName: scenic.value.scenicSpotName,
      cityName: scenic.value.cityName,
      scenicSpotGrade: scenic.value.scenicSpotGrade,
      scenicSpotIntroduction: scenic.value.scenicSpotIntroduction,
      scenicSpotLocation: scenic.value.scenicSpotLocation,
      scenicSpotRemoteness: scenic.value.scenicSpotRemoteness
    }
    await axios.put(`https://123.60.14.84/api/ScenicSpot/${scenic.value.scenicSpotId}/update`, scenicToUpdate);
    ElMessage.success('景区信息更新成功');
    isEditingScenic.value = false;
    scenic.value = null;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 定义数据模型
const scenicToAdd = reactive({
  scenicSpotName: '',
  cityName: '',
  scenicSpotGrade: '',
  scenicSpotIntroduction: '',
  scenicSpotLocation: '',
  scenicSpotRemoteness: ''
});

const scenicToDelete = reactive({
  scenicSpotId: ''
});

const scenicToModify = reactive({
  scenicSpotId: ''
});
</script>

<style lang="scss" scoped>
.scenic-card {
  margin-top: 20px;
  margin-bottom: 20px;
}

.edit-button-col {
  margin-left: 20px;
}
</style>
