<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "Transport-management"
})

import AddScheduleTicket from "./component/AddScheduleTicket.vue";
//import ModifyScheduleTicket from "./component/ModifyScheduleTicket.vue";
import SearchScheduleAndTicket from "./component/SearchScheduleAndTicket.vue";
import modify from "./component/modify.vue";
</script>

<template>
  <div class="app-container">
    <AddScheduleTicket />
    <!-- <ModifyScheduleTicket /> -->
    <modify />
    <SearchScheduleAndTicket />
  </div>
</template>
