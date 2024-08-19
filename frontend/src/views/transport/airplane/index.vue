<script lang="ts" setup>
//import { reactive } from "vue"

defineOptions({
  name: "Airplane"
})

//const text = ref("")

// const flights = reactive([
//   {
//     "1234": {
//       airline: "Airline Name",
//       flightNo: "1234",
//       departureTime: "12:00",
//       departureAirport: "Departure Airport",
//       arrivalTime: "12:30",
//       arrivalAirport: "Arrival Airport",
//       duration: "24小时60分钟",
//       price: 2000
//     }
//   }
// ])
import { ref } from "vue"
import axios from "axios"
const searchResults = ref([
  {
    "1234": {
      vehicleId: 1234,
      vehicleType: "Airplane",
      departureCity: "上海",
      arrivalCity: "北京",
      departureTime: "2022-01-01 12:00:00",
      arrivalTime: "2022-01-01 12:30:00",
      departureStation: "上海虹桥国际机场",
      arrivalStation: "BJS"
    }
  }
])

// 模拟查询参数
const queryParams = ref({
  departureDate: "", // 出行日期
  departureCity: "", // 出发城市
  arrivalCity: "" // 到达城市
})

async function fetchTickets() {
  axios
    .get(`https://123.60.14.84/api/ScenicSpot/${encodeURIComponent("上海")}`)
    .then((response) => {
      searchResults.value = response.data
    })
    .catch((error) => {
      console.error(error)
    })
}

function submit() {
  console.log(searchResults.value)
}
</script>

<template>
  <div class="flight-list">
    <span>
      <el-botton id="submit" type="primary" @click="submit">提交订单</el-botton>
      <el-card class="flight-card" shadow="hover" v-for="flight in searchResults" :key="flight">
        <div index="0" class="flight-item">
          <div>
            <div>
              <div class="flight-item">
                <div class="flight-box">
                  <div class="flight-row">
                    <div class="flight-airline">
                      <!-- can be airline logo -->
                      <div class="airline-name">
                        <span>{{ flight[1234].vehicleId }}</span>
                      </div>
                      <div class="plane">
                        <div class="plane">
                          <span class="plane-No">
                            1234
                            <span class>机型</span>
                          </span>
                        </div>
                      </div>
                    </div>
                    <div class="flight-detail">
                      <div class="depart-box">
                        <div class="time">12:00</div>
                        <div class="airport">
                          <span>Departure</span>
                          <span>Airport</span>
                        </div>
                      </div>
                      <div class="arrow-box">
                        <i class="arrow-oneway">to</i>
                      </div>
                      <div class="arrive-box">
                        <div class="time">12:30</div>
                        <div class="airport">
                          <span>Arrival</span>
                          <span>Airport</span>
                        </div>
                      </div>
                    </div>
                    <div class="flight-duration">24小时60分钟</div>
                  </div>
                </div>
                <div class="flight-price">¥2000</div>
                <el-input-number
                  step="1"
                  step-strict="true"
                  min="0"
                  max="10"
                  class="numOfTicket"
                  placeholder="请输入数量"
                  controls-position="right"
                  size="mini"
                  v-model="searchResults"
                  >100
                </el-input-number>
              </div>
            </div>
          </div>
        </div>
      </el-card>
    </span>
  </div>
</template>

<style lang="scss" scoped>
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
