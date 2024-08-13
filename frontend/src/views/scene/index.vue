<script lang="ts" setup>
import { ref } from "vue"
import { ElMenu, ElMenuItem, ElContainer, ElAside, ElMain } from "element-plus"
import scene1 from "@/assets/scene/scene1.jpg"
import scene2 from "@/assets/scene/scene2.jpg"
import scene3 from "@/assets/scene/scene3.jpg"

defineOptions({
  name: "Scene"
})

const selectedItem = ref("")
const isAsideVisible = ref(false)
const showImages = ref(true) // 控制图片和滚动按钮显示的变量

const handleSelect = (key: string) => {
  if (selectedItem.value === key) {
    selectedItem.value = ""
    isAsideVisible.value = false
    showImages.value = true  // 恢复显示图片和滚动按钮
  } else {
    selectedItem.value = key
    isAsideVisible.value = true
    showImages.value = false // 隐藏图片和滚动按钮
  }
}

const currentIndex = ref(0)
const images = [scene1, scene2, scene3]

const nextImage = () => {
  currentIndex.value = (currentIndex.value + 1) % images.length
}

const prevImage = () => {
  currentIndex.value = (currentIndex.value - 1 + images.length) % images.length
}
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
        <!-- 使用 showImages 控制图片和滚动按钮的显示 -->
        <div v-if="showImages" class="image-gallery">
          <a href="scene1.html">
            <img :src="scene1" alt="Scene 1" class="scene-image1" />
          </a>
        </div>

        <div v-else-if="selectedItem === '1'" class="city-links">
          <a href="http://localhost:3333/#/scene/shanghai">上海</a>
          <a>北京</a>
          <a>天津</a>
          <a>广州</a>
        </div>
        <div v-else-if="selectedItem === '2'" class="city-links">
          <a href="http://localhost:3333/#/scene/tokyo">东京</a>
          <a>曼谷</a>
          <a>新加坡</a>
          <a>迪拜</a>
        </div>
        <div v-else-if="selectedItem === '3'" class="city-links">
          <a href="http://localhost:3333/#/scene/cairo">开罗</a>
          <a>开普敦</a>
          <a>约翰内斯堡</a>
          <a>马拉喀什</a>
        </div>
        <div v-else-if="selectedItem === '4'" class="city-links">
          <a href="http://localhost:3333/#/scene/paris">巴黎</a>
          <a>伦敦</a>
          <a>威尼斯</a>
          <a>罗马</a>
        </div>
        <div v-else-if="selectedItem === '5'" class="city-links">
          <a href="http://localhost:3333/#/scene/newyork">纽约</a>
          <a>多伦多</a>
          <a>洛杉矶</a>
          <a>温哥华</a>
        </div>
        <div v-else-if="selectedItem === '6'" class="city-links">
          <a href="http://localhost:3333/#/scene/riodejaneiro">里约热内卢</a>
          <a>圣保罗</a>
          <a>基多</a>
          <a>圣地亚哥</a>
        </div>
        <div v-else-if="selectedItem === '7'" class="city-links">
          <a href="http://localhost:3333/#/scene/sydney">悉尼</a>
          <a>墨尔本</a>
          <a>奥克兰</a>
          <a>皇后镇</a>
        </div>

        <div v-if="showImages" class="scrollbar">
          <button @click="prevImage" class="scroll-button"><</button>
          <div class="scroll-images">
            <img :src="images[currentIndex]" alt="Scene" class="scroll-image" />
            <img :src="images[(currentIndex + 1) % images.length]" alt="Scene" class="scroll-image" />
            <img :src="images[(currentIndex + 2) % images.length]" alt="Scene" class="scroll-image" />
          </div>
          <button @click="nextImage" class="scroll-button">></button>
        </div>
      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
/* 移除页面的滚动条 */
.no-scroll {
  overflow: hidden;
  height: 130vh; /* 限制页面高度为视窗高度 */
}

/* 保持原有样式 */
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
  height: 120px;
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
  width: 808px;
  height: 492px;
  gap: 20px;
}
.scene-image-container {
  display: grid;
  grid-template-rows: auto;
  border-radius: 15px;
  gap: 30px;
}
.scene-image1{
  width: 808px;
  height: 492px;
  display: block;
  border-radius: 15px;
  object-fit: contain;
}
.scene-image {
  width: 256px;
  height: 256px;
  display: block;
  border-radius: 20px;
  object-fit: contain;
}
.scrollbar {
  display: flex;
  margin-left: 30px;
  gap: 20px;
  margin-top: 20px;
}
.scroll-button {
  font-size: 2em;
  background: none;
  border: none;
  cursor: pointer;
  color: #000;
}
.scroll-button:hover {
  color: rgb(0, 157, 255);
}
.scroll-image {
  width: 200px;
  height: 200px;
  border-radius: 15px;
  object-fit: cover;
  gap: 20px;
  margin: 5px;
}
</style>
