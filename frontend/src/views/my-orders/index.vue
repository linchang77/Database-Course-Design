<script lang="ts" setup>
import { onMounted, ref } from "vue"
import { Search } from "@element-plus/icons-vue"

// 订单的类型定义
interface Order {
  id: number
  createTime: string
  orderState: number
  countdown?: string
  payMoney: number
  postFee: number
  skus: Sku[]
}

interface Sku {
  id: number
  name: string
  attrsText: string
  realPay: number
  quantity: number
}

// 获取订单列表返回的类型
interface OrderResponse {
  result: {
    items: Order[]
    counts: number
  }
}

// 参数类型定义
interface Params {
  orderState: number
  page: number
  pageSize: number
}

//根据订单状态筛选
import type { TabsPaneContext } from "element-plus"
const activeName = ref("first")
const handleClick = (tab: TabsPaneContext, event: Event) => {
  console.log(tab, event)
}

//更多筛选
const value_all = ref("全部订单")
const value_pending = ref("全部订单")
const value_completed = ref("全部订单")
const value_canceled = ref("全部订单")

const options = [
  { value: "全部订单", label: "全部订单" },
  { value: "酒店", label: "酒店" },
  { value: "出行", label: "出行" },
  { value: "景点", label: "景点" },
  { value: "导游", label: "导游" },
  { value: "旅行团", label: "旅行团" }
]

const order_id_all_input = ref("")
const order_id_pending_input = ref("")
const order_id_completed_input = ref("")
const order_id_canceled_input = ref("")

const passenger_name_all_input = ref("")
const passenger_name_pending_input = ref("")
const passenger_name_completed_input = ref("")
const passenger_name_canceled_input = ref("")

const date_all_input = ref("")
const date_pending_input = ref("")
const date_completed_input = ref("")
const date_canceled_input = ref("")

// import { getUserOrder } from '@/api/order'

// tab列表
// const tabTypes = [
//   { name: "all", label: "全部订单" },
//   { name: "pending", label: "待完成" },
//   { name: "complete", label: "已完成" },
//   { name: "cancel", label: "已取消" }
// ]
// 获取订单列表
const orderList = ref<Order[]>([])
const total = ref(0)
const params = ref({
  orderState: 0,
  page: 1,
  pageSize: 10
})

// 模拟获取用户订单的函数
const getUserOrder = async (_params: Params): Promise<OrderResponse> => {
  // 模拟一个 API 响应
  return {
    result: {
      items: [
        {
          id: 1,
          createTime: "2024-08-01",
          orderState: 1,
          countdown: "23:59:59",
          payMoney: 100.5,
          postFee: 10,
          skus: [
            {
              id: 1,
              name: "商品名称",
              attrsText: "属性信息",
              realPay: 100,
              quantity: 1
            }
          ]
        }
      ],
      counts: 1
    }
  }
}

const getOrderList = async () => {
  const res = await getUserOrder(params.value)
  orderList.value = res.result.items
  total.value = res.result.counts
}

onMounted(() => getOrderList())

// tab切换
// const tabChange = (type: number) => {
//   console.log(type)
//   params.value.orderState = type
//   getOrderList()
// }

// 页数切换
const pageChange = (page: number) => {
  console.log(page)
  params.value.page = page
  getOrderList()
}

const fomartPayState = (payState: number) => {
  const stateMap: Record<number, string> = {
    1: "待完成",
    2: "已完成",
    3: "已取消"
  }
  return stateMap[payState]
}
</script>

