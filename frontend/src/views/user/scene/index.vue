<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import nanjing from "/images/nanjing.jpg";
import shanghai from "/images/shanghai.jpg";
import chengdu from "/images/chengdu.jpg";
import beijing from "/images/beijing.jpg";
import wuhan from "/images/wuhan.jpg";

const selectedItem = ref("");
const selectedNumber = ref(0);
const showImages = ref(true);
const currentIndex = ref(0);

const menuItemPlace = [
  "0","138px","276px","414px","552px","691px","829px"
]

const supportedCities = [
  { lower: 'shanghai', upper: '上海' },
  { lower: 'nanjing', upper: '南京' },
  { lower: 'chengdu', upper: '成都' },
  { lower: 'beijing', upper: '北京' },
  { lower: 'wuhan', upper: '武汉' },
];

const images = [shanghai, nanjing, chengdu, beijing, wuhan];

const router = useRouter();

// 切换侧边栏时展示a标签内容
const handleSelect = (key: string) => {
  selectedItem.value = selectedItem.value === key ? "" : key;
  selectedNumber.value = Number(key);
};

// 处理图片切换逻辑
const handleChange = (index: number) => {
  currentIndex.value = index;
};

// 城市点击后跳转
const handleCityClick = (cityLower: string) => {
  const city = supportedCities.find(c => c.lower === cityLower);
  if (city) {
    router.push({ path: '/scene/city', query: { city: city.lower } });
  }
};
</script>

<template>
  <div class="no-scroll">
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
        <div>
          <!-- 图片轮播 -->
          <el-carousel v-if="showImages" :interval="4000" type="card" height="300px" @change="handleChange">
            <el-carousel-item v-for="(image, index) in images" :key="index">
              <img @click="handleCityClick(supportedCities[index].lower)" :src="image" alt="Scenic Spot" class="carousel-image" />
            </el-carousel-item>
          </el-carousel>
          <!-- 全尺寸图片 -->
          <div v-if="showImages" class="full-image">
            <a @click.prevent="handleCityClick(supportedCities[currentIndex].lower)">
              <img :src="images[currentIndex]" alt="Full Scenic Spot" class="scene-image1" />
            </a>
            <!-- 在图片上方显示标签 -->
            <div v-if="selectedItem" class="overlay-label" :style="{top: 12% + menuItemPlace[selectedNumber]}">
              <div v-if="selectedItem === '1'" class="city-links">
                <a v-for="city in supportedCities" :key="city.lower" @click.prevent="handleCityClick(city.lower)">
                 {{ city.upper }}
                </a>
              </div>

              <div v-else-if="selectedItem === '2' || selectedItem === '3' || selectedItem === '4' || selectedItem === '5' || selectedItem === '6' || selectedItem === '7'" class="city-links">
              </div>
            </div>
          </div>
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
  margin-left: 2%;
  cursor: pointer;
  border-radius: 8px;
}

.el-menu-item {
  cursor: pointer;
  height: 138px;
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

button.Search-Scene {
  padding: 12px;
  margin: 20px 0;
  margin-right: 10%;
  width: 10%;
  box-sizing: border-box;
  color: #fef9f9;
  background-color: rgb(0, 157, 255);
  border: 2px rgb(0, 157, 255) solid;
  cursor: pointer;
}

.carousel-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 10px;
}

.scene-image1 {
  margin-top: 30px;
  width: 100%;
  height: auto;
  display: block;
  border-radius: 15px;
  object-fit: contain;
}

/* 覆盖图片上方的标签样式 */
.overlay-label {
  position: absolute;
  top: 1%;
  left: 28%;
  width: 30%;
  height: 20%;
  background-color: rgba(255, 255, 255, 0.8);
  padding: 10px;
  border-radius: 5px;
  z-index: 10;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
}

.overlay-label a {
  color: black;
  padding: 10px;
  text-decoration: none;
  cursor: pointer;
}

.overlay-label a:hover {
  color: rgb(0, 157, 255);
}
</style>
