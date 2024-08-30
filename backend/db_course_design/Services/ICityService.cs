using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Services.impl;

namespace db_course_design.Services
{
    public interface ICityService
    {
        IMapper _mapper { get; }

        Task<ICollection<CityResponse>> GetAllCitiesAsync();
        Task<CityDetail?> GetCityByNameAsync(string name);
        Task<CityResponse?> AddCityAsync(CityRequest request);
        Task<bool> DeleteCityAsync(string name);
        Task<string?> UpdateCityIntroAsync(string name, string intro);
        Task<ClimateResponse?> UpdateCityClimateAsync(string name, decimal t1, string w1, decimal t2, string w2);
    }
}
