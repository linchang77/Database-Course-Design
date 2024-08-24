<script lang="ts" setup>
//import { reactive } from "vue"

defineOptions({
  name: "Airplane"
})


import { ref, computed, onMounted } from "vue"
import PlaceSelector from "./components/PlaceSelector.vue"
import TimeSelector from "./components/TimeSelector.vue"
import { useRouter } from "vue-router"

const departure = ref("")
const destination = ref("")
const departureTime = ref("")
const router = useRouter()

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
// {
//     {
//     "vehicleId": "1234",
//     "vehicleType": "plane",
//     "vehicleModel": "波音373(中)",
//     "departureCity": "上海",
//     "arrivalCity": "北京",
//     "departureTime": "2024-08-18T08:10:00",
//     "arrivalTime": "2024-08-18T10:35:00",
//     "departureStation": "浦东国际机场T1",
//     "arrivalStation": "大兴国际机场",
//     "ticketId": 6.0,
//     "ticketType": "经济舱",
//     "ticketPrice": 1479.0,
//     "ticketRemaining": 100.0
//     }
//   }
const searchResults = ref([
  {
    "vehicleId": "1234",
    "vehicleType": "plane",
    "vehicleModel": "波音373(中)",
    "departureCity": "上海",
    "arrivalCity": "北京",
    "departureTime": "2024-08-18T08:10:00",
    "arrivalTime": "2024-08-18T10:35:00",
    "departureStation": "浦东国际机场T1",
    "arrivalStation": "大兴国际机场",
    "ticketId": 6.0,
    "ticketType": "经济舱",
    "ticketPrice": 1479.0,
    "ticketRemaining": 100.0
  }
])



const passengerInfo = ref({
  name: "",
  phone: "",
  idCard: ""
});

const orderInfo = ref({
  flight: searchResults.value[0], // 默认使用第一个航班
  price: 2000,
  quantity: 1
});

async function fetchTickets() {
  const url = `https://123.60.14.84/api/Vehicle/info/plane,${destination.value},${departure.value},${encodeURIComponent(departureTime.value)}`
  console.log("url:", url)
  axios
    .get(url)
    .then((response) => {
      searchResults.value = response.data
      console.log("searchResults:", response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}

function submit() {
  console.log(searchResults.value)
}

function submitOrder() {
  console.log("Submitting order:", passengerInfo.value, orderInfo.value)
  goToOrderPage() // 跳转到订单页面
}

function goToOrderPage() {
  console.log(router.currentRoute.value)
  router.push('/order');
  console.log(router.currentRoute.value)
}

</script>

<template>
  <div class="app">
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
        <el-botton id="submit" type="primary" @click="submit">提交订单</el-botton>
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
                            <span>{{ flight.departureCity }}</span>
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
                            <span>{{ flight.departureCity }}</span>
                          </div>
                        </div>
                      </div>
                      <div class="flight-duration">24小时60分钟</div>
                    </div>
                  </div>
                  <div class="flight-price">{{ flight.ticketPrice }}</div>
                  <el-button type="primary">
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
  font-size: 18px;
  color: #ff5722;
  font-weight: bold;
  margin-left: 10px;
  margin-right: 10px;
}
.flight-box {
  width: 550px;
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
  justify-content: flex-start;
  margin: 20px;
}

.flight-card {
  width: 800px;
  margin: 10px;
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
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 5px;
}

.plane-No {
  font-size: 16px;
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
  width: 180px;
  flex: 1;
  font-size: 18px;
  color: gray;
  margin-left: 20px;
}

.arrow-oneway {
  font-size: 20px;
  font-weight: bold;
}
</style>
