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
    <div class="search">
      <input placeholder="搜索景点/城市" />
      <button class="Search-Scene">搜索</button>
    </div>

    <el-container>
      <el-aside width="300px" class="aside">
        <el-menu :default-active="selectedItem">
          <el-menu-item index="1">
            <div style="display: block;">
              <div style="display: block;">国内（含港澳台）</div>
              <div class="city-links">
                <a v-for="city in supportedCities" :key="city.lower" @click.prevent="handleCityClick(city.lower)">
                  {{ city.upper }}
                </a>
              </div>
            </div>
          </el-menu-item>
          <el-menu-item index="2">
            <div style="display: block;">
              <div style="display: block;">亚洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
          <el-menu-item index="3">
            <div style="display: block;">
              <div style="display: block;">非洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
          <el-menu-item index="4">
            <div style="display: block;">
              <div style="display: block;">欧洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
          <el-menu-item index="5">
            <div style="display: block;">
              <div style="display: block;">北美洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
          <el-menu-item index="6">
            <div style="display: block;">
              <div style="display: block;">南美洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
          <el-menu-item index="7">
            <div style="display: block;">
              <div style="display: block;">大洋洲</div>
              <div class="city-links-no">敬请期待</div>
            </div>
          </el-menu-item>
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
          </div>
        </div>
      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
.no-scroll{
  margin-left:30px;
  margin-right:30px;
}

.el-container {
  height: 90vh;
  margin: 0 auto;
  box-sizing: border-box;
  height: 100vh;
  overflow: hidden;
}

.el-main {
  display: flex;
  flex-direction: column;
  width: 70%;
  height: 100%;
  overflow: hidden;
}

.el-aside {
  display: block;
  height: 966px;
  background: #2d3a4b;
  color: white;
  margin-left: 2%;
  cursor: pointer;
  border-radius: 8px;
  margin-right: 2%;
}

.el-menu{
  height: 100%;
}

.el-menu-item {
  cursor: pointer;
  height: 138px;
}

.el-menu-item.is-active {
  color: black;
}

.el-menu-item:hover {
  background-color: transparent !important;
}

.city-links a {
  display: inline-block;
  margin-right: 10px;
  color: grey;
}

.city-links a:hover {
  color: rgb(0, 157, 255);
}

.city-links-no{
  color: grey;
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
  margin: 10px 0;
  margin-right: 10%;
  width: 10%;
  box-sizing: border-box;
  color: #fef9f9;
  background-color: rgb(0, 157, 255);
  border: 2px rgb(0, 157, 255) solid;
  cursor: pointer;
  border-top-right-radius: 10px;
  border-bottom-right-radius: 10px;
}

.carousel-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 10px;
}

.scene-image1 {
  margin-top: 30px;
  width: 75%;
  height: auto;
  display: block;
  border-radius: 15px;
  object-fit: contain;
  margin-left: 127px;
}

</style>
