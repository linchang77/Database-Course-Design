<template>
  <div>
    <h3>订单已完成</h3>
    <p>感谢您的订购！</p>
    <el-button type="primary" @click="$emit('submit')">返回上一步</el-button>
  </div>
</template>

<script lang="ts" setup>
defineEmits(['submit']);
</script>
