<template>
  <el-form :model="passengerInfo" label-width="120px">
    <el-form-item label="票数">
      <el-input-number v-model="numberOfTickets" :min="1" :max="10" label="数量" />
    </el-form-item>

    <template v-for="(passenger, index) in passengerInfo" :key="index">
      <el-form-item :label="`乘客 ${index + 1} 姓名`">
        <el-input v-model="passenger.name" placeholder="请输入姓名" />
      </el-form-item>
      <el-form-item :label="`乘客 ${index + 1} 手机号`">
        <el-input v-model="passenger.phone" placeholder="请输入手机号" />
      </el-form-item>
      <el-form-item :label="`乘客 ${index + 1} 身份证号`">
        <el-input v-model="passenger.idCard" placeholder="请输入身份证号" />
      </el-form-item>
    </template>

    <el-form-item>
      <el-button type="primary" @click="$emit('prevStep')">上一步</el-button>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" :disabled="!isBuyButtonEnabled" @click="buyTicket">购票</el-button>
    </el-form-item>
  </el-form>
</template>

<script lang="ts" setup>
import { ref, reactive, computed, watch } from "vue";
import axios from "axios";
import { ElMessage } from "element-plus"
const isBuyButtonEnabled = computed(() => {
  return passengerInfo.every(passenger =>
    passenger.name.trim() !== "" &&
    passenger.phone.trim() !== "" &&
    passenger.idCard.trim() !== ""
  );
});

interface PassengerInfo {
  name: string;
  phone: string;
  idCard: string;
}

interface VehiclePassengerRequest {
  PassengerId: string;
  PassengerName?: string;
}

type Flight = {
  vehicleId: string;
  vehicleType: string;
  vehicleModel: string;
  departureCity: string;
  arrivalCity: string;
  departureTime: string;
  arrivalTime: string;
  departureStation: string;
  arrivalStation: string;
  ticketId: number;
  ticketType: string;
  ticketPrice: number;
  ticketRemaining: number;
};

const orderInfo = defineProps({
  flight: {
    type: Object as () => Flight,
    required: true
  }
});

const numberOfTickets = ref(1);
const passengerInfo = reactive<Array<PassengerInfo>>([]);

const addPassenger = () => {
  const newPassenger: PassengerInfo = {
    name: "",
    phone: "",
    idCard: ""
  };
  passengerInfo.push(newPassenger);
};

const removePassenger = (index: number) => {
  passengerInfo.splice(index, 1);
};

const buildPassengers = () => {
  const newPassengers: VehiclePassengerRequest[] = [];
  passengerInfo.forEach((passenger) => {
    newPassengers.push({
      PassengerId: passenger.idCard,
      PassengerName: passenger.name
    });
  });
  return newPassengers;
};
function returnId() {
  const id = localStorage.getItem("id");
  console.log("id:", id)
  return id
}
const emit = defineEmits(['prevStep', 'nextStep']);
async function buyTicket() {
  const userId = returnId();
  const ticketId = orderInfo.flight.ticketId;
  const passengers = buildPassengers();

  const url = `https://123.60.14.84/api/Vehicle/ticket/purchase/${userId},${ticketId}`;

  console.log("posting to url:", url);
  console.log("passengers:", passengers);
  try {
    const response = await axios.post(url, passengers);
    console.log("Ticket bought successfully:", response.data);
    ElMessage.success("购票成功！");
    emit('nextStep');
  } catch (error) {
    console.error("Error buying ticket:", error);
    ElMessage.warning("购票失败，请稍后再试。");
  }
}



// 初始化乘客信息
addPassenger();

// 监听票数变化并添加或移除乘客
watch(numberOfTickets, (newVal, oldVal) => {
  if (newVal > oldVal) {
    for (let i = passengerInfo.length; i < newVal; i++) {
      addPassenger();
    }
  } else if (newVal < oldVal) {
    for (let i = oldVal - 1; i >= newVal; i--) {
      removePassenger(i);
    }
  }
});
</script>
