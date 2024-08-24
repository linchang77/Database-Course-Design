<template>
  <el-form :model="orderInfo" label-width="120px">
    <el-form-item label="航班ID">
      <span>{{ orderInfo.flight.vehicleId }}</span>
    </el-form-item>
    <el-form-item label="出发地">
      <span>{{ orderInfo.flight.departureCity }}</span>
    </el-form-item>
    <el-form-item label="目的地">
      <span>{{ orderInfo.flight.arrivalCity }}</span>
    </el-form-item>
    <el-form-item label="出发时间">
      <span>{{ orderInfo.flight.departureTime }}</span>
    </el-form-item>
    <el-form-item label="到达时间">
      <span>{{ orderInfo.flight.arrivalTime }}</span>
    </el-form-item>
    <el-form-item label="票价">
      <span>{{ orderInfo.price }}元</span>
    </el-form-item>
    <el-form-item label="数量">
      <el-input-number v-model="orderInfo.quantity" :min="1" :max="10" />
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="$emit('submit')">下一步</el-button>
    </el-form-item>
  </el-form>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { defineEmits } from 'vue'

const orderInfo = ref({
  flight: searchResults.value[0],
  price: 2000,
  quantity: 1
});

defineEmits(['submit']);
</script>
