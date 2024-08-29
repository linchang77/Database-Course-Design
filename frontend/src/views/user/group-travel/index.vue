<script lang="ts" setup>
import { onMounted, ref } from 'vue'
import axios from "axios";
import { Search } from "@element-plus/icons-vue"
import { useRouter } from "vue-router"

// 定义行程的接口
interface TourItinerary {
  itineraryId: number;
  itineraryTime: string;
  itineraryDuration: string;
  activities: string;
  scenicSpotId: number | null;
}

// 定义酒店接口
interface Hotel {
  hotelId: number;
  hotelName: string;
  cityName: string;
  hotelGrade: string;
  hotelLocation: string;
  hotelIntroduction: string;
}

// 定义旅游团的接口
interface TourGroup {
  groupId: string;
  groupName: string;
  groupPrice: number;
  startDate: string;
  endDate: string;
  guideName: string;
  imageUrl: string;
  tourItineraries: TourItinerary[];
  hotels: Hotel[];
}

// 定义存储数据的变量
const tourGroups = ref<TourGroup[]>([]);
// 定义路由
const router = useRouter()

// 旅游团与图片url的对应关系
const imageMap: Record<number, string> = {
  1: 'https://img.dahepiao.com/uploads/image/2020/12/17/56d9e3bc071de06c4de6f0fa2f8e7a84.jpg',
  22: 'https://th.bing.com/th/id/R.6f45552a07ce3691540b97b4be845785?rik=XOX7sQNnRUYI1A&riu=http%3a%2f%2fimgbdb3.bendibao.com%2fcsbdb%2fjieri%2f20214%2f29%2f2021429101819_16270.jpg&ehk=n2DNPUTw2bA4t4i9mvG9nFskomvtIPyYiFKgwBpp9ic%3d&risl=&pid=ImgRaw&r=0',
  23: 'https://img.zcool.cn/community/01088d556841970000012b20ccfc1a.jpg@3000w_1l_2o_100sh.jpg',
  // 添加更多的映射
};

const cities = [
  { value: "上海", label: "上海" },
  { value: "北京", label: "北京" },
  { value: "天津", label: "天津" },
  { value: "广州", label: "广州" },
]

// 获取推荐旅游团
const fetchTourGroups = () => {
  axios
    .get("https://123.60.14.84:10000/api/TourGroup/recommendedtours")
    .then((response) => {
      const data = response.data;
      if (Array.isArray(data)) {
        tourGroups.value = data.map((group: any) => ({
          groupId: group.groupId,
          groupName: group.groupName,
          groupPrice: group.groupPrice,
          startDate: group.startDate,
          endDate: group.endDate,
          guideName: group.guideName,
          imageUrl: imageMap[group.groupId],
          tourItineraries: group.tourItineraries.map((itinerary: any) => ({
            itineraryId: itinerary.itineraryId,
            itineraryTime: itinerary.itineraryTime,
            itineraryDuration: itinerary.itineraryDuration,
            activities: itinerary.activities,
            scenicSpotId: itinerary.scenicSpotId
          })),
          hotels: group.hotels.map((hotel: any) => ({
            hotelId: hotel.hotelId,
            hotelName: hotel.hotelName,
            cityName: hotel.cityName,
            hotelGrade: hotel.hotelGrade,
            hotelLocation: hotel.hotelLocation,
            hotelIntroduction: hotel.hotelIntroduction
          }))
        }));
      } else {
        console.error("Unexpected response format.");
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error);
    });
};

// 筛选 还没写！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
const fetchFilter = () => {
  axios
    .get("https://123.60.14.84:10000/api/TourGroup/search", {
      params: {
        Departure: "北京",
        Destination: "上海"
      }
    })
    .then((response) => {
      console.log("API Response:", response.data);
      const data = response.data;
      // 确保数据是数组，并将其存储到 tourGroups 中
      if (Array.isArray(data)) {
        tourGroups.value = data.map((group: any) => ({
          groupId: group.groupId,
          groupName: group.groupName,
          groupPrice: group.groupPrice,
          startDate: group.startDate,
          endDate: group.endDate,
          guideName: group.guideName,
          imageUrl: imageMap[group.groupId],
          tourItineraries: group.tourItineraries.map((itinerary: any) => ({
            itineraryId: itinerary.itineraryId,
            itineraryTime: itinerary.itineraryTime,
            itineraryDuration: itinerary.itineraryDuration,
            activities: itinerary.activities,
            scenicSpotId: itinerary.scenicSpotId
          })),
          hotels: group.hotels.map((hotel: any) => ({
            hotelId: hotel.hotelId,
            hotelName: hotel.hotelName,
            cityName: hotel.cityName,
            hotelGrade: hotel.hotelGrade,
            hotelLocation: hotel.hotelLocation,
            hotelIntroduction: hotel.hotelIntroduction
          }))
        }));
      } else {
        console.error("Unexpected response format.");
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error);
    });
};

const goToGroup = (group: TourGroup) => {
  router.push({
    path: `/group-travel/groups/detail`,
    query: {
      groupId: group.groupId.toString(),
      groupName: group.groupName,
      groupPrice: group.groupPrice.toString(),
      startDate: group.startDate,
      endDate: group.endDate,
      guideName: group.guideName,
      imageUrl: group.imageUrl,
      tourItineraries: JSON.stringify(group.tourItineraries), 
      hotels: JSON.stringify(group.hotels)
    }
  });
};


// 在组件挂载时调用API
onMounted(() => {
  fetchTourGroups();
});

// 筛选的双向绑定
const departure_input=ref("")
const destination_input=ref("")
const duration_input=ref("")
const date_input=ref("")

</script>

<template>
<div>
  <div class="group-filter-container">
    <div>
      <span class="word">出发地 </span>
          <el-select
            v-model="departure_input"
            placeholder="请选择出发地"
            style="width: 200px"
          >
            <el-option v-for="item in cities" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>
      <span class="word"> 目的地 </span>
      <el-select
            v-model="destination_input"
            placeholder="请选择目的地"
            style="width: 200px"
          >
            <el-option v-for="item in cities" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

      <span class="word"> 行程天数 </span>
      <el-input
        v-model="duration_input"
        style="width: 200px"
        placeholder="请输入行程天数"
        :prefix-icon="Search"
         class="box"
      />

      <span class="word"> 启程时间 </span>
      <el-date-picker
        v-model="date_input"
        type="daterange"
        range-separator="To"
        start-placeholder="最早时间"
        end-placeholder="最晚时间"
        size="default"
      />
  
      <el-button type="primary" class="button"> 筛选 </el-button>
    </div>
  </div>

  <div class="group-container">
  <div class="group-card" v-for="group in tourGroups" :key="group.groupId" @click="goToGroup(group)" >
    <div class="group-image">
      <img :src="group.imageUrl" alt="旅游团图片" />

    </div>
    <div class="group-info" >
      <p class="title" >{{ group.groupName }}</p>
      <p>启程时间：{{ new Date(group.startDate).toLocaleDateString('zh-CN', { year: 'numeric', month: '2-digit', day: '2-digit' }) }}</p>
      <p>返程时间：{{ new Date(group.endDate).toLocaleDateString('zh-CN', { year: 'numeric', month: '2-digit', day: '2-digit' }) }}</p>
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
  display: flex;
  gap: 20px; 
}

.group-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  width: 30%; 
  background-color: white;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
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


</style>