<script lang="ts" setup>
import { onMounted, reactive, ref } from "vue"
import axios from "axios";
import { ElButton, ElDialog, ElRate, ElMessage } from 'element-plus';


// 筛选部分

// 接口部分
interface Guide {
  guideId: number;               
  //password: string;// 这好像不需要
  guideName: string;     
  guideGender: string;          
  guideFree: number;// 导游是否空闲 (0 或 1)
  guideIntroduction: string;     
  //guideSalary: number;// 这好像不需要
  guidePerformanceLevel: number;
  //guideSeniority: string;//这好像不需要
  guidePrice: number;  
  profilePicture: string;// 看后端
}

// 数据
const guides = ref<Guide[]>([]);
const value = ref(3.7)
const dialogVisible = ref(false)
const selectedGuide = ref<Guide | null>(null);
const date_input = ref('')

const guidesEg: Guide[] = [
  {
    guideId: 1,
    guideName: "张伟",
    guideGender: "男",
    guideFree: 1, // 表示空闲
    guideIntroduction: "经验丰富的导游，熟悉多个景区的历史文化。",
    guidePerformanceLevel: 4,
    guidePrice: 200.0,
    profilePicture: "https://th.bing.com/th/id/R.d68dcaee479f08cce46b46d2f268691f?rik=1gR2azuO%2fp1%2b3g&riu=http%3a%2f%2fgss0.baidu.com%2f9fo3dSag_xI4khGko9WTAnF6hhy%2fzhidao%2fpic%2fitem%2f37d12f2eb9389b50053be23b8635e5dde6116e96.jpg&ehk=bvj7ZF98h7hwoPr%2b12EMgI%2fmXfSvZfSfzyvvz6vgjqw%3d&risl=&pid=ImgRaw&r=0",
  },
  {
    guideId: 2,
    guideName: "李静",
    guideGender: "女",
    guideFree: 0, // 表示不空闲
    guideIntroduction: "擅长讲解自然风光，带队经验丰富。",
    guidePerformanceLevel: 3,
    guidePrice: 180.0,
    profilePicture: "https://th.bing.com/th/id/OIP.TKN6MUV8TpXRSTGsXymxMwHaKX?rs=1&pid=ImgDetMain",
  },
  {
    guideId: 3,
    guideName: "王强",
    guideGender: "男",
    guideFree: 1, // 表示空闲
    guideIntroduction: "主要带领团队游览历史文化遗址。",
    guidePerformanceLevel: 4,
    guidePrice: 220.0,
    profilePicture: "https://th.bing.com/th/id/OIP.IXH5Twk0zpHOuxDpyhRfdwHaKl?rs=1&pid=ImgDetMain",
  },
  {
    guideId: 4,
    guideName: "刘芳",
    guideGender: "女",
    guideFree: 1, // 表示空闲
    guideIntroduction: "熟悉各地风土人情，能够提供个性化服务。",
    guidePerformanceLevel: 5,
    guidePrice: 250.0,
    profilePicture: "https://th.bing.com/th/id/OIP.MZZJSvAhRTPXRiIwzq2sSAHaLA?rs=1&pid=ImgDetMain",
  },
  {
    guideId: 4,
    guideName: "刘芳",
    guideGender: "女",
    guideFree: 1, // 表示空闲
    guideIntroduction: "熟悉各地风土人情，能够提供个性化服务。",
    guidePerformanceLevel: 5,
    guidePrice: 250.0,
    profilePicture: "https://th.bing.com/th/id/OIP.MZZJSvAhRTPXRiIwzq2sSAHaLA?rs=1&pid=ImgDetMain",
  },
  {
    guideId: 4,
    guideName: "刘芳",
    guideGender: "女",
    guideFree: 1, // 表示空闲
    guideIntroduction: "熟悉各地风土人情，能够提供个性化服务。",
    guidePerformanceLevel: 5,
    guidePrice: 250.0,
    profilePicture: "https://th.bing.com/th/id/OIP.MZZJSvAhRTPXRiIwzq2sSAHaLA?rs=1&pid=ImgDetMain",
  },
];


