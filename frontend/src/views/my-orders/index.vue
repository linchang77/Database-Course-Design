<script lang="ts" setup>
import { onMounted, ref } from "vue"
import { ElMessage, ElMessageBox } from "element-plus"
import type { Action } from "element-plus"
import { Search } from "@element-plus/icons-vue"
import axios from "axios"

// 定义订单的响应类型
interface BaseOrder {
  orderId: number
  orderType: string
  status: string
  orderDate?: string
  price?: number
}

// 定义不同类型订单的详细信息接口
interface GuideOrder extends BaseOrder {
  orderType: "GuideOrder"
  service: string
  guideName: string
  guideGender: string
  serviceBeginDate?: string
  serviceEndDate?: string
}

interface HotelOrder extends BaseOrder {
  orderType: "HotelOrder"
  cityName?: string
  hotelName?: string
  hotelLocation?: string
  checkInDate?: string
  checkOutDate?: string
  roomType: string
}

interface ScenicOrder extends BaseOrder {
  orderType: "ScenicOrder"
  cityName?: string
  scenicSpotName: string
  ticketType: string
  ticketNumber?: number
  ticketDate: string
}

interface TourOrder extends BaseOrder {
  orderType: "TourOrder"
  groupId?: number
  groupName?: string
  guideId?: number
  guideName: string
  guideGender: string
  startDate?: string
  endDate?: string
}

interface Passenger {
  passengerId: string
  passengerName: string
}

interface VehicleOrder extends BaseOrder {
  orderType: "VehicleOrder"
  vehicleId?: string
  vehicleType?: string
  ticketId: number
  ticketType?: string
  ticketUserName: string
  ticketDepartureTime?: string
  ticketArrivalTime?: string
  ticketDepartureCity?: string
  ticketArrivalCity?: string
  ticketDepartureStation?: string
  ticketArrivalStation?: string
  passengers: Passenger[]
}

type Order = GuideOrder | HotelOrder | ScenicOrder | TourOrder | VehicleOrder

const orders = ref<Order[]>([])

const categoryFilter = ref("")
const statusFilter = ref("")
const startDate = ref("")
const endDate = ref("")
const userId = 22 // 根据需求替换为实际的用户ID
const userRole = "user"

const total = ref(0)
// const currentPage = ref(1)
// const pageSize = ref(5)
const showEmptyMessage = ref(false) // 新增，用于控制是否显示“暂无订单数据”

// 获取订单列表
const fetchOrders = () => {
  axios
    .get(`https://123.60.14.84/api/Order/role`, {
      params: {
        role: userRole, // 角色类型替换为实际角色
        Id: userId,
        // page: currentPage.value,
        // pageSize: pageSize.value,
        orderType: categoryFilter.value || undefined,
        statusType: statusFilter.value || undefined,
        start: startDate.value || undefined,
        end: endDate.value || undefined
      }
    })
    .then((response) => {
      console.log("API Response:", response.data) // 调试输出查看返回的数据结构
      // 遍历返回的数据并根据 orderType 将不同类型的订单添加到 orders 数组中
      const orderData = response.data // 直接使用 response.data 作为订单数据
      if (orderData && Array.isArray(orderData)) {
        orders.value = orderData.map((order: any) => {
          switch (order.orderType) {
            case "GuideOrder":
              return {
                ...order,
                service: order.service,
                guideId: order.guideId,
                guideName: order.guideName,
                guideGender: order.guideGender,
                serviceBeginDate: order.serviceBeginDate,
                serviceEndDate: order.serviceEndDate
              } as GuideOrder
            case "HotelOrder":
              return { ...order, ...order.HotelOrderDetail }
            case "ScenicOrder":
              return { ...order, ...order.ScenicOrderDetail }
            case "TourOrder":
              return { ...order, ...order.TourOrderDetail }
            case "VehicleOrder":
              return { ...order, ...order.VehicleOrderDetail }
            default:
              return order
          }
        })
        total.value = response.data.length || 0
        showEmptyMessage.value = orders.value.length === 0
      } else {
        console.error("Orders data is missing or not an array.")
        orders.value = [] // 确保 orders 不为空
        total.value = 0
        showEmptyMessage.value = true
      }
    })
    .catch((error) => {
      console.error("Error fetching orders:", error)
      showEmptyMessage.value = true
    })
}

