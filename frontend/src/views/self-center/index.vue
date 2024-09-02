<script setup>
import { ref, onMounted } from "vue"
import axios from "axios"

const userType = ref("")
const user = ref({
  Id: null,
  Name: "未设置",
  Gender: "未设置",
  ProfilePicture: "",
  PhoneNumbers: []
})

const guide = ref({
  Id: null,
  Password: "未设置",
  Name: "未设置",
  Gender: "未设置",
  Introduction: "未设置",
  Salary: 0,
  PerformanceLevel: "未设置",
  Seniority: "未设置",
  Price: 0,
  ProfilePicture: "",
  PhoneNumbers: [],
  Regions: []
})

const admin = ref({
  Id: null,
  Password: "未设置",
  Name: "未设置"
})

const isEditing = ref({
  userName: false,
  userGender: false,
  userPhoneNumbers: [],
  guideName: false,
  guideIntroduction: false,
  guideGender: false,
  guidePhoneNumbers: [],
  guideRegions: [],
  adminName: false,
  oldPhoneNumber: null,
  oldRegion: null
})

const newPhoneNumber = ref("") // 存储新号码的变量
const addingPhoneNumber = ref(false) // 控制是否在添加新号码

const newRegion = ref("") // 存储新区域的变量
const addingRegion = ref(false) // 控制是否在添加新区域

const baseUrl = "https://123.60.14.84"

// 获取用户信息
async function fetchUserData() {
  try {
    if (userType.value === "user") {
      const response = await axios.get(`${baseUrl}/api/Profile/user/${user.value.Id}`)
      user.value = {
        Id: response.data.id || "未设置",
        Name: response.data.name || "未设置",
        Gender: response.data.gender || "未设置",
        ProfilePicture: response.data.profilePicture || "",
        PhoneNumbers: response.data.phoneNumbers.length ? response.data.phoneNumbers : []
      }
    } else if (userType.value === "guide") {
      const response = await axios.get(`${baseUrl}/api/Profile/guide/${guide.value.Id}`)
      guide.value = {
        Id: response.data.id || "未设置",
        Name: response.data.name || "未设置",
        Gender: response.data.gender || "未设置",
        ProfilePicture: response.data.profilePicture || "",
        Introduction: response.data.introduction || "未设置",
        Price: response.data.price || "未设置",
        Regions: response.data.regions.length ? response.data.regions : [],
        PhoneNumbers: response.data.phoneNumbers.length ? response.data.phoneNumbers : []
      }
    } else if (userType.value === "admin") {
      const response = await axios.get(`${baseUrl}/api/Profile/admin/${admin.value.Id}`)
      admin.value = {
        Id: response.data.id || "未设置",
        Name: response.data.name || "未设置"
      }
    }
  } catch (error) {
    console.error("Error fetching user data:", error)
    alert("获取用户信息失败")
  }
}

// 更新用户信息
async function updateUserData(field, value) {
  try {
    let apiUrl = ""

    if (userType.value === "user") {
      const userId = user.value.Id
      apiUrl = `${baseUrl}/api/Profile/user/${userId}/${field}/${value}`
    } else if (userType.value === "guide") {
      const guideId = guide.value.Id
      apiUrl = `${baseUrl}/api/Profile/guide/${guideId}/${field}/${value}`
    } else if (userType.value === "admin") {
      const adminId = admin.value.Id
      apiUrl = `${baseUrl}/api/Profile/admin/${adminId}/${field}/${value}`
    }

    await axios.put(apiUrl, {})
    alert("新信息已保存！")
  } catch (error) {
    console.error("Error updating user data:", error)
    alert("更新信息失败！")
  }
}

// 添加电话号码
async function addPhoneNumber() {
  if (!newPhoneNumber.value) {
    alert("请输入一个有效的电话号码")
    return
  }

  try {
    if (userType.value === "guide") {
      const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/phone/add/${newPhoneNumber.value}`
      await axios.post(apiUrl)
    } else if (userType.value === "user") {
      const apiUrl = `${baseUrl}/api/Profile/user/${user.value.Id}/phone/add/${newPhoneNumber.value}`
      await axios.post(apiUrl)
    }
    fetchUserData() // 刷新数据
    addingPhoneNumber.value = false
    newPhoneNumber.value = "" // 清空临时号码
  } catch (error) {
    console.error("Error adding phone number:", error)
  }
  window.location.reload()
}

// 删除电话号码
async function deletePhoneNumber(oldNumber) {
  try {
    if (userType.value === "guide") {
      const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/phone/delete/${oldNumber}`
      await axios.delete(apiUrl)
    } else if (userType.value === "user") {
      const apiUrl = `${baseUrl}/api/Profile/user/${user.value.Id}/phone/delete/${oldNumber}`
      await axios.delete(apiUrl)
    }
    alert("电话号码删除成功！")
    fetchUserData() // 更新用户信息
    window.location.reload()
  } catch (error) {
    console.error("Error deleting phone number:", error)
    alert("删除电话号码失败！")
  }
}

