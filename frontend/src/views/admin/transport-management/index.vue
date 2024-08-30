<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "Transport-management"
})

import AddScheduleTicket from "./component/AddScheduleTicket.vue";
import ModifyScheduleTicket from "./component/ModifyScheduleTicket.vue";


</script>

<template>
  <div class="app-container">
    <AddScheduleTicket />
    <ModifyScheduleTicket />
  </div>
</template>
