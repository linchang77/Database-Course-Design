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
    <AddAndModifyTickets style="margin-top: 10px; margin-bottom: 10px"/>
    <SearchSceneAndTickets style="margin-top: 10px; margin-bottom: 10px"/>
  </div>
</template>
