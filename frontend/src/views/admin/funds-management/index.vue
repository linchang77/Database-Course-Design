<script setup lang="ts">
import { onMounted, ref } from "vue"
import axios from "axios"

interface TransactionRecord {
  transactionId: number
  userId: number
  transactionTime: string
  amount: number
  transactionObject: string
  transactionStatus: string
  transactionMethod: string
  transactionCategory: string
  description: string
}

const searchForm = ref({
  userId: "",
  category: ""
})

const categoryOptions = ref([
  "全部",
  "酒店",
  "出行",
  "景点",
  "导游",
  "旅行团"
  // 其他类别选项
])

const transactions = ref<TransactionRecord[]>([])
const loading = ref(false)
const total = ref(0)
const showEmptyMessage = ref(false) // 用于控制是否显示“暂无交易数据”
const userIdInput = ref("")
const categoryInput = ref("全部")
const dateInput = ref("")
const categoryFilter = ref("")
const startDate = ref("")
const endDate = ref("")
const apiUrl = "https://123.60.14.84:11100/api/Transaction/admin/1"

// 获取交易列表
const fetchTransactions = () => {
  loading.value = true
  axios
    .get(`${apiUrl}`)
    .then((response) => {
      console.log("API Response:", response.data)
      transactions.value = response.data
      total.value = response.data.length || 0
      showEmptyMessage.value = transactions.value.length === 0
    })
    .catch((error) => {
      console.error(`获取交易记录失败: ${error.message}`)
      transactions.value = [] // 确保 transactions 不为空
      total.value = 0
      showEmptyMessage.value = true
    })
    .finally(() => {
      loading.value = false
    })
}

// 按用户ID搜索交易记录
async function searchByUserId() {
  const userId = userIdInput.value
  categoryInput.value = "全部"
  dateInput.value = ""
  if (!userId) {
    try {
      await fetchTransactions()
      showEmptyMessage.value = transactions.value.length === 0
    } catch (error) {
      console.error("Error fetching all transactions:", error)
      transactions.value = [] // 确保 transactions 不为空
      total.value = 0
      showEmptyMessage.value = true
    }
    return
  }

  try {
    const response = await axios.get(`${apiUrl}/search/userId`)
    console.log("API Response:", response.data)
    transactions.value = response.data
    total.value = response.data.length || 0
    showEmptyMessage.value = transactions.value.length === 0
  } catch (error) {
    console.error("Error searching by user ID:", error)
    transactions.value = [] // 确保 transactions 不为空
    total.value = 0
    showEmptyMessage.value = true
  }
}

// 按类别搜索交易记录
const searchByCategory = () => {
  switch (categoryInput.value) {
    case "全部":
      categoryFilter.value = ""
      break
    case "酒店":
      categoryFilter.value = "hotel"
      break
    case "出行":
      categoryFilter.value = "vehicle"
      break
    case "景点":
      categoryFilter.value = "scenic"
      break
    case "导游":
      categoryFilter.value = "guide"
      break
    case "旅行团":
      categoryFilter.value = "tour"
      break
    // 其他类别选项
    default:
      categoryFilter.value = ""
      break
  }
  if (categoryFilter.value) {
    axios
      .get(`${apiUrl}/category/${categoryFilter.value}`)
      .then((response) => {
        if (response.data && response.data.length > 0) {
          transactions.value = response.data
          total.value = response.data.length || 0
          showEmptyMessage.value = transactions.value.length === 0
        } else {
          transactions.value = [] // 确保 transactions 不为空
          total.value = 0
          showEmptyMessage.value = true
        }
      })
      .catch((error) => {
        console.error("Error searching by category:", error)
        transactions.value = [] // 确保 transactions 不为空
        total.value = 0
        showEmptyMessage.value = true
      })
  } else {
    fetchTransactions()
  }
}

// 按日期搜索交易记录
const searchByDate = () => {
  startDate.value = dateInput.value[0]
  endDate.value = dateInput.value[1]
  if (startDate.value && endDate.value) {
    axios
      .get(`${apiUrl}/date-range`, {
        params: {
          start: startDate.value,
          end: endDate.value
        }
      })
      .then((response) => {
        if (response.data && response.data.length > 0) {
          transactions.value = response.data
          total.value = response.data.length
        } else {
          transactions.value = []
          total.value = 0
        }
      })
      .catch((error) => {
        console.error(error)
        transactions.value = []
        total.value = 0
      })
  } else {
    fetchTransactions()
  }
}

