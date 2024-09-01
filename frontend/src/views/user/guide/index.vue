<script lang="ts" setup>
import { onMounted, reactive, ref } from "vue"
import axios from "axios";
import { ElButton, ElDialog, ElRate, ElMessage } from 'element-plus';
import { Search } from "@element-plus/icons-vue"

// 1、导游6星等级太高了无法显示
// 2、根据id和姓名筛选：只输入一个属性api调用失败
// 3、根据等级和价格筛选：只输入一个属性api调用失败，价格筛选部分有问题
// 4、预定：想要一个预定成功的body截图（时间输入格式：2024-08-22T16:00:00.000Z？），boby是不是还要加上userId产生一个pending的订单

// 接口部分
interface Guide {
  guideId: number               
  guideName: string
  guideGender: string
  guideIntroduction: string
  guideSalary: number
  guidePerformanceLevel: number
  guideSeniority: string
  guidePrice: number
}

// 数据部分
const guides = ref<Guide[]>([]);
const guideId_input = ref('')
const guideName_input = ref('')
const guidePrice_input = ref<number[]>([]); // 定义为 Ref 数组
const guideGrade_input = ref('')
const dialogVisible = ref(false)
const selectedGuide = ref<Guide | null>(null);
const date_input = ref('')

const imageMap: Record<number, string> = {
  2: 'https://th.bing.com/th/id/R.d68dcaee479f08cce46b46d2f268691f?rik=1gR2azuO%2fp1%2b3g&riu=http%3a%2f%2fgss0.baidu.com%2f9fo3dSag_xI4khGko9WTAnF6hhy%2fzhidao%2fpic%2fitem%2f37d12f2eb9389b50053be23b8635e5dde6116e96.jpg&ehk=bvj7ZF98h7hwoPr%2b12EMgI%2fmXfSvZfSfzyvvz6vgjqw%3d&risl=&pid=ImgRaw&r=0',
  5: 'https://th.bing.com/th/id/OIP.IXH5Twk0zpHOuxDpyhRfdwHaKl?rs=1&pid=ImgDetMain',
  13: 'https://th.bing.com/th/id/OIP.qVCyjt_e3_xM60_2q0frjQHaKY?rs=1&pid=ImgDetMain',
  33: 'https://th.bing.com/th/id/OIP.JoJ-AVHAUxutTyGUa3uHuAHaKk?rs=1&pid=ImgDetMain',
  9: 'https://th.bing.com/th/id/R.36ca40fef9c4da005b251a3820d6fb4a?rik=Q6IQFoVA3Gs9Ew&riu=http%3a%2f%2ffiles.photops.com%3a81%2fattachment%2fMon_1203%2f61_207514_57205c36941dcd2.jpg%3f207&ehk=wpZxbNylcejNwiUkNkUEbVucC0%2fMWuICMBVH%2f%2bn7dNg%3d&risl=&pid=ImgRaw&r=0',
  10: 'https://img1.baidu.com/it/u=3838128346,2925275137&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=742',
  1: 'https://img0.baidu.com/it/u=3193702081,1747174116&fm=253&fmt=auto&app=120&f=JPEG?w=417&h=581',
  3: 'https://th.bing.com/th/id/OIP.TKN6MUV8TpXRSTGsXymxMwHaKX?rs=1&pid=ImgDetMain',
  4: 'https://gss0.baidu.com/94o3dSag_xI4khGko9WTAnF6hhy/zhidao/wh%3D450%2C600/sign=5cf347cf97dda144da5c64b68787fc94/7af40ad162d9f2d30708c733a9ec8a136227ccd5.jpg',
  26: 'https://img2.baidu.com/it/u=2793308119,144286892&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=700',
  34: 'https://gss0.baidu.com/-4o3dSag_xI4khGko9WTAnF6hhy/zhidao/pic/item/caef76094b36acaff26b35af78d98d1000e99cde.jpg'
}

