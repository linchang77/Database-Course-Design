using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Controllers
{
    /*业务逻辑（用户个人信息）：
         普通用户个人中心界面
    api/
        Profile/
            user/
                {id}/
                    GET             - 获取指定ID的普通用户信息
                    name/{name}/
                        PUT         - 修改指定ID的普通用户的用户名
                    password/{password}/
                        PUT         - 修改指定ID的普通用户的密码
                    picture/{picture}/
                        PUT         - 修改指定ID的普通用户的头像
                    gender/{gender}/
                        PUT         - 修改指定ID的普通用户的性别
                    phone/
                        add/{number}/
                            POST    - 增加指定ID的普通用户的手机号码
                        delete/{number}/
                            DELETE  - 删除指定ID的普通用户的手机号码
                        modify/{old},{new}/
                            PUT     - 修改指定ID的普通用户的手机号码
      业务逻辑（导游个人信息）：
         导游个人中心界面
    api/
        Profile/
            guide/
                {id}/
                    GET             - 获取指定ID的导游信息
                    name/{name}/
                        PUT         - 修改指定ID的导游的用户名
                    password/{password}/
                        PUT         - 修改指定ID的导游的密码
                    picture/{picture}/
                        PUT         - 修改指定ID的导游的头像
                    gender/{gender}/
                        PUT         - 修改指定ID的导游的性别
                    intro/{intro}/
                        PUT         - 修改指定ID的导游的介绍
                    price/{price}/
                        PUT         - 修改指定ID的导游的价格
                    phone/
                        add/{numbers}/
                            POST    - 增加指定ID的导游的手机号码
                        delete/{numbers}/
                            DELETE  - 删除指定ID的导游的手机号码
                        modify/{old},{new}/
                            PUT     - 修改指定ID的导游的手机号码
                    regions/
                        add/{region}/
                            POST    - 增加指定ID的导游的地区
                        delete/{region}/
                            DELETE  - 删除指定ID的导游的地区
                        modify/{old},{new}/
                            PUT     - 修改指定ID的导游的地区
      业务逻辑（管理员个人信息）：
         管理员个人中心界面
    api/
        Profile/
            admin/
                {id}/
                    GET             - 获取指定ID的管理员信息
                    name/{name}/
                        PUT         - 修改指定ID的管理员信息
                    password/{password}/
                        PUT         - 修改指定ID的管理员信息
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        
    }
}
