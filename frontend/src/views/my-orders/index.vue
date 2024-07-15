<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "My-orders"
})

const text = ref("")
</script>

<template>
  <div class="app-container">
    <el-card header="订单列表">
    </el-card>
  </div>
</template>
