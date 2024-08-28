<template>
  <div class="main-container">
      <div class="slot-container">
          <slot></slot>
      </div>
      <div class="demo-date-picker">
          <span class="demonstration">
          </span>
          <el-date-picker
          v-model="value"
          type="date"
          placeholder="请选择"
          :disabled-date="disabledDate"
          @change="handleChange"
          /><!-- 禁用今天之前的日期 -->
      </div>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'

const value = ref('')

const emit = defineEmits(['updateValue'])

const today = new Date()
today.setHours(0, 0, 0, 0) // 仅比较日期部分，不比较时间

const disabledDate = (time: Date) => {
  //return time.getTime() < today.getTime()
  return false
}

const handleChange = (value: any) => {
  if (value !== '' && value !== null && value !== undefined) {
    let month=value.getMonth() + 1;
    let date=value.getDate();
    if (month < 10) {
      month = '0' + month;
    }
    if(date < 10) {
      date = '0' + date;
    }
    const formattedDate = `${value.getFullYear()}-${month}-${date}`;
    emit('updateValue', formattedDate);
    console.log('Selected Date:', formattedDate);
  } else {
      console.log('Date Cleared')
  }
}
</script>

<style >
.demo-date-picker {
  display: flex;
  width: 100%;
  padding: 0;
  flex-wrap: wrap;
}

.slot-container{
  margin: 5%
}
</style>
