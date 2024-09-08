<template>
  <div>
    <h3>订单已完成</h3>
    <p>感谢您的订购！</p>
    <el-button type="primary" @click="backToQueryPage">
      返回查询页
    </el-button>
  </div>
</template>

<script lang="ts" setup>
  import router from '@/router';
  function backToQueryPage() {
    router.push({
      name: "Airplane"
    });
  }
</script>
