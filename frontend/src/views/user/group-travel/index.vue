<script lang="ts" setup>
import { onMounted, ref } from 'vue'
import axios from "axios"
import { Search } from "@element-plus/icons-vue"
import { useRouter } from "vue-router"
import { ElButton, ElMessage } from 'element-plus'

// 接口
// 定义车票的接口
interface GoTicket {
  vehicleId: string
  ticketType: string
  ticketPrice: number
  ticketDepartureTime: string
  ticketArrivalTime: string
  ticketDepartureCity: string
  ticketArrivalCity: string
  ticketId: number
}

interface ReturnTicket {
  vehicleId: string
  ticketType: string
  ticketPrice: number
  ticketDepartureTime: string
  ticketArrivalTime: string
  ticketDepartureCity: string
  ticketArrivalCity: string
  ticketId: number
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
  groupId: number
  guideId: number
  startDate: string
  endDate: string
  groupName: string
  groupPrice: number
  goTicketId: number
  returnTicketId: number
  departure: string
  destination: string
  guideName: string
  goTicket?: GoTicket
  returnTicket?: ReturnTicket
  tourItineraries?: TourItinerary[]
  hotels?: Hotel[]
  imageUrl?: string
}

// 数据
const tourGroups = ref<TourGroup[]>([])
const router = useRouter()
const groupId_input=ref("")
const departure_input=ref("")
const destination_input=ref("")
const date_input=ref("")
const showEmptyMessage = ref(false)

// 旅游团与图片url的对应关系
const return2 = (str: string) => {
  return str.slice(0, 2);
};

const imageMap: Record<string, string> = {
  '上海': 'https://img.dahepiao.com/uploads/image/2020/12/17/56d9e3bc071de06c4de6f0fa2f8e7a84.jpg',
  '北京': 'https://img.zcool.cn/community/010e2d5de0f549a80120686b802e63.jpg@1280w_1l_2o_100sh.jpg',
  '南京': 'https://img.zcool.cn/community/01088d556841970000012b20ccfc1a.jpg@3000w_1l_2o_100sh.jpg',
  '成都': 'https://img.zcool.cn/community/01d9495b6dbc33a801215c8fe1df09.jpg@3000w_1l_0o_100sh.jpg',
  '武汉': 'https://th.bing.com/th/id/R.43107bcfc6d493fd0e41b86a47f8a125?rik=Gy0Juky%2b9G1B4g&riu=http%3a%2f%2fimg.pconline.com.cn%2fimages%2fupload%2fupc%2ftx%2fphotoblog%2f1410%2f26%2fc2%2f40147263_1414299382894_mthumb.jpg&ehk=Vqm38FQdH7T8bH%2fAlDVATSrxmDaeqAosJOIE31tqabQ%3d&risl=&pid=ImgRaw&r=0',
};

const cities = [
  { value: "上海", label: "上海" },
  { value: "北京", label: "北京" },
  { value: "南京", label: "南京" },
  { value: "武汉", label: "武汉" },
  { value: "成都", label: "成都" },
]

