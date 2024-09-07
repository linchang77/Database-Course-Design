<script lang="ts" setup>
import { ref,onMounted, computed} from "vue"
import { useRoute,useRouter } from 'vue-router'
import axios from 'axios';

defineOptions({
  name: "Detail"
})
//定义酒店接口
interface Hotel {
  hotelId: number;
  hotelName: string;
  cityName: string;
  hotelGrade: string;
  hotelLocation: string;
  hotelIntroduction: string;
}
//定义酒店房间接口
interface HotelRoom{
  hotelId: number;
  roomType: string;
  roomLeft: number;
  roomPrice: number; 
}
//酒店星级和数字转换
const gradeToNumber = (grade: string): number => {
  const gradeMap: { [key: string]: number } = {
    "五星级": 5,
    "四星级": 4,
    "三星级": 3,
    "二星级": 2,
    "一星级": 1
  };
  return gradeMap[grade] || 0;
};


const route = useRoute()
const router = useRouter()
const hotels = ref<Hotel[]>([]);
const hotelRooms = ref<HotelRoom[]>([]);
const sortOrder = ref<'asc' | 'desc'>('asc');
const sortBy = ref<'grade' | 'price'>('grade');
const destination = decodeURIComponent(route.query.destination as string);

//接收相关参数
const checkInTime = route.query.checkInTime;
const checkOutTime = route.query.checkOutTime;

//匹配相关酒店
const fetchHotels = async (): Promise<Hotel[]> => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/Hotel/${encodeURIComponent(destination)}`);
    hotels.value = response.data
    return response.data;
  } catch (error) {
    console.error('Error fetching hotel data:', error);
    return [];
  }
};

//匹配相关酒店房间
const fetchHotelRooms = async (hotelId: number): Promise<HotelRoom[]> => {
  try {
    const response = await axios.get(`https://123.60.14.84/api/Hotel/${encodeURIComponent(hotelId)}/type`);
    hotelRooms.value = response.data
    return response.data; 
  } catch (error) {
    console.error(`Error fetching rooms for hotelId ${hotelId}:`, error);
    return [];
  }
}

//更新酒店信息
const updateHotel = async () => {
  try {
    const hotelsData = await fetchHotels();
    const allHotelRooms: HotelRoom[] = [];
    for (const hotel of hotelsData) {
      const rooms = await fetchHotelRooms(hotel.hotelId);
      allHotelRooms.push(...rooms); 
    }
    hotelRooms.value = allHotelRooms; 
  } catch (error) {
    console.error('Error updating hotels:', error);
  }
};


onMounted(() => {
  updateHotel();
});

//排序酒店
const sortedHotels = computed(() => {
  return hotels.value.slice().sort((a, b) => {
    let comparison = 0;
    //判断排序种类
    if (sortBy.value === 'price') {
      const priceA = hotelRooms.value.find(room => room.hotelId === a.hotelId)?.roomPrice ?? 0;
      const priceB = hotelRooms.value.find(room => room.hotelId === b.hotelId)?.roomPrice ?? 0;
      comparison = priceA - priceB;
    } else if (sortBy.value === 'grade'){
      const gradeA = gradeToNumber(a.hotelGrade);
      const gradeB = gradeToNumber(b.hotelGrade);
      comparison = gradeA - gradeB;
    }
    return sortOrder.value === 'asc' ? comparison : -comparison;
  });
});

//按等级排序逻辑
const toggleSortBygrade = () => {
  if (sortBy.value === 'grade') {
    sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc';
  } else {
    sortBy.value = 'grade';
    sortOrder.value = 'asc';
  }
};
//获得某酒店最低价格
const getLowestPriceForHotel = (hotelId: number): number => {
  const rooms = hotelRooms.value.filter(room => room.hotelId === hotelId);
  if (rooms.length === 0) return 0;
  return Math.min(...rooms.map(room => room.roomPrice));
};
//按价格排序逻辑
const toggleSortByPrice = () => {
  sortBy.value = 'price'; 
  sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc'; 
};
//传递参数
const viewDetails = (selectedHotelId: number) => {
  const filteredHotel = hotels.value.filter(hotel => hotel.hotelId === selectedHotelId);
  const filteredHotelRooms = hotelRooms.value.filter(room => room.hotelId === selectedHotelId);
  router.push({
    name: 'Room', 
    query: {
      hotel: encodeURIComponent(JSON.stringify(filteredHotel)),
      hotelRoom:encodeURIComponent(JSON.stringify(filteredHotelRooms)),
      checkInTime: checkInTime,
      checkOutTime: checkOutTime
    } 
  });

}

onMounted(() => {
  fetchHotels();
});
</script>

<template>
  <div class="app-container">
    <el-card header="酒店详情">
      <div class="index-container">
        <div class="sort-buttons">
          <button @click="toggleSortByPrice" class="sort-button">
            {{ sortBy === 'price' ? (sortOrder === 'asc' ? '按价格升序排序' : '按价格降序排序') : '按价格排序' }}
          </button>
          <button @click="toggleSortBygrade" class="sort-button">
            {{ sortBy === 'grade' ? (sortOrder === 'asc' ? '按星级升序排序' : '按星级降序排序') : '按星级排序' }}
          </button>
          </div>
        <div v-for="hotel in sortedHotels" :key="hotel.hotelName" class="hotel-card">
          <img :src="`/images/hotel_${(hotel.hotelId)%9}.jpg`" alt="Hotel Image" style="width: 100%; height: auto;"/>
          <div class="info-container">
            <div class="info-1">
              <h2>{{ hotel.hotelName }}</h2>
              <p>位置: {{ hotel.hotelLocation }}</p>
              <p>等级: {{ hotel.hotelGrade }}</p>
              <br>
              <p>介绍: {{ hotel.hotelIntroduction }}</p>
            </div>
            <div class="info-2">
              <p>价格: ¥{{ getLowestPriceForHotel(hotel.hotelId) }} 起</p>
              <button @click="viewDetails(hotel.hotelId)" class="view-details-button">查看详情</button>
            </div>
          </div>
        </div>
      </div>
    </el-card>
  </div>
</template>



<style scoped>
.index-container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.sort-buttons {
  display: flex;
  gap: 10px; 
}

.sort-button {
  padding: 10px;
  border: none;
  border-radius: 5px;
  background-color: #007BFF;
  color: white;
  cursor: pointer;
  font-size: 16px;
}

.sort-button:hover {
  background-color: #0056b3;
}

.hotel-card {
  margin: 10px;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  width: 100%;
  max-width: 600px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.hotel-card h2 {
  margin-top: 0;
  font-size: 1.5em;
}

.hotel-card p {
  margin: 5px 0;
}

.view-details-button {
  padding: 10px;
  border: none;
  border-radius: 5px;
  background-color: #28a745;
  color: white;
  cursor: pointer;
  font-size: 16px;
}

.view-details-button:hover {
  background-color: #218838;
}

.info-container {
  margin-top: 10px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.info-1 {
  flex: 1;
  margin: 0 20px;
}

.info-2 {
  text-align: right;
  margin: 0 40px;
}
</style>
