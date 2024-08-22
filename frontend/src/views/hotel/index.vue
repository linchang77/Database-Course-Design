<script lang="ts" setup>
import { ref,computed } from "vue"
import PlaceSelector from "./components/PlaceSelector.vue"
import TimeSelector from "./components/TimeSelector.vue"
import { useRouter } from 'vue-router'

defineOptions({
  name: "Hotel"
})

const destination = ref('')
const chekInTime = ref('')
const chekOutTime = ref('')
const router = useRouter()

const setDestination = (val : any) => {
  destination.value = val[val.length - 1]
}


const setCheckInTime = (val : any) => {
  chekInTime.value = val
  console.log(val.getDate())
}

const setCheckOutTime = (val : any) => {
  chekOutTime.value = val
  console.log(val.getDate())
}

const searchTickets = () => {
      console.log('目的地'+destination.value,'入住时间'+chekInTime.value,'退房时间'+chekOutTime.value)
      // router.push({
      //   name: 'TicketDetailsPage',
      //   query: {
      //     departure: departure.value,
      //     destination: destination.value,
      //     departureTime: departureTime.value
      //   }
      // })
    }

const isSearchDisabled = computed(() => {
  return !destination.value || !chekInTime.value || !chekOutTime.value
})

</script>

<template>
  <div class="app-container">
    <el-card header="酒店查询">
      <div class="index-container">
        <PlaceSelector @updateValue="setDestination">目的地</PlaceSelector>
        <TimeSelector @updateValue='setCheckInTime'>请选择入住时间</TimeSelector>
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
</style>
