<script lang="ts" setup>
import { ref, onMounted } from "vue"
import { ElMessage, ElMessageBox } from "element-plus"
import { Search, Refresh, CirclePlus, Delete } from "@element-plus/icons-vue"
import axios from "axios"

const loading = ref<boolean>(false)
defineOptions({
  name: "Group-management"
})
// 定义导游的接口
interface Guide {
  guideId: number
  guideName: string
}

// 定义行程的接口
interface TourItinerary {
  itineraryId: number
  itineraryTime: string
  itineraryDuration: string
  activities: string
  scenicSpotId: number | null
}

// 定义酒店接口
interface Hotel {
  hotelId: number
  hotelName: string
  cityName: string
  hotelGrade: string
  hotelLocation: string
  hotelIntroduction: string
}

// 定义旅游团的接口
interface TourGroup {
  groupId: string
  groupName: string
  groupPrice: number
  startDate: string
  endDate: string
  guideName: string
  departure: string
  destination: string
  tourItineraries: TourItinerary[]
  hotels: Hotel[]
}

const tourGroups = ref<TourGroup[]>([])
const guides = ref<Guide[]>([])
const selectedTourIds = ref<string[]>([]) // 选中的旅行团ID
const tourDialogVisible = ref(false)
const tourDetailsDialogVisible = ref(false)
const tourForm = ref<TourGroup>({} as TourGroup)
const tourDetails = ref<TourGroup>({} as TourGroup)
const isEditing = ref(false)

// 筛选条件
const filter = ref({
  departure: "",
  destination: "",
  dateRange: [] as string[], // [startDate, endDate]
  groupName: ""
})

// 获取旅行团列表
const fetchTourGroups = () => {
  axios
    .get("/api/tour-groups")
    .then((response) => {
      tourGroups.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
    })
}

// 获取导游列表
const fetchGuides = () => {
  axios
    .get("/api/guides")
    .then((response) => {
      guides.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching guides:", error)
    })
}

// 新增旅行团
const addTour = () => {
  axios
    .post("/api/tour-groups", tourForm.value)
    .then(() => {
      ElMessage.success("旅行团新增成功")
      fetchTourGroups()
      tourDialogVisible.value = false
    })
    .catch((error) => {
      ElMessage.error("新增失败: " + error.message)
    })
}

// 编辑旅行团
const openEditTourDialog = (tourGroup: TourGroup) => {
  isEditing.value = true
  tourForm.value = { ...tourGroup }
  tourDialogVisible.value = true
}

// 更新旅行团
const updateTour = () => {
  axios
    .put(`/api/tour-groups/${tourForm.value.groupId}`, tourForm.value)
    .then(() => {
      ElMessage.success("旅行团更新成功")
      fetchTourGroups()
      tourDialogVisible.value = false
    })
    .catch((error) => {
      ElMessage.error("更新失败: " + error.message)
    })
}

// 删除旅行团
const deleteTour = (groupId: number) => {
  ElMessageBox.confirm("确认删除该旅行团吗？", "提示", {
    type: "warning"
  })
    .then(() => {
      axios
        .delete(`/api/tour-groups/${groupId}`)
        .then(() => {
          ElMessage.success("旅行团删除成功")
          fetchTourGroups()
        })
        .catch((error) => {
          ElMessage.error("删除失败: " + error.message)
        })
    })
    .catch(() => {
      ElMessage.info("已取消删除")
    })
}

// 批量删除旅行团
const deleteSelectedTours = () => {
  if (selectedTourIds.value.length === 0) {
    ElMessage.warning("请先选择要删除的旅行团")
    return
  }
  ElMessageBox.confirm("确认删除选中的旅行团吗？", "提示", {
    type: "warning"
  })
    .then(() => {
      axios
        .delete(`/api/tour-groups`, { data: { ids: selectedTourIds.value } })
        .then(() => {
          ElMessage.success("批量删除成功")
          fetchTourGroups()
          selectedTourIds.value = [] // 清空选择
        })
        .catch((error) => {
          ElMessage.error("批量删除失败: " + error.message)
        })
    })
    .catch(() => {
      ElMessage.info("已取消删除")
    })
}

// 查看旅行团详情
const viewTourDetails = (groupId: number) => {
  axios
    .get(`/api/tour-groups/${groupId}`)
    .then((response) => {
      tourDetails.value = response.data
      tourDetailsDialogVisible.value = true
    })
    .catch((error) => {
      console.error("Error fetching tour details:", error)
    })
}

// 格式化日期字符串
function formatDate(dateString?: string): string {
  if (!dateString) {
    return "暂无"
  }
  // 解析日期字符串
  const date = new Date(dateString)

  // 获取年、月、日、时、分、秒
  const year = date.getFullYear()
  const month = String(date.getMonth() + 1).padStart(2, "0")
  const day = String(date.getDate()).padStart(2, "0")
  const hours = String(date.getHours()).padStart(2, "0")
  const minutes = String(date.getMinutes()).padStart(2, "0")
  const seconds = String(date.getSeconds()).padStart(2, "0")

  // 格式化为需要的字符串
  return `${year}年${month}月${day}日 ${hours}:${minutes}:${seconds}`
}

// 打开新增旅行团对话框
const openAddTourDialog = () => {
  isEditing.value = false
  tourForm.value = {} as TourGroup
  tourDialogVisible.value = true
}

// 重置筛选条件
const resetSearch = () => {
  filter.value = {
    departure: "",
    destination: "",
    dateRange: [],
    groupName: ""
  }
  fetchTourGroups() // 重置后重新获取列表
}

