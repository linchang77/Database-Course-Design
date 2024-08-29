<script lang="ts" setup>
import { ref, computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

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
const selectedNumber = ref(0);

const checkInTime = computed(() => {
  return route.query.checkInTime ? new Date(parseInt(route.query.checkInTime as string)).toISOString() : null;
});
const checkOutTime = computed(() => {
  return route.query.checkOutTime ? new Date(parseInt(route.query.checkOutTime as string)).toISOString() : null;
});

const selectedHotelId = route.query.orderHotelId
const selectedRoomType = route.query.orderRoomType

const hotel = ref<Hotel[]>([]);
const hotelRooms = ref<HotelRoom[]>([]);

const isSubmitDisabled = computed(() => selectedNumber.value === 0);

const handleSubmit = async() => {
  for (let i = 0; i < selectedNumber.value; i++) {
    try {
      const response = await axios.post(`https://123.60.14.84/api/Hotel/create`, {
        userId: Number(localStorage.getItem("id")),
        hotelId: Number(selectedHotelId),
        checkInDate: checkInTime.value,
        checkOutDate: checkOutTime.value,
        roomType: selectedRoomType,
      })
      alert("购买成功!")
      console.log("Purchase successful:", response.data)
    } catch (error) {
      alert("购买失败，请再尝试")
      console.error("Failed to complete purchase:", error)
    }
  }
};

onMounted(() => {
  const hotelQuery = route.query.hotel as string;
  const hotelRoomsQuery = route.query.hotelRoom as string;

  hotel.value = JSON.parse(decodeURIComponent(hotelQuery));
  hotelRooms.value = JSON.parse(decodeURIComponent(hotelRoomsQuery));

  console.log("hotel", hotel.value)
  console.log("room",hotelRooms.value)
});
</script>

<template>
  <div class="app-container">
    <el-card header="酒店订单">
      <div class="hotel-container" >
        <h2>订单详情</h2>
        <div v-for="hotel in hotel">
          <div class="info-container" v-for="room in hotelRooms">
            <div class="info-1" >
              <p>酒店名称: {{ hotel.hotelName }}</p>
              <p>酒店地址: {{ hotel.hotelLocation }}</p>
              <div>
                <p>房型: {{ room.roomType }}</p>
                <p>价格: ¥{{ room.roomPrice }} /间</p>
              </div>
            </div>
            <div class="info-2">
              <div class="quantity-selector">
                <el-input-number 
                  v-model="selectedNumber" 
                  :min="0" 
                  :max="room.roomLeft" 
                />
              </div>
              <p>订单总价格: ¥{{ room.roomPrice * selectedNumber }}</p>
              <button 
              :disabled="isSubmitDisabled"
              @click="handleSubmit"
              >
              提交订单
              </button>
            </div>
          </div>
        </div>
      </div>
    </el-card>
  </div>
</template>

<style scoped>
.hotel-container{
  border: 1px solid #ddd;
  padding: 15px;
  border-radius: 5px;
  max-width: 600px;
  margin: 0 auto;
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
  text-align: center;
}


input {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
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

.quantity-selector input {
  width: 80px;
  margin-right: 10px;
}
</style>