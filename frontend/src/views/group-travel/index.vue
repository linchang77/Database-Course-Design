<script lang="ts" setup>
import { ref } from "vue"
import { Search } from "@element-plus/icons-vue"

defineOptions({
  name: "Group-travel"
})

const city_buttons = [
  { type: 'primary', text: '上海' },
  { type: 'primary', text: '北京' },
  { type: 'primary', text: '天津' },
  { type: 'primary', text: '广州' },
] as const

</script>

<template>
<div class="city-links">
    <p>旅行团目的城市：</p>
    <router-link :to="{ path: '/group-travel/cities/shanghai' }">
        <el-button :type="city_buttons[0].type" text bg>
            {{ city_buttons[0].text }}
        </el-button>
    </router-link>

    <router-link :to="{ path: './scene/shanghai' }">
        <el-button :type="city_buttons[1].type" text bg>
            {{ city_buttons[1].text }}
        </el-button>
    </router-link>

    <router-link :to="{ path: './scene/shanghai' }">
        <el-button :type="city_buttons[2].type" text bg>
            {{ city_buttons[2].text }}
        </el-button>
    </router-link>

    <router-link :to="{ path: './scene/shanghai' }">
        <el-button :type="city_buttons[3].type" text bg>
            {{ city_buttons[3].text }}
        </el-button>
    </router-link>
</div>
</template>

<style lang="css">
.city-links {
    display: inline-block;
    margin-left: 20px;
}

.city-links p,
.city-links router-link {
    display: inline-block;
    margin-right: 10px; /* 可选：为文本和按钮之间增加一些间距 */
}
</style>