// 按订单ID搜索订单
async function searchOrder() {
  const orderId = order_id_input.value
  if (!orderId) {
    // 如果订单号为空，显示全部订单
    try {
      // 调用函数获取所有订单
      await fetchOrders()
      showEmptyMessage.value = false
    } catch (error) {
      // 处理错误情况
      console.error("Error fetching all orders:", error)
      orders.value = []
      total.value = 0
      showEmptyMessage.value = true
    }
    return
  }

  try {
    // 调用后端 API 获取订单详情
    const response = await axios.get(`https://123.60.14.84/api/Order/role/${orderId}`, {
      params: { role: userRole, Id: userId }
    })
    // 处理搜索结果
    console.log("Order Details:", response.data)
    orders.value = [response.data] // 将搜索结果设置为订单列表
    total.value = 1 // 搜索结果总数
    showEmptyMessage.value = false
  } catch (error) {
    // 处理错误情况
    console.error("Error fetching order:", error)
    orders.value = []
    total.value = 0
    showEmptyMessage.value = true
  }
}

// 按订单分类筛选订单ok
const filterOrdersByCategory = () => {
  categoryFilter.value = order_type_input.value
  switch (order_type_input.value) {
    case "全部订单":
      categoryFilter.value = ""
      break
    case "导游":
      categoryFilter.value = "GuideOrder"
      break
    case "酒店":
      categoryFilter.value = "HotelOrder"
      break
    case "景点":
      categoryFilter.value = "ScenicOrder"
      break
    case "出行":
      categoryFilter.value = "VehicleOrder"
      break
    case "旅行团":
      categoryFilter.value = "TourOrder"
      break
    default:
      categoryFilter.value = ""
  }
  if (categoryFilter.value) {
    axios
      .get(`https://123.60.14.84/api/Order/role/category/${categoryFilter.value}`, {
        params: {
          role: userRole,
          Id: userId
        }
      })
      .then((response) => {
        if (response.data && response.data.length > 0) {
          orders.value = response.data
          total.value = response.data.length
        } else {
          orders.value = []
          showEmptyMessage.value = true
          total.value = 0
        }
      })
      .catch((error) => {
        console.error(error)
        orders.value = []
        total.value = 0
      })
  } else {
    fetchOrders()
  }
}

// 按订单状态筛选订单ok
const filterOrdersByStatus = () => {
  switch (order_status_input.value) {
    case "全部订单":
      statusFilter.value = ""
      break
    case "已支付":
      statusFilter.value = "Completed"
      break
    case "待支付":
      statusFilter.value = "Pending"
      break
    case "已取消":
      statusFilter.value = "Canceled"
      break
    default:
      statusFilter.value = ""
  }
  if (statusFilter.value) {
    axios
      .get(`https://123.60.14.84/api/Order/role/status/${statusFilter.value}`, {
        params: {
          role: userRole,
          Id: userId
        }
      })
      .then((response) => {
        if (response.data && response.data.length > 0) {
          orders.value = response.data
          total.value = response.data.length
        } else {
          orders.value = []
          total.value = 0
        }
      })
      .catch((error) => {
        console.error(error)
        orders.value = []
        total.value = 0
      })
  } else {
    fetchOrders()
  }
}

