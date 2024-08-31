<script lang="ts" setup>
import { ref, computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

interface Hotel {
  hotelId: number;
  hotelName: string;
  cityName: string;
  hotelGrade: string;
  hotelLocation: string;
  hotelIntroduction: string;
}

interface HotelRoom{
  hotelId: number;
  roomType: string;
  roomLeft: number;
  roomPrice: number; 
}

const route = useRoute();
const router = useRouter();

const checkInTime = route.query.checkInTime;
const checkOutTime = route.query.checkOutTime;

const hotel = ref<Hotel[]>([]);
const hotelRooms = ref<HotelRoom[]>([]);


const viewOrder = (selectedRoomType: string, selectedHotelId: number) => {
  const filteredHotelRoom = hotelRooms.value.filter(room => room.roomType === selectedRoomType);
  router.push({
    name: 'Order', 
    query: {
      hotel: encodeURIComponent(JSON.stringify(hotel.value)),
      hotelRoom:encodeURIComponent(JSON.stringify(filteredHotelRoom)),
      orderHotelId: selectedHotelId,
      orderRoomType: selectedRoomType,
      checkInTime: checkInTime,
      checkOutTime: checkOutTime
    } 
  });
}

onMounted(() => {
  const hotelQuery = route.query.hotel as string;
  const hotelRoomsQuery = route.query.hotelRoom as string;

  hotel.value = JSON.parse(decodeURIComponent(hotelQuery));
  hotelRooms.value = JSON.parse(decodeURIComponent(hotelRoomsQuery));
})

</script>

<template>
  <div class="app-container">
    <el-card header="酒店房间" v-for="hotel in hotel">
      <div class="hotel-detail">
        <img :src="`/images/hotel_${(hotel.hotelId)%9}.jpg`" alt="Hotel Image" style="width: 100%; height: auto;"/>
        <h2>{{ hotel.hotelName }}</h2>
        <p>介绍: {{ hotel.hotelIntroduction }}</p>
        <br>
        <p>等级: {{ hotel.hotelGrade }}</p>
        <p>位置: {{ hotel.hotelLocation }}</p>
      </div>
      <div class="hotel-detail" v-for="room in hotelRooms ">
        <div class="info-container">
          <div class="info-1">
            <h3>{{ room.roomType }}</h3> 
            <p>剩余房间: {{ room.roomLeft }} 间</p> 
          </div>
          <div class="info-2">
            <p>价格: ¥{{ room.roomPrice }} /间</p>
            <button @click="viewOrder(room.roomType,hotel.hotelId)">查看详情</button>
          </div>
        </div>
      </div>
    </el-card>
  </div>
</template>

<style scoped>

.hotel-detail {
  border: 1px solid #ddd;
  padding: 15px;
  border-radius: 5px;
  max-width: 600px;
  margin: 0 auto;
}

.hotel-detail h2 {
  margin-top: 0;
  font-size: 2em;
}

.hotel-detail p {
  margin: 10px 0;
}

button {
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  background-color: #28a745;
  color: white;
  cursor: pointer;
}

button:hover {
  background-color: #218838;
}

button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
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