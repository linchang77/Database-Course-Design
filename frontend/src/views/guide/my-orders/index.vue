<script lang="ts" setup>
import { onMounted, ref } from "vue"
import { ElMessage, ElMessageBox } from "element-plus"
import type { Action } from "element-plus"
import { Search } from "@element-plus/icons-vue"
import axios from "axios"
import { useUserStoreHook } from '@/store/modules/user';

const userStore = useUserStoreHook();
const userRole = userStore.roles
//const userId = ref<string | null>(localStorage.getItem('id'))
//const userRole = "guide"
const userId = ref(5)

// 定义订单的响应类型
interface BaseOrder {
  orderId: number
  orderType?: string
  status?: string
  orderDate?: string
  price?: number
}

// 定义不同类型订单的详细信息接口
interface GuideOrder extends BaseOrder {
  orderType: "GuideOrder"
  service: string
  userName: string
  userId: number
  serviceBeginDate?: string
  serviceEndDate?: string
}

interface TourOrder extends BaseOrder {
  orderType: "TourOrder"
  groupId?: number
  groupName?: string
  userId: number
  userName: string
  orderNumber: number
  startDate?: string
  endDate?: string
}

// 更多筛选选项
const options = [
  { value: "全部订单", label: "全部订单" },
  { value: "导游", label: "导游" },
  { value: "旅行团", label: "旅行团" }
]

// 筛选用的双向绑定
const order_id_input = ref("")
const user_id_input = ref("")
const order_type_input = ref("全部订单")
const date_input = ref("")

type Order = GuideOrder | TourOrder

const orders = ref<Order[]>([])
const total = ref(0)
const showEmptyMessage = ref(false) // 用于控制是否显示“暂无订单数据”
const categoryFilter = ref("")
const statusFilter = ref("")
const startDate = ref("")
const endDate = ref("")

const apiUrl = "https://123.60.14.84/api/Order"