// 按时间段筛选订单ok
const filterByDate = () => {
  startDate.value = date_input.value[0]
  endDate.value = date_input.value[1]
  if (startDate.value && endDate.value) {
    axios
      .get(`https://123.60.14.84/api/Order/role/date-range`, {
        params: {
          role: userRole,
          Id: userId,
          start: startDate.value,
          end: endDate.value
        }
      })
      .then((response) => {
        if (response.data && response.data.length > 0) {
          orders.value = response.data
          total.value = response.data.length
        } else {
          orders.value = []
          total.value = 0
        }
      })
      .catch((error) => {
        console.error(error)
        orders.value = []
        total.value = 0
      })
  } else {
    fetchOrders()
  }
}

// 取消订单
async function deleteOrder(orderId: number) {
  try {
    const response = await axios.delete(`https://123.60.14.84/api/Order/role/${orderId}`, {
      params: { role: userRole, Id: userId }
    })
    // 直接使用 axios 解析好的数据
    const data = response.data
    console.log(data.message) // 显示成功消息
    alert(`订单号${orderId}的订单已取消.`)
  } catch (error) {
    // 判断错误类型并处理
    if (axios.isAxiosError(error)) {
      // 处理响应错误
      if (error.response) {
        // 请求已发出，服务器响应状态码不在2xx范围内
        console.error("Error:", error.response.data.Message)
        alert(`取消订单失败: ${error.response.data.Message}`)
      } else if (error.request) {
        // 请求已发出，但没有收到响应
        console.error("Error:", error.request)
        alert("取消订单时发生错误。")
      } else {
        // 其他错误
        console.error("Error:", error.message)
        alert("取消订单时发生错误。")
      }
    } else {
      // 非 axios 错误
      console.error("Error:", error)
      alert("取消订单时发生错误。")
    }
  }
}

// 初次加载时获取订单
onMounted(() => {
  console.log("Component mounted, fetching orders...")
  fetchOrders()
  // console.log("Component mounted, using mock orders...")
  // orders.value = mockOrders
})

// 格式化订单状态显示
const formatPayState = (status: string) => {
  const stateMap: Record<string, string> = {
    Pending: "待支付",
    Completed: "已支付",
    Canceled: "已取消"
  }
  return stateMap[status] || "未知状态"
}

// 格式化订单分类显示
const formatCategory = (status: string) => {
  const stateMap: Record<string, string> = {
    GuideOrder: "导游",
    HotelOrder: "酒店",
    ScenicOrder: "景点",
    TourOrder: "旅行团",
    VehicleOrder: "出行"
  }
  return stateMap[status] || "未知类型"
}

// 更多筛选选项
const status_options = [
  { value: "全部订单", label: "全部订单" },
  { value: "已支付", label: "已支付" },
  { value: "待支付", label: "待支付" },
  { value: "已取消", label: "已取消" }
]

const options = [
  { value: "全部订单", label: "全部订单" },
  { value: "酒店", label: "酒店" },
  { value: "出行", label: "出行" },
  { value: "景点", label: "景点" },
  { value: "导游", label: "导游" },
  { value: "旅行团", label: "旅行团" }
]

const order_id_input = ref("")
const order_status_input = ref("全部订单")
const order_type_input = ref("全部订单")
const date_input = ref("")

// 确认付款弹窗
const openPayment = (orderId: number) => {
  ElMessageBox.confirm("确认要付款吗？", "付款确认", {
    confirmButtonText: "确认",
    cancelButtonText: "取消",
    type: "warning",
    callback: (action: Action) => {
      if (action === "confirm") {
        // Call deleteOrder after the payment is confirmed
        deleteOrder(orderId)
        ElMessage({
          type: "success",
          message: "付款成功！"
        })
      } else {
        ElMessage({
          type: "info",
          message: "付款已取消"
        })
      }
    }
  })
}

