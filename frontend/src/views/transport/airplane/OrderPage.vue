<template>
  <div>
  <el-steps :active="currentStep - 1" finish-status="success">
    <el-step title="车票信息确认" />
    <el-step title="乘客信息" />
    <el-step title="完成" />
  </el-steps>

  <div v-if="currentStep === 1">
    <OrderConfirmation  v-bind:flight="flight" @submit="nextStep" />
  </div>

  <div v-if="currentStep === 2">
    <PassengerInfoForm  @next-step="nextStep" @prev-step="prevStep" :flight="flight" />
  </div>

  <div v-if="currentStep === 3">
    <OrderCompletion :search-results="searchResults" @submit="prevStep" />
  </div>
  </div>
</template>

<script lang="ts" setup>
import PassengerInfoForm from './components/PassengerInfoForm.vue';
import OrderConfirmation from './components/OrderConfirmation.vue';
import OrderCompletion from './components/OrderCompletion.vue';
import { useSearchResultsStore } from "@/store/modules/searchResults"
import { storeToRefs } from 'pinia'

// ... 上面定义的状态和函数
import { ref } from "vue";


const currentStep = ref(1); // 初始步骤设置为1

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

const store = useSearchResultsStore()
const { searchResults } = storeToRefs(store)
const flight = searchResults.value[store.index]
console.log("flight", flight)
</script>
