<template>
  <div>
    <el-button @click="showAddScenicForm">新增景区</el-button>
    <el-button @click="showDeleteScenicForm">删除景区</el-button>
    <el-button @click="showModifyScenicForm">修改景区</el-button>

    <!-- 新增景区的对话框 -->
    <el-dialog v-model="addScenicFormVisible" title="新增景区" :before-close="handleCloseAddScenicForm">
      <el-form :model="scenicToAdd" label-width="120px">
        <el-form-item label="景区名称">
          <el-input v-model="scenicToAdd.scenicName" placeholder="请输入景区名称"></el-input>
        </el-form-item>
        <el-form-item label="所在城市">
          <el-input v-model="scenicToAdd.city" placeholder="请输入所在城市"></el-input>
        </el-form-item>
        <el-form-item label="景区等级">
          <el-input v-model="scenicToAdd.grade" placeholder="请输入景区等级"></el-input>
        </el-form-item>
        <el-form-item label="景区简介">
          <el-input v-model="scenicToAdd.introduction" type="textarea" placeholder="请输入景区简介"></el-input>
        </el-form-item>
        <el-form-item label="景区位置">
          <el-input v-model="scenicToAdd.location" placeholder="请输入景区位置"></el-input>
        </el-form-item>
        <el-form-item label="距离市中心远近评分">
          <el-input v-model="scenicToAdd.remoteness" placeholder="请输入距离市中心远近评分"></el-input>
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
          <el-input v-model="scenicToDelete.scenicId" placeholder="请输入景区ID"></el-input>
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
          <el-input v-model="scenicToModify.scenicId" placeholder="请输入景区ID"></el-input>
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
    <el-card v-if="scenic" shadow="hover">
      <template #header>
        <div>景区信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="scenic" label-width="80px">
            <el-form-item label="景区ID">
              <el-input v-model="scenic.ScenicId" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区名称">
              <el-input v-model="scenic.ScenicName" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="所在城市">
              <el-input v-model="scenic.City" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区等级">
              <el-input v-model="scenic.Grade" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区简介">
              <el-input v-model="scenic.Introduction" type="textarea" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="景区位置">
              <el-input v-model="scenic.Location" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
            <el-form-item label="距离市中心远近评分">
              <el-input v-model="scenic.Remoteness" :disabled="!isEditingScenic"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4">
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
  const scenicToAdd = scenicToAdd.value;
  if (!scenicToAdd.ScenicName || !scenicToAdd.City) {
    ElMessage.error('请输入景区名称和所在城市');
    return;
  }

  try {
    await axios.post('https://123.60.14.84:11000/api/Scenic', scenicToAdd);
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
  const scenicId = scenicToDelete.value.ScenicId;
  if (!scenicId) {
    ElMessage.error('请输入景区ID');
    return;
  }

  try {
    await axios.delete(`https://123.60.14.84:11000/api/Scenic/${scenicId}`);
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
  const scenicId = scenicToModify.value.ScenicId;
  if (!scenicId) {
    ElMessage.error('请输入景区ID');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84:11000/api/Scenic/${scenicId}`);
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
    await axios.put(`https://123.60.14.84:11000/api/Scenic/${scenic.value.ScenicId}`, scenic.value);
    ElMessage.success('景区信息更新成功');
    isEditingScenic.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 定义数据模型
const scenicToAdd = reactive({
  ScenicName: '',
  City: '',
  Grade: '',
  Introduction: '',
  Location: '',
  Remoteness: ''
});

const scenicToDelete = reactive({
  ScenicId: ''
});

const scenicToModify = reactive({
  ScenicId: ''
});
</script>
