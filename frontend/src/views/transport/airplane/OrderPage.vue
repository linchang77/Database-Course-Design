<template>
  <div>
  <el-steps :active="currentStep - 1" finish-status="success">
    <el-step title="乘客信息" />
    <el-step title="车票信息确认" />
    <el-step title="完成" />
  </el-steps>

  <div v-if="currentStep === 1">
    <PassengerInfoForm @submit="nextStep" />
  </div>

  <div v-if="currentStep === 2">
    <OrderConfirmation @submit="nextStep" />
  </div>

  <div v-if="currentStep === 3">
    <OrderCompletion @submit="prevStep" />
  </div>
  </div>
</template>

<script lang="ts" setup>
import PassengerInfoForm from './components/PassengerInfoForm.vue';
import OrderConfirmation from './components/OrderConfirmation.vue';
import OrderCompletion from './components/OrderCompletion.vue';

// ... 上面定义的状态和函数
import { ref } from "vue";
import { useRouter } from "vue-router";


const currentStep = ref(1); // 初始步骤设置为1
const router = useRouter();

function nextStep() {
  if (currentStep.value < 3) {
    currentStep.value++;
  }
}

function prevStep() {
  if (currentStep.value > 1) {
    currentStep.value--;
  }
}

</script>
