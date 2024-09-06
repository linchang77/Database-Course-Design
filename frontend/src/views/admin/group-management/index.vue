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
  guideId: string
  guideName: string
}

// 定义行程的接口
interface TourItinerary {
  itineraryId: string
  groupId?: string
  itineraryTime?: string
  itineraryDuration?: string
  activities?: string
  scenicSpotId?: number | null
}

// 定义酒店接口
interface Hotel {
  hotelId: string
  hotelName?: string
  cityName?: string
  hotelGrade?: string
  hotelLocation?: string
  hotelIntroduction?: string
}

// 定义门票接口
interface TourTicket {
  vehicleId?: string
  vehicleType?: string
  ticketType?: string
  ticketPrice?: number
  ticketDepartureTime?: string
  ticketArrivalTime?: string
  ticketDepartureCity?: string
  ticketArrivalCity?: string
  ticketId: string
}

// 定义旅游团的接口
interface TourGroup {
  groupId: string
  guideId?: string
  startDate?: string
  endDate?: string
  groupName?: string
  groupPrice?: number | null
  departure?: string
  destination?: string
  guideName?: string
  goTicket: TourTicket
  returnTicket: TourTicket
  tourItineraries: TourItinerary[]
  hotels: Hotel[]
}

// 定义景点接口
interface scenicSpot {
  scenicSpotId: string
  scenicSpotName: string
}

const tourGroups = ref<TourGroup[]>([])
const guides = ref<Guide[]>([])
const hotels = ref<Hotel[]>([])
const tourTickets = ref<TourTicket[]>([])
const scenicSpots = ref<scenicSpot[]>([])
const selectedTourIds = ref<string[]>([]) // 选中的旅行团ID
const tourDialogVisible = ref(false)
const tourForm = ref<TourGroup>({} as TourGroup)
const isEditing = ref(false)
const apiUrl = "https://123.60.14.84/api/tourgroup"

const groupNameInput = ref("")
const groupIdInput = ref("")

// 筛选条件
const filter = ref({
  departure: "",
  destination: "",
  departureTime: null as Date | null, // 出发时间
  daysOfTravel: null as number | null // 旅行天数
})

