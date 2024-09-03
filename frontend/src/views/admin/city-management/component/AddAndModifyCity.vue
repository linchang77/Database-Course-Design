<template>
  <div>
    <el-button @click="showAddCityForm">新增城市</el-button>
    <el-button @click="showDeleteCityForm">删除城市</el-button>
    <el-button @click="showModifyCityForm">修改城市</el-button>

    <!-- 新增城市的对话框 -->
    <el-dialog v-model="addCityFormVisible" title="新增城市" :before-close="handleCloseAddCityForm">
      <el-form :model="cityToAdd" label-width="120px">
        <el-form-item label="城市名称">
          <el-input v-model="cityToAdd.cityName" placeholder="请输入城市名称"></el-input>
        </el-form-item>
        <el-form-item label="省份">
          <el-input v-model="cityToAdd.province" placeholder="请输入省份"></el-input>
        </el-form-item>
        <el-form-item label="城市介绍">
          <el-input v-model="cityToAdd.cityIntroduction" placeholder="请输入城市介绍"></el-input>
        </el-form-item>
        <el-form-item label="今日温度">
          <el-input v-model.number="cityToAdd.todayTemperature" placeholder="请输入今日温度"></el-input>
        </el-form-item>
        <el-form-item label="今日天气">
          <el-input v-model="cityToAdd.todayWeather" placeholder="请输入今日天气"></el-input>
        </el-form-item>
        <el-form-item label="明日温度">
          <el-input v-model.number="cityToAdd.tomorrowTemperature" placeholder="请输入明日温度"></el-input>
        </el-form-item>
        <el-form-item label="明日天气">
          <el-input v-model="cityToAdd.tomorrowWeather" placeholder="请输入明日天气"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="addCity">添加</el-button>
          <el-button @click="addCityFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 删除城市的对话框 -->
    <el-dialog v-model="deleteCityFormVisible" title="删除城市" :before-close="handleCloseDeleteCityForm">
      <el-form :model="cityToDelete" label-width="120px">
        <el-form-item label="城市名称">
          <el-input v-model="cityToDelete.cityName" placeholder="请输入城市名称"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="deleteCity">删除</el-button>
          <el-button @click="deleteCityFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 修改城市的对话框 -->
    <el-dialog v-model="modifyCityFormVisible" title="修改城市" :before-close="handleCloseModifyCityForm">
      <el-form :model="cityToModify" label-width="120px">
        <el-form-item label="城市名称">
          <el-input v-model="cityToModify.cityName" placeholder="请输入城市名称"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="fetchCity">查询</el-button>
          <el-button @click="modifyCityFormVisible = false">取消</el-button>
        </span>
      </template>
    </el-dialog>

    <!-- 显示查询结果的卡片 -->
    <el-card v-if="city" shadow="hover">
      <template #header>
        <div>城市信息</div>
      </template>
      <el-row>
        <el-col :span="12">
          <el-form :model="city" label-width="80px">
            <el-form-item label="城市名称">
              <el-input v-model="city.cityName" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="省份">
              <el-input v-model="city.province" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="城市介绍">
              <el-input v-model="city.cityIntroduction" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="今日温度">
              <el-input v-model.number="city.todayTemperature" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="今日天气">
              <el-input v-model="city.todayWeather" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="明日温度">
              <el-input v-model.number="city.tomorrowTemperature" :disabled="!isEditingCity"></el-input>
            </el-form-item>
            <el-form-item label="明日天气">
              <el-input v-model="city.tomorrowWeather" :disabled="!isEditingCity"></el-input>
            </el-form-item>
          </el-form>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="editCity" v-if="!isEditingCity">编辑</el-button>
          <el-button type="success" @click="updateCity" v-else>完成</el-button>
        </el-col>
      </el-row>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

// 新增城市表单是否可见
const addCityFormVisible = ref(false);

// 删除城市表单是否可见
const deleteCityFormVisible = ref(false);

// 修改城市表单是否可见
const modifyCityFormVisible = ref(false);

// 城市数据
const city = ref(null);

// 是否正在编辑状态
const isEditingCity = ref(false);

// 显示新增城市表单
function showAddCityForm() {
  addCityFormVisible.value = true;
}

// 显示删除城市表单
function showDeleteCityForm() {
  deleteCityFormVisible.value = true;
}

// 显示修改城市表单
function showModifyCityForm() {
  modifyCityFormVisible.value = true;
}

// 关闭新增城市表单
function handleCloseAddCityForm(done: () => void) {
  try {
    addCityFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the add city form:', error);
  }
}

// 关闭删除城市表单
function handleCloseDeleteCityForm(done: () => void) {
  try {
    deleteCityFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the delete city form:', error);
  }
}

// 关闭修改城市表单
function handleCloseModifyCityForm(done: () => void) {
  try {
    modifyCityFormVisible.value = false;
    done();
  } catch (error) {
    console.error('Error closing the modify city form:', error);
  }
}

// 新增城市
async function addCity() {
  const cityToadd = cityToAdd;
  if (!cityToAdd.cityName) {
    ElMessage.error('请输入城市名称');
    return;
  }
  console.log(cityToadd);
  try {
    await axios.post('https://123.60.14.84/api/City/add', cityToadd);
    ElMessage.success('城市添加成功');
    addCityFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('添加失败');
  }
}

// 删除城市
async function deleteCity() {
  const cityName = cityToDelete.cityName;
  if (!cityName) {
    ElMessage.error('请输入城市名称');
    return;
  }

  try {
    await axios.delete(`https://123.60.14.84/api/City/del/${cityName}`);
    ElMessage.success('城市删除成功');
    deleteCityFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('删除失败');
  }
}

// 查询并显示城市信息
async function fetchCity() {
  const cityName = cityToModify.cityName;
  if (!cityName) {
    ElMessage.error('请输入城市名称');
    return;
  }

  try {
    const response = await axios.get(`https://123.60.14.84/api/City/${cityName}`);
    city.value = response.data;
    isEditingCity.value = false;
    modifyCityFormVisible.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('查询失败');
  }
}

// 编辑城市信息
function editCity() {
  isEditingCity.value = true;
}

// 更新城市信息
async function updateCity() {
  try {
    const cityToUpdate = city.value;
    console.log(cityToUpdate);
    await axios.patch(`https://123.60.14.84/api/City/mod/intro/${cityToUpdate.cityName},${cityToUpdate.cityIntroduction}`);
    await axios.patch(`https://123.60.14.84/api/City/mod/climate/${cityToUpdate.cityName},${cityToUpdate.todayTemperature},${cityToUpdate.todayWeather},${cityToUpdate.tomorrowTemperature},${cityToUpdate.tomorrowWeather}`);
    ElMessage.success('城市信息更新成功');
    isEditingCity.value = false;
  } catch (error) {
    console.error(error);
    ElMessage.error('更新失败');
  }
}

// 定义数据模型
const cityToAdd = reactive({
  cityName: '',
  province: '',
  cityIntroduction: '',
  todayTemperature: undefined,
  todayWeather: '',
  tomorrowTemperature: undefined,
  tomorrowWeather: ''
});

const cityToDelete = reactive({
  cityName: ''
});

const cityToModify = reactive({
  cityName: ''
});
</script>