// 同时按用户ID，类别，日期搜索交易记录
const search = () => {
  const category = ref("")
  switch (categoryInput.value) {
    case "全部":
      category.value = ""
      break
    case "酒店":
      category.value = "hotel"
      break
    case "出行":
      category.value = "vehicle"
      break
    case "景点":
      category.value = "scenic"
      break
    case "导游":
      category.value = "guide"
      break
    case "旅行团":
      category.value = "tour"
      break
    // 其他类别选项
    default:
      category.value = ""
      break
  }
  const startDateValue = dateInput.value[0]
  const endDateValue = dateInput.value[1]
  const requests = []

  //添加类型筛选请求
  if (category.value) {
    requests.push(axios.get(`${apiUrl}/category/${category.value}`))
  } else {
    requests.push(axios.get(`${apiUrl}`))
  }

  //添加日期筛选请求
  if (startDateValue && endDateValue) {
    requests.push(
      axios.get(`${apiUrl}/date-range`, {
        params: {
          start: startDateValue,
          end: endDateValue
        }
      })
    )
  } else {
    requests.push(axios.get(`${apiUrl}`))
  }

  //添加用户ID筛选请求
  if (userIdInput.value) {
    requests.push(axios.get(`${apiUrl}/search/userId`))
  } else {
    requests.push(axios.get(`${apiUrl}`))
  }

  // 并行请求
  Promise.all(requests)
    .then((responses) => {
      let filteredTransactions = responses[0].data

      // 合并筛选结果
      responses.slice(1).forEach((response) => {
        filteredTransactions = filteredTransactions.filter((transaction: TransactionRecord) =>
          response.data.some(
            (filteredTransactions: TransactionRecord) =>
              filteredTransactions.transactionId === transaction.transactionId
          )
        )
      })
      transactions.value = filteredTransactions
      total.value = filteredTransactions.length || 0
      showEmptyMessage.value = transactions.value.length === 0
    })
    .catch((error) => {
      console.error(error)
      transactions.value = []
      total.value = 0
    })
}

const resetSearch = () => {
  searchForm.value = {
    userId: "",
    category: ""
  }
  fetchTransactions()
}

// 格式化时间到秒
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

// 格式化分类显示
const formatCategory = (category: string): string => {
  const stateMap: Record<string, string> = {
    hotel: "酒店",
    vehicle: "出行",
    scenic: "景点",
    guide: "导游",
    tour: "旅行团"
  }
  return stateMap[category] || "未知类型"
}

// 格式化状态显示
const formatStatus = (status: string): string => {
  const stateMap: Record<string, string> = {
    success: "成功",
    pending: "待支付",
    failed: "失败"
  }
  return stateMap[status] || "未知状态"
}

// 格式化支付方式显示
const formatMethod = (method: string): string => {
  const stateMap: Record<string, string> = {
    wechat: "微信支付",
    alipay: "支付宝",
    bank: "银行卡支付"
  }
  return stateMap[method] || "未知支付方式"
}

// 初始化获取所有交易记录
onMounted(() => {
  fetchTransactions()
})
</script>

<template>
  <div class="transaction-management">
    <el-card class="filter-card">
      <el-form :inline="true" :model="searchForm" class="demo-form-inline">
        <el-form-item label="用户ID">
          <el-input v-model="searchForm.userId" placeholder="请输入用户ID" style="width: 200px" />
        </el-form-item>
        <el-form-item label="订单类别">
          <el-select v-model="searchForm.category" placeholder="请选择交易类别" style="width: 200px">
            <el-option v-for="item in categoryOptions" :key="item" :label="item" :value="item" />
          </el-select>
        </el-form-item>
        <el-form-item label="交易时间">
          <el-date-picker
            v-model="dateInput"
            type="daterange"
            range-separator="To"
            start-placeholder="开始时间"
            end-placeholder="结束时间"
            size="default"
          />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="search">搜索</el-button>
          <el-button @click="resetSearch">重置</el-button>
        </el-form-item>
      </el-form>
    </el-card>

    <el-scrollbar height="400px">
      <div class="holder-container" v-if="transactions.length === 0 || showEmptyMessage">
        <el-empty description="暂无交易数据" />
      </div>
      <div v-else>
        <div class="number-of-transactions">
          <span>共 {{ transactions.length }} 条交易记录</span>
        </div>

        <el-table :data="transactions" style="width: 100%" v-loading="loading">
          <el-table-column prop="transactionId" label="交易ID" width="100" align="center" />
          <el-table-column prop="userId" label="用户ID" width="100" align="center" />
          <el-table-column prop="transactionTime" label="交易时间" width="200" align="center">
            <template #default="scope">{{ formatDate(scope.row.transactionTime) }}</template>
          </el-table-column>
          <el-table-column prop="amount" label="金额" width="150" align="center" />
          <el-table-column prop="transactionObject" label="交易对象" width="200" align="center" />
          <el-table-column prop="transactionStatus" label="交易状态" width="150" align="center">
            <template #default="scope">{{ formatStatus(scope.row.transactionStatus) }}</template>
          </el-table-column>
          <el-table-column prop="transactionMethod" label="支付方式" width="120" align="center">
            <template #default="scope">{{ formatMethod(scope.row.transactionMethod) }}</template>
          </el-table-column>
          <el-table-column prop="transactionCategory" label="交易类别" width="120" align="center">
            <template #default="scope">{{ formatCategory(scope.row.transactionCategory) }}</template>
          </el-table-column>
          <el-table-column prop="description" label="交易描述" width="300" align="center" />
        </el-table>
      </div>
    </el-scrollbar>
  </div>
</template>

<style scoped>
.transaction-management {
  padding: 10px;
}

.demo-form-inline .el-form-item {
  margin-right: 20px;
}

.custom-card {
  margin-bottom: 10px;
}

.delete-button {
  margin-top: 10px;
}

.number-of-transactions {
  margin-top: 10px;
  margin-left: 10px;
  font-size: smaller;
  margin-bottom: 10px;
  color: #888;
}
</style>
