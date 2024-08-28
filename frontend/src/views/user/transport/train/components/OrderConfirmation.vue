<template>
  <el-form :model="orderInfo" label-width="120px">
    <el-form-item label="列车ID">
      <span>{{ flight.vehicleId }}</span>
    </el-form-item>
    <el-form-item label="列车型号">
      <span>{{ flight.vehicleModel }}</span>
    </el-form-item>
    <el-form-item label="出发地">
      <span>{{ flight.departureCity }}</span>
    </el-form-item>
    <el-form-item label="目的地">
      <span>{{ flight.arrivalCity }}</span>
    </el-form-item>
    <el-form-item label="出发时间">
      <span>{{ flight.departureTime }}</span>
    </el-form-item>
    <el-form-item label="到达时间">
      <span>{{ flight.arrivalTime }}</span>
    </el-form-item>
    <el-form-item label="出发车站">
      <span>{{ flight.departureStation }}</span>
    </el-form-item>
    <el-form-item label="到达车站">
      <span>{{ flight.arrivalStation }}</span>
    </el-form-item>
    <el-form-item label="座位类型">
      <span>{{ flight.ticketType }}</span>
    </el-form-item>
    <el-form-item label="票价">
      <span>{{ flight.ticketPrice }}元</span>
    </el-form-item>

    <el-form-item>
      <el-button type="primary" @click="$emit('submit')">下一步</el-button>
    </el-form-item>
  </el-form>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { defineEmits } from 'vue'

type Flight = {
  vehicleId: string;
  vehicleType: string;
  vehicleModel: string;
  departureCity: string;
  arrivalCity: string;
  departureTime: string;
  arrivalTime: string;
  departureStation: string;
  arrivalStation: string;
  ticketId: number;
  ticketType: string;
  ticketPrice: number;
  ticketRemaining: number;
};

const orderInfo = defineProps({
  flight: {
    type: Object as () => Flight,
    required: true
  }
})
console.log("Order", orderInfo.flight)

defineEmits(['submit']);
</script>
