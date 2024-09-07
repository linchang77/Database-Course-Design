using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Profiles;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace db_course_design.Services.impl
{
    public class CityRequest
    {
        public string CityName { get; set; } = null!;

        public string? Province { get; set; }

        public string? CityIntroduction { get; set; }

        public decimal? TodayTemperature { get; set; }

        public string? TodayWeather { get; set; }

        public decimal? TomorrowTemperature { get; set; }

        public string? TomorrowWeather { get; set; }
    }

    public class CityService : ICityService
    {
        private readonly ModelContext _context;

        public IMapper _mapper { get; }

        public CityService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<CityProfile>()).CreateMapper();
        }

        public async Task<ICollection<CityResponse>> GetAllCitiesAsync()
        {
            return await _context.Cities.Select(c => _mapper.Map<CityResponse>(c)).ToListAsync();
        }

        public async Task<CityResponse?> GetCityByNameAsync(string name)
        {
            var city = await _context.Cities.FindAsync(name);

            if (city == null)
                return null;
            return _mapper.Map<CityResponse>(city);
        }

        public async Task<CityDetail?> GetCityDetailByNameAsync(string name)
        {
            var city = await _context.Cities
                .Where(c => c.CityName == name)
                .Include(c => c.Climate)
                .Include(c => c.Hotels)
                .Include(c => c.ScenicSpots)
                .Include(c => c.VehicleScheduleArrivalCityNavigations)
                .Include(c => c.VehicleScheduleDepartureCityNavigations)
                .Include(c => c.VehicleTicketTicketArrivalCityNavigations)
                .Include(c => c.VehicleTicketTicketDepartureCityNavigations)
                .SingleOrDefaultAsync();

            if (city == null)
                return null;
            return _mapper.Map<CityDetail>(city);
        }

        public async Task<CityResponse?> AddCityAsync(CityRequest request)
        {
            try
            {
                var city = _mapper.Map<City>(request);
                var climate = _mapper.Map<Climate>(request);
                _context.Cities.Add(city);
                _context.Climates.Add(climate);
                await _context.SaveChangesAsync();
                return _mapper.Map<CityResponse>(city);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteCityAsync(string name)
        {
            var target = await _context.Cities.FindAsync(name);

            if (target == null)
                return false;

            _context.Cities.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> UpdateCityIntroAsync(string name, string intro)
        {
            try
            {
                var target = await _context.Cities.FindAsync(name);
                if (target == null)
                    throw new Exception();
                target.CityIntroduction = intro;
                await _context.SaveChangesAsync();
                return target.CityIntroduction;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ClimateResponse?> UpdateCityClimateAsync(string name, decimal t1, string w1, decimal t2, string w2)
        {
            try
            {
                var target = await _context.Climates.FindAsync(name);
                if (target == null)
                    throw new Exception();
                target.TodayTemperature = t1;
                target.TodayWeather = w1;
                target.TomorrowTemperature = t2;
                target.TomorrowWeather = w2;
                await _context.SaveChangesAsync();
                return _mapper.Map<ClimateResponse>(target);
            }
            catch
            {
                return null; 
            }
        }
    }
}
