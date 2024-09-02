<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { ElCarousel, ElCarouselItem } from 'element-plus';
import cairo from "@/assets/scene/cairo.jpg";
import newyork from "@/assets/scene/newyork.jpg";
import paris from "@/assets/scene/paris.jpg";
import shanghai from "@/assets/scene/shanghai.jpg";
import sydney from "@/assets/scene/sydney.jpg";
import tokyo from "@/assets/scene/tokyo.jpg";
import riodejaneiro from "@/assets/scene/riodejaneiro.jpg";

const selectedItem = ref("");
const isAsideVisible = ref(false);
const showImages = ref(true);
const currentIndex = ref(0);
const images = [shanghai, cairo, newyork, paris, sydney, tokyo, riodejaneiro];
const imagesHref = [
  "http://localhost:3333/#/scene/shanghai",
  "http://localhost:3333/#/scene/cairo",
  "http://localhost:3333/#/scene/newyork",
  "http://localhost:3333/#/scene/paris",
  "http://localhost:3333/#/scene/sydney",
  "http://localhost:3333/#/scene/tokyo",
  "http://localhost:3333/#/scene/riodejaneiro"
];

const handleSelect = (key: string) => {
  selectedItem.value = selectedItem.value === key ? "" : key;
  isAsideVisible.value = selectedItem.value !== "";
  showImages.value = selectedItem.value === "";
};

const handleChange = (index: number) => {
  currentIndex.value = index;
};
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
              <img :src="image" alt="Scenic Spot" class="carousel-image" />
            </el-carousel-item>
          </el-carousel>
          <div v-if="showImages" class="full-image">
            <a :href="imagesHref[currentIndex]">
              <img :src="images[currentIndex]" alt="Full Scenic Spot" class="scene-image1" />
            </a>
          </div>
        </div>
        <div v-else-if="selectedItem === '1'" class="city-links">
          <router-link :to="{ path: '/scene/shanghai' }">上海</router-link>
          <a>北京</a>
          <a>天津</a>
          <a>广州</a>
        </div>
        <div v-else-if="selectedItem === '2'" class="city-links">
          <router-link :to="{ path: '/scene/tokyo' }">东京</router-link>
          <a>曼谷</a>
          <a>新加坡</a>
          <a>迪拜</a>
        </div>
        <div v-else-if="selectedItem === '3'" class="city-links">
          <router-link :to="{ path: '/scene/cairo' }">开罗</router-link>
          <a>开普敦</a>
          <a>约翰内斯堡</a>
          <a>马拉喀什</a>
        </div>
        <div v-else-if="selectedItem === '4'" class="city-links">
          <router-link :to="{ path: '/scene/paris' }">巴黎</router-link>
          <a>伦敦</a>
          <a>威尼斯</a>
          <a>罗马</a>
        </div>
        <div v-else-if="selectedItem === '5'" class="city-links">
          <router-link :to="{ path: '/scene/newyork' }">纽约</router-link>
          <a>多伦多</a>
          <a>洛杉矶</a>
          <a>温哥华</a>
        </div>
        <div v-else-if="selectedItem === '6'" class="city-links">
          <router-link :to="{ path: '/scene/riodejaneiro' }">里约热内卢</router-link>
          <a>圣保罗</a>
          <a>基多</a>
          <a>圣地亚哥</a>
        </div>
        <div v-else-if="selectedItem === '7'" class="city-links">
          <router-link :to="{ path: '/scene/sydney' }">悉尼</router-link>
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
  height: 840px;
  background: #2d3a4b;
  color: white;
  margin-left: 10%;
  cursor: pointer;
}
.el-menu-item {
  cursor: pointer;
  height: 100px;
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

.el-aside {
  display: block;
  height: 700px;
  background: #2d3a4b;
  color: white;
  margin-left: 10%;
  cursor: pointer;
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