// 确认取消订单弹窗
const openCancel = (orderId: number) => {
  ElMessageBox.confirm("确认要取消订单吗？", "取消订单确认", {
    confirmButtonText: "确认",
    cancelButtonText: "取消",
    type: "warning",
    callback: (action: Action) => {
      if (action === "confirm") {
        // Call deleteOrder after the cancellation is confirmed
        deleteOrder(orderId)
        ElMessage({
          type: "success",
          message: "取消订单成功！"
        })
      } else {
        ElMessage({
          type: "info",
          message: "取消订单已取消"
        })
      }
    }
  })
}

//确认退款弹窗
const openRefund = (orderId: number) => {
  ElMessageBox.confirm("确认要退款吗？", "退款确认", {
    confirmButtonText: "确认",
    cancelButtonText: "取消",
    type: "warning",
    callback: (action: Action) => {
      if (action === "confirm") {
        // Call deleteOrder after the refund is confirmed
        deleteOrder(orderId)
        ElMessage({
          type: "success",
          message: "退款成功！"
        })
      } else {
        ElMessage({
          type: "info",
          message: "退款已取消"
        })
      }
    }
  })
}

function formatDate(dateString?: string): string {
  if (!dateString) {
    return "暂无"
  }
  // 解析日期字符串
  const date = new Date(dateString)

  // 获取年、月、日、时、分、秒
  const year = date.getFullYear()
  const month = String(date.getMonth() + 1).padStart(2, "0")
  const day = String(date.getDate()).padStart(2, "0")
  const hours = String(date.getHours()).padStart(2, "0")
  const minutes = String(date.getMinutes()).padStart(2, "0")
  const seconds = String(date.getSeconds()).padStart(2, "0")

  // 格式化为需要的字符串
  return `${year}年${month}月${day}日 ${hours}:${minutes}:${seconds}`
}
</script>

