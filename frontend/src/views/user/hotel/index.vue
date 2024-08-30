<script lang="ts" setup>
import { ref, computed, onMounted } from 'vue';
import PlaceSelector from './components/PlaceSelector.vue';
import TimeSelector from './components/TimeSelector.vue';
import { useRouter } from 'vue-router';
import axios from 'axios';

interface Hotel {
  hotelId: number;
  hotelName: string;
  cityName: string;
  hotelGrade: string;
  hotelLocation: string;
  hotelIntroduction: string;
  imageUrl: string; // 确保接口包含 imageUrl 属性
}

const hotels = ref<Hotel[]>([]);
const cities = ref<Array<{ value: string; label: string }>>([]);

const destination = ref<string>('');
const checkInTime = ref<Date | undefined>(undefined);
const checkOutTime = ref<Date | undefined>(undefined);

const router = useRouter();

const setDestination = (val: any) => {
  destination.value = val[val.length - 1];
};

const setCheckInTime = (val: any) => {
  checkInTime.value = val;
};

const setCheckOutTime = (val: any) => {
  checkOutTime.value = val;
};

const fetchHotels = async (): Promise<Hotel[]> => {
  try {
    const response = await axios.get<Hotel[]>('https://123.60.14.84/api/Hotel/all');
    hotels.value = response.data;
    const uniqueCities = Array.from(new Set(response.data.map(hotel => hotel.cityName)));
    cities.value = uniqueCities.map(city => ({ value: city, label: city }));
    return response.data;
  } catch (error) {
    console.error('Error fetching hotel data:', error);
    return [];
  }
};


const searchTickets = () => {
  router.push({
    name: 'Detail',
    query: {
      destination: encodeURIComponent(destination.value),
      checkInTime: checkInTime.value?.getTime(),
      checkOutTime: checkOutTime.value?.getTime(),
    },
  });
};

const numberOfNights = computed(() => {
  if (checkInTime.value && checkOutTime.value) {
    const timeDifference = checkOutTime.value.getTime() - checkInTime.value.getTime();
    return timeDifference > 0 ? Math.ceil(timeDifference / (1000 * 60 * 60 * 24)) : 0;
  }
  return 0;
});

const isSearchDisabled = computed(() => {
  return !destination.value || !checkInTime.value || !checkOutTime.value;
});

onMounted(() => {
  fetchHotels();
});
</script>

<template>
  <div class="app-container">
    <el-carousel :interval="4000" type="card" height="200px">
      <el-carousel-item
        v-for="hotel in hotels"
        :key="hotel.hotelId"
        class="carousel-item"
      >
        <div class="image-container">
          <img :src="`/images/hotel_${(hotel.hotelId)%9}.jpg`" alt="Hotel Image" />
          <div class="name-container">{{ hotel.hotelName }}</div>
        </div>
      </el-carousel-item>
    </el-carousel>
    <el-card header="酒店查询" class="detail-container">
      <div class="index-container">
        <PlaceSelector :options="cities" @updateValue="setDestination">目的地</PlaceSelector>
        <TimeSelector @updateValue="setCheckInTime">请选择入住时间</TimeSelector>
        <div class="date-container" :style="{ visibility: numberOfNights > 0 ? 'visible' : 'hidden' }">入住{{ numberOfNights }}晚</div>
        <TimeSelector @updateValue="setCheckOutTime">请选择退房时间</TimeSelector>
        <el-button type="primary" size="large" icon="search" :disabled="isSearchDisabled" @click="searchTickets">搜索</el-button>
      </div>
    </el-card>
  </div>
</template>

<style scoped>
.index-container {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.index-container > * {
  margin: 0 5%;
}

.index-container .date-container {
  margin: 0;
}
.image-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
}

.el-carousel__item img {
  height: 100%;
  width: 80%;
  object-fit: cover;
}

.el-carousel__item h3 {
  color: #475669;
  opacity: 0.75;
  line-height: 200px;
  margin: 0;
  text-align: center;
}

.name-container{
  margin: 0 30px;
  font-weight: bold;
  font-size: 18px;
  white-space: nowrap;
}
.detail-container{
  margin-top: 70px;
}

.el-carousel__item:nth-child(2n) {
  background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
  background-color: #d3dce6;
}
</style>