// api部分
// 获取导游信息
const fetchGuides = () => {
  axios
    .get("https://123.60.14.84:11100/api/Guide/all")
    .then((response) => {
      console.log("API Response:", response.data);
      const data = response.data;
      if (Array.isArray(data)) {
        guides.value = data.map((guide: any) => ({
          guideId: guide.guideId,            
          guideName: guide.guideName,
          guideGender: guide.guideGender,
          guideIntroduction: guide.guideIntroduction,
          guideSalary: guide.guideSalary,
          guidePerformanceLevel: Number(guide.guidePerformanceLevel),
          guideSeniority: guide.guideSeniority,
          guidePrice: guide.guidePrice,
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

// 根据编号、姓名筛选
const fetchById = () => {
  axios
    .get(`https://123.60.14.84:11100/api/Guide/person/${guideId_input.value},${guideName_input.value}`)
    .then((response) => {
      console.log("API Response:", response.data);
      const data = response.data;
      if (Array.isArray(data)) {
        guides.value = data.map((guide: any) => ({
          guideId: guide.guideId,            
          guideName: guide.guideName,
          guideGender: guide.guideGender,
          guideIntroduction: guide.guideIntroduction,
          guideSalary: guide.guideSalary,
          guidePerformanceLevel: Number(guide.guidePerformanceLevel),
          guideSeniority: guide.guideSeniority,
          guidePrice: guide.guidePrice,
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

// 根据星级、价格筛选
const fetchByGrade = () => {
  axios
    .get(`https://123.60.14.84:11100/api/Guide/ability/${guidePrice_input.value[0]},${guidePrice_input.value[1]},${guideGrade_input.value}`)
    .then((response) => {
      console.log("API Response:", response.data);
      const data = response.data;
      if (Array.isArray(data)) {
        guides.value = data.map((guide: any) => ({
          guideId: guide.guideId,            
          guideName: guide.guideName,
          guideGender: guide.guideGender,
          guideIntroduction: guide.guideIntroduction,
          guideSalary: guide.guideSalary,
          guidePerformanceLevel: Number(guide.guidePerformanceLevel),
          guideSeniority: guide.guideSeniority,
          guidePrice: guide.guidePrice,
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

// 预定导游
const reserve = () => {
  axios
    .post(`https://123.60.14.84:11100/api/Guide/reservation/${guidePrice_input.value[0]},${guidePrice_input.value[1]},${guideGrade_input.value}`)
    .then((response) => {
      ElMessage.success(`预定成功！`)
      console.log("API Response:", response.data);
      const data = response.data;
      if (Array.isArray(data)) {
        guides.value = data.map((guide: any) => ({
          guideId: guide.guideId,            
          guideName: guide.guideName,
          guideGender: guide.guideGender,
          guideIntroduction: guide.guideIntroduction,
          guideSalary: guide.guideSalary,
          guidePerformanceLevel: Number(guide.guidePerformanceLevel),
          guideSeniority: guide.guideSeniority,
          guidePrice: guide.guidePrice,
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

const confirm = async () => {
  if (selectedGuide.value && date_input.value) {
    const url = `https://123.60.14.84:11100/api/Guide/reservation`;
    try {
      const response = await axios.post(url, {
        GuideId: selectedGuide.value,
        StartDate: date_input.value[0],
        EndDate: date_input.value[1]
      }, {
        headers: {
          'Content-Type': 'application/json',
          'accept': '*/*'
        }
      })
      ElMessage.success(`预定成功！导游: ${selectedGuide.value.guideName}`)
      dialogVisible.value = false
      selectedGuide.value = null
      date_input.value = ''
    } catch (error) {
      ElMessage({
            type: "info",
            message: "预定失败！"
          })
    }
  }else{
    ElMessage.info(`请选择时间`)
  }
}   

const cancel = () => {
  dialogVisible.value = false;
  selectedGuide.value = null
  date_input.value = ''
};

</script>

<template>
<div>
    <div class="filter-container">
      <div class="first-row">
        <span class="word"> 导游编号 </span>
        <el-input
          v-model="guideId_input"
          style="width: 210px"
          placeholder="请输入导游编号"
          :prefix-icon="Search"
          @keyup.enter="fetchById"
        />

        <span class="word"> 导游姓名 </span>
        <el-input
          v-model="guideName_input"
          style="width: 210px"
          placeholder="请输入导游姓名"
          :prefix-icon="Search"
          @keyup.enter="fetchById"
        />

        <el-button type="primary" class="button" style="margin-left: 10px;" @click="fetchById"> 搜索 </el-button>
      </div>

      <div class="second_row">
        <span class="word"> 导游星级 </span>
        <el-input-number v-model="guideGrade_input" :min="1" :max="500000" />
        <span class="word"> 导游价格 </span>
        <el-input-number v-model="guidePrice_input[0]" :min="1" :max="500000"/>
        - 
        <el-input-number v-model="guidePrice_input[1]" :min="1" :max="500000"/>
        
        <el-button type="primary" class="button" @click="fetchByGrade"> 筛选 </el-button>
      </div>
    </div>

    <div class="guide-container">
        <div v-for="guide in guides" :key="guide.guideId" class="guide-card">
            <div class="first">
                <img :src="imageMap[guide.guideId]" alt="导游照片" class="photo"/>
                <div class="guide-name-gender">
                    <p class="name">{{ guide.guideName }}</p>
                    <img v-if="guide.guideGender === '男 '" src="@/views/user/guide/icon/male.svg" alt="男" class="gender-icon" />
                    <img v-else src="@/views/user/guide/icon/female.svg" alt="女" class="gender-icon" />
                </div>    
            </div>
            
            <div class="second" >
                <p>导游编号： {{ guide.guideId }}</p>
                <p>基本介绍: {{ guide.guideIntroduction }}</p>
                <p>价格（日）: ¥{{ guide.guidePrice }}</p>
                <el-rate
                    v-model="guide.guidePerformanceLevel"
                    disabled
                    show-score
                    text-color="#ff9900"
                    score-template="{value}星"
                />
        
            </div>

            <div class="third">
              
                <el-button type="primary" @click="openDialog(guide)">立即预定</el-button>
              
              <!--
              <el-button type="primary" @click="reserve">立即预定</el-button>
              -->
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
.filter-container {
  margin-left: 30px;
  margin-top: 20px;
  margin-right: 40px;
  display: flex;
  gap: 5px; 
  display: flex;
  flex-direction: column;
}

.word, .button{
  margin-left: 10px;
}

.guide-container {
  margin-left: 40px;
  margin-top: 20px;
  margin-right: 40px;
  display: grid;
  grid-template-columns: repeat(4, 1fr); 
  gap: 20px; 
}

.guide-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  background-color: white;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-width: 100%; 
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
  margin: 0;
  font-size: 1.2em;
  font-weight: bold; 
  line-height: 1;
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
