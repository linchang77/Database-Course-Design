<script lang="ts" setup>
import { ref } from "vue"
import axios from "axios"

defineOptions({
  name: "Shanghai"
})

// 定义景点对象的接口
interface Attraction {
  scenicSpotId: string
  scenicSpotName: string
  scenicSpotGrade: string
  scenicSpotIntroduction: string
  scenicSpotLocation: string
}

const currentPage = ref("home")
const attractions = ref<Attraction[]>([])

const searchQuery = ref("")
const starFilter = ref("全部")
const distanceFilter = ref("全部")

const navigateTo = (page: string) => {
  currentPage.value = page
}

const starOptions = ["全部", "1", "2", "3", "4", "5"]
const distanceOptions = ["全部", "2km内", "2-5km", "5-20km", "20km以上"]

const fetchAttractions = () => {
  axios
    .get<Attraction[]>(`https://123.60.14.84/api/ScenicSpot/${encodeURIComponent("上海")}`)
    .then((response) => {
      let filteredAttractions = response.data

      // 星级筛选
      if (starFilter.value !== "全部") {
        filteredAttractions = filteredAttractions.filter(
          (attraction) => attraction.scenicSpotGrade === starFilter.value
        )
      }

      // 距离筛选
      if (distanceFilter.value !== "全部") {
        filteredAttractions = filteredAttractions.filter((attraction) => {
          const distance = parseFloat(attraction.scenicSpotLocation)
          switch (distanceFilter.value) {
            case "2km内":
              return distance <= 2
            case "2-5km":
              return distance > 2 && distance <= 5
            case "5-20km":
              return distance > 5 && distance <= 20
            case "20km以上":
              return distance > 20
            default:
              return true
          }
        })
      }

      attractions.value = filteredAttractions
    })
    .catch((error) => {
      if (error.response && error.response.status === 404) {
        attractions.value = []
      } else {
        console.error(error)
      }
    })
}

fetchAttractions()

const searchAttraction = () => {
  if (searchQuery.value) {
    if (!isNaN(Number(searchQuery.value))) {
      axios
        .get<Attraction>(`https://123.60.14.84/api/ScenicSpot/id/${searchQuery.value}`)
        .then((response) => {
          attractions.value = response.data ? [response.data] : []
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            attractions.value = []
          } else {
            console.error(error)
          }
        })
    } else {
      axios
        .get<Attraction[]>(`https://123.60.14.84/api/ScenicSpot/name/${encodeURIComponent(searchQuery.value)}`)
        .then((response) => {
          attractions.value = response.data ? response.data : []
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            attractions.value = []
          } else {
            console.error(error)
          }
        })
    }
  } else {
    fetchAttractions()
  }
}

const setStarFilter = (option: string) => {
  starFilter.value = option
  fetchAttractions()
}

const setDistanceFilter = (option: string) => {
  distanceFilter.value = option
  fetchAttractions()
}
</script>

<template>
  <div class="app-container">
    <header class="header">
      <div class="title">上海</div>
      <div class="title1">SHANGHAI</div>
      <nav class="nav">
        <button
          v-for="page in ['home', 'attractions', 'accommodation']"
          :key="page"
          :class="{ active: currentPage === page }"
          @click="navigateTo(page)"
        >
          {{ page === "home" ? "首页" : page === "attractions" ? "景点" : "住宿" }}
        </button>
      </nav>
    </header>

    <div v-if="currentPage === 'attractions'" class="filters-container">
      <div class="search-bar">
        <input type="text" v-model="searchQuery" placeholder="输入景点名称或ID进行搜索" />
        <button @click="searchAttraction">搜索</button>
      </div>
      <div class="filter-row">
        <span>星级：</span>
        <button
          v-for="option in starOptions"
          :key="option"
          :class="{ active: starFilter === option }"
          @click="setStarFilter(option)"
        >
          {{ option }}
        </button>
      </div>
      <div class="filter-row">
        <span>距离：</span>
        <button
          v-for="option in distanceOptions"
          :key="option"
          :class="{ active: distanceFilter === option }"
          @click="setDistanceFilter(option)"
        >
          {{ option }}
        </button>
      </div>
    </div>

    <main class="main-content">
      <div v-if="currentPage === 'home'">
        <img src="/images/shanghai.jpg" alt="Shanghai" class="home-image" />
      </div>
      <div v-if="currentPage === 'attractions'" class="attractions-grid">
        <div v-if="attractions.length === 0" class="no-results">无结果</div>
        <div v-else v-for="attraction in attractions" :key="attraction.scenicSpotId" class="attraction-card">
          <img
            :src="`/images/${encodeURIComponent(attraction.scenicSpotName)}.jpg`"
            alt="attraction.scenicSpotName"
            class="attraction-image"
          />
          <div class="attraction-info">
            <h3>{{ attraction.scenicSpotName }}</h3>
            <p>{{ attraction.scenicSpotGrade }}A</p>
            <p>{{ attraction.scenicSpotIntroduction }}</p>
            <p>距离：{{ attraction.scenicSpotLocation }}公里</p>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<style scoped>
.app-container {
  font-family: Arial, sans-serif;
}

.header {
  display: flex;
  align-items: center;
  padding: 20px;
  background-color: #f0f0f0;
}

.title {
  font-size: 48px;
  font-weight: bold;
  margin-right: 12px;
}

.title1 {
  font-size: 48px;
  font-weight: bold;
  margin-right: auto;
  color: grey;
}

.nav button {
  margin: 0 15px;
  padding: 10px 20px;
  font-size: 18px;
  border: none;
  background-color: transparent;
  cursor: pointer;
  transition:
    color 0.3s ease,
    border-bottom 0.3s ease;
}

.nav button:hover,
.nav button.active {
  color: #3498db;
  border-bottom: 2px solid #3498db;
}

.filters-container {
  padding: 20px;
  background-color: #f9f9f9;
  border-bottom: 1px solid #ddd;
}

.search-bar {
  display: flex;
  margin-bottom: 20px;
}

.search-bar input {
  flex: 1;
  padding: 8px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.search-bar button {
  margin-left: 10px;
  padding: 8px 16px;
  font-size: 16px;
  background-color: #3498db;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.filter-row {
  margin-bottom: 10px;
  display: flex;
  align-items: center;
}

.filter-row span {
  margin-right: 10px;
  font-weight: bold;
}

.filter-row button {
  margin-right: 10px;
  padding: 5px 10px;
  font-size: 16px;
  border: 1px solid #ccc;
  background-color: white;
  cursor: pointer;
  transition:
    background-color 0.3s ease,
    border-color 0.3s ease;
}

.filter-row button.active {
  background-color: #3498db;
  color: white;
  border-color: #3498db;
}

.filter-row button:hover {
  background-color: #e0e0e0;
}

.main-content {
  padding: 20px;
}

.home-image {
  width: 100%;
  height: auto;
}

.attractions-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
}

.attraction-card {
  background-color: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 15px;
  text-align: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.attraction-image {
  width: 100%;
  height: 250px;
  object-fit: cover;
  border-radius: 8px;
  margin-bottom: 5px;
}

.attraction-info {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.attraction-info h3 {
  margin-bottom: 5px;
  font-size: 20px;
}

.attraction-info p {
  margin: 5px 0;
  color: #555;
}

.no-results {
  grid-column: span 3;
  text-align: center;
  font-size: 18px;
  color: #777;
  margin-top: 20px;
}
</style>
