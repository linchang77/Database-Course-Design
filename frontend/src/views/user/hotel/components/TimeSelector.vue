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
            />
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
    return time.getTime() < today.getTime()
  }

  const handleChange = (value: any) => {
    if (value !== '' && value !== null && value !== undefined) {
      //const localISOTime = new Date(value.getTime() - (value.getTimezoneOffset() * 60000)).toISOString();
      emit('updateValue', value.toLocaleString())
      console.log('Selected Date:', value.toLocaleString())
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
  