<script lang="ts" setup>
import { ref } from "vue"
import { Search } from "@element-plus/icons-vue"

defineOptions({
  name: "Group-travel"
})

const transportation_options = [
  {value: '不限',
  label: '不限',},
  {value: '飞机',
    label: '飞机',},
  {value: '高铁',
    label: '高铁',},
  {value: '动车',
    label: '动车',},
  {value: '火车',
    label: '火车',},
  {value: '巴士',
    label: '巴士',},
  {value: '船',
    label: '船',},
]

const scale_options = [
  {value: '不限',
  label: '不限',},
  {value: '10人及以下',
    label: '10人及以下',},
  {value: '11-30人',
    label: '11-30人',},
  {value: '31-50人',
    label: '31-50人',},
  {value: '50人以上',
    label: '50人以上',},

]

const departure_input=ref("")
const destination_input=ref("")
const duration_input=ref("")
const date_input=ref("")
const guide_input=ref("")
const transportation_input = ref(['不限']);
const scale_input=ref("不限")

const tours = ref([
  {
    id: 1,
    name: '欧洲德国+法国+意大利+瑞士12日',
    image: 'https://th.bing.com/th/id/R.17730a406f552186470aedcba9c41e61?rik=TMTgDwanN3pRjg&riu=http%3a%2f%2fimg.pconline.com.cn%2fimages%2fupload%2fupc%2ftx%2fphotoblog%2f1411%2f14%2fc4%2f40930578_40930578_1415972407711.jpg&ehk=5CuF8G2FaQGc0cs8v7q0dnLuiUS5VMztT9vPlj9iyDg%3d&risl=&pid=ImgRaw&r=0',
    description: '⭐巴黎两宫【卢浮宫+凡尔赛宫】含资深官导讲解+免排队服务<br>⭐罗马一段高速火车直接上威尼斯岛【感受火车穿越大海的不同风景】+升级一段包船前往圣马可岛开启威尼斯的摇曳之旅',
    departure: '上海',
    destination: '欧洲德国+法国+意大利+瑞士',
    time: '2024/8/10-2024/8/21',
    transportation: '飞机往返',
    guide: 'kk',
    price: 19836
  } 
])

</script>

<template>
  <div class="group-travel-container">
    <div>
      <span class="word">出发地 </span>
      <el-input
        v-model="departure_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
         class="box"
      />

      <span class="word"> 目的地 </span>
      <el-input
        v-model="destination_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
         class="box"
      />

      <span class="word"> 行程天数 </span>
      <el-input
        v-model="duration_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
         class="box"
      />

      <span class="word"> 出发时间 </span>
      <el-date-picker
        v-model="date_input"
        type="daterange"
        range-separator="To"
        start-placeholder="最早时间"
        end-placeholder="最晚时间"
        size="default"
      />
    </div>

    <div style="margin-top: 10px;">
      <span class="word"> 交通工具 </span>
      <el-select
        v-model="transportation_input"
        multiple
        style="width: 240px"
      >
      <el-option
        v-for="item in transportation_options"
        :key="item.value"
        :label="item.label"
        :value="item.value"
      />
      </el-select>

      <span class="word"> 团队规模 </span>
          <el-select v-model="scale_input"  style="width: 240px">
            <el-option v-for="item in scale_options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

      <span class="word"> 导游 </span>
      <el-input
        v-model="guide_input"
        style="width: 240px"
         placeholder=" "
        :prefix-icon="Search"
        class="box"
      />

      <el-button type="primary" class="button"> 筛选 </el-button>
    </div>
  </div>

  <div class="content" style="margin-top: 20px;">
    <div v-for="tour in tours" :key="tour.id" class="scrollbar-item">
      <img :src="tour.image" alt="tour image" style="margin-right: 15px; width: 200px; height: 150px">
      <div class="tour-info">
        <h3>{{ tour.name }}</h3>
        <p>{{ tour.time }}</p>
        <p>{{ tour.description }}</p>
        <p>交通工具：{{ tour.transportation }}</p>
        <p>导游：{{ tour.guide }}</p>
      </div>
      <div class="tour-price">
        <h3>价格：{{ tour.price }}</h3>
      </div>
    </div>
  </div>
</template>

<style lang="css">
  .group-travel-container{
    margin-top: 30px;
    margin-left: 20px;
  }

  .word,
  .button {
    margin-left: 10px;
  }

  .scrollbar-item {
    display: flex;/*使用flex布局*/
    align-items: center; /*垂直居中对齐*/
    justify-content: flex-start; /*水平左对齐*/
    height: 180px;
    margin-left: 40px;
    margin-right: 50px;
    padding: 15px; /*添加内边距*/
    text-align: left; /*确保文本左对齐*/
    border-radius: 4px;
    background: white;
    color: var(--el-color-primary);
  }

  .tour-info {
    flex: 0.95; /*占据剩余空间*/
  }

  .tour-info h3 {
    margin: 10px 10px; /* 调整p标签的上下外边距，减少间隙 */
  }

  .tour-info p {
    margin: 5px 10px; /* 调整p标签的上下外边距，减少间隙 */
  }

</style>