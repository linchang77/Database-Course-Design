<script lang="ts" setup>
import { ref,onMounted, computed} from "vue"
import { useRoute,useRouter } from 'vue-router'
import axios from 'axios';

defineOptions({
  name: "Detail"
})

interface Hotel {
  id: number;
  name: string;
  grade: string;
  location: string;
  description: string;
  roomType: string;
  roomLeft: number;
  roomPrice: number;
  imageUrl: string; 
}

const gradeToNumber = (grade: string): number => {
  const gradeMap: { [key: string]: number } = {
    "5星": 5,
    "4星": 4,
    "3星": 3,
    "2星": 2,
    "1星": 1
  };
  return gradeMap[grade] || 0;
};


const route = useRoute()
const router = useRouter()
const hotels = ref<Hotel[]>([]);
const sortOrder = ref<'asc' | 'desc'>('asc');
const sortBy = ref<'grade' | 'price'>('grade');


const destination = decodeURIComponent(route.query.destination as string);
const checkInTime = decodeURIComponent(route.query.checkIn as string);
const checkOutTime = decodeURIComponent(route.query.checkOut as string);


const fetchHotels = async () => {
  try {
    console.log("111111")
    const hotelId = 10
    const response = await axios.get(`https://123.60.14.84/api/Hotel/detail/${hotelId}`,{
      // params:{
      //   city: "上海",
      // }
    });
    console.log(response.data)
    //hotels.value = response.data;

  } catch (error) {
    console.log("22222")
    console.error('Error fetching hotel data:', error);
    console.log(destination)
  }
};

onMounted(() => {
  fetchHotels();
});

// const fetchHotels = async () => {
//   const simulatedHotels: Hotel[] = [
//     {
//       id: 1,
//       name: "Hotel A",
//       grade: "5星",
//       location: "北京市",
//       description: "一家豪华酒店，提供高品质的服务和舒适的住宿体验。",
//       roomType: "标间",
//       roomLeft: 3,
//       roomPrice: 600,
//       imageUrl: "/images/hotel_1.jpg"
//     },
//     {
//       id: 3,
//       name: "Hotel B",
//       grade: "4星",
//       location: "上海市",
//       description: "一家现代化酒店，位置优越，设施齐全。",
//       roomType: "大床房",
//       roomLeft: 1,
//       roomPrice: 800,
//       imageUrl: "/images/hotel_2.jpg"
//     },
//     {
//       id: 18,
//       name: "Hotel C",
//       grade: "3星",
//       location: "广州市",
//       description: "经济型酒店，提供基础的住宿设施。",
//       roomType: "总统套房",
//       roomLeft: 9,
//       roomPrice: 100,
//       imageUrl: "/images/hotel_3.jpg"
//     },
//   ];
  
//   hotels.value = simulatedHotels;
// };

const sortedHotels = computed(() => {
  return hotels.value.slice().sort((a, b) => {
    let comparison = 0;
    if (sortBy.value === 'grade') {
      const gradeA = gradeToNumber(a.grade);
      const gradeB = gradeToNumber(b.grade);
      comparison = gradeA - gradeB;
    } else if (sortBy.value === 'price') {
      comparison = a.roomPrice - b.roomPrice;
    }
    return sortOrder.value === 'asc' ? comparison : -comparison;
  });
});

const toggleSortBygrade = () => {
  if (sortBy.value === 'grade') {
    sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc';
  } else {
    sortBy.value = 'grade';
    sortOrder.value = 'asc';
  }
};


const toggleSortByPrice = () => {
  if (sortBy.value === 'price') {
    sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc';
  } else {
    sortBy.value = 'price';
    sortOrder.value = 'asc';
  }
};

const viewDetails = (hotel: Hotel) => {
    router.push({
         name: 'Room', 
         query: {
             hotel: encodeURIComponent(JSON.stringify(hotel))
        } 
    });
    console.log(hotel)
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
            <button @click="toggleSortBygrade" class="sort-button">
              {{ sortBy === 'grade' ? (sortOrder === 'asc' ? '按星级升序排序' : '按星级降序排序') : '按星级排序' }}
            </button>
            <button @click="toggleSortByPrice" class="sort-button">
              {{ sortBy === 'price' ? (sortOrder === 'asc' ? '按价格升序排序' : '按价格降序排序') : '按价格排序' }}
            </button>
          </div>
          <div v-for="hotel in sortedHotels" :key="hotel.name" class="hotel-card">
            <img :src="hotel.imageUrl" alt="Hotel Image" style="width: 100%; height: auto;"/>
            <div class="info-container">
              <div class="info-1">
                <h2>{{ hotel.name }}</h2>
                <p>介绍: {{ hotel.description }}</p>
                <p>位置: {{ hotel.location }}</p>
                <p>等级: {{ hotel.grade }}</p>
              </div>
              <div class="info-2">
                <p>价格: ¥{{ hotel.roomPrice }} 起</p>
                <button @click="viewDetails(hotel)" class="view-details-button">查看详情</button>
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
  gap: 10px; /* Adjust space between buttons as needed */
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
}

.info-2 {
  text-align: right;
}
</style>
