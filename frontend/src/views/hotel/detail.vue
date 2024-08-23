<script lang="ts" setup>
import { ref,onMounted, computed} from "vue"
import { useRoute,useRouter } from 'vue-router'
import axios from 'axios';

defineOptions({
  name: "Detail"
})

interface Hotel {
  name: string;
  rating: string;
  location: string;
  description: string;
  price: number; 
}

const ratingToNumber = (rating: string): number => {
  const ratingMap: { [key: string]: number } = {
    "5星": 5,
    "4星": 4,
    "3星": 3,
    "2星": 2,
    "1星": 1
  };
  return ratingMap[rating] || 0;
};

const destination = ref<string | null>(null);
const checkInTime = ref<string | null>(null);
const checkOutTime = ref<string | null>(null);
const route = useRoute()
const router = useRouter()
const hotels = ref<Hotel[]>([]);
const sortOrder = ref<'asc' | 'desc'>('asc');
const sortBy = ref<'rating' | 'price'>('rating');

destination.value = route.query.destination as string | null;
checkInTime.value = route.query.checkIn as string | null;
checkOutTime.value = route.query.checkOut as string | null;

console.log('Destination:', destination.value);
console.log('Check In Date:', checkInTime.value);
console.log('Check Out Date:', checkOutTime.value);



// const fetchHotels = async () => {
//   try {
//     const response = await axios.get('/api/hotels', {
//       params: {
//         destination: destination.value,
//         checkIn: checkInTime.value,
//         checkOut: checkOutTime.value
//       }
//     });
//     hotels.value = response.data;
//   } catch (error) {
//     console.error('Error fetching hotel data:', error);
//   }
// };

// onMounted(() => {
//   fetchHotels();
// });
const fetchHotels = async () => {
  const simulatedHotels: Hotel[] = [
    {
      name: "Hotel A",
      rating: "5星",
      location: "北京市",
      description: "一家豪华酒店，提供高品质的服务和舒适的住宿体验。",
      price: 200,
    },
    {
      name: "Hotel B",
      rating: "4星",
      location: "上海市",
      description: "一家现代化酒店，位置优越，设施齐全。",
      price: 600,
    },
    {
      name: "Hotel C",
      rating: "3星",
      location: "广州市",
      description: "经济型酒店，提供基础的住宿设施。",
      price: 1000,
    },
  ];
  
  hotels.value = simulatedHotels;
};

const sortedHotels = computed(() => {
  return hotels.value.slice().sort((a, b) => {
    let comparison = 0;
    if (sortBy.value === 'rating') {
      const ratingA = ratingToNumber(a.rating);
      const ratingB = ratingToNumber(b.rating);
      comparison = ratingA - ratingB;
    } else if (sortBy.value === 'price') {
      comparison = a.price - b.price;
    }
    return sortOrder.value === 'asc' ? comparison : -comparison;
  });
});

const toggleSortByRating = () => {
  if (sortBy.value === 'rating') {
    sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc';
  } else {
    sortBy.value = 'rating';
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
         name: 'Order', 
         query: {
             hotel: JSON.stringify(hotel) 
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
            <button @click="toggleSortByRating" class="sort-button">
              {{ sortBy === 'rating' ? (sortOrder === 'asc' ? '按星级升序排序' : '按星级降序排序') : '按星级排序' }}
            </button>
            <button @click="toggleSortByPrice" class="sort-button">
              {{ sortBy === 'price' ? (sortOrder === 'asc' ? '按价格升序排序' : '按价格降序排序') : '按价格排序' }}
            </button>
          </div>
          <div v-for="hotel in sortedHotels" :key="hotel.name" class="hotel-card">
            <h2>{{ hotel.name }}</h2>
            <p>等级: {{ hotel.rating }}</p>
            <p>位置: {{ hotel.location }}</p>
            <p>介绍: {{ hotel.description }}</p>
            <p>价格: ¥{{ hotel.price }}</p>
            <button @click="viewDetails(hotel)" class="view-details-button">查看详情</button>
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
  margin-top: 10px;
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
</style>
