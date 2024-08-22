<script lang="ts" setup>
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

const buyTicket = () => {
  const url = `${scene.value.ticketLink}?date=${selectedDate.value}&quantity=${ticketQuantity.value}`
  window.open(url, "_blank")
}

onMounted(() => {
  const spotName = route.query.name as string

  switch (spotName) {
    case "上海迪士尼":
      scene.value = {
        name: "上海迪士尼乐园",
        description:
          "上海迪士尼乐园是中国大陆首座迪士尼主题乐园，拥有多个主题区域，是一个集游乐、娱乐、购物、餐饮为一体的旅游目的地。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 399,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
    case "东方明珠":
      scene.value = {
        name: "东方明珠",
        description:
          "东方明珠电视塔是上海著名的地标建筑，位于浦东新区陆家嘴。它以其独特的设计和现代化的外观吸引了大量游客。东方明珠塔的塔高468米，是中国最早的一批超高层建筑之一。塔内设有多个观光层，提供360度的全景视野，俯瞰上海的壮丽景色。此外，塔内还有餐厅、历史陈列馆等设施，是一个集观光、餐饮、娱乐于一体的多功能旅游景点。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 299,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
    case "海昌海洋公园":
      scene.value = {
        name: "海昌海洋公园",
        description:
          "海昌海洋公园位于上海，是中国最大的海洋主题公园之一。公园集海洋动物展示、互动体验、娱乐表演于一体，拥有多个主题区域，如极地探险区、海洋奇遇区和热带雨林区。游客可以在这里观赏到各种海洋生物，如海豚、鲨鱼、企鹅等，并参与到丰富多彩的水上娱乐项目中。此外，公园还定期举办海洋动物表演和科普教育活动，是亲子游和家庭度假的理想选择。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 199,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
    case "东滩湿地公园":
      scene.value = {
        name: "东滩湿地公园",
        description:
          "东滩湿地公园位于上海市崇明岛的东部，是中国重要的生态保护区之一，也是候鸟的重要栖息地。公园总面积达24.2平方公里，拥有广阔的湿地、滩涂和草地，丰富的自然景观吸引了众多生态旅游爱好者和鸟类观察者。每年，成千上万的候鸟在迁徙途中停留在这里，公园也因此成为观鸟的热门地点。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 99,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
    case "豫园":
      scene.value = {
        name: "豫园",
        description:
          "豫园位于上海市黄浦区，是中国江南著名的古典园林，建于明朝嘉靖年间。豫园以其精致的园林设计、独特的建筑风格和丰富的文化底蕴吸引了大量游客。园内亭台楼阁、假山流水、古树名木相映成趣，处处展现出中国传统园林的巧妙布局和自然美景。豫园不仅是一个休闲游览的好去处，也是体验上海历史和文化的重要场所。周边的豫园商城也是购物和品尝上海传统小吃的热门地点。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 39,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
    case "同济大学":
      scene.value = {
        name: "同济大学",
        description:
          "同济大学位于上海市，是中国著名的综合性大学，具有悠久的历史和深厚的学术底蕴。学校创建于1907年，最初由德国医生埃里希·宝隆创办，经过百余年的发展，同济大学已成为中国高水平研究型大学之一，并在国内外享有盛誉。同济大学以工科见长，尤其是在土木工程、建筑、交通运输等领域具有强大的学术影响力。此外，学校还在环境科学、医学、管理学、经济学等学科领域拥有显著的优势。同济大学校园环境优美，教学设施先进，吸引了来自全国乃至世界各地的优秀学子前来求学。学校坚持国际化发展战略，与全球众多知名大学和科研机构建立了广泛的合作关系，为学生提供了丰富的国际交流与合作机会。",
        imageUrl: `/images/${encodeURIComponent(spotName)}.jpg`,
        ticketPrice: 0,
        ticketLink: "https://www.shanghaidisneyresort.com/tickets/"
      }
      break
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