<template>
  <div class="order-container">
    <el-tabs v-model="activeName" class="filter_box" @tab-click="handleClick">
      <el-tab-pane label="全部订单" name="first" class="filter_box_all">
        <div>
          <span class="word">订单号 </span>
          <el-input v-model="order_id_all_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <el-button type="primary" class="button"> 搜索 </el-button>
        </div>

        <div>
          <span class="word">订单类型 </span>
          <el-select v-model="value_all" placeholder="Select" style="width: 240px">
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 旅客 </span>
          <el-input v-model="order_id_all_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <span class="word"> 导游 </span>
          <el-input
            v-model="passenger_name_all_input"
            style="width: 240px"
            placeholder=" "
            :prefix-icon="Search"
            class="box"
          />

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_all_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
          />

          <el-button type="primary" class="button"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <el-tab-pane label="待完成" name="second" class="filter_box_pending">
        <div>
          <span class="word"> 订单号 </span>
          <el-input v-model="order_id_all_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <el-button type="primary" class="button"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select v-model="value_pending" placeholder="Select" style="width: 240px">
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 旅客 </span>
          <el-input v-model="order_id_pending_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <span class="word"> 导游 </span>
          <el-input v-model="passenger_name_pending_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_pending_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
          />

          <el-button type="primary" class="button"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <el-tab-pane label="已完成" name="third" class="filter_box_completed">
        <div>
          <span class="word"> 订单号 </span>
          <el-input v-model="order_id_all_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <el-button type="primary" class="button"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select v-model="value_completed" placeholder="Select" style="width: 240px">
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 旅客 </span>
          <el-input v-model="order_id_completed_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <span class="word"> 导游 </span>
          <el-input
            v-model="passenger_name_completed_input"
            style="width: 240px"
            placeholder=" "
            :prefix-icon="Search"
          />

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_completed_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
          />

          <el-button type="primary" class="button"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <el-tab-pane label="已取消" name="fourth" class="filter_box_canceled">
        <div>
          <span class="word"> 订单号 </span>
          <el-input v-model="order_id_all_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <el-button type="primary" class="button"> 搜索 </el-button>
        </div>

        <div>
          <span class="word"> 订单类型 </span>
          <el-select v-model="value_canceled" placeholder="Select" style="width: 240px">
            <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
          </el-select>

          <span class="word"> 旅客 </span>
          <el-input v-model="order_id_canceled_input" style="width: 240px" placeholder=" " :prefix-icon="Search" />

          <span class="word"> 导游 </span>
          <el-input
            v-model="passenger_name_canceled_input"
            style="width: 240px"
            placeholder=" "
            :prefix-icon="Search"
          />

          <span class="word"> 日期 </span>
          <el-date-picker
            v-model="date_canceled_input"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
          />

          <el-button type="primary" class="button"> 筛选 </el-button>
        </div>
      </el-tab-pane>

      <div class="main-container">
        <div class="holder-container" v-if="orderList.length === 0">
          <el-empty description="暂无订单数据" />
        </div>
        <div v-else>
          <!-- 订单列表 -->
          <div class="order-item" v-for="order in orderList" :key="order.id">
            <div class="head">
              <span>下单时间：{{ order.createTime }}</span>
              <span>订单编号：{{ order.id }}</span>
              <!-- 未付款，倒计时时间还有 -->
              <span class="down-time" v-if="order.orderState === 1">
                <i class="iconfont icon-down-time" />
                <b>付款截止: {{ order.countdown }}</b>
              </span>
            </div>
            <div class="body">
              <div class="column goods">
                <ul>
                  <li v-for="item in order.skus" :key="item.id">
                    <!-- <a class="image" href="javascript:;">
                      <img :src="item.image" alt="" />
                    </a> -->
                    <div class="info">
                      <p class="name ellipsis-2">
                        {{ item.name }}
                      </p>
                      <p class="attr ellipsis">
                        <span>{{ item.attrsText }}</span>
                      </p>
                    </div>
                    <div class="price">¥{{ item.realPay?.toFixed(2) }}</div>
                    <div class="count">x{{ item.quantity }}</div>
                  </li>
                </ul>
              </div>
              <div class="column state">
                <p>{{ fomartPayState(order.orderState) }}</p>
                <p v-if="order.orderState === 1">
                  <a href="javascript:;" class="green">查看物流</a>
                </p>
                <p v-if="order.orderState === 1">
                  <a href="javascript:;" class="green">评价商品</a>
                </p>
                <p v-if="order.orderState === 1">
                  <a href="javascript:;" class="green">查看评价</a>
                </p>
              </div>
              <div class="column amount">
                <p class="red">¥{{ order.payMoney?.toFixed(2) }}</p>
                <p>（含运费：¥{{ order.postFee?.toFixed(2) }}）</p>
                <p>在线支付</p>
              </div>
              <div class="column action">
                <el-button v-if="order.orderState === 1" type="primary" size="small"> 立即付款 </el-button>
                <el-button v-if="order.orderState === 3" type="primary" size="small"> 确认收货 </el-button>
                <p><a href="javascript:;">查看详情</a></p>
                <p v-if="[2, 3].includes(order.orderState)">
                  <a href="javascript:;">再次购买</a>
                </p>
                <p v-if="[2, 3].includes(order.orderState)">
                  <a href="javascript:;">申请售后</a>
                </p>
                <p v-if="order.orderState === 1"><a href="javascript:;">取消订单</a></p>
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
    </el-tabs>
  </div>
</template>

<style lang="css">
.filter_box {
  margin: 20px;
}

.filter_box >>> .el-tabs__item {
  font-size: 18px;
}

.word,
.button {
  margin-left: 15px;
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

    .holder-container {
      min-height: 500px;
      display: flex;
      justify-content: center;
      align-items: center;
    }
  }
}

.order-item {
  margin-bottom: 20px;
  border: 1px solid #dcdcdc;

  .head {
    height: 50px;
    line-height: 50px;
    background: #f5f5f5;
    padding: 0 20px;
    overflow: hidden;

    span {
      margin-right: 20px;

      &.down-time {
        margin-right: 0;
        float: right;

        i {
          vertical-align: middle;
          margin-right: 3px;
        }

        b {
          vertical-align: middle;
          font-weight: normal;
        }
      }
    }

    .del {
      margin-right: 0;
      float: right;
      color: #999;
    }
  }

  .body {
    display: flex;
    align-items: stretch;

    .column {
      border-left: 1px solid #f5f5f5;
      text-align: center;
      padding: 20px;

      > p {
        padding-top: 10px;
      }

      &:first-child {
        border-left: none;
      }

      &.goods {
        flex: 1;
        padding: 0;
        align-self: center;

        ul {
          li {
            border-bottom: 1px solid #f5f5f5;
            padding: 10px;
            display: flex;

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
                }

                &.attr {
                  color: #999;
                  font-size: 12px;

                  span {
                    margin-right: 5px;
                  }
                }
              }
            }

            .price {
              width: 100px;
            }

            .count {
              width: 80px;
            }
          }
        }
      }

      &.state {
        width: 120px;

        .green {
          color: #27ba9b;
        }
      }

      &.amount {
        width: 200px;

        .red {
          color: #cf4444;
        }
      }

      &.action {
        width: 140px;

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
