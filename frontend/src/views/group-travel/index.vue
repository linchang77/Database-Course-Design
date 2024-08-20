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

  <div class="content" style="margin-top: 10px;">
    <el-scrollbar height="600px">
      <p v-for="item in 20" :key="item" class="scrollbar-demo-item">{{ item }}</p>
    </el-scrollbar>
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

  .scrollbar-demo-item {
    display: flex;
    align-items: center;
    justify-content: center;
    height: 100px;
    margin-left: 40px;
    margin-right: 50px;
    text-align: center;
    border-radius: 4px;
    background: white;
    color: var(--el-color-primary);
}
</style>