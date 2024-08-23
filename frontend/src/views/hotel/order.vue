<script lang="ts" setup>
import { ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const hotelQuery = route.query.hotel as string | undefined;

interface Hotel {
  name: string;
  rating: string;
  location: string;
  description: string;
  price: number;
}

const hotel = hotelQuery ? JSON.parse(hotelQuery) as Hotel : null;

// Form fields
const name = ref<string>('');
const phoneNumber = ref<string>('');

// Function to handle form submission
const handleSubmit = () => {
  // Save or process the user's input as needed
  console.log('Name:', name.value);
  console.log('Phone Number:', phoneNumber.value);

  // Here you might send this data to a backend server or local storage
  // Example: axios.post('/api/save-user-info', { name: name.value, phoneNumber: phoneNumber.value });
};
</script>

<template>
  <div class="app-container">
      <el-card header="酒店结算">
        <div class="hotel-detail" v-if="hotel">
            <h2>{{ hotel.name }}</h2>
            <p>等级: {{ hotel.rating }}</p>
            <p>位置: {{ hotel.location }}</p>
            <p>介绍: {{ hotel.description }}</p>
            <p>价格: ¥{{ hotel.price }}</p>
        </div>
        <div class="user-info">
            <h2>用户信息</h2>
            <form @submit.prevent="handleSubmit">
                <div class="form-group">
                    <label for="name">姓名:</label>
                    <input type="text" id="name" v-model="name" placeholder="请输入姓名" required />
                </div>
                <div class="form-group">
                    <label for="phone">手机号:</label>
                    <input type="tel" id="phone" v-model="phoneNumber" placeholder="请输入手机号" required />
                </div>
                <button type="submit">提交</button>
            </form>
        </div>
      </el-card>
    </div>
</template>

<style scoped>
.order-container {
  padding: 20px;
}

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

.user-info {
  margin-top: 20px;
  border: 1px solid #ddd;
  padding: 15px;
  border-radius: 5px;
  max-width: 600px;
  margin: 0 auto;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
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
</style>
