<script lang="ts" setup>
import { ref,computed } from "vue"
import PlaceSelector from "./components/PlaceSelector.vue"
import TimeSelector from "./components/TimeSelector.vue"
import { useRouter } from 'vue-router'

defineOptions({
  name: "Hotel"
})

const destination = ref('')
const checkInTime = ref<Date>();
const checkOutTime = ref<Date>();
const router = useRouter()

const setDestination = (val : any) => {
  destination.value = val[val.length - 1]
}

const setCheckInTime = (val : any) => {
  checkInTime.value = val
}

const setCheckOutTime = (val : any) => {
  checkOutTime.value = val
}

// const formatDate = (date: Date | null) => {
//   if (!date) return '';
//   return date.toISOString().split('T')[0]; // 仅保留日期部分
// };


const searchTickets = () => {
  //const formattedCheckIn = formatDate(checkInTime.value);
  //const formattedCheckOut = formatDate(checkOutTime.value);
  router.push({
    name: 'Detail', 
    query: {
      destination: encodeURIComponent(destination.value),
      checkInTime: checkInTime.value?.getTime(),
      checkOutTime: checkOutTime.value?.getTime()
    }
  });
}

const numberOfNights = computed(() => {
  if (checkInTime.value && checkOutTime.value) {
    const timeDifference = checkOutTime.value.getTime() - checkInTime.value.getTime();
    return timeDifference > 0 ? Math.ceil(timeDifference / (1000 * 60 * 60 * 24)) : 0;
  }
  return 0;
});    

const isSearchDisabled = computed(() => {
  return !destination.value || !checkInTime.value || !checkOutTime.value
})

</script>

<template>
  <div class="app-container">
    <el-card header="酒店查询">
      <div class="index-container">
        <PlaceSelector @updateValue="setDestination">目的地</PlaceSelector>
        <TimeSelector @updateValue='setCheckInTime'>请选择入住时间</TimeSelector>
        <div class="date-container" :style="{ visibility: numberOfNights > 0 ? 'visible' : 'hidden' }">入住{{ numberOfNights }}晚</div>
        <TimeSelector @updateValue='setCheckOutTime'>请选择退房时间</TimeSelector>
        <el-button type="primary" size="large" icon="search" :disabled="isSearchDisabled" @click="searchTickets">搜索</el-button>
      </div>
    </el-card>
  </div>
</template>


<style scoped>
.index-container{
  display: flex;
  flex-direction: row;
  align-items: center;
}
.index-container > * {
  margin: 0 5%;
}
.index-container .date-container{
  margin: 0
}
</style>