// 初始化时加载旅行团和导游列表
onMounted(() => {
  fetchTourGroups()
  fetchGuides()
})
</script>

<template>
  <div>
    <!-- 筛选框 -->
    <el-card v-loading="loading" shadow="never" class="search-wrapper">
      <div>
        <span class="word">出发地 </span>
        <el-input v-model="filter.departure" placeholder="请输入出发地" style="width: 200px" />

        <span class="word"> 目的地 </span>
        <el-input v-model="filter.destination" placeholder="请输入目的地" style="width: 200px" />

        <span class="word"> 启程时间 </span>
        <el-date-picker
          v-model="filter.dateRange"
          type="daterange"
          range-separator="到"
          start-placeholder="最早时间"
          end-placeholder="最晚时间"
          size="default"
        />
        <span class="filter-button">
          <el-button type="primary" @click="fetchTourGroups" :icon="Search">筛选</el-button>
          <el-button @click="resetSearch" :icon="Refresh">重置</el-button>
        </span>
      </div>
    </el-card>

    <!-- 操作按钮 -->
    <el-row class="toolbar" type="flex" justify="space-between">
      <el-col>
        <el-button type="primary" @click="openAddTourDialog" :icon="CirclePlus">新增旅行团</el-button>
        <el-button type="danger" @click="deleteSelectedTours" :icon="Delete">批量删除</el-button>
      </el-col>
    </el-row>

    <!-- 旅行团列表 -->
    <el-scrollbar height="400px">
      <el-table
        v-loading="loading"
        :data="tourGroups"
        style="width: 100%"
        @selection-change="(rows: TourGroup[]) => (selectedTourIds.value = rows.map((row) => row.groupId))"
        ref="multipleTable"
      >
        <el-table-column type="selection" width="55" />
        <el-table-column prop="groupId" label="旅行团ID" />
        <el-table-column prop="groupName" label="旅行团名称" />
        <el-table-column prop="groupPrice" label="价格" />
        <el-table-column prop="departure" label="出发地" />
        <el-table-column prop="destination" label="目的地" />
        <el-table-column prop="startDate" label="出发日期" :formatter="formatDate" />
        <el-table-column prop="endDate" label="返回日期" :formatter="formatDate" />
        <el-table-column label="操作">
          <template #default="scope">
            <el-button @click="openEditTourDialog(scope.row)" type="primary" size="mini">编辑</el-button>
            <el-button @click="deleteTour(scope.row.groupId)" type="danger" size="mini">删除</el-button>
            <el-button @click="viewTourDetails(scope.row.groupId)" type="info" size="mini">查看详情</el-button>
          </template>
        </el-table-column>
      </el-table>
    </el-scrollbar>
    <!-- 添加/编辑旅行团对话框 -->
    <el-dialog :title="isEditing ? '编辑旅行团' : '新增旅行团'" v-model:visible="tourDialogVisible">
      <el-form :model="tourForm">
        <el-form-item label="旅行团名称" required>
          <el-input v-model="tourForm.groupName" />
        </el-form-item>
        <el-form-item label="价格" required>
          <el-input v-model="tourForm.groupPrice" type="number" />
        </el-form-item>
        <el-form-item label="导游" required>
          <el-select v-model="tourForm.guideName" placeholder="请选择导游">
            <el-option v-for="guide in guides" :key="guide.guideId" :label="guide.guideName" :value="guide.guideId" />
          </el-select>
        </el-form-item>
        <el-form-item label="出发地" required>
          <el-input v-model="tourForm.departure" />
        </el-form-item>
        <el-form-item label="目的地" required>
          <el-input v-model="tourForm.destination" />
        </el-form-item>
        <el-form-item label="出发日期" required>
          <el-date-picker v-model="tourForm.startDate" type="date" />
        </el-form-item>
        <el-form-item label="返回日期" required>
          <el-date-picker v-model="tourForm.endDate" type="date" />
        </el-form-item>
      </el-form>
      <template v-slot:footer>
        <div class="dialog-footer">
          <el-button @click="tourDialogVisible = false">取消</el-button>
          <el-button type="primary" @click="isEditing ? updateTour() : addTour()">确定</el-button>
        </div>
      </template>
    </el-dialog>

    <!-- 旅行团详情对话框 -->
    <el-dialog title="旅行团详情" v-model:visible="tourDetailsDialogVisible">
      <el-form :model="tourDetails">
        <el-form-item label="旅行团名称">
          <el-input v-model="tourDetails.groupName" disabled />
        </el-form-item>
        <!-- 添加其他详情信息的展示 -->
        <el-form-item label="价格">
          <el-input v-model="tourDetails.groupPrice" disabled />
        </el-form-item>
        <el-form-item label="出发地">
          <el-input v-model="tourDetails.departure" disabled />
        </el-form-item>
        <el-form-item label="目的地">
          <el-input v-model="tourDetails.destination" disabled />
        </el-form-item>
        <el-form-item label="行程天数">
          <el-input v-model="tourDetails.tourItineraries[2]" disabled />
        </el-form-item>
        <!-- 可以继续添加其他详情 -->
      </el-form>
    </el-dialog>
  </div>
</template>

<style scoped>
.button {
  margin-left: 10px;
}

.dialog-footer {
  text-align: right;
}

.toolbar {
  margin-left: 20px;
  margin-top: 5px;
  margin-bottom: 5px;
}

.filter-button {
  margin-left: 20px;
}
</style>

