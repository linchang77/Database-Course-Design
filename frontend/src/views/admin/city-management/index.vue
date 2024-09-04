<script lang="ts" setup>


defineOptions({
  name: "City-management"
})

import AddAndModifyCity from "./component/AddAndModifyCity.vue";
import SearchCity from "./component/SearchCity.vue";
</script>

<template>
  <div class="app-container">
    <AddAndModifyCity />
    <SearchCity />
    <!-- <el-card header="城市管理">
    </el-card>
  -->
  </div>
</template>