// api部分
// 获取导游信息
const fetchGuides = () => {
  axios
    .get("https://123.60.14.84/api/TourGroup/guide/all")
    .then((response) => {
      console.log("API Response:", response.data);
      const data = response.data;
      if (Array.isArray(data)) {
        guides.value = data.map((guide: any) => ({
          guideId: guide.guideId,
          password: guide.password,
          guideName: guide.guideName,
          guideGender: guide.guideGender,
          guideFree: guide.guideFree,
          guideIntroduction: guide.guideIntroduction,
          guideSalary: guide.guideSalary,
          guidePerformanceLevel: guide.guidePerformanceLevel,
          guideSeniority: guide.guideSeniority,
          guidePrice: guide.guidePrice,
          profilePicture: guide.profilePicture,
        }));
        console.log("Guides:", guides);
      } else {
        console.error("Unexpected response format.");
      }
    })
    .catch((error) => {
      console.error("Error fetching guides:", error);
    });
};

onMounted(() => {
  fetchGuides()
});

const openDialog = (guide: Guide) => {
  selectedGuide.value = guide
  dialogVisible.value = true
};

const confirm = () => {
  if (selectedGuide.value && date_input.value) {
    ElMessage.success(`预定成功！导游: ${selectedGuide.value.guideName}`)
    dialogVisible.value = false
    selectedGuide.value = null
    date_input.value = ''
  }else{
    ElMessage.info(`请选择时间`)
  }
};

const cancel = () => {
  dialogVisible.value = false;
  selectedGuide.value = null
  date_input.value = ''
};

</script>

<template>
<div>
    <div class="filter-container">
        <p>筛选</p>
    </div>

    <div class="guide-container">
        <div class="group-card" v-for="guide in guidesEg" :key="guide.guideId" >
            <div class="first">
                <img :src="guide.profilePicture" alt="导游照片" class="photo"/>
                <div class="guide-name-gender">
                    <p class="name">{{ guide.guideName }}</p>
                    <img v-if="guide.guideGender === '男'" src="@/views/user/guide/icon/male.svg" alt="男" class="gender-icon" />
                    <img v-else src="@/views/user/guide/icon/female.svg" alt="女" class="gender-icon" />
                </div>    
            </div>
            
        
            <div class="second" >
                <p>导游是否空闲: {{ guide.guideFree ? '是' : '否' }}</p>
                <p>基本介绍: {{ guide.guideIntroduction }}</p>
                <p>价格（日）: ¥{{ guide.guidePrice }}</p>
                <el-rate
                    v-model= guide.guidePerformanceLevel
                    disabled
                    show-score
                    text-color="#ff9900"
                    score-template="{value}星"
                />
        
            </div>

            <div class="third">
                <el-button type="primary" @click="openDialog(guide)">立即预定</el-button>
            </div>
        </div>
    </div>
    
    <el-dialog v-model="dialogVisible" title="导游预定" width="500px">
        <el-date-picker
          v-model="date_input"
          type="daterange"
          range-separator="To"
          start-placeholder="开始时间"
          end-placeholder="结束时间"
          size="default"
        />
    <template #footer>
      <div class="dialog-footer">
        <el-button type="primary" @click="confirm">确认</el-button>
        <el-button @click="cancel">取消</el-button>
      </div>
    </template>
    </el-dialog>
</div>

</template>

<style>
.guide-container {
  margin-left: 40px;
  margin-top: 20px;
  display: flex;
  flex-wrap: wrap;
  gap: 20px; 
}

.group-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  background-color: white;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 30%;
}

.photo {
  width: 100px;
  border-radius: 5%;
  margin-top: 10px;
}

.guide-name-gender {
  display: flex;
  align-items: center;
  justify-content: center; 
  gap: 5px;
  width: 100%;
  margin-top: 10px; 
}

.name {
  margin: 0; /* 去除 <p> 元素的默认外边距 */
  font-size: 1.2em;
  font-weight: bold; 
  line-height: 1; /* 确保文本行高适中 */
}

.gender-icon {
  width: 16px;
  height: 16px;
}

.second p {
  margin: 5px 0;
  line-height: 1.5; 
}

.third {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  padding: 10px;
}



</style>
