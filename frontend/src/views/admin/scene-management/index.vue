<script lang="ts" setup>


defineOptions({
  name: "Scene-management"
})
import AddAndModifySScene from './component/AddAndModifySScene.vue';
import AddAndModifyTickets from './component/AddAndModifyTickets.vue';
import SearchSceneAndTickets from './component/SearchSceneAndTickets.vue';
</script>

<template>
  <div class="app-container">
    <AddAndModifySScene />
    <AddAndModifyTickets />
    <SearchSceneAndTickets />
    <!-- 页面内容
    <el-card header="景点管理">
    </el-card>
    -->
  </div>
</template>