<template>
  <div class="order-container">
    <div class="filter-box">
      <span class="word"> 订单号 </span>
      <el-input
        v-model="order_id_input"
        style="width: 210px"
        placeholder="请输入订单号"
        :prefix-icon="Search"
        @keyup.enter="searchOrder"
      />

      <span class="word"> 订单状态 </span>
      <el-select
        v-model="order_status_input"
        placeholder="请选择订单状态"
        style="width: 210px"
        @change="filterOrdersByStatus"
      >
        <el-option v-for="item in status_options" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>

      <span class="word"> 订单类型 </span>
      <el-select
        v-model="order_type_input"
        placeholder="请选择订单类型"
        style="width: 210px"
        @change="filterOrdersByCategory"
      >
        <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>

      <span class="word"> 日期 </span>
      <el-date-picker
        v-model="date_input"
        type="daterange"
        range-separator="To"
        start-placeholder="开始时间"
        end-placeholder="结束时间"
        size="default"
        @change="filterByDate"
      />

      <el-button type="primary" class="button" @click="filterOrdersByStatus"> 筛选 </el-button>
    </div>

    <!-- Main container for displaying orders -->
    <div class="main-container">
      <div class="holder-container" v-if="orders.length === 0 || showEmptyMessage">
        <el-empty description="暂无订单数据" />
      </div>
      <div v-else>
        <div class="number-of-order">
          <span>共 {{ orders.length }} 条订单记录</span>
        </div>
        <!-- 订单列表 -->
        <div class="order-item" v-for="order in orders" :key="order.orderId">
          <div class="head">
            <span v-if="order.orderDate">订单日期：{{ formatDate(order.orderDate) }}</span>
            <span v-else>订单日期：无</span>

            <span>订单编号：{{ order.orderId }}</span>
            <span>订单类型：{{ formatCategory(order.orderType) }}</span>
            <span>订单状态：{{ formatPayState(order.status) }}</span>
          </div>
          <div class="body">
            <div class="column orders">
              <!-- 根据订单类型显示不同的订单详情 -->
              <!-- 导游订单 -->
              <ul v-if="order.orderType === 'GuideOrder'">
                <li>服务内容：{{ (order as GuideOrder).service }}</li>
                <li>导游姓名：{{ (order as GuideOrder).guideName }}</li>
                <li>导游性别：{{ (order as GuideOrder).guideGender }}</li>
                <li>
                  服务时间：{{ formatDate((order as GuideOrder).serviceBeginDate) }} 至
                  {{ formatDate((order as GuideOrder).serviceEndDate) }}
                </li>
              </ul>
              <ul v-if="order.orderType === 'HotelOrder'">
                <li>酒店名称：{{ (order as HotelOrder).hotelName }}</li>
                <li>所在城市：{{ (order as HotelOrder).cityName }}</li>
                <li>入住日期：{{ formatDate((order as HotelOrder).checkInDate) }}</li>
                <li>退房日期：{{ formatDate((order as HotelOrder).checkOutDate) }}</li>
                <li>房型：{{ (order as HotelOrder).roomType }}</li>
              </ul>
              <ul v-if="order.orderType === 'ScenicOrder'">
                <li>门票类型: {{ (order as ScenicOrder).ticketType }}</li>
                <li>门票数量: {{ (order as ScenicOrder).ticketNumber }}</li>
                <li>游玩日期: {{ formatDate((order as ScenicOrder).ticketDate) }}</li>
                <li>景点名称：{{ (order as ScenicOrder).scenicSpotName }}</li>
                <li>所在城市：{{ (order as ScenicOrder).cityName }}</li>
              </ul>
              <ul v-if="order.orderType === 'TourOrder'">
                <li>旅行团编号：{{ (order as TourOrder).groupId }}</li>
                <li>旅行目的地：{{ (order as TourOrder).groupName }}</li>
                <li>导游编号：{{ (order as TourOrder).guideId }}</li>
                <li>导游姓名：{{ (order as TourOrder).guideName }}</li>
                <li>导游性别：{{ (order as TourOrder).guideGender }}</li>
                <li>开始日期：{{ formatDate((order as TourOrder).startDate) }}</li>
                <li>结束日期：{{ formatDate((order as TourOrder).endDate) }}</li>
              </ul>
              <ul v-if="order.orderType === 'VehicleOrder'">
                <li>交通类型：{{ (order as VehicleOrder).vehicleType }}</li>
                <li>出行票号：{{ (order as VehicleOrder).ticketId }}</li>
                <li>出发时间：{{ formatDate((order as VehicleOrder).ticketDepartureTime) }}</li>
                <li>到达时间：{{ formatDate((order as VehicleOrder).ticketArrivalTime) }}</li>
                <li>
                  起始站台：{{ (order as VehicleOrder).ticketDepartureCity }}市-{{
                    (order as VehicleOrder).ticketDepartureStation
                  }}
                </li>
                <li>
                  目的站台：{{ (order as VehicleOrder).ticketArrivalCity }}市-{{
                    (order as VehicleOrder).ticketArrivalStation
                  }}
                </li>
                <li v-for="passenger in (order as VehicleOrder).passengers" :key="passenger.passengerId">
                  乘客：{{ passenger.passengerName }} (ID: {{ passenger.passengerId }})
                </li>
              </ul>
            </div>
            <div class="column state">
              <!-- 根据订单状态显示不同的操作按钮 -->
              <p v-if="order.status === 'Pending'">
                <a href="javascript:;" class="pay" @click="openPayment(order.orderId)">立即付款</a>
              </p>
              <p v-if="order.status === 'Pending'">
                <a href="javascript:;" class="del" @click="openCancel(order.orderId)">取消订单</a>
              </p>
              <p v-if="order.status === 'Completed'">
                <a href="javascript:;" class="del" @click="openRefund(order.orderId)">申请退款</a>
              </p>
            </div>
            <div class="column amount">
              <p class="red">¥{{ order.price?.toFixed(2) }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="css">
.filter_box {
  margin: 10px;
}

.filter_box >>> .el-tabs__item {
  font-size: 18px;
}

.word,
.button {
  margin-left: 10px;
}
.word,
.button {
  margin-left: 10px;
}

.filter_box_all,
.filter_box_pending,
.filter_box_completed,
.filter_box_canceled {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  align-items: center;
}

.order-container {
  padding: 10px 20px;

  .pagination-container {
    display: flex;
    justify-content: center;
  }

  .main-container {
    min-height: 500px;
    padding: 10px 0; /* 调整整体容器的上下内边距 */

    .holder-container {
      min-height: 500px;
      display: flex;
      justify-content: center;
      align-items: center;
    }
  }
}

.number-of-order {
  margin-left: 10px;
  font-size: smaller;
  margin-bottom: 10px;
  color: #888;
}
.order-item {
  margin-bottom: 15px;
  border: 1px solid #dcdcdc;
  background-color: #fff; /* 设置白色背景颜色 */
  border-radius: 5px; /* 让订单项的边角稍微圆润 */
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* 添加阴影效果 */

  .head {
    height: 50px;
    line-height: 50px;
    background: #f0f0f0; /* 提升背景色的对比度 */
    padding: 0 20px;
    overflow: hidden;
    font-weight: bold; /* 加粗订单头部信息 */

    span {
      margin-right: 20px;
      color: #333; /* 提升文字颜色对比度 */

      &.down-time {
        margin-right: 0;
        float: right;

        i {
          vertical-align: middle;
          margin-right: 3px;
        }

        b {
          vertical-align: middle;
          font-weight: bold; /* 加粗时间信息 */
        }
      }
    }
  }

  .body {
    display: flex;
    align-items: stretch;
    padding: 0px 20px; /* 增加内容区域的内边距，减少内容之间的行间距 */

    .column {
      border-left: 1px solid #f5f5f5;
      text-align: center;
      padding: 10px;

      > p {
        padding-top: 10px;
        margin-bottom: 5px; /* 缩小段落之间的间距 */
        color: #555; /* 提升文字颜色对比度 */
      }

      &:first-child {
        border-left: none;
      }

      &.orders {
        flex: 1;
        padding: 0;
        align-self: center;

        ul {
          li {
            border-bottom: 1px solid #f5f5f5;
            padding: 10px;
            display: flex;
            align-items: center;

            &:last-child {
              border-bottom: none;
            }

            .image {
              width: 70px;
              height: 70px;
              border: 1px solid #f5f5f5;
            }

            .info {
              width: 220px;
              text-align: left;
              padding: 0 10px;

              p {
                margin-bottom: 5px;

                &.name {
                  height: 38px;
                  font-weight: bold; /* 加粗名称信息 */
                }

                &.attr {
                  color: #888;
                  font-size: 12px;

                  span {
                    margin-right: 5px;
                  }
                }
              }
            }

            .price {
              width: 100px;
              font-weight: bold; /* 加粗价格信息 */
              font-size: larger;
              color: #cf4444; /* 使用红色强调价格信息 */
            }

            .count {
              width: 80px;
              font-weight: bold; /* 加粗数量信息 */
            }
          }
        }
      }

      &.state {
        width: 120px;
        display: flex; /* 使用flex布局 */
        flex-direction: column; /* 垂直排列子元素 */
        justify-content: center; /* 子元素上下居中 */
        padding-bottom: 5%;
        .pay:hover {
          color: #3498db;
        }
        .del:hover {
          color: #ff4d4f; /* 使用鲜明的颜色显示删除操作 */
        }
      }

      &.amount {
        width: 150px;
        display: flex; /* 使用flex布局 */
        flex-direction: column; /* 垂直排列子元素 */
        justify-content: center; /* 子元素上下居中 */
        padding-bottom: 5%;
        .red {
          color: #3498db;
          font-weight: bold; /* 加粗金额信息 */
          font-size: larger;
        }
      }
    }
  }
}
</style>
