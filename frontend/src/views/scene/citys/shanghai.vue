<script lang="ts" setup>
import { ref } from "vue";
import axios from "axios";

defineOptions({
  name: "Shanghai"
})
const currentPage = ref('home')
const attractions = ref<Array<{ id: number, name: string, grade: string, description: string, distance: number }>>([]);

const searchQuery = ref('');
const starFilter = ref('全部');
const distanceFilter = ref('全部');

const navigateTo = (page: string) => {
  currentPage.value = page
}
const starOptions = ['全部', '1A', '2A', '3A', '4A', '5A'];
const distanceOptions = ['全部', '2km内', '2-5km', '5-20km', '20km以上'];

const fetchAttractions = () => {
  axios.get(`https://123.60.14.84/api/ScenicSpot/${encodeURIComponent('上海')}`)
    .then(response => {
      attractions.value = response.data;
    })
    .catch(error => {
      console.error(error);
    });
};

fetchAttractions();

const searchAttraction = () => {
  if (searchQuery.value) {
    if (!isNaN(Number(searchQuery.value))) {
      axios.get(`https://123.60.14.84/api/ScenicSpot/id/${searchQuery.value}`)
        .then(response => {
          attractions.value = response.data;
        })
        .catch(error => {
          console.error(error);
        });
    } else {
      axios.get(`https://123.60.14.84/api/ScenicSpot/name/${encodeURIComponent(searchQuery.value)}`)
        .then(response => {
          attractions.value = response.data;
        })
        .catch(error => {
          console.error(error);
        });
    }
  } else {
    fetchAttractions();
  }
};

const setStarFilter = (option: string) => {
  starFilter.value = option;
  if (option !== '全部') {
    axios.get(`https://123.60.14.84/api/ScenicSpot/${encodeURIComponent('上海')}/grade/${option}`)
      .then(response => {
        attractions.value = response.data;
      })
      .catch(error => {
        console.error(error);
      });
  } else {
    fetchAttractions();
  }
};

const setDistanceFilter = (option: string) => {
  distanceFilter.value = option;
  let mindis = 0;
  let maxdis = 0;

  switch (option) {
    case '2km内':
      maxdis = 2000;
      break;
    case '2-5km':
      mindis = 2000;
      maxdis = 5000;
      break;
    case '5-20km':
      mindis = 5000;
      maxdis = 20000;
      break;
    case '20km以上':
      mindis = 20000;
      maxdis = 100000;
      break;
    default:
      fetchAttractions();
      return;
  }

  axios.get(`https://123.60.14.84/api/ScenicSpot/${encodeURIComponent('上海')}/distance/${mindis},${maxdis}`)
    .then(response => {
      attractions.value = response.data;
    })
    .catch(error => {
      console.error(error);
    });
};
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
          @click="navigateTo(page)">
          {{ page === 'home' ? '首页' : page === 'attractions' ? '景点' : '住宿' }}
        </button>
      </nav>
    </header>

    <div v-if="currentPage === 'attractions'" class="filters-container">
      <div class="search-bar">
        <input type="text" v-model="searchQuery" placeholder="输入景点名称或ID进行搜索">
        <button @click="searchAttraction">搜索</button>
      </div>
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
      <div v-if="currentPage === 'home'">
        <img src="/images/shanghai.jpg" alt="Shanghai" class="home-image"/>
      </div>

      <div v-if="currentPage === 'attractions'" class="attractions-grid">
        <div v-for="attraction in attractions" :key="attraction.id" class="attraction-card">
          <img :src="`/images/${attraction.name}.jpg`" alt="attraction.name" class="attraction-image">
          <div class="attraction-info">
            <h3>{{ attraction.name }}</h3>
            <p>等级：{{ attraction.grade }}</p>
            <p>{{ attraction.description }}</p>
            <p>距离：{{ attraction.distance }}米</p>
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
  transition: color 0.3s ease, border-bottom 0.3s ease;
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

.attractions-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
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
  height: auto;
  border-radius: 8px;
  margin-bottom: 10px;
}

.attraction-info h3 {
  margin-bottom: 10px;
  font-size: 20px;
}

.attraction-info p {
  margin: 5px 0;
  color: #555;
}
</style>
