<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "Paris"
})

const currentPage = ref('home')

const navigateTo = (page: string) => {
  currentPage.value = page
}

const starFilter = ref('全部')
const distanceFilter = ref('全部')

const starOptions = ['全部', '1A', '2A', '3A', '4A', '5A']
const distanceOptions = ['全部', '500m内', '500m-2km', '2km-5km', '5km以上']

const setStarFilter = (option: string) => {
  starFilter.value = option
}

const setDistanceFilter = (option: string) => {
  distanceFilter.value = option
}

</script>

<template>
  <div class="app-container">
    <header class="header">
      <div class="title">巴黎</div>
      <div class="title1">PARIS</div>
      <nav class="nav">
        <button 
          v-for="page in ['home', 'attractions', 'accommodation']" 
          :key="page" 
          :class="{ active: currentPage === page }" 
          @click="navigateTo(page)">
          {{ page === 'home' ? '首页' : page === 'attractions' ? '景点' : '住宿' }}
        </button>
      </nav>
    </header>

    <div v-if="currentPage === 'attractions'" class="filters-container">
      <div class="filter-row">
        <span>星级：</span>
        <button 
          v-for="option in starOptions" 
          :key="option" 
          :class="{ active: starFilter === option }" 
          @click="setStarFilter(option)">
          {{ option }}
        </button>
      </div>
      <div class="filter-row">
        <span>距离：</span>
        <button 
          v-for="option in distanceOptions" 
          :key="option" 
          :class="{ active: distanceFilter === option }" 
          @click="setDistanceFilter(option)">
          {{ option }}
        </button>
      </div>
    </div>

    <main class="main-content">
      <img v-if="currentPage === 'home'" src="/images/paris.jpg" alt="Paris" class="home-image"/>
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
  color:grey
}

.nav button {
  margin: 0 15px;
  padding: 10px 20px;
  font-size: 18px;
  border: none;
  background-color: transparent;
  cursor: pointer;
  transition: color 0.3s ease, border-bottom 0.3s ease;
}

.nav button:hover,
.nav button.active {
  color: #3498db;
  border-bottom: 2px solid #3498db;
}

.filters-container {
  padding: 10px 20px;
  background-color: #f9f9f9;
  border-bottom: 1px solid #ddd;
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
  transition: background-color 0.3s ease, border-color 0.3s ease;
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
</style>
