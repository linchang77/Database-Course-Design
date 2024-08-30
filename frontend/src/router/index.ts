/* eslint-disable prettier/prettier */
import { type RouteRecordRaw, createRouter } from "vue-router"
import { history, flatMultiLevelRoutes } from "./helper"
import routeSettings from "@/config/route"

const Layouts = () => import("@/layouts/index.vue")

/**
 * 常驻路由
 * 除了 redirect/403/404/login 等隐藏页面，其他页面建议设置 Name 属性
 */

export const constantRoutes: RouteRecordRaw[] = [

  {
    path: "/403",
    component: () => import("@/views/error-page/403.vue"),
    meta: {
      hidden: true
    }
  },
  {
    path: "/404",
    component: () => import("@/views/error-page/404.vue"),
    meta: {
      hidden: true
    },
    alias: "/:pathMatch(.*)*"
  },
  {
    path: "/login",
    component: () => import("@/views/login/index.vue"),
    meta: {
      hidden: true
    }
  },
  {
    path: "/",
    redirect: "/self-center",
  },
]

/**
 * 动态路由
 * 用来放置有权限 (Roles 属性) 的路由
 * 必须带有 Name 属性
 */
export const dynamicRoutes: RouteRecordRaw[] = [
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user"]
    },
    children: [
      {
        path: "dashboard",
        component: () => import("@/views/user/dashboard/index.vue"),
        name: "Dashboard",
        meta: {
          title: "首页",
          svgIcon: "dashboard",
          affix: true,
        }
      }
    ]
  },
  {
    path: "/transport",
    component: Layouts,
    redirect: "/transport/airplane",
    name: "Transport",
    meta: {
      title: "出行",
      svgIcon: "transport",
      roles: ["user"],
    },
    children: [
      {
        path: "airplane",
        component: () => import("@/views/user/transport/airplane/index.vue"),
        name: "Airplane",
        meta: {
          title: "飞机",
          svgIcon: "plane",
          affix: true
        }
      },
      {
        path: "bus",
        component: () => import("@/views/user/transport/bus/index.vue"),
        name: "Bus",
        meta: {
          title: "大巴",
          svgIcon: "bus",
          keepAlive: true,
          affix: true
        }
      },
      {
        path: "train",
        component: () => import("@/views/user/transport/train/index.vue"),
        name: "Train",
        meta: {
          title: "火车",
          svgIcon: "train",
          keepAlive: true,
          affix: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user"]
    },
    children: [
      {
        path: "hotel",
        component: () => import("@/views/user/hotel/index.vue"),
        name: "Hotel",
        meta: {
          title: "酒店",
          svgIcon: "hotel",
          affix: true
        }
      }
    ]
  },
  {
    path: "/hotel",
    component: Layouts,
    meta: {
      hidden: true
    },
    children: [
      {
        path: "detail",
        component: () => import("@/views/user/hotel/detail.vue"),
        name: "Detail",
        meta: {
          title: "酒店详情",
          hidden: true
        }
      },
      {
        path: "room",
        component: () => import("@/views/user/hotel/room.vue"),
        name: "Room",
        meta: {
          title: "酒店房型",
          hidden: true
        }
      },
      {
        path: "order",
        component: () => import("@/views/user/hotel/order.vue"),
        name: "Order",
        meta: {
          title: "酒店订单",
          hidden: true
        }
      },
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user"]
    },
    children: [
      {
        path: "scene",
        component: () => import("@/views/user/scene/index.vue"),
        name: "Scene",
        meta: {
          title: "景点",
          svgIcon: "scene",
          affix: true
        }
      }
    ]
  },
  {
    path: "/scene",
    component: Layouts,
    meta: {
      hidden: true,
    },
    children: [
      {
        path: "shanghai",
        component: () => import("@/views/user/scene/citys/shanghai.vue"),
        name: "Shanghai",
        meta: {
          title: "上海"
        }
      },
      {
        path: "shanghai/tickets",
        component: () => import("@/views/user/scene/citys/city_shanghai/上海景点购票.vue"),
        name: "SceneTickets",
        meta: {
          title: "上海景点购票"
        }
      },
      {
        path: "tokyo",
        component: () => import("@/views/user/scene/citys/tokyo.vue"),
        name: "Tokyo",
        meta: {
          title: "东京"
        }
      },
      {
        path: "cairo",
        component: () => import("@/views/user/scene/citys/cairo.vue"),
        name: "Cairo",
        meta: {
          title: "开罗"
        }
      },
      {
        path: "paris",
        component: () => import("@/views/user/scene/citys/paris.vue"),
        name: "Paris",
        meta: {
          title: "巴黎"
        }
      },
      {
        path: "newyork",
        component: () => import("@/views/user/scene/citys/newyork.vue"),
        name: "Newyork",
        meta: {
          title: "纽约"
        }
      },
      {
        path: "riodejaneiro",
        component: () => import("@/views/user/scene/citys/riodejaneiro.vue"),
        name: "Riodejaneiro",
        meta: {
          title: "里约热内卢"
        }
      },
      {
        path: "sydney",
        component: () => import("@/views/user/scene/citys/sydney.vue"),
        name: "Sydney",
        meta: {
          title: "悉尼"
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user"]
    },
    children: [
      {
        path: "group-travel",
        component: () => import("@/views/user/group-travel/index.vue"),
        name: "Group-travel",
        meta: {
          title: "跟团游",
          svgIcon: "group-travel",
          affix: true
        }
      }
    ]
  },
  {
    path: "/group-travel",
    component: Layouts,
    meta: {
      hidden: true
    },
    children: [
    {
      path: "groups/detail",
      component: () => import(`@/views/user/group-travel/groups/detail.vue`), 
      name: "group-detail",
      meta: {
        title: "旅行团",
      }
  }]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user"]
    },
    children: [
      {
        path: "guide",
        component: () => import("@/views/user/guide/index.vue"),
        name: "guide",
        meta: {
          title: "导游",
          svgIcon: "guide",
          affix: true,
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["guide"]
    },
    children: [
      {
        path: "guide-travel",
        component: () => import("@/views/guide/guide-travel/index.vue"),
        name: "Guide-travel",
        meta: {
          title: "带团游",
          svgIcon: "guide",
          affix: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["user","guide"]
    },
    children: [
      {
        path: "my-orders",
        component: () => import("@/views/my-orders/index.vue"),
        name: "My-orders",
        meta: {
          title: "我的订单",
          svgIcon: "my-orders",
          affix: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["guide"]
    },
    children: [
      {
        path: "performance",
        component: () => import("@/views/guide/performance/index.vue"),
        name: "Performance",
        meta: {
          title: "业绩",
          svgIcon: "performance",
          affix: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    meta:{
      roles: ["admin"],
      svgIcon: "management",
      title: "管理",
      affix: true
    },
    children: [
      {
        path: "transport-management",
        component: () => import("@/views/admin/transport-management/index.vue"),
        name: "Transport-management",
        meta: {
          title: "交通管理",
          svgIcon: "transport",
          affix: true
        }
      },
      {
        path: "hotel-management",
        component: () => import("@/views/admin/hotel-management/index.vue"),
        name: "Hotel-management",
        meta: {
          title: "酒店管理",
          svgIcon: "hotel",
          affix: true
        }
      },
      {
        path: "scene-management",
        component: () => import("@/views/admin/scene-management/index.vue"),
        name: "Scene-management",
        meta: {
          title: "景点管理",
          svgIcon: "scene",
          affix: true
        }
      },
      {
        path: "group-management",
        component: () => import("@/views/admin/group-management/index.vue"),
        name: "Group-management",
        meta: {
          title: "旅行团管理",
          svgIcon: "group-travel",
          affix: true
        }
      },
      {
        path: "city-management",
        component: () => import("@/views/admin/city-management/index.vue"),
        name: "City-management",
        meta: {
          title: "城市管理",
          svgIcon: "city",
          affix: true
        }
      },
      {
        path: "users-management",
        component: () => import("@/views/admin/users-management/index.vue"),
        name: "Users-management",
        meta: {
          title: "用户管理",
          svgIcon: "user",
          affix: true
        }
      },
      {
        path: "funds-management",
        component: () => import("@/views/admin/funds-management/index.vue"),
        name: "Funds-management",
        meta: {
          title: "资金管理",
          svgIcon: "fund",
          affix: true
        }
      },
      {
        path: "guides-management",
        component: () => import("@/views/admin/guides-management/index.vue"),
        name: "Guides-management",
        meta: {
          title: "导游管理",
          svgIcon: "guide",
          affix: true
        }
      },
    ]
  },
  {
    path: "/",
    component: Layouts,
    children: [
      {
        path: "self-center",
        component: () => import("@/views/self-center/index.vue"),
        name: "Self-center",
        meta: {
          title: "个人中心",
          svgIcon: "self-center",
          affix: true
        }
      }
    ]
  },
]

const router = createRouter({
  history,
  routes: routeSettings.thirdLevelRouteCache ? flatMultiLevelRoutes(constantRoutes) : constantRoutes
})

/** 重置路由 */
export function resetRouter() {
  // 注意：所有动态路由路由必须带有 Name 属性，否则可能会不能完全重置干净
  try {
    router.getRoutes().forEach((route) => {
      const { name, meta } = route
      if (name && meta.roles?.length) {
        router.hasRoute(name) && router.removeRoute(name)
      }
    })
  } catch {
    // 强制刷新浏览器也行，只是交互体验不是很好
    window.location.reload()
  }
}

export default router
