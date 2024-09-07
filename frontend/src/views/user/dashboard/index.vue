<script lang="ts" setup>
import { ref, onMounted } from "vue"
import axios from "axios"
import { useRouter } from "vue-router"

interface GoTicket {
  vehicleId: string
  ticketType: string
  ticketPrice: number
  ticketDepartureTime: string
  ticketArrivalTime: string
  ticketDepartureCity: string
  ticketArrivalCity: string
  ticketId: number
}

interface ReturnTicket {
  vehicleId: string
  ticketType: string
  ticketPrice: number
  ticketDepartureTime: string
  ticketArrivalTime: string
  ticketDepartureCity: string
  ticketArrivalCity: string
  ticketId: number
}

// 定义行程的接口
interface TourItinerary {
  itineraryId: number
  itineraryTime: string
  itineraryDuration: string
  activities: string
  scenicSpotId: number | null
}

// 定义酒店接口
interface Hotel {
  hotelId: number
  hotelName: string
  cityName: string
  hotelGrade: string
  hotelLocation: string
  hotelIntroduction: string
}

// 定义旅游团的接口
interface TourGroup {
  groupId: number
  guideId: number
  startDate: string
  endDate: string
  groupName: string
  groupPrice: number
  goTicketId: number
  returnTicketId: number
  departure: string
  destination: string
  guideName: string
  goTicket?: GoTicket
  returnTicket?: ReturnTicket
  tourItineraries?: TourItinerary[]
  hotels?: Hotel[]
  imageUrl?: string
}

//景点数据接口
interface Attraction {
  scenicSpotId: string
  scenicSpotName: string
  scenicSpotGrade: string
  scenicSpotIntroduction: string
  scenicSpotLocation: string
  scenicSpotRemoteness: string
}
// 景点数据
const scenicSpots = ref<Attraction[]>([])
const childTicketPrices = ref<{ [key: string]: number }>({})
const router = useRouter()
const return2 = (str: string) => {
  return str.slice(0, 2)
}
const tourGroups = ref<TourGroup[]>([])
// 获取景点信息
const fetchScenicSpots = async () => {
  try {
    const response = await axios.get("https://123.60.14.84/scenicspots")
    scenicSpots.value = response.data // 获取前3个景点信息
    for (const spot of scenicSpots.value) {
      fetchTicketInfo(spot.scenicSpotName)
    }
  } catch (error) {
    console.error("Failed to fetch scenic spots:", error)
  }
}

// 获取票价信息
const fetchTicketInfo = async (spotName: string) => {
  try {
    const response = await axios.get(
      `https://123.60.14.84/api/ScenicSpot/ticket/${encodeURIComponent(spotName)}/date/2024-8-19`
    )
    const childTicket = response.data.childTicket
    childTicketPrices.value[spotName] = childTicket.ticketPrice
  } catch (error) {
    console.error("Failed to fetch ticket information:", error)
  }
}

// 景点跳转
const goToAttraction = (scenicSpotName: string, scenicSpotIntroduction: string, scenicSpotId: string) => {
  router.push({
    path: `scene/city/tickets`,
    query: { name: scenicSpotName, introduction: scenicSpotIntroduction, id: scenicSpotId }
  })
}

// 获取推荐旅游团
const fetchTourGroups = () => {
  axios
    .get("https://123.60.14.84/api/TourGroup/recommendedtours")
    .then((response) => {
      const data = response.data
      if (Array.isArray(data)) {
        tourGroups.value = data.map((group) => ({
          ...group,
          imageUrl: group.imageUrl || imageMap[return2(group.groupName)] // 使用映射或者默认图片
        }))
      } else {
        console.error("Unexpected response format.")
      }
    })
    .catch((error) => {
      console.error("Error fetching tour groups:", error)
    })
}

// 旅游团跳转
const goToGroup = (group: TourGroup) => {
  router.push({
    path: `group-travel/groups/detail`,
    query: {
      groupId: group.groupId.toString(),
      guideId: group.guideId.toString(),
      startDate: group.startDate,
      endDate: group.endDate,
      groupName: group.groupName,
      groupPrice: group.groupPrice.toString(),
      departure: group.departure,
      destination: group.destination,
      guideName: group.guideName,
      goTicket: JSON.stringify(group.goTicket),
      returnTicket: JSON.stringify(group.returnTicket),
      tourItineraries: JSON.stringify(group.tourItineraries),
      hotels: JSON.stringify(group.hotels),
      imageUrl: group.imageUrl
    }
  })
}

// 日期格式化
const formatDate = (date: string) => {
  return new Date(date).toLocaleDateString("zh-CN", { year: "numeric", month: "2-digit", day: "2-digit" })
}

onMounted(() => {
  fetchScenicSpots()
  fetchTourGroups()
})