// 获取旅游团
const fetchTourGroups = () => {
  axios
    //.get("https://123.60.14.84/api/TourGroup/search/all")
    .get("https://123.60.14.84/api/TourGroup/recommendedtours")
    .then((response) => {
      const data = response.data
      console.log(data)
      if (Array.isArray(data)) {
        tourGroups.value = response.data.map((group: any) => ({
        ...group,
        imageUrl: group.imageUrl || imageMap[return2(group.groupName)]
        }));
        showEmptyMessage.value = false
      } else {
        console.error("Unexpected response format.")
        showEmptyMessage.value = true
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
      showEmptyMessage.value = true
    })
}

// 根据旅游团编号筛选
const fetchId = () => {
  departure_input.value = ""
  destination_input.value = ""
  date_input.value = ""
  const groupId = groupId_input.value
  axios
    .get(`https://123.60.14.84/api/TourGroup/search/id/${groupId}`)
    .then((response) => {
      const data = response.data
      console.log(data)
      if (data) {
        tourGroups.value = [{
          ...response.data,
          imageUrl: response.data.imageUrl || imageMap[return2(response.data.groupName)]
        }];
        console.log(tourGroups.value)
        showEmptyMessage.value = false
      } else {
        console.error("Unexpected response format.")
        showEmptyMessage.value = true
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
      showEmptyMessage.value = true
    })
}

// 筛选
const fetchFilter = () => {
  if (!departure_input.value || !destination_input.value) {
    ElMessage.info(`请输入出发地和目的地`)
    return
  }
  axios
    .get("https://123.60.14.84/api/TourGroup/search", {
      params: {
        Departure: departure_input.value,
        Destination: destination_input.value,
        Departure_Time: date_input.value,
      }
    })
    .then((response) => {
      const data = response.data
      if (Array.isArray(data)) {
        tourGroups.value = response.data.map((group: any) => ({
        ...group,
        imageUrl: group.imageUrl || imageMap[return2(group.groupName)]
        }));
        showEmptyMessage.value = false
      } else {
        console.error("Unexpected response format.")
        showEmptyMessage.value = true
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
      showEmptyMessage.value = true
    })
}

// 旅行团跳转
const goToGroup = (group: TourGroup) => {
  router.push({
    path: `/group-travel/groups/detail`,
    query: {
      groupId: group.groupId.toString(),
      guideId: group.guideId.toString(),
      startDate: group.startDate,
      endDate: group.endDate,
      groupName: group.groupName,
      groupPrice: group.groupPrice.toString(),
      departure: group.departure,
      destination: group.destination,
      guideName: group.guideName,
      goTicket:JSON.stringify(group.goTicket), 
      returnTicket:JSON.stringify(group.returnTicket), 
      tourItineraries: JSON.stringify(group.tourItineraries), 
      hotels: JSON.stringify(group.hotels),
      imageUrl: group.imageUrl
    }
  })
}

// 在组件挂载时调用API
onMounted(() => {
  fetchTourGroups()
})
</script>

<template>
<div>
  <div class="group-filter-container">
    <div class="first-row">
        <span class="word"> 旅行团编号 </span>
        <el-input
          v-model="groupId_input"
          style="width: 210px"
          placeholder="请输入旅行团编号"
          :prefix-icon="Search"
          @keyup.enter="fetchId"
        />

        <el-button type="primary" class="button" @click="fetchId" icon="Search"> 搜索 </el-button>
    </div>

    <div class="second-row" style="margin-top: 5px;">
      <span class="word">出发地 </span>
          <el-select
            v-model="departure_input"
            placeholder="请选择出发地"
            style="width: 210px"
          >
            <el-option v-for="item in cities" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>
      <span class="word"> 目的地 </span>
      <el-select
            v-model="destination_input"
            placeholder="请选择目的地"
            style="width: 210px"
          >
            <el-option v-for="item in cities" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>
      <!--
      <span class="word"> 行程天数 </span>
      <el-input
        v-model="duration_input"
        style="width: 200px"
        placeholder="请输入行程天数"
        :prefix-icon="Search"
         class="box"
      />
      -->

      <span class="word"> 启程时间 </span>
      <el-date-picker
        v-model="date_input"
        type="date"
        placeholder="请选择日期"
        size="default"
      />
  
      <el-button type="primary" class="button" @click="fetchFilter" icon="Search"> 筛选 </el-button>
    </div>
  </div>

  <div class="group-container">
  <div class="holder-container" v-if="tourGroups.length === 0 || showEmptyMessage">
      <el-empty description="暂无旅行团" />
  </div>
  <div v-else class="group-card" v-for="group in tourGroups" :key="group.groupId" @click="goToGroup(group)" >
    <div class="group-image">
      <img :src="group.imageUrl" alt="旅游团图片" />
    </div>
    <div class="group-info" >
      <p class="title" >{{ group.groupName }}</p>
      <p>旅行团编号： {{ group.groupId }}</p>
      <p>出发地：{{ group.departure }} - 目的地：{{ group.destination }}</p>
      <p>时间：{{ new Date(group.startDate).toLocaleDateString('zh-CN', { year: 'numeric', month: '2-digit', day: '2-digit' }) }} -- {{ new Date(group.endDate).toLocaleDateString('zh-CN', { year: 'numeric', month: '2-digit', day: '2-digit' }) }}</p>
      <p>导游：{{ group.guideName }}</p>
    </div>
    <div class="group-price">
      <p>{{ group.groupPrice }} 元起</p>
    </div>
  </div>
  </div>
</div>
</template>

<style lang="css">
.group-filter-container{
   margin-top: 10px;
   margin-left: 20px;
 }

.word,
.button {
  margin-left: 10px;
}

.group-container {
  margin-left: 40px;
  margin-top: 20px;
  margin-right: 40px;
  display: grid;
  grid-template-columns: repeat(3, 1fr); 
  gap: 20px; 
  justify-content: center;
  align-items: center;  
}

.group-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  background-color: white;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-width: 100%; 
  overflow: hidden;
}

.group-image img {
  width: 100%;
  height: 100%;
}

.title {
  font-size: 1.25em;
  font-weight: bold;
  color:#3498db;
}

.group-info, .group-price {
  padding: 5px;
}

.group-price {
  color:#3498db;
}

.group-price {
  font-size: 1.2em;
  font-weight: bold;
  color:#3498db;
  width: 100%;
  padding: 10px;
  background-color: #f8f8f8;
}

.holder-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 70vh;
  width: 100vw;
}

</style>