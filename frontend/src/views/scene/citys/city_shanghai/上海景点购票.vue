<script lang="ts" setup>
import axios from "axios"
import { ref, onMounted } from "vue"
import { useRoute } from "vue-router"

defineOptions({
  name: "Tickets"
})

const route = useRoute()
const scene = ref({
  name: "",
  description: "",
  imageUrl: "",
  ticketPrice: 0,
  ticketLink: ""
})

const selectedDate = ref("")
const ticketQuantity = ref(1)
const ticketType = ref("成人票") // 添加票类型的状态
const adultTicketPrice = ref<number>(0)
const adultTicketRemaining = ref<number>(0)
const childTicketPrice = ref<number>(0)
const childTicketRemaining = ref<number>(0)

const fetchTicketInfo = async (spotName: string) => {
  try {
    const response = await axios.get(
      `https://123.60.14.84/api/ScenicSpot/ticket/${encodeURIComponent(spotName)}/date/2024-8-19`
    )

    // 提取成人票信息
    const adultTicket = response.data.adultTicket
    adultTicketPrice.value = adultTicket.ticketPrice
    adultTicketRemaining.value = adultTicket.ticketRemaining

    // 提取儿童票信息
    const childTicket = response.data.childTicket
    childTicketPrice.value = childTicket.ticketPrice
    childTicketRemaining.value = childTicket.ticketRemaining
  } catch (error) {
    console.error("Failed to fetch ticket information:", error)
  }
}

const buyTicket = async () => {
  const url = `https://123.60.14.84/api/ScenicSpot/ticket/${encodeURIComponent(scene.value.name)}/date/${selectedDate.value}/purchase/type/${encodeURIComponent(ticketType.value)}/quantity/${ticketQuantity.value}`

  try {
    // 发送POST请求进行购票
    const response = await axios.post(url, {
      orderDate: selectedDate.value,
      userId: localStorage.getItem("id"), // 这里的userId需要根据具体用户登录信息动态设置
      status: "pending", // 初始状态，可能是待付款或待确认
      price: scene.value.ticketPrice * ticketQuantity.value
    })
    alert("购票成功!")
    console.log("Purchase successful:", response.data)
  } catch (error) {
    alert("购票失败，请再尝试")
    console.error("Failed to complete purchase:", error)
  }
}

onMounted(async () => {
  const spotName = route.query.name as string
  const spotIntroduction = route.query.introduction as string
  await fetchTicketInfo(spotName)

  const ticketPrice = adultTicketPrice.value

  scene.value = {
    name: spotName,
    description: spotIntroduction,
    imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
    ticketPrice: ticketPrice,
    ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
  }
})
</script>

<template>
  <div class="scene-container">
    <h1>{{ scene.name }}</h1>
    <img :src="scene.imageUrl" alt="Image of {{ scene.name }}" class="scene-image" />
    <p class="scene-description">{{ scene.description }}</p>

    <div class="ticket-section">
      <h2>购票信息</h2>

      <div class="ticket-prices">
        <p class="ticket-price">成人票价：￥{{ adultTicketPrice }} / 每张</p>
        <p class="ticket-price">儿童票价：￥{{ childTicketPrice }} / 每张</p>
      </div>

      <label for="type">选择票类型:</label>
      <select id="type" v-model="ticketType" class="type-select">
        <option value="成人票">成人票</option>
        <option value="儿童票">儿童票</option>
      </select>

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

.ticket-prices {
  display: flex;
  justify-content: space-between;
  margin-bottom: 20px;
}

.ticket-price {
  font-size: 18px;
  color: #333;
}

.type-select,
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
