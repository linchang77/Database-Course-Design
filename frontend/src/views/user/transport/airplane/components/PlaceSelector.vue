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
    value: '国内',
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
    value: '国际/中国港澳台',
    label: '国际/中国港澳台',
    children: [
      {
        value: "东京",
        label: "东京",
      },
      {
        value: "首尔",
        label: "首尔",
      },
      {
        value: "新加坡",
        label: "新加坡",
      },
      {
        value: "曼谷",
        label: "曼谷",
      },
      {
        value: "吉隆坡",
        label: "吉隆坡",
      },
      {
        value: "雅加达",
        label: "雅加达",
      },
      {
        value: "胡志明市",
        label: "胡志明市",
      },
      {
        value: "新德里",
        label: "新德里",
      },
      {
        value: "香港",
        label: "香港",
      },
      {
        value: "台北",
        label: "台北",
      },
      {
        value: "伦敦",
        label: "伦敦",
      },
      {
        value: "巴黎",
        label: "巴黎",
      },
      {
        value: "柏林",
        label: "柏林",
      },
      {
        value: "罗马",
        label: "罗马",
      },
      {
        value: "马德里",
        label: "马德里",
      },
      {
        value: "阿姆斯特丹",
        label: "阿姆斯特丹",
      },
      {
        value: "维也纳",
        label: "维也纳",
      },
      {
        value: "布鲁塞尔",
        label: "布鲁塞尔",
      },
      {
        value: "苏黎世",
        label: "苏黎世",
      },
      {
        value: "斯德哥尔摩",
        label: "斯德哥尔摩",
      },
      {
        value: "纽约",
        label: "纽约",
      },
      {
        value: "洛杉矶",
        label: "洛杉矶",
      },
      {
        value: "芝加哥",
        label: "芝加哥",
      },
      {
        value: "迈阿密",
        label: "迈阿密",
      },
      {
        value: "多伦多",
        label: "多伦多",
      },
      {
        value: "温哥华",
        label: "温哥华",
      },
      {
        value: "墨西哥城",
        label: "墨西哥城",
      },
      {
        value: "圣保罗",
        label: "圣保罗",
      },
      {
        value: "布宜诺斯艾利斯",
        label: "布宜诺斯艾利斯",
      },
      {
        value: "利马",
        label: "利马",
      },
      {
        value: "悉尼",
        label: "悉尼",
      },
      {
        value: "墨尔本",
        label: "墨尔本",
      },
      {
        value: "布里斯班",
        label: "布里斯班",
      },
      {
        value: "奥克兰",
        label: "奥克兰",
      },
      {
        value: "惠灵顿",
        label: "惠灵顿",
      },
      {
        value: "开普敦",
        label: "开普敦",
      },
      {
        value: "约翰内斯堡",
        label: "约翰内斯堡",
      },
      {
        value: "内罗毕",
        label: "内罗毕",
      },
      {
        value: "拉各斯",
        label: "拉各斯",
      },
      {
        value: "开罗",
        label: "开罗",
      },
    ],
  },
];
</script>

<style>
.slot-container{
margin: 5%
}
</style>
