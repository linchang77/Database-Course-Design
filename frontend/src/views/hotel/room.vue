<script lang="ts" setup>
import { ref, computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();
const hotelQuery = route.query.hotel as string;

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

const hotel = JSON.parse(decodeURIComponent(hotelQuery)) as Hotel;

function viewOrder() {
  if (hotel) {
    router.push({
       name: 'Order', 
       query: { hotel: encodeURIComponent(JSON.stringify(hotel)) } 
      }
    );
  }
}

</script>

<template>
  <div class="app-container">
    <el-card header="酒店房间">
      <div class="hotel-detail" v-if="hotel">
        <img :src="hotel.imageUrl" alt="Hotel Image" style="width: 100%; height: auto;"/>
        <h2>{{ hotel.name }}</h2>
        <p>等级: {{ hotel.grade }}</p>
        <p>位置: {{ hotel.location }}</p>
        <p>介绍: {{ hotel.description }}</p>
      </div>
      <div class="hotel-detail" v-if="hotel">
        <div class="info-container">
          <div class="info-1">
            <p>房型: {{ hotel.roomType }}</p> 
            <p>剩余房间: {{ hotel.roomLeft }} 间</p> 
          </div>
          <div class="info-2">
            <p>价格: ¥{{ hotel.roomPrice }} /间</p>
            <button @click="viewOrder">查看详情</button>
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