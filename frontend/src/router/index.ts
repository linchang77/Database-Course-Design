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
    path: "/redirect",
    component: Layouts,
    meta: {
      hidden: true
    },
    children: [
      {
        path: ":path(.*)",
        component: () => import("@/views/redirect/index.vue")
      }
    ]
  },
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
    component: Layouts,
    redirect: "/dashboard",
    children: [
      {
        path: "dashboard",
        component: () => import("@/views/dashboard/index.vue"),
        name: "Dashboard",
        meta: {
          title: "首页",
          svgIcon: "dashboard",
          affix: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    children: [
      {
        path: "scene",
        component: () => import("@/views/scene/index.vue"),
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
      hidden: true
    },
    children: [
      {
        path: "shanghai",
        component: () => import("@/views/scene/citys/shanghai.vue"),
        name: "Shanghai",
        meta: {
          hidden: true
        }
      },
      {
        path: "shanghai/tickets",
        component: () => import("@/views/scene/citys/city_shanghai/上海景点购票.vue"),
        name: "SceneTickets",
        meta: {
          hidden: true
        }
      },
      {
        path: "tokyo",
        component: () => import("@/views/scene/citys/tokyo.vue"),
        name: "Tokyo",
        meta: {
          hidden: true
        }
      },
      {
        path: "cairo",
        component: () => import("@/views/scene/citys/cairo.vue"),
        name: "Cairo",
        meta: {
          hidden: true
        }
      },
      {
        path: "paris",
        component: () => import("@/views/scene/citys/paris.vue"),
        name: "Paris",
        meta: {
          hidden: true
        }
      },
      {
        path: "newyork",
        component: () => import("@/views/scene/citys/newyork.vue"),
        name: "Newyork",
        meta: {
          hidden: true
        }
      },
      {
        path: "riodejaneiro",
        component: () => import("@/views/scene/citys/riodejaneiro.vue"),
        name: "Riodejaneiro",
        meta: {
          hidden: true
        }
      },
      {
        path: "sydney",
        component: () => import("@/views/scene/citys/sydney.vue"),
        name: "Sydney",
        meta: {
          hidden: true
        }
      }
    ]
  },
  {
    path: "/",
    component: Layouts,
    children: [
      {
        path: "group-travel",
        component: () => import("@/views/group-travel/index.vue"),
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
    path: '/group-travel',
    component: Layouts,
    meta: {
      hidden: true
    },
    children: [
      {
        path: 'cities/shanghai',
        component: () => import('@/views/group-travel/cities/shanghai.vue'), 
        name: 'shanghai-group',
        meta: {
          hidden: true
        }
      }
    ]
  },
  //csh end
  {
    path: "/",
    component: Layouts,
    children: [
      {
        path: "free-travel",
        component: () => import("@/views/free-travel/index.vue"),
        name: "Free-travel",
        meta: {
          title: "自由行",
          svgIcon: "free-travel",
          affix: true
        }
      }
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
  {
    path: "/",
    component: Layouts,
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
  // {
  //   path: "/unocss",
  //   component: Layouts,
  //   redirect: "/unocss/index",
  //   children: [
  //     {
  //       path: "index",
  //       component: () => import("@/views/unocss/index.vue"),
  //       name: "UnoCSS",
  //       meta: {
  //         title: "UnoCSS",
  //         svgIcon: "unocss"
  //       }
  //     }
  //   ]
  // },
  // {
  //   path: "/link",
  //   meta: {
  //     title: "外链",
  //     svgIcon: "link"
  //   },
  //   children: [
  //     {
  //       path: "https://juejin.cn/post/7089377403717287972",
  //       component: () => {},
  //       name: "Link1",
  //       meta: {
  //         title: "中文文档"
  //       }
  //     },
  //     {
  //       path: "https://juejin.cn/column/7207659644487139387",
  //       component: () => {},
  //       name: "Link2",
  //       meta: {
  //         title: "新手教程"
  //       }
  //     }
  //   ]
  // },
  // {
  //   path: "/table",
  //   component: Layouts,
  //   redirect: "/table/element-plus",
  //   name: "Table",
  //   meta: {
  //     title: "表格",
  //     elIcon: "Grid"
  //   },
  //   children: [
  //     {
  //       path: "element-plus",
  //       component: () => import("@/views/table/element-plus/index.vue"),
  //       name: "ElementPlus",
  //       meta: {
  //         title: "Element Plus",
  //         keepAlive: true
  //       }
  //     },
  //     {
  //       path: "vxe-table",
  //       component: () => import("@/views/table/vxe-table/index.vue"),
  //       name: "VxeTable",
  //       meta: {
  //         title: "Vxe Table",
  //         keepAlive: true
  //       }
  //     }
  //   ]
  // },
  {
    path: "/transport",
    component: Layouts,
    redirect: "/transport/airplane",
    name: "Transport",
    meta: {
      title: "出行",
      svgIcon: "transport"
    },
    children: [
      {
        path: "airplane",
        component: () => import("@/views/transport/airplane/index.vue"),
        name: "Airplane",
        meta: {
          title: "飞机"
        }
      },
      {
        path: "bus",
        component: () => import("@/views/transport/bus/index.vue"),
        name: "Bus",
        meta: {
          title: "大巴",
          keepAlive: true
        }
      },
      {
        path: "train",
        component: () => import("@/views/transport/train/index.vue"),
        name: "Train",
        meta: {
          title: "火车",
          keepAlive: true
        }
      }
    ]
  }

  // {
  //   path: "/hook-demo",
  //   component: Layouts,
  //   redirect: "/hook-demo/use-fetch-select",
  //   name: "HookDemo",
  //   meta: {
  //     title: "Hook",
  //     elIcon: "Menu",
  //     alwaysShow: true
  //   },
  //   children: [
  //     {
  //       path: "use-fetch-select",
  //       component: () => import("@/views/hook-demo/use-fetch-select.vue"),
  //       name: "UseFetchSelect",
  //       meta: {
  //         title: "useFetchSelect"
  //       }
  //     },
  //     {
  //       path: "use-fullscreen-loading",
  //       component: () => import("@/views/hook-demo/use-fullscreen-loading.vue"),
  //       name: "UseFullscreenLoading",
  //       meta: {
  //         title: "useFullscreenLoading"
  //       }
  //     },
  //     {
  //       path: "use-watermark",
  //       component: () => import("@/views/hook-demo/use-watermark.vue"),
  //       name: "UseWatermark",
  //       meta: {
  //         title: "useWatermark"
  //       }
  //     }
  //   ]
  // }
]

/**
 * 动态路由
 * 用来放置有权限 (Roles 属性) 的路由
 * 必须带有 Name 属性
 */
export const dynamicRoutes: RouteRecordRaw[] = [
  {
    path: "/permission",
    component: Layouts,
    redirect: "/permission/page",
    name: "Permission",
    meta: {
      title: "权限",
      svgIcon: "lock",
      roles: ["admin", "editor"], // 可以在根路由中设置角色
      alwaysShow: true // 将始终显示根菜单
    },
    children: [
      {
        path: "page",
        component: () => import("@/views/permission/page.vue"),
        name: "PagePermission",
        meta: {
          title: "页面级",
          roles: ["admin"] // 或者在子导航中设置角色
        }
      },
      {
        path: "directive",
        component: () => import("@/views/permission/directive.vue"),
        name: "DirectivePermission",
        meta: {
          title: "按钮级" // 如果未设置角色，则表示：该页面不需要权限，但会继承根路由的角色
        }
      }
    ]
  }
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
