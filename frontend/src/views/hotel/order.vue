<script lang="ts" setup>
import { ref, computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const selectedNumber = ref(0);

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

const hotel = ref<Hotel | null>(null);

const isSubmitDisabled = computed(() => selectedNumber.value === 0);

const handleSubmit = () => {
  // axios.post('/api/save-user-info', { name: name.value, phoneNumber: phoneNumber.value });
};

onMounted(() => {
  const hotelQuery = route.query.hotel as string | undefined;
  if (hotelQuery) {
    hotel.value = JSON.parse(decodeURIComponent(hotelQuery)) as Hotel;
  }
});
</script>

<template>
  <div class="app-container">
    <el-card header="酒店订单">
      <div class="hotel-container" v-if="hotel">
        <h2>订单详情</h2>
        <div class="info-container">
          <div class="info-1">
            <p>酒店名称: {{ hotel.name }}</p>
            <p>酒店地址: {{ hotel.location }}</p>
            <p>房型: {{ hotel.roomType }}</p>
            <p>价格: ¥{{ hotel.roomPrice }} /间</p>
          </div>
          <div class="info-2">
            <div class="quantity-selector">
              <el-input-number 
                v-model="selectedNumber" 
                :min="0" 
                :max="hotel.roomLeft" 
              />
            </div>
            <p>订单总价格: ¥{{ hotel.roomPrice * selectedNumber }}</p>
            <button 
            :disabled="isSubmitDisabled"
            @click="handleSubmit"
          >
            提交订单
          </button>
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