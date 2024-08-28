<template>

  <div class="order-page">
    <el-steps :active="currentStep - 1" finish-status="success">
      <el-step title="车票信息确认" />
      <el-step title="乘客信息" />
      <el-step title="完成" />
    </el-steps>

    <div class="step-content step-one" v-if="currentStep === 1 ">
      <OrderConfirmation  v-bind:flight="flight" @submit="nextStep" />
    </div>

    <div class="step-content step-two" v-if="currentStep === 2">
      <PassengerInfoForm  @next-step="nextStep" @prev-step="prevStep" :flight="flight" />
    </div>

    <div class="step-content step-three" v-if="currentStep === 3">
      <OrderCompletion :search-results="searchResults" @submit="prevStep" />
    </div>
  </div>
</template>

<script lang="ts" setup>
import PassengerInfoForm from './components/PassengerInfoForm.vue';
import OrderConfirmation from './components/OrderConfirmation.vue';
import OrderCompletion from './components/OrderCompletion.vue';
import { useSearchResultsStoreForBus } from "@/store/modules/searchResultsForBus"
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

const store = useSearchResultsStoreForBus()
const { searchResultsForBus } = storeToRefs(store)
const flight = searchResultsForBus.value[store.index]
console.log("flight", flight)
</script>

<style lang="scss" scoped>
.order-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 20px; /* 间距 */

  .el-steps {
    width: 80%; /* 宽度自适应 */
  }

  .step-content {
    width: 100%; /* 宽度自适应 */

    padding: 20px; /* 内边距 */
    box-sizing: border-box; /* 包含边框和内边距在元素总宽高内 */

  }

  .step-one {
    flex: 0 0 auto; /* 固定宽度 */
  }

  .step-two {
    flex: 1 1 auto; /* 自适应宽度 */
    display: flex;
    justify-content: center; /* 居中对齐 */
  }

  .step-three {
    flex: 0 0 auto; /* 固定宽度 */
    text-align: center; /* 文字右对齐 */
  }
}
</style>