// 获取旅行团列表
const fetchTourGroups = () => {
  axios
    .get(`${apiUrl}/search/all`)
    .then((response) => {
      console.log("Response data:", response.data)
      const data = response.data
      if (Array.isArray(data)) {
        tourGroups.value = data.map((group: any) => ({
          groupId: group.groupId,
          guideId: group.guideId,
          groupName: group.groupName,
          groupPrice: group.groupPrice,
          startDate: group.startDate,
          endDate: group.endDate,
          departure: group.departure,
          destination: group.destination,
          guideName: group.guideName,
          goTicket: group.goTicket,
          returnTicket: group.returnTicket,
          tourItineraries: Array.isArray(group.tourItineraries)
            ? group.tourItineraries.map((itinerary: any) => ({
                itineraryId: itinerary.itineraryId,
                itineraryTime: itinerary.itineraryTime,
                itineraryDuration: itinerary.itineraryDuration,
                activities: itinerary.activities,
                scenicSpotId: itinerary.scenicSpotId
              }))
            : [],
          hotels: Array.isArray(group.hotels)
            ? group.hotels.map((hotel: any) => ({
                hotelId: hotel.hotelId,
                hotelName: hotel.hotelName,
                cityName: hotel.cityName,
                hotelGrade: hotel.hotelGrade,
                hotelLocation: hotel.hotelLocation,
                hotelIntroduction: hotel.hotelIntroduction
              }))
            : []
        }))
      } else {
        console.log("Raw response data:", data)
        console.error("Unexpected data format")
        tourGroups.value = []
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
    })
}

// 获取导游列表
const fetchGuides = () => {
  axios
    .get(`${apiUrl}/guide/all`)
    .then((response) => {
      guides.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching guides:", error)
    })
}

// 获取酒店列表
const fetchHotels = () => {
  axios
    .get(`https://123.60.14.84/api/hotel/all`)
    .then((response) => {
      hotels.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching hotels:", error)
    })
}

// 获取门票列表
const fetchTourTickets = () => {
  axios
    .get(`https://123.60.14.84/api/vehicle/tickets`)
    .then((response) => {
      tourTickets.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching tour tickets:", error)
    })
}

// 获取景点列表
const fetchScenicSpots = () => {
  axios
    .get(`https://123.60.14.84/api/scenicspot/all/spots`)
    .then((response) => {
      scenicSpots.value = response.data
    })
    .catch((error) => {
      console.error("Error fetching tour tickets:", error)
    })
}

// 新增旅行团
const addTour = () => {
  const newTourForm = {
    value: {
      guideId: tourForm.value.guideId,
      startDate: tourForm.value.startDate,
      endDate: tourForm.value.endDate,
      groupName: tourForm.value.groupName,
      groupPrice: tourForm.value.groupPrice,
      goTicketId: tourForm.value.goTicket.ticketId,
      returnTicketId: tourForm.value.returnTicket.ticketId,
      departure: tourForm.value.departure,
      destination: tourForm.value.destination,
      tourItineraries: tourForm.value.tourItineraries.map((itinerary) => ({
        itineraryTime: itinerary.itineraryTime,
        itineraryDuration: itinerary.itineraryDuration,
        activities: itinerary.activities,
        scenicSpotId: itinerary.scenicSpotId
      })),
      hotels: tourForm.value.hotels.map((hotel) => hotel.hotelId)
    }
  }
  axios
    .post(`${apiUrl}/add`, newTourForm.value)
    .then(() => {
      ElMessage.success("旅行团新增成功")
      fetchTourGroups()
      tourDialogVisible.value = false
    })
    .catch((error) => {
      ElMessage.error("新增失败: " + error.message)
    })
}

// 转换出行类别为中文
const formatVehicleType = (type?: string) => {
  switch (type) {
    case "plane":
      return "飞机"
    case "train":
      return "火车"
    case "car":
      return "汽车"
    default:
      return "其他"
  }
}

// 编辑旅行团
const openEditTourDialog = (tourGroup: TourGroup) => {
  isEditing.value = true
  tourForm.value = { ...tourGroup }
  tourDialogVisible.value = true
}

// 更新旅行团
const updateTour = () => {
  const newTourForm = {
    value: {
      guideId: tourForm.value.guideId,
      startDate: tourForm.value.startDate,
      endDate: tourForm.value.endDate,
      groupName: tourForm.value.groupName,
      groupPrice: tourForm.value.groupPrice,
      goTicketId: tourForm.value.goTicket.ticketId,
      returnTicketId: tourForm.value.returnTicket.ticketId,
      departure: tourForm.value.departure,
      destination: tourForm.value.destination,
      tourItineraries: tourForm.value.tourItineraries.map((itinerary) => ({
        itineraryTime: itinerary.itineraryTime,
        itineraryDuration: itinerary.itineraryDuration,
        activities: itinerary.activities,
        scenicSpotId: itinerary.scenicSpotId
      })),
      hotels: tourForm.value.hotels.map((hotel) => hotel.hotelId)
    }
  }

  axios
    .put(`${apiUrl}/mod/${tourForm.value.groupId}`, newTourForm.value)
    .then(() => {
      ElMessage.success("旅行团更新成功")
      fetchTourGroups()
      tourDialogVisible.value = false
    })
    .catch((error) => {
      ElMessage.error("更新失败: " + error.message)
    })

  fetchTourGroups()
}

const showDeleteConfirm = ref<boolean>(true)
// 删除旅行团
const deleteTour = (groupId: string) => {
  if (showDeleteConfirm.value) {
    ElMessageBox.confirm("确认删除该旅行团吗？", "提示", {
      type: "warning"
    })

      .then(() => {
        axios
          .delete(`${apiUrl}/del/${groupId}`)
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
}

// 批量删除旅行团
const deleteSelectedTours = () => {
  if (selectedTourIds.value.length === 0) {
    ElMessage.warning("请先选择要删除的旅行团")
    return
  }
  showDeleteConfirm.value = false
  ElMessageBox.confirm("确认删除选中的旅行团吗？", "提示", {
    type: "warning"
  })
    .then(() => {
      // 使用Promise.all来并行删除所有选中的旅行团
      Promise.all(selectedTourIds.value.map((id) => deleteTour(id)))
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
  showDeleteConfirm.value = true
}

// 添加行程
const addItinerary = () => {
  tourForm.value.tourItineraries.push({
    itineraryId: "",
    groupId: tourForm.value.groupId,
    itineraryTime: "",
    itineraryDuration: "",
    activities: "",
    scenicSpotId: null
  })
}

// 删除行程
const removeItinerary = (index: number) => {
  tourForm.value.tourItineraries.splice(index, 1)
}

// 添加酒店
const addHotel = () => {
  tourForm.value.hotels.push({
    hotelId: "",
    hotelName: "",
    cityName: "",
    hotelGrade: "",
    hotelLocation: "",
    hotelIntroduction: ""
  })
}

// 删除酒店
const removeHotel = (index: number) => {
  tourForm.value.hotels.splice(index, 1)
}

// 根据名称搜索旅行团
async function searchTourGroupsByName() {
  try {
    if (!groupNameInput.value) {
      fetchTourGroups()
      return
    }
    const response = await axios.get(`${apiUrl}/search/name/${groupNameInput.value}`)
    if (response.status === 200) {
      tourGroups.value = response.data
    } else {
      ElMessage.error("No tour group found.")
      tourGroups.value = [] // 清空列表
    }
  } catch (error) {
    console.error("Error searching tour groups by name:", error)
    ElMessage.error("Failed to search tour groups by name.")
  }
}

// 根据ID搜索旅行团
async function searchTourGroupById() {
  try {
    if (!groupIdInput.value) {
      fetchTourGroups()
      return
    }
    const response = await axios.get(`${apiUrl}/search/id/${groupIdInput.value}`)
    if (response.status === 200) {
      tourGroups.value = response.data ? [response.data] : []
    } else {
      ElMessage.error("No tour group found.")
      tourGroups.value = [] // 清空列表
    }
  } catch (error) {
    console.error("Error searching tour group by id:", error)
    ElMessage.error("Failed to search tour group by id.")
  }
}

// 根据筛选条件搜索旅行团
async function searchTourGroups() {
  try {
    const queryParams = new URLSearchParams({
      departure: filter.value.departure,
      destination: filter.value.destination,
      departure_Time: filter.value.departureTime ? filter.value.departureTime.toISOString() : "",
      days_of_Travel: filter.value.daysOfTravel?.toString() || ""
    }).toString()

    const response = await axios.get(`${apiUrl}/search?${queryParams}`)
    if (response.status === 200) {
      tourGroups.value = response.data
    } else {
      ElMessage.error("No matching tour groups found.")
      tourGroups.value = [] // 清空列表
    }
  } catch (error) {
    console.error("Error searching tour groups:", error)
    ElMessage.error("Failed to search tour groups.")
  }
}

// 格式化时间到秒
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

// 格式化时间到日
function formatDateToDay(dateString?: string): string {
  if (!dateString) {
    return "暂无"
  }
  // 解析日期字符串
  const date = new Date(dateString)

  // 获取年、月、日
  const year = date.getFullYear()
  const month = String(date.getMonth() + 1).padStart(2, "0")
  const day = String(date.getDate()).padStart(2, "0")

  // 格式化为需要的字符串
  return `${year}年${month}月${day}日`
}

// 打开新增旅行团对话框
const openAddTourDialog = () => {
  isEditing.value = false
  Object.assign(tourForm.value, {
    groupId: "",
    guideId: "",
    startDate: "",
    endDate: "",
    groupName: "",
    groupPrice: null,
    departure: "",
    destination: "",
    guideName: "",
    tourItineraries: [],
    hotels: [],
    goTicket: {} as TourTicket,
    returnTicket: {} as TourTicket
  })
  tourDialogVisible.value = true
}

// 重置筛选条件
const resetSearch = () => {
  groupIdInput.value = ""
  groupNameInput.value = ""
  filter.value = {
    departure: "",
    destination: "",
    departureTime: null,
    daysOfTravel: null
  }
  fetchTourGroups() // 重置后重新获取列表
}

const durationOptions = Array.from({ length: 24 }, (_, i) => `${(i + 1).toString().padStart(2, "0")}:00:00`)

// 初始化时加载旅行团和导游列表
onMounted(() => {
  fetchTourGroups()
  fetchGuides()
  fetchHotels()
  fetchTourTickets()
  fetchScenicSpots()
})
</script>

<template>
  <div>
    <!-- 筛选框 -->
    <el-card v-loading="loading" shadow="never" class="search-wrapper">
      <div>
        <!-- 新增团名搜索框 -->
        <div style="margin-bottom: 10px">
          <span class="word">旅行团ID </span>
          <el-input v-model="groupIdInput" placeholder="请输入旅行团ID" style="width: 180px" clearable />
          <el-button type="primary" class="search-button" @click="searchTourGroupById" :icon="Search">搜索</el-button>
          <span class="word">旅行团名称 </span>
          <el-input v-model="groupNameInput" placeholder="请输入旅行团名称" style="width: 180px" clearable />
          <el-button type="primary" class="search-button" @click="searchTourGroupsByName" :icon="Search"
            >搜索</el-button
          >
        </div>

        <!-- 出发地、目的地和启程时间筛选 -->
        <span class="word">出发地 </span>
        <el-input v-model="filter.departure" placeholder="请输入出发地" style="width: 180px" />

        <span class="word"> 目的地 </span>
        <el-input v-model="filter.destination" placeholder="请输入目的地" style="width: 180px" />

        <span class="word"> 启程时间 </span>
        <el-date-picker
          v-model="filter.departureTime"
          placeholder="选择启程时间"
          style="width: 180px"
          size="default"
          type="datetime"
        />
        <span class="word"> 旅行天数 </span>
        <el-input-number v-model="filter.daysOfTravel" placeholder="选择旅行天数" style="width: 180px" :min="1" />
        <span class="filter-button">
          <el-button type="primary" @click="searchTourGroups" :icon="Search">筛选</el-button>
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
        @selection-change="(rows: TourGroup[]) => (selectedTourIds = rows.map((row) => row.groupId))"
        ref="multipleTable"
      >
        <el-table-column type="selection" width="55" align="center" />
        <el-table-column prop="groupId" label="旅行团ID" width="100" align="center" />
        <el-table-column prop="groupName" label="旅行团名称" width="240" align="center" />
        <el-table-column prop="groupPrice" label="价格" width="100" align="center" />
        <el-table-column prop="startDate" label="开始日期" width="180" align="center">
          <template #default="scope">{{ formatDateToDay(scope.row.startDate) }}</template>
        </el-table-column>
        <el-table-column prop="endDate" label="结束日期" width="180" align="center">
          <template #default="scope">{{ formatDateToDay(scope.row.endDate) }}</template>
        </el-table-column>
        <el-table-column prop="guideName" label="导游" width="100" align="center" />
        <el-table-column prop="departure" label="出发地" width="150" align="center" />
        <el-table-column prop="destination" label="目的地" width="150" align="center" />

        <el-table-column label="操作" width="200px" align="center">
          <template #default="scope">
            <el-button @click="openEditTourDialog(scope.row)" type="primary" size="small">编辑</el-button>
            <el-button @click="deleteTour(scope.row.groupId)" type="danger" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
    </el-scrollbar>

    <!-- 添加/编辑旅行团对话框 -->
    <el-scrollbar height="200px">
      <el-dialog
        height="400px"
        v-model="tourDialogVisible"
        title="旅行团信息"
        :before-close="(done: Function) => done()"
      >
        <el-form :model="tourForm">
          <el-form-item label="旅行团名称" required>
            <el-input v-model="tourForm.groupName" />
          </el-form-item>
          <el-form-item label="价格">
            <el-input v-model="tourForm.groupPrice" type="number" />
          </el-form-item>
          <el-form-item label="开始日期" required>
            <el-date-picker v-model="tourForm.startDate" type="date" placeholder="选择开始日期" />
          </el-form-item>
          <el-form-item label="结束日期" required>
            <el-date-picker v-model="tourForm.endDate" type="date" placeholder="选择结束日期" />
          </el-form-item>
          <el-form-item label="导游" required>
            <el-select v-model="tourForm.guideId" placeholder="请选择导游">
              <el-option v-for="guide in guides" :key="guide.guideId" :label="guide.guideName" :value="guide.guideId" />
            </el-select>
          </el-form-item>
          <el-form-item label="出发地" required>
            <el-input v-model="tourForm.departure" />
          </el-form-item>
          <el-form-item label="目的地" required>
            <el-input v-model="tourForm.destination" />
          </el-form-item>
          <el-form-item label="出发车票">
            <el-select v-model="tourForm.goTicket.ticketId" placeholder="请选择出发车票">
              <el-option
                v-for="ticket in tourTickets"
                :key="ticket.ticketId"
                :label="
                  formatVehicleType(ticket.vehicleType) +
                  ' ' +
                  ticket.vehicleId +
                  ': ' +
                  ticket.ticketDepartureCity +
                  ' - ' +
                  ticket.ticketArrivalCity +
                  ' (' +
                  formatDate(ticket.ticketDepartureTime) +
                  ' - ' +
                  formatDate(ticket.ticketArrivalTime) +
                  ')' +
                  '  价格:' +
                  ticket.ticketPrice +
                  '元' +
                  '  票型:' +
                  ticket.ticketType
                "
                :value="ticket.ticketId"
              />
            </el-select>
          </el-form-item>
          <el-form-item label="返回车票">
            <el-select v-model="tourForm.returnTicket.ticketId" placeholder="请选择返回车票">
              <el-option
                v-for="ticket in tourTickets"
                :key="ticket.ticketId"
                :label="
                  formatVehicleType(ticket.vehicleType) +
                  ' ' +
                  ticket.vehicleId +
                  ': ' +
                  ticket.ticketDepartureCity +
                  ' - ' +
                  ticket.ticketArrivalCity +
                  ' (' +
                  formatDate(ticket.ticketDepartureTime) +
                  ' - ' +
                  formatDate(ticket.ticketArrivalTime) +
                  ')' +
                  '  价格:' +
                  ticket.ticketPrice +
                  '元' +
                  '  票型:' +
                  ticket.ticketType
                "
                :value="ticket.ticketId"
              />
            </el-select>
          </el-form-item>

          <!-- 动态行程安排 -->
          <el-form-item label="行程安排">
            <div
              v-for="(itinerary, index) in tourForm.tourItineraries"
              :key="itinerary.itineraryId"
              class="custom-card"
            >
              <el-form-item label="时间">
                <el-date-picker
                  v-model="itinerary.itineraryTime"
                  type="datetime"
                  placeholder="选择行程时间"
                  value-format="YYYY-MM-DD HH:mm:ss"
                />
              </el-form-item>
              <el-form-item label="时长">
                <el-select v-model="itinerary.itineraryDuration" placeholder="请选择时长"
                  ><el-option v-for="duration in durationOptions" :key="duration" :label="duration" :value="duration"
                /></el-select>
              </el-form-item>
              <el-form-item label="活动描述">
                <el-input v-model="itinerary.activities" />
              </el-form-item>
              <el-form-item label="景点">
                <el-select v-model="itinerary.scenicSpotId" placeholder="请选择景点">
                  <el-option
                    v-for="scenicSpot in scenicSpots"
                    :key="scenicSpot.scenicSpotId"
                    :label="scenicSpot.scenicSpotName"
                    :value="scenicSpot.scenicSpotId"
                  />
                </el-select>
              </el-form-item>
              <!-- 删除行程按钮 -->
              <el-button type="danger" @click="removeItinerary(index)" class="delete-button">删除行程</el-button>
            </div>
          </el-form-item>
          <!-- 添加行程按钮 -->
          <el-form-item>
            <el-button type="primary" @click="addItinerary" class="add-button">添加行程</el-button>
          </el-form-item>

          <!-- 动态酒店信息 -->
          <el-form-item label="酒店信息">
            <div v-for="(hotel, index) in tourForm.hotels" :key="hotel.hotelId" class="custom-card">
              <el-select v-model="hotel.hotelId" placeholder="请选择酒店">
                <el-option
                  v-for="hotel in hotels"
                  :key="hotel.hotelId"
                  :label="hotel.hotelName + ' (' + hotel.hotelLocation + ')' + ': ' + hotel.hotelGrade"
                  :value="hotel.hotelId"
                />
              </el-select>
              <!-- 删除酒店按钮 -->
              <el-button type="danger" @click="removeHotel(index)" class="delete-button">删除酒店</el-button>
            </div>
          </el-form-item>
          <!-- 添加酒店按钮 -->
          <el-form-item>
            <el-button type="primary" @click="addHotel" class="add-button">添加酒店</el-button>
          </el-form-item>
        </el-form>
        <template v-slot:footer>
          <span class="dialog-footer">
            <el-button @click="tourDialogVisible = false">取消</el-button>
            <el-button v-if="isEditing" type="primary" @click="updateTour">更新</el-button>
            <el-button v-else type="primary" @click="addTour">添加</el-button>
          </span>
        </template>
      </el-dialog>
    </el-scrollbar>
  </div>
</template>

<style scoped>
.word {
  margin-left: 10px;
}

.search-button {
  margin-left: 20px;
  margin-right: 20px;
}

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

.dialog-footer {
  text-align: right;
}

.filter-button {
  margin-left: 20px;
}

.custom-card {
  border: 1px solid #e0e0e0;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 4px;
}
.delete-button {
  margin-top: 10px;
}

.add-button {
  margin-top: -10px;
  margin-left: 70px;
}
</style>
