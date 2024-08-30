using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Controllers
{
    /* 
     * 路由设计
     *api/Guide/
     *      all/
     *          Get         获取全部导游信息
     *      person/
     *          {GuideId},{name}/
     *              Get     根据导游id、姓名筛选
     *      ability/
     *          {minCost},{maxCost},{grade}/
     *              Get     根据价格区间、级别筛选
     *      reservation/
     *          Post    预约导游[GuideReservationResponse:GuideId,StartDate,EndDate]
     */
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController
    {

    }
}
