<script lang="ts" setup>
import { ref } from "vue"

defineOptions({
  name: "My-orders"
})

const text = ref("")
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
    margin-left: 15px;
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




