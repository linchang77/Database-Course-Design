<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { ElCarousel, ElCarouselItem } from 'element-plus';
import nanjing from "/images/nanjing.jpg";
import shanghai from "/images/shanghai.jpg";
import chengdu from "/images/chengdu.jpg";
import beijing from "/images/beijing.jpg";
import wuhan from "/images/wuhan.jpg";
const selectedItem = ref("");
const isAsideVisible = ref(false);
const showImages = ref(true);
const currentIndex = ref(0);
const editedCities = ref<string[]>([]);

const supportedCities = [
  { lower: 'shanghai', upper: '上海' },
  { lower: 'nanjing', upper: '南京' },
  { lower: 'chengdu', upper: '成都' },
  { lower: 'beijing', upper: '北京' },
  { lower: 'wuhan', upper: '武汉' },
];

const images = [shanghai, nanjing, chengdu, beijing, wuhan];

const router = useRouter();

const handleSelect = (key: string) => {
  selectedItem.value = selectedItem.value === key ? "" : key;
  isAsideVisible.value = selectedItem.value !== "";
  showImages.value = selectedItem.value === "";
};

const handleChange = (index: number) => {
  currentIndex.value = index;
};

// 添加点击城市跳转逻辑
const handleCityClick = (cityLower: string) => {
  const city = supportedCities.find(c => c.lower === cityLower);
  if (city) {
    router.push({ path: '/scene/city', query: { city: city.lower } });
  }
};

// 确保所有支持的城市都是已编辑的城市
onMounted(() => {
  editedCities.value = supportedCities.map(city => city.upper);
});
</script>

<template>
  <div class="no-scroll">
    <div>
      <input placeholder="搜索景点/城市" />
      <button class="Search-Scene">搜索</button>
    </div>
    <el-container>
      <el-aside width="300px" class="aside">
        <el-menu @select="handleSelect" :default-active="selectedItem">
          <el-menu-item index="1">国内（含港澳台）</el-menu-item>
          <el-menu-item index="2">亚洲</el-menu-item>
          <el-menu-item index="3">非洲</el-menu-item>
          <el-menu-item index="4">欧洲</el-menu-item>
          <el-menu-item index="5">北美洲</el-menu-item>
          <el-menu-item index="6">南美洲</el-menu-item>
          <el-menu-item index="7">大洋洲</el-menu-item>
        </el-menu>
      </el-aside>
      <el-main>
        <div v-if="showImages">
          <el-carousel :interval="4000" type="card" height="300px" @change="handleChange">
            <el-carousel-item v-for="(image, index) in images" :key="index">
              <img @click="handleCityClick(supportedCities[index].lower)" :src="image" alt="Scenic Spot" class="carousel-image" />
            </el-carousel-item>
          </el-carousel>
          <div v-if="showImages" class="full-image">
            <a @click.prevent="handleCityClick(supportedCities[currentIndex].lower)">
              <img :src="images[currentIndex]" alt="Full Scenic Spot" class="scene-image1" />
            </a>
          </div>
        </div>
        <div v-else-if="selectedItem === '1'" class="city-links">
          <a v-for="city in supportedCities.filter(city => city.lower === 'shanghai')" @click.prevent="handleCityClick(city.lower)">{{ city.upper }}</a>
          <a v-for="city in supportedCities.filter(city => city.lower === 'nanjing')" @click.prevent="handleCityClick(city.lower)">{{ city.upper }}</a>
          <a v-for="city in supportedCities.filter(city => city.lower === 'chengdu')" @click.prevent="handleCityClick(city.lower)">{{ city.upper }}</a>
          <a v-for="city in supportedCities.filter(city => city.lower === 'beijing')" @click.prevent="handleCityClick(city.lower)">{{ city.upper }}</a>
          <a v-for="city in supportedCities.filter(city => city.lower === 'wuhan')" @click.prevent="handleCityClick(city.lower)">{{ city.upper }}</a>
        </div>
        <div v-else-if="selectedItem === '2'" class="city-links">
          <a>东京</a>
          <a>曼谷</a>
          <a>新加坡</a>
          <a>迪拜</a>
        </div>
        <div v-else-if="selectedItem === '3'" class="city-links">
          <a>开罗</a>
          <a>开普敦</a>
          <a>约翰内斯堡</a>
          <a>马拉喀什</a>
        </div>
        <div v-else-if="selectedItem === '4'" class="city-links">
          <a>巴黎</a>
          <a>伦敦</a>
          <a>威尼斯</a>
          <a>罗马</a>
        </div>
        <div v-else-if="selectedItem === '5'" class="city-links">
          <a>纽约</a>
          <a>多伦多</a>
          <a>洛杉矶</a>
          <a>温哥华</a>
        </div>
        <div v-else-if="selectedItem === '6'" class="city-links">
          <a>里约热内卢</a>
          <a>圣保罗</a>
          <a>基多</a>
          <a>圣地亚哥</a>
        </div>
        <div v-else-if="selectedItem === '7'" class="city-links">
          <a>悉尼</a>
          <a>墨尔本</a>
          <a>奥克兰</a>
          <a>皇后镇</a>
        </div>
      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
