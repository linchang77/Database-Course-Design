<script lang="ts" setup>
defineOptions({
  name: "Airplane"
})

import { ref, computed } from "vue"
import PlaceSelector from "./components/PlaceSelector.vue"
import TimeSelector from "./components/TimeSelector.vue"
import AddScheduleTicket from "./components/AddScheduleTicket.vue"
import { useSearchResultsStore } from "@/store/modules/searchResults"
import { storeToRefs } from 'pinia'
import { checkPermission } from "@/utils/permission"
const departure = ref("")
const destination = ref("")
const departureTime = ref("")

const setDeparture = (val: any) => {
  departure.value = val[val.length - 1]
  console.log("departure.value:", departure.value)
}

const setDestination = (val: any) => {
  destination.value = val[val.length - 1]
  console.log("destination.value:", destination.value)
}

const setDepartureTime = (val: any) => {
  departureTime.value = val
  console.log("departureTime.value:", departureTime.value)
}

const isSearchDisabled = computed(() => {
  return !departure.value || !destination.value || !departureTime.value
})

import axios from "axios"

const store = useSearchResultsStore()
const { searchResults } = storeToRefs(store)

async function fetchTickets() {
  const url = `https://123.60.14.84/api/Vehicle/info/plane,${destination.value},${departure.value},${encodeURIComponent(departureTime.value)}`
  console.log("url:", url)
  axios
    .get(url)
    .then((response) => {
      store.setSearchResults(response.data)
      console.log("searchResults:", response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}


function recordIndex(index: number) {
  store.index = index
  console.log("index:", store.index)
}

function calculateTimeDifference(departureTime: string, arrivalTime: string): { hours: number, minutes: number } {
  const departure = new Date(departureTime);
  const arrival = new Date(arrivalTime);

  // 计算时间差的毫秒数
  const timeDifferenceMilliseconds = arrival.getTime() - departure.getTime();

  // 将毫秒转换为小时和分钟
  const hours = Math.floor(timeDifferenceMilliseconds / (1000 * 60 * 60));
  const minutes = Math.round((timeDifferenceMilliseconds % (1000 * 60 * 60)) / (1000 * 60));

  return { hours, minutes };
}

</script>

<template>
  <div class="app">
    <AddScheduleTicket v-if="checkPermission(['admin'])" />
    <div class="app-container">
      <el-card header="机票查询">
        <div class="index-container">
          <PlaceSelector @updateValue="setDestination">目的地</PlaceSelector>
          <PlaceSelector @updateValue="setDeparture">出发地</PlaceSelector>
          <TimeSelector @updateValue="setDepartureTime">请选择出发时间</TimeSelector>
          <el-button type="primary" size="large" icon="search" :disabled="isSearchDisabled" @click="fetchTickets"
            >搜索</el-button
          >
        </div>
      </el-card>
    </div>

    <div class="flight-list">
      <span>
        <el-card class="flight-card" shadow="hover" v-for="(flight, index) in searchResults" :key="index">
          <div index="0" class="flight-item">
            <div>
              <div>
                <div class="flight-item">
                  <div class="flight-box">
                    <div class="flight-row">
                      <div class="flight-airline">
                        <!-- can be airline logo -->
                        <div class="airline-name">
                          <span>{{ flight.vehicleId }}</span>
                        </div>
                        <div class="plane">
                          <div class="plane">
                            <span class="plane-No">
                              <span class>{{ flight.vehicleModel }}</span>
                            </span>
                          </div>
                        </div>
                      </div>
                      <div class="flight-detail">
                        <div class="depart-box">
                          <div class="time">{{ flight.departureTime.split("T")[1] }}</div>
                          <div class="airport">
                            <span>Departure</span>
                            <span>Airport</span>
                            <br />
                            <span>{{ flight.departureStation }}</span>
                          </div>
                        </div>
                        <div class="arrow-box">
                          <i class="arrow-oneway">to</i>
                        </div>
                        <div class="arrive-box">
                          <div class="time">{{ flight.arrivalTime.split("T")[1] }}</div>
                          <div class="airport">
                            <span>Arrival</span>
                            <span>Airport</span>
                            <br />
                            <span>{{ flight.arrivalStation }}</span>
                          </div>
                        </div>
                      </div>
                      <div class="flight-duration">
                        {{ calculateTimeDifference(flight.departureTime, flight.arrivalTime).hours }}小时
                        {{ calculateTimeDifference(flight.departureTime, flight.arrivalTime).minutes }}分钟
                      </div>
                      <div class="flight-seat">{{ flight.ticketType }}</div>
                    </div>
                  </div>
                  <div class="flight-price">¥{{ flight.ticketPrice }}</div>
                  <el-button type="primary" @click="recordIndex(index)">
                    <a href="http://localhost:3333/#/transport/airplane/order">购票</a>
                  </el-button>
                </div>
              </div>
            </div>
          </div>
        </el-card>
      </span>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.index-container {
  display: flex;
  flex-direction: row;
  align-items: center;
}
.index-container > * {
  margin: 0 5%;
}

#submit {
  margin-top: 20px;
  margin-bottom: 20px;
  background-color: #409eff;
  color: #fff;
  font-size: 16px;
  width: 150px;
  height: 40px;
  cursor: pointer;
}
.flight-price {
  font-size: 25px;
  color: #ff5722;
  font-weight: bold;
  margin-left: 20px;
  margin-right: 20px;
}
.flight-box {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 10px;
  border-radius: 10px;
  background-color: #f5f5f5;
}
.flight-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}
.flight-list {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  margin: 20px;
}

.flight-card {

  margin: 10px;
  box-sizing: border-box; /* 包含边框和内边距在元素总宽高内 */
}

.flight-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.flight-airline {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.airline-name {
  font-size: 30px;
  font-weight: bold;
  margin-bottom: 5px;
}

.plane-No {
  font-size: 20px;
  color: gray;
}

.flight-detail {
  flex: 2;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-left: 10px;
}

.depart-box,
.arrive-box {
  text-align: center;
}

.time {
  flex-grow: 1;
  font-size: 24px;
  font-weight: bold;
}

.airport {
  font-size: 16px;
  color: gray;
}

.arrow-box {
  display: flex;
  flex: 2;
  flex-direction: column;
  align-items: center;
}

.flight-duration {
  width: 400px;
  flex: 1;
  font-size: 25px;
  color: gray;
  margin-left: 70px;
  margin-right: 30px;
}
.flight-seat {
  width: 40px;
  flex: 1;
  font-size: 25px;
  color: gray;
  margin-left: 20px;
  margin-right: 10px;
}
.arrow-oneway {
  font-size: 20px;
  font-weight: bold;
}
</style>
