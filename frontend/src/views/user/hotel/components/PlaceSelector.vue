<template>
    <div class="main-container">
      <div class="slot-container">
      <slot></slot>
      </div>
      <el-cascader
        v-model="value"
        :options="options"
        :props="props"
        :show-all-levels=false
        @change="handleChange"
      />
    </div>
  </template>
  
  <script lang="ts" setup>
  import { ref } from 'vue'
  
  const value = ref([])
  
  const props = {
    expandTrigger: 'hover' as const,
  }
  
  const emit = defineEmits(['updateValue'])

  const handleChange = (value: any) => {
  emit('updateValue',value)
}
  
  const options = [
    {
      value: 'domestic',
      label: '国内',
      children: [
        {
          value: "北京",
          label: "北京",
        },
        {
          value: "上海",
          label: "上海",
        },
        {
          value: "广州",
          label: "广州",
        },
        {
          value: "深圳",
          label: "深圳",
        },
        {
          value: "成都",
          label: "成都",
        },
        {
          value: "杭州",
          label: "杭州",
        },
        {
          value: "重庆",
          label: "重庆",
        },
        {
          value: "白山",
          label: "白山",
        },
        {
          value: "西安",
          label: "西安",
        },
        {
          value: "南京",
          label: "南京",
        },
        {
          value: "武汉",
          label: "武汉",
        },
        {
          value: "苏州",
          label: "苏州",
        },
        {
          value: "天津",
          label: "天津",
        },
        {
          value: "青岛",
          label: "青岛",
        },
        {
          value: "厦门",
          label: "厦门",
        },
        {
          value: "大连",
          label: "大连",
        },
        {
          value: "长沙",
          label: "长沙",
        },
        {
          value: "福州",
          label: "福州",
        },
        {
          value: "昆明",
          label: "昆明",
        },
        {
          value: "贵阳",
          label: "贵阳",
        },
        {
          value: "海口",
          label: "海口",
        },
      ],
    },
    {
      value: 'abroad',
      label: '国际/中国港澳台',
      children: [
        {
          value: "tokyo",
          label: "东京",
        },
        {
          value: "seoul",
          label: "首尔",
        },
        {
          value: "singapore",
          label: "新加坡",
        },
        {
          value: "bangkok",
          label: "曼谷",
        },
        {
          value: "kualalumpur",
          label: "吉隆坡",
        },
        {
          value: "jakarta",
          label: "雅加达",
        },
        {
          value: "hochiminhcity",
          label: "胡志明市",
        },
        {
          value: "newdelhi",
          label: "新德里",
        },
        {
          value: "hongkong",
          label: "香港",
        },
        {
          value: "taipei",
          label: "台北",
        },
        {
          value: "london",
          label: "伦敦",
        },
        {
          value: "paris",
          label: "巴黎",
        },
        {
          value: "berlin",
          label: "柏林",
        },
        {
          value: "rome",
          label: "罗马",
        },
        {
          value: "madrid",
          label: "马德里",
        },
        {
          value: "amsterdam",
          label: "阿姆斯特丹",
        },
        {
          value: "vienna",
          label: "维也纳",
        },
        {
          value: "brussels",
          label: "布鲁塞尔",
        },
        {
          value: "zurich",
          label: "苏黎世",
        },
        {
          value: "stockholm",
          label: "斯德哥尔摩",
        },
        {
          value: "newyork",
          label: "纽约",
        },
        {
          value: "losangeles",
          label: "洛杉矶",
        },
        {
          value: "chicago",
          label: "芝加哥",
        },
        {
          value: "miami",
          label: "迈阿密",
        },
        {
          value: "toronto",
          label: "多伦多",
        },
        {
          value: "vancouver",
          label: "温哥华",
        },
        {
          value: "mexicocity",
          label: "墨西哥城",
        },
        {
          value: "saopaulo",
          label: "圣保罗",
        },
        {
          value: "buenosaires",
          label: "布宜诺斯艾利斯",
        },
        {
          value: "lima",
          label: "利马",
        },
        {
          value: "sydney",
          label: "悉尼",
        },
        {
          value: "melbourne",
          label: "墨尔本",
        },
        {
          value: "brisbane",
          label: "布里斯班",
        },
        {
          value: "auckland",
          label: "奥克兰",
        },
        {
          value: "wellington",
          label: "惠灵顿",
        },
        {
          value: "capetown",
          label: "开普敦",
        },
        {
          value: "johannesburg",
          label: "约翰内斯堡",
        },
        {
          value: "nairobi",
          label: "内罗毕",
        },
        {
          value: "lagos",
          label: "拉各斯",
        },
        {
          value: "cairo",
          label: "开罗",
        }
      ],
    },
  ]
  </script>
  
<style>
.slot-container{
  margin: 5%
}
</style>