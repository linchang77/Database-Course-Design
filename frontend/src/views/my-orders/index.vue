<script lang="ts" setup>
import { onMounted, ref } from "vue"
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
}

type Order = GuideOrder | HotelOrder | ScenicOrder | TourOrder | VehicleOrder

const orders = ref<Order[]>([])

// 模拟订单数据
const mockOrders: Order[] = [
  {
    orderId: 1,
    orderType: "GuideOrder",
    status: "Completed",
    orderDate: "2024-08-01",
    price: 1500,
    service: "City Tour",
    guideName: "John Doe",
    guideGender: "Male",
    serviceBeginDate: "2024-08-01",
    serviceEndDate: "2024-08-02"
  },
  {
    orderId: 2,
    orderType: "HotelOrder",
    status: "Pending",
    orderDate: "2024-08-05",
    price: 200,
    cityName: "Beijing",
    hotelName: "Grand Hotel",
    checkInDate: "2024-08-10",
    checkOutDate: "2024-08-12",
    roomType: "Deluxe"
  },
  {
    orderId: 3,
    orderType: "ScenicOrder",
    status: "Canceled",
    orderDate: "2024-07-25",
    price: 80,
    cityName: "Shanghai",
    scenicSpotName: "The Bund",
    ticketType: "Adult",
    ticketNumber: 2,
    ticketDate: "2024-08-03"
  },
  {
    orderId: 4,
    orderType: "TourOrder",
    status: "Completed",
    orderDate: "2024-06-15",
    price: 3000,
    groupId: 101,
    groupName: "Golden Circle Tour",
    guideId: 55,
    guideName: "Jane Smith",
    guideGender: "Female",
    startDate: "2024-06-20",
    endDate: "2024-06-25"
  },
  {
    orderId: 5,
    orderType: "VehicleOrder",
    status: "Pending",
    orderDate: "2024-07-10",
    price: 500,
    vehicleId: "V12345",
    vehicleType: "Flight",
    ticketId: 789,
    ticketUserName: "Alice Johnson",
    ticketDepartureTime: "2024-07-15 08:00",
    ticketArrivalTime: "2024-07-15 10:00",
    ticketDepartureCity: "New York",
    ticketArrivalCity: "Los Angeles",
    ticketDepartureStation: "JFK",
    ticketArrivalStation: "LAX"
  }
]

const searchQuery = ref("")
const categoryFilter = ref("")
const statusFilter = ref("")
const startDate = ref("")
const endDate = ref("")
const userId = 1 // 根据需求替换为实际的用户ID

// 参数类型定义
interface Params {
  orderState: number
  page: number
  pageSize: number
}

// 页数、分页大小和订单总数
const params = ref<Params>({
  orderState: 0,
  page: 1,
  pageSize: 10
})
const total = ref(0)

// 获取订单列表
const fetchOrders = () => {
  axios
    .get(`https://123.60.14.84:11100/api/Order/role`, {
      params: {
        role: "guide", // 角色类型替换为实际角色
        Id: userId,
        page: params.value.page,
        pageSize: params.value.pageSize
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
        total.value = response.data.total || 0
      } else {
        console.error("Orders data is missing or not an array.")
        orders.value = [] // 确保 orders 不为空
        total.value = 0
      }
    })
    .catch((error) => {
      console.error("Error fetching orders:", error)
    })
}

// 按订单ID搜索订单
const searchOrder = () => {
  if (searchQuery.value) {
    axios
      .get(`https://123.60.14.84:11100/api/Order/role/${searchQuery.value}`, {
        params: {
          role: "guide",
          Id: userId
        }
      })
      .then((response) => {
        orders.value = [response.data]
      })
      .catch((error) => {
        console.error(error)
      })
  } else {
    fetchOrders()
  }
}