// 旅游团图片映射
const imageMap: Record<string, string> = {
  上海: "https://img.dahepiao.com/uploads/image/2020/12/17/56d9e3bc071de06c4de6f0fa2f8e7a84.jpg",
  北京: "https://img.zcool.cn/community/010e2d5de0f549a80120686b802e63.jpg@1280w_1l_2o_100sh.jpg",
  南京: "https://img.zcool.cn/community/01088d556841970000012b20ccfc1a.jpg@3000w_1l_2o_100sh.jpg",
  成都: "https://img1.qunarzz.com/travel/poi/201407/30/cc58461b40f01e3cc8d65eac.jpg",
  武汉: "https://th.bing.com/th/id/R.43107bcfc6d493fd0e41b86a47f8a125?rik=Gy0Juky%2b9G1B4g&riu=http%3a%2f%2fimg.pconline.com.cn%2fimages%2fupload%2fupc%2ftx%2fphotoblog%2f1410%2f26%2fc2%2f40147263_1414299382894_mthumb.jpg&ehk=Vqm38FQdH7T8bH%2fAlDVATSrxmDaeqAosJOIE31tqabQ%3d&risl=&pid=ImgRaw&r=0"
}
</script>

<template>
  <div>
    <div class="header">
      <img src="@\assets\layouts\logo.png" alt="Logo" class="logo" />
      <h1 class="title1">e行天下</h1>
      <p class="slogan">漫步云端之下，心随风景轻舞，每一段旅程，皆有惊喜！</p>
    </div>

    <div>
      <!-- 上部: 热门旅游团 -->
      <section>
        <h2 class="section-title">热门旅游团</h2>
        <div class="group-container">
          <div class="group-card" v-for="group in tourGroups" :key="group.groupId" @click="goToGroup(group)">
            <div class="group-image">
              <img :src="group.imageUrl" alt="旅游团图片" />
            </div>
            <div class="group-info">
              <p class="title">{{ group.groupName }}</p>
              <p>{{ formatDate(group.startDate) }} -- {{ formatDate(group.endDate) }}</p>
              <p>导游：{{ group.guideName }}</p>
            </div>
            <div class="group-price">
              <p>{{ group.groupPrice }} 元起</p>
            </div>
          </div>
        </div>
      </section>

      <!-- 下部: 景点推荐 -->
      <section>
        <h2 class="section-title">景点推荐</h2>
        <div class="content-wrapper">
          <div v-if="scenicSpots.length" class="attraction-container">
            <div
              v-for="spot in scenicSpots"
              :key="spot.scenicSpotId"
              class="attraction-card"
              @click="goToAttraction(spot.scenicSpotName, spot.scenicSpotIntroduction, spot.scenicSpotId)"
            >
              <div class="image-wrapper">
                <img :src="`/images/${spot.scenicSpotName}.jpg`" :alt="spot.scenicSpotName" class="attraction-image" />
              </div>
              <div class="attraction-info">
                <h3>
                  {{ spot.scenicSpotName }} <span>{{ spot.scenicSpotGrade }}A</span>
                </h3>
                <span class="price">{{
                  childTicketPrices[spot.scenicSpotName] ? childTicketPrices[spot.scenicSpotName] + "元起" : "免费"
                }}</span>
              </div>
            </div>
          </div>
          <div class="right-space" />
        </div>
      </section>
    </div>
  </div>
</template>

<style scoped>
.section-title {
  font-size: 1.8em;
  font-weight: bold;
  margin-left: 5%;
  margin-bottom: 20px;
}
.content-wrapper {
  display: flex;
}

.attraction-container {
  margin-left: 40px;
  margin-top: 10px;
  display: flex;
  gap: 20px;
}

.attraction-card {
  background-color: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 0;
  text-align: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  flex: 1;
  max-width: 30%;
  cursor: pointer;
  overflow: hidden;
  transition: transform 0.2s;
}

.attraction-card:hover {
  transform: translateY(-5px);
}

.image-wrapper {
  width: 100%;
  height: 300px;
  overflow: hidden;
}

.attraction-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.attraction-info {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 10px;
}

.attraction-info h3 {
  font-size: 21px;
  margin: 0;
  text-align: left;
}

.attraction-info span {
  font-size: 18px;
  color: #555;
}

.price {
  text-align: right;
  font-weight: bold;
  margin-left: auto;
  color: #3498db;
  background-color: #f8f8f8;
}

.right-space {
  width: 0%;
}

/* 旅游团样式 */
.group-container {
  margin-left: 40px;
  margin-top: 20px;
  display: flex;
  gap: 20px;
}

.group-card {
  background-color: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 0;
  text-align: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  flex: 1;
  max-width: 30%;
  cursor: pointer;
  overflow: hidden;
  transition: transform 0.2s;
}

.group-card:hover {
  transform: translateY(-5px);
}

.group-image img {
  width: 100%;
  height: 100%;
}

.title {
  font-size: 1.25em;
  font-weight: bold;
  color: #000203;
}

.group-info,
.group-price {
  padding: 5px;
}

.group-price {
  font-size: 1.2em;
  font-weight: bold;
  color: #3498db;
  width: 100%;
  padding: 10px;
  background-color: #f8f8f8;
}

.header {
  display: flex;
  align-items: center;
  padding: 20px;
  background-color: #f8f8f8;

  .logo {
    height: 60px;
    margin-right: 20px;
    margin-left: 2%;
  }

  .slogan {
    font-size: 22px;
    font-weight: bold;
    color: #51b9ffb8;
    margin-top: 25px;
    margin-left: 30px; /* 根据需要调整 */
  }
}

.header-title {
  font-size: 2em;
  font-weight: bold;
  color: #000203;
}

.title1 {
  font-size: 2.5em;
  font-weight: bold;
  color: #3498db;
}

.attraction-container,
.group-container {
  margin-left: 100px;
  margin-right: 60px;
}
</style>