// 获取订单列表
const fetchOrders = () => {
  axios
    .get(`https://123.60.14.84:11100/api/Guide/5/filter/`, {
    params: {
        guideId: userId.value,
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
            case "TourOrder":
              return {
                ...order,
                groupId: order.groupId,
                groupName: order.groupName,
              }
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
  user_id_input.value = ""
  order_type_input.value = "全部订单"
  date_input.value = ""
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
    const response = await axios.get(`${apiUrl}/${userRole}/${userId.value}/${orderId}`, {})
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

// 同时筛选订单
const filterOrders = () => {
  order_id_input.value = ""
  const category = ref("")
  const startDateValue = date_input.value[0]
  const endDateValue = date_input.value[1]
  switch (order_type_input.value) {
    case "全部订单":
      category.value = ""
      break
    case "导游":
      category.value = "GuideOrder"
      break
    case "旅行团":
      category.value = "TourOrder"
      break
    default:
      category.value = ""
  }
  axios
    .get(`https://123.60.14.84/api/Guide/${userId.value}/filter/`, {
    params: {
        OrderType: category.value,
        UserId: user_id_input.value,
        startDate: startDateValue,
        EndDate: endDateValue
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
            case "TourOrder":
              return { ...order, ...order.TourOrderDetail }
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

// 取消订单
async function deleteOrder(orderId: number) {
  try {
    const response = await axios.delete(`${apiUrl}/${userRole}/${userId.value}/${orderId}`, {
      headers: {
        "Content-Type": "application/json"
      }
    })
    // 直接使用 axios 解析好的数据
    const data = response.data
    console.log(data.message) // 显示成功消息
    alert(`订单号${orderId}的订单已取消.`)
    fetchOrders() // 刷新订单列表
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
  fetchOrders()
})

// 格式化订单状态显示
const formatPayState = (status: string) => {
  const stateMap: Record<string, string> = {
    Pending: "待支付",
    Completed: "已支付",
    Cancelled: "已取消"
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

// 格式化出行订单的交通类型显示
const formatTransport = (status: string) => {
  const stateMap: Record<string, string> = {
    plane: "飞机",
    train: "火车高铁",
    car: "大巴"
  }
  return stateMap[status] || "未知类型"
}


// 确认取消订单弹窗
const openCancel = (orderId: number) => {
  ElMessageBox.confirm("确认要取消订单吗？", "取消订单确认", {
    confirmButtonText: "确认",
    cancelButtonText: "取消",
    type: "warning",
    callback: (action: Action) => {
      if (action === "confirm") {
        deleteOrder(orderId)
        ElMessage({
          type: "success",
          message: "正在进行取消！"
        })
      } else {
        ElMessage({
          type: "info",
          message: "取消订单已取消！"
        })
      }
    }
  })
}

// 格式化时间到日
function formatDateToDay(dateString?: string): string {
  if (!dateString) {
    return "暂无"
  }
  // 解析日期字符串
  const date = new Date(dateString)

  // 获取年、月、日
  const year = date.getFullYear()
  const month = String(date.getMonth() + 1).padStart(2, "0")
  const day = String(date.getDate()).padStart(2, "0")

  // 格式化为需要的字符串
  return `${year}年${month}月${day}日`
}
</script>

<template>
  <div class="order-container">
    <div class="filter-box">
      <div class="first-row">
        <span class="word"> 订单号 </span>
        <el-input
          v-model="order_id_input"
          style="width: 210px"
          placeholder="请输入订单号"
          :prefix-icon="Search"
          @keyup.enter="searchOrder"
        />

        <el-button type="primary" class="button" @click="searchOrder"> 搜索 </el-button>
      </div>
      <div class="second=row" style="margin-top: 5px">
        <span class="word"> 用户编号 </span>
        <el-input
          v-model="user_id_input"
          style="width: 210px"
          placeholder="请输入用户编号"
          :prefix-icon="Search"
        />

        <span class="word"> 订单类型 </span>
        <el-select
          v-model="order_type_input"
          placeholder="请选择订单类型"
          style="width: 210px"
        >
          <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
        </el-select>

        <span class="word"> 服务日期 </span>
        <el-date-picker
          v-model="date_input"
          type="daterange"
          range-separator="To"
          start-placeholder="开始时间"
          end-placeholder="结束时间"
          size="default"
        />

        <el-button type="primary" class="button" @click="filterOrders"> 筛选 </el-button>
      </div>
    </div>

    <!-- Main container for displaying orders -->
    <el-scrollbar height="700px" style="margin-top: 10px">
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
              <span v-if="order.orderType === 'GuideOrder'">订单编号：{{ order.orderId }}</span>
              <span v-else>旅行团编号：{{ (order as TourOrder).groupId }}</span>
              <span v-if="order.orderType === 'GuideOrder'">订单类型：{{ formatCategory(order.orderType) }}</span>
              <span v-else>订单类型：旅行团</span>
            </div>
            <div class="body">
              <div class="column orders">
                <!-- 根据订单类型显示不同的订单详情 -->
                <!-- 导游订单 -->
                <ul v-if="order.orderType === 'GuideOrder'">
                  <li>服务内容：{{ (order as GuideOrder).service }}</li>
                  <li>用户编号：{{ (order as GuideOrder).userId }}</li>
                  <li>用户姓名：{{ (order as GuideOrder).userName }}</li>
                  <li>
                    服务时间：{{ formatDateToDay((order as GuideOrder).serviceBeginDate) }} 至 
                    {{ formatDateToDay((order as GuideOrder).serviceEndDate) }}
                  </li>
                </ul>
                <ul v-else>
                  <li>旅行团：{{ (order as TourOrder).groupName }}</li>
                  <li>服务时间：{{ formatDateToDay((order as TourOrder).startDate) }} 至 
                  {{ formatDateToDay((order as TourOrder).endDate) }}</li>
                </ul>
              </div>
              <div class="column state">
                <!-- 根据订单状态显示不同的操作按钮 -->
                <p v-if="order.status === 'Completed'">
                  <a href="javascript:;" class="del" @click="openCancel(order.orderId)">申请取消</a>
                </p>
              </div>
              <div class="column amount">
                <p class="red" v-if="order.orderType === 'GuideOrder'">¥{{ order.price?.toFixed(2) }}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </el-scrollbar>
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
    padding: 10px 0; 

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
  margin-top: -10px;
  color: #888;
}
.order-item {
  margin-bottom: 15px;
  border: 1px solid #dcdcdc;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);

  .head {
    height: 50px;
    line-height: 50px;
    background: #f0f0f0; 
    padding: 0 20px;
    overflow: hidden;
    font-weight: bold; 

    span {
      margin-right: 20px;
      color: #333; 

      &.down-time {
        margin-right: 0;
        float: right;

        i {
          vertical-align: middle;
          margin-right: 3px;
        }

        b {
          vertical-align: middle;
          font-weight: bold; 
        }
      }
    }
  }

  .body {
    display: flex;
    align-items: stretch;
    padding: 0px 20px; 

    .column {
      border-left: 1px solid #f5f5f5;
      text-align: center;
      padding: 10px;

      > p {
        padding-top: 10px;
        margin-bottom: 5px;
        color: #555; 
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
                  font-weight: bold; 
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
              font-weight: bold; 
              font-size: larger;
              color: #cf4444; 
            }

            .count {
              width: 80px;
              font-weight: bold; 
            }
          }
        }
      }

      &.state {
        width: 120px;
        display: flex; 
        flex-direction: column; 
        justify-content: center; 
        padding-bottom: 5%;
        .pay:hover {
          color: #3498db;
        }
        .del:hover {
          color: #ff4d4f;
        }
      }

      &.amount {
        width: 150px;
        display: flex; 
        flex-direction: column; 
        justify-content: center; 
        padding-bottom: 5%;
        .red {
          color: #3498db;
          font-weight: bold; 
          font-size: larger;
        }
      }
    }
  }
}
</style>