// 按订单分类筛选订单
const filterOrdersByCategory = () => {
  if (categoryFilter.value) {
    axios
      .get(`https://123.60.14.84:11100/api/Order/role/category/${categoryFilter.value}`, {
        params: {
          role: "User",
          Id: userId
        }
      })
      .then((response) => {
        orders.value = response.data
      })
      .catch((error) => {
        console.error(error)
      })
  } else {
    fetchOrders()
  }
}

// 按订单状态筛选订单
const filterOrdersByStatus = () => {
  if (statusFilter.value) {
    axios
      .get(`https://123.60.14.84/api/Order/role/status/${statusFilter.value}`, {
        params: {
          role: "User",
          Id: userId
        }
      })
      .then((response) => {
        orders.value = response.data
      })
      .catch((error) => {
        console.error(error)
      })
  } else {
    fetchOrders()
  }
}

// 按时间段筛选订单
const filterByDate = () => {
  if (startDate.value && endDate.value) {
    axios
      .get(`https://123.60.14.84/api/Order/role/date-range`, {
        params: {
          role: "User",
          Id: userId,
          start: startDate.value,
          end: endDate.value
        }
      })
      .then((response) => {
        orders.value = response.data
      })
      .catch((error) => {
        console.error(error)
      })
  } else {
    fetchOrders()
  }
}

// 删除订单
const deleteOrder = (orderId: number) => {
  axios
    .delete(`https://123.60.14.84/api/Order/role/${orderId}`, {
      params: {
        role: "User",
        Id: userId
      }
    })
    .then(() => {
      fetchOrders()
    })
    .catch((error) => {
      console.error(error)
    })
}

// 初次加载时获取订单
onMounted(() => {
  console.log("Component mounted, fetching orders...")
  fetchOrders()
  // console.log("Component mounted, using mock orders...")
  // orders.value = mockOrders
})

// tab切换处理
import type { TabsPaneContext } from "element-plus"
const activeName = ref("first")
const handleClick = (tab: TabsPaneContext, event: Event) => {
  console.log(tab, event)
}

// 页数切换处理
const pageChange = (page: number) => {
  console.log(page)
  params.value.page = page
  fetchOrders()
}

// 格式化订单状态显示
const fomartPayState = (status: string) => {
  const stateMap: Record<string, string> = {
    Pending: "待完成",
    Completed: "已完成",
    Canceled: "已取消"
  }
  return stateMap[status] || "未知状态"
}

