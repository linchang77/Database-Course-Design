using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using db_course_design.Profiles;
using db_course_design.Common;
using static db_course_design.Controler.AuthController;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace db_course_design.Services.impl
{
    public class GuideRequest
    {
        public string? GuideName { get; set; }

        public string? GuideGender { get; set; }

        public string? GuideIntroduction { get; set; }

        public decimal? GuideSalary { get; set; }

        public string? GuidePerformanceLevel { get; set; }

        public string? GuideSeniority { get; set; }

        public decimal? GuidePrice { get; set; }

        public string? ProfilePicture { get; set; }

        public bool? GuideFree { get; set; }

        public string? Password { get; set; }
    }

    public class GuideService : IGuideService
    {
        private readonly ModelContext _context;

        public IMapper _mapper { get; }


        public GuideService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<GuideProfile>()).CreateMapper();
        }
        /*--获取全部导游信息--*/
        public async Task<List<GuideResponse>> GetAllGuideAsync()
        {
            return await _context.Guides.Select(p => _mapper.Map<GuideResponse>(p)).ToListAsync();
        }
        /*--根据导游id、姓名筛选--*/
        public async Task<List<GuideResponse>> GetGuideByPersonAsync(byte? GuideId, string? name)
        {
            var query = _context.Guides.AsQueryable();

            if (GuideId.HasValue)
            {
                query = query.Where(o => o.GuideId == GuideId);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(o => o.GuideName.Equals(name));
            }
            
            var guides = await query
                .Select(o => _mapper.Map<GuideResponse>(o)).ToListAsync();
            return guides;
        }
        /*--根据价格区间、级别筛选--*/
        public async Task<List<GuideResponse>> GetGuideByAbilityAsync(decimal? minCost,decimal? maxCost,string? grade)
        {
            var query = _context.Guides.AsQueryable();

            if (!string.IsNullOrEmpty(grade))
            {
                query = query.Where(o => o.GuidePerformanceLevel.Equals(grade));
            }
            if (minCost.HasValue)
            {
                Console.WriteLine("get minCost" + minCost.Value);
                query = query.Where(o => o.GuidePrice.HasValue
                && decimal.Compare(o.GuidePrice.Value, minCost.Value) >= 0);
            }
            if (maxCost.HasValue)
            {
                Console.WriteLine("get maxCost" + maxCost.Value);
                query = query.Where(o => o.GuidePrice.HasValue
                && decimal.Compare(o.GuidePrice.Value, maxCost.Value) <= 0);
            }

            var guides = await query
                .Select(o => _mapper.Map<GuideResponse>(o)).ToListAsync();
            return guides;
        }

        public async Task<GuideResponse> GetGuideByIdAsync(byte GuideId)
        {
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return null;
            }

            return _mapper.Map<GuideResponse>(guide);
        }
        /*--获取某个导游近一年的工作时间*/
        public async Task<List<GuideTimeRange>> GetGuideWorkTimeAsync(byte GuideId)
        {
            var guide = await _context.Guides
                .Where(g => g.GuideId == GuideId)
                .Include(g => g.GuideOrders)
                .ThenInclude(go => go.Order)
                .Include(g => g.TourGroups)
                .ThenInclude(tg => tg.TourOrders)
                .ThenInclude(to => to.Order)
                .FirstOrDefaultAsync();

            if (guide == null)
            {
                throw new Exception("导游不存在");
            }

            // 获取所有持续到明天之后导游和旅行团订单分别排序
            var Gorders = guide.GuideOrders
                .Where(o => o.ServiceEndDate >= DateTime.UtcNow.AddDays(1) && o.Order.Status.Equals("Completed"))
                .OrderBy(o => o.ServiceBeginDate)
                .ToList();
            var Torders = guide.TourGroups
                .Where(o => o.EndDate >= DateTime.UtcNow.AddDays(1) && o.TourOrders.All(t => t.Order.Status.Equals("Completed")))
                .OrderBy(o => o.StartDate)
                .ToList();

            // 使用AutoMapper进行映射
            var GWorkTime = Gorders.Select(o => _mapper.Map<GuideTimeRange>(o)).ToList();
            var TWorkTime = Torders.Select(o => _mapper.Map<GuideTimeRange>(o)).ToList();
            
            // 合并并重新排序
            var AllWorkTime = GWorkTime.Concat(TWorkTime).ToList();
            AllWorkTime = AllWorkTime.OrderBy(o => o.StartDate).ToList();

            /* 输出调试信息*/
            Console.WriteLine("All Work Times:");
            foreach (var workTime in AllWorkTime)
            {
                Console.WriteLine($"StartDate: {workTime.StartDate}, EndDate: {workTime.EndDate}");
            }

            return AllWorkTime;
        }
        /*--获取某个导游可预约时间--*/
        public async Task<List<GuideTimeRange>> GetGuideFreeTimesAsync(byte GuideId)
        {
            var workTimes = await GetGuideWorkTimeAsync(GuideId);
            
            // 如果没有工作
            List<GuideTimeRange> freeTimes = new List<GuideTimeRange>();
            if (!workTimes.Any())
            {
                freeTimes.Add(new GuideTimeRange
                {
                    StartDate = DateTime.UtcNow.Date.AddDays(1),
                    EndDate = DateTime.UtcNow.Date.AddYears(1)
                });
                return freeTimes;
            }

            // 根据工作时间计算空闲时间
            DateTime? lastEndDate = DateTime.UtcNow;
            foreach (var time in workTimes)
            {
                Console.WriteLine($"{lastEndDate}<{time.StartDate}");
                if(lastEndDate.Value.Date < time.StartDate)
                {
                    freeTimes.Add(new GuideTimeRange
                    {
                        StartDate = lastEndDate.Value.AddDays(1),
                        EndDate = time.StartDate.Value.AddDays(-1)
                    });
                }

                lastEndDate = time.EndDate;
            }

            // 如果最后一个工作结束时间小于一年后，则剩下的都是freetime
            if (lastEndDate < DateTime.UtcNow.AddYears(1))
            {
                freeTimes.Add(new GuideTimeRange
                {
                    StartDate = lastEndDate.Value.AddDays(1),
                    EndDate = DateTime.UtcNow.AddYears(1)
                });
            }

            return freeTimes;
        }
        /*--计算导游订单Price--*/
        public async Task<decimal?> CountPriceAsync(int days, byte GuideId)
        {
            decimal? price = null;

            var PricePerDay = (await _context.Guides.FindAsync(GuideId)).GuidePrice;
            price = PricePerDay * days;

            return price;
        }
        /*--创建一个导游订单--*/
        public async Task<bool> CreateGuideOrderAsync(GuideReservationRequest request)
        {
            var freeTimes = await GetGuideFreeTimesAsync(request.GuideId);

            // 判断预约时间合法性
            if(!freeTimes.Any())
                return false;

            bool legal = false;
            foreach(var time in freeTimes)
            {
                if(request.StartDate >= time.StartDate && request.EndDate <= time.EndDate)
                {
                    legal = true;
                    break;
                }
            }
            if (!legal)
                return false;

            // 添加数据到Order_Data表，保存后同步Guide_Order
            var orderDatum = new OrderDatum
            {
                OrderType = "guide",
                OrderDate = DateTime.Now,
                UserId = request.userId,
                Status = "Pending",
                Price = await CountPriceAsync((request.EndDate-request.StartDate).Value.Days + 1, request.GuideId),
            };
            _context.OrderData.Add(orderDatum);
            await _context.SaveChangesAsync();
            var guideOrder = new GuideOrder
            {
                OrderId = orderDatum.OrderId,
                GuideId = request.GuideId,
                ServiceBeginDate = request.StartDate,
                Service = request.Service,
                ServiceEndDate = request.EndDate,
            };
            _context.GuideOrders.Add(guideOrder);
            await _context.SaveChangesAsync();

            return true;
        }

        /*--按条件筛选--*/
        public async Task<List<GuideOrderDetailOfGuide>> GuideOrderFilter(byte GuideId, int? UserId, DateTime? StartDate, DateTime? EndDate)
        {
            var query = _context.GuideOrders.AsQueryable();
            query = query.Where(o => o.GuideId == GuideId && o.Order.Status.Equals("Completed"));
            if (UserId != null)
                query = query.Where(o => o.Order.UserId == UserId);
            if (StartDate.HasValue)
                query = query.Where(o => o.ServiceEndDate > StartDate);
            if (EndDate.HasValue)
                query = query.Where(o => o.ServiceBeginDate < EndDate);
            var Gorders = await query
                .Select(o => new GuideOrderDetailOfGuide
                {
                    OrderId = o.OrderId,
                    OrderType = "GuideOrder",
                    Status = o.Order.Status,
                    Price = o.Order.Price,
                    ServiceBeginDate = o.ServiceBeginDate,
                    ServiceEndDate = o.ServiceEndDate,
                    Service = o.Service,
                    GuideId = o.Guide.GuideId,
                    GuideName = o.Guide.GuideName,
                    GuideGender = o.Guide.GuideGender,
                    UserId = o.Order.UserId,
                    UserName = o.Order.User.UserName,
                }).ToListAsync();
            return Gorders;
        }
        public async Task<List<TourGroupDetail>> TourOrderFilter(byte GuideId, DateTime? StartDate, DateTime? EndDate)
        {
            var query = _context.TourGroups.AsQueryable();
            query = query.Where(o => o.GuideId == GuideId && o.TourOrders.All(to => to.Order.Status.Equals("Completed")));
            if (StartDate.HasValue)
                query = query.Where(o => o.EndDate > StartDate);
            if (EndDate.HasValue)
                query = query.Where(o => o.StartDate < EndDate);
            var Torders = await query
                .Select(o => new TourGroupDetail
                {
                    GroupId = o.GroupId,
                    GroupName = o.GroupName,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    OrderNumber = o.TourOrders.Count,
                }).ToListAsync();
            return Torders;
        }
        public async Task<List<OrderResponseOfGuide>> OrderFilterofGuide(byte GuideId, string? OrderType, int? UserId, DateTime? StartDate, DateTime? EndDate)
        {
            var allOrders = new List<OrderResponseOfGuide>();
            if (UserId.HasValue)
            {
                var guideOrder = await GuideOrderFilter(GuideId, UserId, StartDate, EndDate);
                allOrders.AddRange(guideOrder);
            }
            else
            {
                if (OrderType == null)
                {
                    var guideOrder = await GuideOrderFilter(GuideId, UserId, StartDate, EndDate);
                    var tourOrder = await TourOrderFilter(GuideId, StartDate, EndDate);
                    allOrders.AddRange(guideOrder);
                    allOrders.AddRange(tourOrder);
                }
                else if (OrderType.Equals("GuideOrder"))
                {
                    var guideOrder = await GuideOrderFilter(GuideId, UserId, StartDate, EndDate);
                    allOrders.AddRange(guideOrder);
                }
                else if (OrderType.Equals("TourOrder"))
                {
                    var tourOrder = await TourOrderFilter(GuideId, StartDate, EndDate);
                    allOrders.AddRange(tourOrder);
                }
            }
            return allOrders;
        }
        /*--添加导游信息--*/
        public async Task<GuideResponse> AddGuideAsync(GuideRequest guideRequest)
        {
            guideRequest.Password= SaltedPassword.HashPassword(guideRequest.Password, SaltedPassword.salt);
            var guide = _mapper.Map<Guide>(guideRequest);

            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();

            return _mapper.Map<GuideResponse>(guide);
        }

        /*--上传导游图片--*/
        public async Task<bool> AddGuidePictureAsync(byte GuideId, string? Url)
        {
            var target = await _context.Guides.FindAsync(GuideId);
            if(target == null)
                return false;

            target.ProfilePicture = Url;
            await _context.SaveChangesAsync();
            return true;
        }

        /*--修改导游信息--*/
        public async Task<GuideResponse> UpdateGuideAsync(byte GuideId, GuideRequest guideRequest)
        {
            guideRequest.Password = SaltedPassword.HashPassword(guideRequest.Password, SaltedPassword.salt);
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return null;
            }

            _mapper.Map(guideRequest, guide);

            _context.Guides.Update(guide);
            await _context.SaveChangesAsync();

            return _mapper.Map<GuideResponse>(guide);
        }



        /*--删除导游信息--*/
        public async Task<bool> DeleteGuideAsync(byte GuideId)
        {
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return false;
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
