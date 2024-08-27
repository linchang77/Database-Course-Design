<script lang="ts" setup>
import { ref,computed } from "vue"
import PlaceSelector from "./components/PlaceSelector.vue"
import TimeSelector from "./components/TimeSelector.vue"
import { useRouter } from 'vue-router'

defineOptions({
  name: "Airplane"
})

const departure = ref('')
const destination = ref('')
const departureTime = ref('')
const router = useRouter()

const setDeparture = (val : any) => {
  departure.value = val[val.length - 1]
}

const setDestination = (val : any) => {
  destination.value = val[val.length - 1]
}


const setDepartureTime = (val : any) => {
  departureTime.value = val
  console.log(val)
}

const searchTickets = () => {
      console.log("出发地"+departure.value,'目的地'+destination.value,'时间'+departureTime.value)
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
  return !departure.value || !destination.value || !departureTime.value
})

</script>

<template>
  <div class="app-container">
    <el-card header="机票查询">
      <div class="index-container">
        <PlaceSelector @updateValue="setDeparture">目的地</PlaceSelector>
        <PlaceSelector @updateValue="setDestination">出发地</PlaceSelector>
        <TimeSelector @updateValue='setDepartureTime'>请选择出发时间</TimeSelector>
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
