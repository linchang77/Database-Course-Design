<template>
  <el-form :model="passengerInfo" label-width="120px">
    <el-form-item label="姓名">
      <el-input v-model="passengerInfo.name" />
    </el-form-item>
    <el-form-item label="手机号">
      <el-input v-model="passengerInfo.phone" />
    </el-form-item>
    <el-form-item label="身份证号">
      <el-input v-model="passengerInfo.idCard" />
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="$emit('submit')">下一步</el-button>
    </el-form-item>
  </el-form>
</template>

<script lang="ts" setup>
import { ref } from "vue"
const passengerInfo = ref({
  name: "",
  phone: "",
  idCard: ""
});

defineEmits(['submit']);
</script>
