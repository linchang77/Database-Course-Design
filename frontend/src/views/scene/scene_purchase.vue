<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "Scene"
})

const scene = ref({
  name: "上海迪士尼乐园",
  description:
    "上海迪士尼乐园是中国大陆首座迪士尼主题乐园，拥有多个主题区域，是一个集游乐、娱乐、购物、餐饮为一体的旅游目的地。",
  imageUrl: new URL("@/views/scene/scene4.jpg", import.meta.url).href,
  ticketPrice: 399,
  ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
})

const selectedDate = ref("")
const ticketQuantity = ref(1)

const buyTicket = () => {
  const url = `${scene.value.ticketLink}?date=${selectedDate.value}&quantity=${ticketQuantity.value}`
  window.open(url, "_blank")
}
</script>

<template>
  <div class="scene-container">
    <h1>{{ scene.name }}</h1>
    <img :src="scene.imageUrl" alt="Image of {{ scene.name }}" class="scene-image" />
    <p class="scene-description">{{ scene.description }}</p>

    <div class="ticket-section">
      <h2>购票信息</h2>
      <p class="ticket-price">票价：￥{{ scene.ticketPrice }} / 每张</p>

      <label for="date">选择日期:</label>
      <input type="date" id="date" v-model="selectedDate" class="date-input" />

      <label for="quantity">选择票数:</label>
      <input type="number" id="quantity" v-model="ticketQuantity" min="1" class="quantity-input" />

      <button @click="buyTicket" class="buy-ticket-button">购票</button>
    </div>
  </div>
</template>

<style scoped>
.scene-container {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

.scene-image {
  width: 100%;
  height: auto;
  border-radius: 10px;
  margin-bottom: 20px;
}

.scene-description {
  font-size: 16px;
  color: #555;
  margin-bottom: 20px;
}

.ticket-section {
  margin-top: 30px;
  text-align: left;
}

.ticket-price {
  font-size: 18px;
  color: #333;
  margin-bottom: 10px;
}

.date-input,
.quantity-input {
  width: 100%;
  padding: 8px;
  margin-top: 10px;
  margin-bottom: 20px;
  border-radius: 5px;
  border: 1px solid #ccc;
  font-size: 16px;
}

.buy-ticket-button {
  background-color: #ff9900;
  color: #fff;
  border: none;
  padding: 10px 20px;
  font-size: 16px;
  cursor: pointer;
  border-radius: 5px;
  transition: background-color 0.3s ease;
  width: 100%;
}

.buy-ticket-button:hover {
  background-color: #e68a00;
}
</style>
