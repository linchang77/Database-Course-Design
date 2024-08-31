<template>
  <div class="main-container">
    <div class="slot-container">
      <slot></slot>
    </div>
    <el-cascader
      v-model="value"
      :options="options"
      :props="props"
      :show-all-levels="false"
      @change="handleChange"
    />
  </div>
</template>

<script lang="ts" setup>
import { ref, defineProps, defineEmits } from 'vue';

const props = defineProps<{
  options: Array<any>;
}>();

const value = ref([]);

const emit = defineEmits(['updateValue']);

const handleChange = (value: any) => {
  emit('updateValue', value);
};

const propsConfig = {
  expandTrigger: 'hover' as const,
};
</script>

<style>
.slot-container {
  margin: 5%;
}
</style>