.el-container {
  height: 100%;
}

.el-aside {
  display: block;
  height: 966px;
  background: #2d3a4b;
  color: white;
  margin-left: 10%;
  cursor: pointer;
  border-radius: 8px;
}

.el-menu-item {
  cursor: pointer;
  height: 138px;
}

.city-links a {
  display: inline-block;
  margin-right: 20px;
  text-decoration: none;
  color: black;
}

.city-links a:hover {
  color: rgb(0, 157, 255);
}
input {
  padding: 12px;
  margin: 20px 0;
  margin-left: 10%;
  margin-top: 5%;
  width: 70%;
  border-top-left-radius: 8px;
  border-bottom-left-radius: 8px;
  border: 2px rgb(0, 157, 255) solid;
  box-sizing: border-box;
}

input:focus {
  padding: 12px;
  margin: 20px 0;
  margin-left: 10%;
  margin-top: 5%;
  width: 70%;
  border-top-left-radius: 8px;
  border-bottom-left-radius: 8px;
  outline: 0px rgb(0, 157, 255) solid;
  box-sizing: border-box;
}
button.Search-Scene {
  padding: 12px;
  margin: 20px 0;
  margin-right: 10%;
  width: 10%;
  box-sizing: border-box;
  color: #fef9f9;
  border-top-right-radius: 8px;
  border-bottom-right-radius: 8px;
  background-color: rgb(0, 157, 255);
  border: 2px rgb(0, 157, 255) solid;
  cursor: pointer;
}
.sidebar {
  height: 70%;
  margin: 20px 0;
  margin-left: 10%;
  width: 25%;
  box-sizing: border-box;
  color: #fef9f9;
  border-radius: 8px;
  background-color: rgb(248, 250, 251);
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.1);
}
button.Inside-sidebar {
  height: 15%;
  margin: 20px 0;
  margin-top: 0;
  margin-left: 0;
  width: 100%;
  box-sizing: border-box;
  color: black;
  border-radius: 8px;
  border: none;
  background-color: rgb(248, 250, 251);
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.1);
}
button.Inside-sidebar:focus {
  cursor: pointer;
}
.sidebar-word {
  font-size: 20px;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  padding: 8px;
  border-bottom: 1px solid #ddd;
}
.image-gallery {
  width: 100%;
  height: 292px;
  gap: 20px;
}
.scene-image-container {
  display: grid;
  grid-template-rows: auto;
  border-radius: 15px;
  gap: 30px;
}
.scene-image1 {
  margin-top: 30px;
  width: 100%;
  height: auto;
  display: block;
  border-radius: 15px;
  object-fit: contain;
}
.el-container {
  height: 100%;
}

.carousel-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 10px;
}

.Search-Scene {
  padding: 12px;
  margin: 20px 0;
  margin-right: 10%;
  width: 10%;
  box-sizing: border-box;
  color: #fef9f9;
  border-top-right-radius: 8px;
  border-bottom-right-radius: 8px;
  background-color: rgb(0, 157, 255);
  border: 2px rgb(0, 157, 255) solid;
  cursor: pointer;
}

.city-links a {
  display: inline-block;
  margin-right: 20px;
  text-decoration: none;
  color: black;
}
.city-links a:hover {
  color: rgb(0, 157, 255);
}
</style>