// 更多筛选选项
const status_options = [
  { value: "全部订单", label: "全部订单" },
  { value: "已支付", label: "已支付" },
  { value: "待支付", label: "待支付" },
  { value: "已取消", label: "已取消" },
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

const value_all = ref("全部订单")
const value_pending = ref("全部订单")
const value_completed = ref("全部订单")
const value_canceled = ref("全部订单")

const order_id_all_input = ref("")
const order_id_pending_input = ref("")
const order_id_completed_input = ref("")
const order_id_canceled_input = ref("")

const date_all_input = ref("")
const date_pending_input = ref("")
const date_completed_input = ref("")
const date_canceled_input = ref("")
</script>

<template>
  <div class="order-container">
    <div class="filter-box">
      <span class="word"> 订单号 </span>
      <el-input
        v-model="order_id_input"
        style="width: 240px"
        placeholder="请输入订单号"
        :prefix-icon="Search"
      />

      <span class="word"> 订单状态 </span>
      <el-select
        v-model="order_status_input"
        placeholder="请选择订单状态"
        style="width: 240px"
        @change=""
      >
        <el-option v-for="item in status_options" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>

      <span class="word"> 订单类型 </span>
      <el-select
        v-model="order_type_input"
        placeholder="请选择订单类型"
        style="width: 240px"
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
    <!-- Tabs for filtering orders by status -->
    <el-tabs v-model="activeName" class="filter_box" @tab-click="handleClick">
      <el-tab-pane label="全部订单" name="first" class="filter_box_all">
        <div>
          <span class="word"> 订单号 </span>
          <el-input
            v-model="order_id_all_input"
            style="width: 240px"
            placeholder="请输入订单号"
            :prefix-icon="Search"
          />
          <el-button type="primary" class="button" @click="searchOrder"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select
            v-model="value_all"
            placeholder="请选择订单类型"
            style="width: 240px"
            @change="filterOrdersByCategory"
          >
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_all_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
            @change="filterByDate"
          />

          <el-button type="primary" class="button" @click="filterOrdersByStatus"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <!-- Other tabs similar to the first one with different inputs and bindings -->
      <el-tab-pane label="待完成" name="second" class="filter_box_pending">
        <div>
          <span class="word"> 订单号 </span>
          <el-input
            v-model="order_id_pending_input"
            style="width: 240px"
            placeholder="请输入订单号"
            :prefix-icon="Search"
          />
          <el-button type="primary" class="button" @click="searchOrder"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select
            v-model="value_pending"
            placeholder="请选择订单类型"
            style="width: 240px"
            @change="filterOrdersByCategory"
          >
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_pending_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
            @change="filterByDate"
          />

          <el-button type="primary" class="button" @click="filterOrdersByStatus"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <el-tab-pane label="已完成" name="third" class="filter_box_completed">
        <div>
          <span class="word"> 订单号 </span>
          <el-input
            v-model="order_id_completed_input"
            style="width: 240px"
            placeholder="请输入订单号"
            :prefix-icon="Search"
          />
          <el-button type="primary" class="button" @click="searchOrder"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select
            v-model="value_completed"
            placeholder="请选择订单类型"
            style="width: 240px"
            @change="filterOrdersByCategory"
          >
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_completed_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
            @change="filterByDate"
          />

          <el-button type="primary" class="button" @click="filterOrdersByStatus"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <el-tab-pane label="已取消" name="fourth" class="filter_box_canceled">
        <div>
          <span class="word"> 订单号 </span>
          <el-input
            v-model="order_id_canceled_input"
            style="width: 240px"
            placeholder="请输入订单号"
            :prefix-icon="Search"
          />
          <el-button type="primary" class="button" @click="searchOrder"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select
            v-model="value_canceled"
            placeholder="请选择订单类型"
            style="width: 240px"
            @change="filterOrdersByCategory"
          >
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_canceled_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
            @change="filterByDate"
          />

          <el-button type="primary" class="button" @click="filterOrdersByStatus"> 筛选 </el-button>
        </div>
      </el-tab-pane>
    </el-tabs>

    <!-- Main container for displaying orders -->
    <div class="main-container">
      <div class="holder-container" v-if="orders.length === 0">
        <el-empty description="暂无订单数据" />
      </div>
      <div v-else>
        <!-- 订单列表 -->
        <div class="order-item" v-for="order in orders" :key="order.orderId">
          <div class="head">
            <span>订单日期：{{ order.orderDate }}</span>
            <span>订单编号：{{ order.orderId }}</span>
            <span>订单类型：{{ order.orderType }}</span>
            <span>订单状态：{{ fomartPayState(order.status) }}</span>
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
                  服务时间：{{ (order as GuideOrder).serviceBeginDate }} 至 {{ (order as GuideOrder).serviceEndDate }}
                </li>
              </ul>
              <ul v-if="order.orderType === 'HotelOrder'">
                <li>酒店名称：{{ (order as HotelOrder).hotelName }}</li>
                <li>所在城市：{{ (order as HotelOrder).cityName }}</li>
                <li>入住日期：{{ (order as HotelOrder).checkInDate }}</li>
                <li>退房日期：{{ (order as HotelOrder).checkOutDate }}</li>
                <li>房型：{{ (order as HotelOrder).roomType }}</li>
              </ul>
              <ul v-if="order.orderType === 'ScenicOrder'">
                <li>门票类型: {{ (order as ScenicOrder).ticketType }}</li>
                <li>门票数量: {{ (order as ScenicOrder).ticketNumber }}</li>
                <li>游玩日期: {{ (order as ScenicOrder).ticketDate }}</li>
                <li>景点名称：{{ (order as ScenicOrder).scenicSpotName }}</li>
                <li>所在城市：{{ (order as ScenicOrder).cityName }}</li>
              </ul>
              <ul v-if="order.orderType === 'TourOrder'">
                <li>旅行团编号：{{ (order as TourOrder).groupId }}</li>
                <li>旅行目的地：{{ (order as TourOrder).groupName }}</li>
                <li>导游编号：{{ (order as TourOrder).guideId }}</li>
                <li>导游姓名：{{ (order as TourOrder).guideName }}</li>
                <li>导游性别：{{ (order as TourOrder).guideGender }}</li>
                <li>开始日期：{{ (order as TourOrder).startDate }}</li>
                <li>结束日期：{{ (order as TourOrder).endDate }}</li>
              </ul>
              <ul v-if="order.orderType === 'VehicleOrder'">
                <li>交通类型：{{ (order as VehicleOrder).vehicleType }}</li>
                <li>出行票号：{{ (order as VehicleOrder).ticketId }}</li>
                <li>出发时间：{{ (order as VehicleOrder).ticketDepartureTime }}</li>
                <li>到达时间：{{ (order as VehicleOrder).ticketArrivalTime }}</li>
                <li>出发城市：{{ (order as VehicleOrder).ticketDepartureCity }}</li>
                <li>目的城市：{{ (order as VehicleOrder).ticketArrivalCity }}</li>
                <li>起始站台：{{ (order as VehicleOrder).ticketDepartureStation }}</li>
                <li>目的站台：{{ (order as VehicleOrder).ticketArrivalStation }}</li>
              </ul>
            </div>
            <div class="column state">
              <p>
                <a href="javascript:;" class="green">查看详情</a>
              </p>
              <!-- 根据订单状态显示不同的操作按钮 -->
              <p v-if="order.status === 'Pending'">
                <a href="javascript:;" class="del">取消订单</a>
              </p>
              <p v-if="order.status === 'Completed'">
                <a href="javascript:;" class="green">查看评价</a>
              </p>
            </div>
            <div class="column amount">
              <p class="red">¥{{ order.price?.toFixed(2) }}</p>
            </div>
            <div class="column action">
              <el-button v-if="order.status === 'Pending'" type="primary" size="small"> 立即付款 </el-button>
              <el-button v-if="order.status === 'Completed'" type="primary" size="small"> 确认订单 </el-button>
              <p><a href="javascript:;">查看详情</a></p>
              <p>
                <a href="javascript:;">再次预订</a>
              </p>
              <p>
                <a href="javascript:;">联系客服</a>
              </p>
            </div>
          </div>
        </div>
        <!-- 分页 -->
        <div class="pagination-container">
          <el-pagination
            :total="total"
            @current-change="pageChange"
            :page-size="params.pageSize"
            background
            layout="prev, pager, next"
          />
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
        .green {
          color: #27ba9b;
          font-weight: bold; /* 加粗状态信息 */
        }
        .del {
          color: #ff4d4f; /* 使用鲜明的颜色显示删除操作 */
          font-weight: bold;
          cursor: pointer; /* 鼠标悬停时显示手型光标 */
        }
      }

      &.amount {
        width: 150px;
        display: flex; /* 使用flex布局 */
        flex-direction: column; /* 垂直排列子元素 */
        justify-content: center; /* 子元素上下居中 */
        padding-bottom: 5%;
        .red {
          color: #cf4444;
          font-weight: bold; /* 加粗金额信息 */
          font-size: larger;
        }
      }

      &.action {
        width: 140px;
        display: flex; /* 使用flex布局 */
        flex-direction: column; /* 垂直排列子元素 */
        justify-content: center; /* 子元素上下居中 */

        a {
          display: block;

          &:hover {
            color: #27ba9b;
          }
        }
      }
    }
  }
}
</style>
