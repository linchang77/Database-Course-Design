<template>
  <el-tabs v-model="activeName" class="filter_box" @tab-click="handleClick">
    <el-tab-pane label="全部订单" name="first" class="filter_box_all">
      <div>
      <span class="word">订单号 </span>
      <el-input
        v-model="order_id_all_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <el-button type="primary" class="button"> 搜索 </el-button>
      </div>

      <div>
      <span class="word">订单类型 </span>
      <el-select
        v-model="value_all"
        placeholder="Select"
        style="width: 240px"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>

      <span class="word"> 旅客 </span>
      <el-input
        v-model="order_id_all_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

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
        size= default
        
      />
             
      <el-button type="primary" class="button"> 筛选 </el-button>
    </div>
    </el-tab-pane>

    <el-tab-pane label="待完成" name="second" class="filter_box_pending">
      <div>
      <span class="word"> 订单号 </span>
      <el-input
        v-model="order_id_all_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <el-button type="primary" class="button"> 搜索 </el-button>
      </div>

      <div>
      <span class="word"> 订单类型 </span>
      <el-select
        v-model="value_pending"
        placeholder="Select"
        style="width: 240px"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>

      <span class="word"> 旅客 </span>
      <el-input
        v-model="order_id_pending_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <span class="word"> 导游 </span>
      <el-input
        v-model="passenger_name_pending_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <span class="word"> 日期 </span>
      <el-date-picker
        v-model="date_pending_input"
        type="daterange"
        range-separator="To"
        start-placeholder="开始时间"
        end-placeholder="结束时间"
        size= default
      />
             
      <el-button type="primary" class="button"> 筛选 </el-button>
      </div>
    </el-tab-pane>

    <el-tab-pane label="已完成" name="third" class="filter_box_completed">
      <div>
      <span class="word"> 订单号 </span>
      <el-input
        v-model="order_id_all_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <el-button type="primary" class="button"> 搜索 </el-button>
      </div>

      <div>
      <span class="word"> 订单类型 </span>
      <el-select
        v-model="value_completed"
        placeholder="Select"
        style="width: 240px"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>

      <span class="word"> 旅客 </span>
      <el-input
        v-model="order_id_completed_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

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
        size= default
      />
             
      <el-button type="primary" class="button"> 筛选 </el-button>
      </div>
    </el-tab-pane>

    <el-tab-pane label="已取消" name="fourth" class="filter_box_canceled">
      <div>
      <span class="word"> 订单号 </span>
      <el-input
        v-model="order_id_all_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

      <el-button type="primary" class="button"> 搜索 </el-button>
      </div>

      <div>
      <span class="word"> 订单类型 </span>
      <el-select
        v-model="value_canceled"
        placeholder="Select"
        style="width: 240px"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>

      <span class="word"> 旅客 </span>
      <el-input
        v-model="order_id_canceled_input"
        style="width: 240px"
        placeholder=" "
        :prefix-icon="Search"
      />

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
        size= default
      />
             
      <el-button type="primary" class="button"> 筛选 </el-button>
      </div>
    </el-tab-pane>
  </el-tabs>

  <el-pagination background layout="prev, pager, next" :total="1000" />
</template>


<script lang="ts" setup>
  import { ref } from 'vue'
  import { Search } from '@element-plus/icons-vue'
  //根据订单状态筛选
  import type { TabsPaneContext } from 'element-plus'
  const activeName = ref('first')
  const handleClick = (tab: TabsPaneContext, event: Event) => {
    console.log(tab, event)
  }

  //更多筛选
  const value_all = ref('全部订单')
  const value_pending = ref('全部订单')
  const value_completed = ref('全部订单')
  const value_canceled = ref('全部订单')

  const options = [
    { value: '全部订单', label: '全部订单' },
    { value: '酒店', label: '酒店' },
    { value: '出行', label: '出行' },
    { value: '景点', label: '景点' },
    { value: '导游', label: '导游' },
    { value: '旅行团', label: '旅行团' },
  ]
  
  const order_id_all_input = ref('')
  const order_id_pending_input = ref('')
  const order_id_completed_input = ref('')
  const order_id_canceled_input = ref('')

  const passenger_name_all_input = ref('')
  const passenger_name_pending_input = ref('')
  const passenger_name_completed_input = ref('')
  const passenger_name_canceled_input = ref('')
  
  const date_all_input = ref('')
  const date_pending_input = ref('')
  const date_completed_input = ref('')
  const date_canceled_input = ref('')

</script>

<style lang="css">
  .filter_box {
    margin: 20px;
  }

  .filter_box >>> .el-tabs__item {
  font-size: 18px; 
  }

  .word,
  .button {
    margin-left: 20px;
    margin-right: 10px;
  }

  .filter_box_all,
  .filter_box_pending,
  .filter_box_completed,
  .filter_box_canceled
  {
    display: flex;
    flex-wrap: wrap;
    gap: 10px;
    align-items: center;
  }


  
  
</style>