function toggleEditPhone(index) {
  if (userType.value === "guide") {
    if (!isEditing.value.guidePhoneNumbers[index]) {
      // 开始编辑时，保存当前的旧号码
      isEditing.value.oldPhoneNumber = guide.value.PhoneNumbers[index]
    } else {
      // 停止编辑时，清除旧号码
      isEditing.value.oldPhoneNumber = null
    }
    isEditing.value.guidePhoneNumbers[index] = !isEditing.value.guidePhoneNumbers[index]
  } else {
    if (!isEditing.value.userPhoneNumbers[index]) {
      isEditing.value.oldPhoneNumber = user.value.PhoneNumbers[index]
    } else {
      // 停止编辑时，清除旧号码
      isEditing.value.oldPhoneNumber = null
    }
    isEditing.value.userPhoneNumbers[index] = !isEditing.value.userPhoneNumbers[index]
  }
}

async function savePhoneNumber(index) {
  const oldPhoneNumber = isEditing.value.oldPhoneNumber // 获取保存的旧号码
  if (userType.value === "guide") {
    const newPhoneNumber = guide.value.PhoneNumbers[index] // 获取用户输入的新的电话号码

    // 检查号码是否修改或无效
    if (!newPhoneNumber || oldPhoneNumber === newPhoneNumber) {
      alert("号码未修改或无效")
      toggleEditPhone(index) // 退出编辑模式
      return
    }

    try {
      const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/phone/modify/${oldPhoneNumber},${newPhoneNumber}`
      await axios.put(apiUrl)
      alert("号码已修改！")
      toggleEditPhone(index)
      fetchUserData() // 更新数据
      window.location.reload()
    } catch (error) {
      console.error("Error saving phone number:", error)
      alert("保存失败：" + (error.response?.data?.message || error.message))
    }
  } else {
    const newPhoneNumber = user.value.PhoneNumbers[index] // 获取用户输入的新的电话号码

    // 检查号码是否修改或无效
    if (!newPhoneNumber || oldPhoneNumber === newPhoneNumber) {
      alert("号码未修改或无效")
      toggleEditPhone(index) // 退出编辑模式
      return
    }

    try {
      const apiUrl = `${baseUrl}/api/Profile/user/${user.value.Id}/phone/modify/${oldPhoneNumber},${newPhoneNumber}`
      await axios.put(apiUrl)
      alert("号码已修改！")
      toggleEditPhone(index)
      fetchUserData() // 更新数据
      window.location.reload()
    } catch (error) {
      console.error("Error saving phone number:", error)
      alert("保存失败：" + (error.response?.data?.message || error.message))
    }
  }
}

// 添加地区
async function addRegion() {
  if (!newRegion.value) {
    alert("请输入一个有效的区域")
    return
  }

  try {
    const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/regions/add/${newRegion.value}`
    await axios.post(apiUrl)
    alert("区域已添加！")
    fetchUserData() // 刷新数据
    addingRegion.value = false
    newRegion.value = "" // 清空临时区域
  } catch (error) {
    console.error("Error adding region:", error)
  }
  window.location.reload()
}

// 删除地区
async function deleteRegion(region) {
  try {
    const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/regions/delete/${region}`
    await axios.delete(apiUrl)
    alert("区域已删除！")
    fetchUserData() // 刷新数据
    window.location.reload()
  } catch (error) {
    console.error("Error deleting region:", error)
    alert("删除区域失败：" + (error.response?.data?.message || error.message))
  }
}

// 修改地区
async function saveRegion(index) {
  const oldRegion = isEditing.value.oldRegion // 获取保存的旧区域
  const newRegion = guide.value.Regions[index] // 获取用户输入的新区域

  // 检查区域是否修改或无效
  if (!newRegion || oldRegion === newRegion) {
    alert("区域未修改或无效")
    toggleEditRegion(index) // 退出编辑模式
    return
  }

  try {
    const apiUrl = `${baseUrl}/api/Profile/guide/${guide.value.Id}/regions/modify/${oldRegion},${newRegion}`
    await axios.put(apiUrl)
    alert("区域已修改！")
    toggleEditRegion(index)
    fetchUserData() // 更新数据
    window.location.reload()
  } catch (error) {
    console.error("Error saving region:", error)
    alert("保存区域失败：" + (error.response?.data?.message || error.message))
  }
}

// 切换地区编辑状态
function toggleEditRegion(index) {
  if (!isEditing.value.guideRegions[index]) {
    isEditing.value.oldRegion = guide.value.Regions[index] // 开始编辑时，保存旧区域
  } else {
    isEditing.value.oldRegion = null // 停止编辑时，清除旧区域
  }
  isEditing.value.guideRegions[index] = !isEditing.value.guideRegions[index]
}

function toggleEdit(field) {
  isEditing.value[field] = !isEditing.value[field]
}

async function saveChanges(field, value) {
  try {
    await updateUserData(field, value)
    toggleEdit(field)
    window.location.reload()
  } catch (error) {
    console.error("Error saving changes:", error)
    alert("保存失败!")
  }
}

onMounted(() => {
  const id = localStorage.getItem("id")
  const role = localStorage.getItem("role")

  if (id && role) {
    userType.value = role

    if (role === "user") {
      user.value.Id = parseInt(id)
    } else if (role === "guide") {
      guide.value.Id = parseInt(id)
    } else if (role === "admin") {
      admin.value.Id = parseInt(id)
    }

    fetchUserData()
  } else {
    alert("获取用户失败！")
  }
})
</script>

<template>
  <div class="profile-container">
    <h1 class="title">用户信息</h1>

    <div v-if="userType === 'user'">
      <div class="info-section">
        <div class="label">ID</div>
        <div class="content">{{ user.Id }}</div>
      </div>
      <div class="info-section">
        <div class="label">游客名称</div>
        <div class="content">
          <span v-if="!isEditing.userName">{{ user.Name }}</span>
          <input v-else v-model="user.Name" />
          <button @click="toggleEdit('userName')" v-if="!isEditing.userName">修改</button>
          <button @click="saveChanges('name', user.Name)" v-else>保存</button>
        </div>
      </div>
      <div class="info-section">
        <div class="label">游客性别</div>
        <div class="content">
          <span v-if="!isEditing.userGender">{{ user.Gender }}</span>
          <input v-else v-model="user.Gender" />
          <button @click="toggleEdit('userGender')" v-if="!isEditing.userGender">修改</button>
          <button @click="saveChanges('gender', user.Gender)" v-else>保存</button>
        </div>
      </div>
      <div class="info-section">
        <div class="label">电话号码</div>
        <div class="content phone-list">
          <div v-for="(phone, index) in user.PhoneNumbers" :key="index" class="phone-item">
            <div v-if="!isEditing.userPhoneNumbers[index]" class="phone-number">{{ phone }}</div>
            <div v-else>
              <input v-model="user.PhoneNumbers[index]" />
            </div>
            <div class="button-group">
              <button v-if="!isEditing.userPhoneNumbers[index]" @click="toggleEditPhone(index)">修改</button>
              <button v-else @click="savePhoneNumber(index)">保存</button>
              <button @click="deletePhoneNumber(phone)">删除号码</button>
            </div>
          </div>

          <div v-if="!addingPhoneNumber" class="add-phone">
            <button @click="addingPhoneNumber = true">添加号码</button>
          </div>
          <div v-else>
            <input v-model="newPhoneNumber" placeholder="输入新号码" />
            <button @click="addPhoneNumber">保存号码</button>
            <button @click="addingPhoneNumber = false">取消</button>
          </div>
        </div>
      </div>
    </div>
    <div v-else-if="userType === 'guide'">
      <div class="info-section">
        <div class="label">ID</div>
        <div class="content">{{ guide.Id }}</div>
      </div>
      <div class="info-section">
        <div class="label">导游名称</div>
        <div class="content">
          <span v-if="!isEditing.guideName">{{ guide.Name }}</span>
          <input v-else v-model="guide.Name" />
          <button @click="toggleEdit('guideName')" v-if="!isEditing.guideName">修改</button>
          <button @click="saveChanges('name', guide.Name)" v-else>保存</button>
        </div>
      </div>
      <div class="info-section">
        <div class="label">导游性别</div>
        <div class="content">
          <span v-if="!isEditing.guideGender">{{ guide.Gender }}</span>
          <input v-else v-model="guide.Gender" />
          <button @click="toggleEdit('guideGender')" v-if="!isEditing.guideGender">修改</button>
          <button @click="saveChanges('gender', guide.Gender)" v-else>保存</button>
        </div>
      </div>
      <div class="info-section">
        <div class="label">导游价格</div>
        <div class="content">
          <span>{{ guide.Price }}</span>
        </div>
      </div>
      <div class="info-section">
        <div class="label">导游介绍</div>
        <div class="content">
          <span v-if="!isEditing.guideIntroduction">{{ guide.Introduction }}</span>
          <input v-else v-model="guide.Introduction" />
          <button @click="toggleEdit('guideIntroduction')" v-if="!isEditing.guideIntroduction">修改</button>
          <button @click="saveChanges('intro', guide.Introduction)" v-else>保存</button>
        </div>
      </div>
      <div class="info-section">
        <div class="label">电话号码</div>
        <div class="content phone-list">
          <div v-for="(phone, index) in guide.PhoneNumbers" :key="index" class="phone-item">
            <div v-if="!isEditing.guidePhoneNumbers[index]" class="phone-number">{{ phone }}</div>
            <div v-else>
              <input v-model="guide.PhoneNumbers[index]" />
            </div>
            <div class="button-group">
              <button v-if="!isEditing.guidePhoneNumbers[index]" @click="toggleEditPhone(index)">修改</button>
              <button v-else @click="savePhoneNumber(index)">保存</button>
              <button @click="deletePhoneNumber(phone)">删除号码</button>
            </div>
          </div>

          <div v-if="!addingPhoneNumber" class="add-phone">
            <button @click="addingPhoneNumber = true">添加号码</button>
          </div>
          <div v-else>
            <input v-model="newPhoneNumber" placeholder="输入新号码" />
            <button @click="addPhoneNumber">保存号码</button>
            <button @click="addingPhoneNumber = false">取消</button>
          </div>
        </div>
      </div>
      <div class="info-section">
        <div class="label">导游地区</div>
        <div class="content phone-list">
          <div v-for="(region, index) in guide.Regions" :key="index" class="phone-item">
            <div v-if="!isEditing.guideRegions[index]" class="phone-number">{{ region }}</div>
            <div v-else>
              <input v-model="guide.Regions[index]" />
            </div>
            <div class="button-group">
              <button v-if="!isEditing.guideRegions[index]" @click="toggleEditRegion(index)">修改</button>
              <button v-else @click="saveRegion(index)">保存</button>
              <button @click="deleteRegion(region)">删除地区</button>
            </div>
          </div>

          <div v-if="!addingRegion" class="add-phone">
            <button @click="addingRegion = true">添加地区</button>
          </div>
          <div v-else>
            <input v-model="newRegion" placeholder="输入新区域" />
            <button @click="addRegion">保存地区</button>
            <button @click="addingRegion = false">取消</button>
          </div>
        </div>
      </div>
    </div>

    <div v-else-if="userType === 'admin'">
      <div class="info-section">
        <div class="label">ID</div>
        <div class="content">{{ admin.Id }}</div>
      </div>
      <div class="info-section">
        <div class="label">管理员名称</div>
        <div class="content">
          <span v-if="!isEditing.adminName">{{ admin.Name }}</span>
          <input v-else v-model="admin.Name" />
          <button @click="toggleEdit('adminName')" v-if="!isEditing.adminName">修改</button>
          <button @click="saveChanges('name', admin.Name)" v-else>保存</button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.profile-container {
  padding: 20px;
  max-width: 900px;
  margin: 0 auto;
}

.title {
  text-align: center;
  font-size: 56px;
  margin-bottom: 20px;
  color: rgb(0, 157, 255);
}

.info-section {
  display: flex;
  margin-bottom: 15px;
  border: 2px solid rgb(0, 157, 255);
  border-radius: 8px;
  overflow: hidden;
}

.label {
  background-color: rgb(0, 157, 255);
  color: white;
  padding: 10px;
  width: 30%;
  text-align: center;
  display: flex;
  align-items: center;
  justify-content: center;
}

.content {
  background-color: white;
  padding: 10px;
  width: 600px;
  text-align: left;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

input {
  padding: 5px;
  font-size: 16px;
}

button {
  margin-left: 10px;
  padding: 5px 10px;
  background-color: rgb(0, 157, 255);
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.phone-list {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.phone-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  margin-bottom: 10px;
}

.phone-number {
  text-align: left; /* 确保电话号码靠左对齐 */
}

.button-group {
  display: flex;
  gap: 10px; /* 按钮之间的间距 */
  justify-content: flex-end; /* 确保按钮靠右对齐 */
}
</style>
