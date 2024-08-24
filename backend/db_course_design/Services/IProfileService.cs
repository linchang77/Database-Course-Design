using AutoMapper;
using db_course_design.DTOs;

namespace db_course_design.Services
{
    public interface IProfileService
    {
        IMapper _mapper { get; }

        Task<UserProfileResponse?> GetUserProfileAsync(int id);

        Task<GuideProfileResponse?> GetGuideProfileAsync(decimal id);

        Task<AdminProfileResponse?> GetAdminProfileAsync(byte id);

        Task<UserProfileResponse?> UpdateUserProfileAsync(int id, string item, object value);

        Task<GuideProfileResponse?> UpdateGuideProfileAsync(int id, string item, object value);

        Task<AdminProfileResponse?> UpdateAdminProfileAsync(int id, string item, object value);

        Task<string?> AddUserPhoneNumberAsync(int id, string number);

        Task<bool> DeleteUserPhoneNumberAsync(int id, string number);

        Task<string?> UpdateUserPhoneNumbersAsync(int id, string o, string n);

        Task<string?> AddGuidePhoneNumberAsync(int id, string number);

        Task<bool> DeleteGuidePhoneNumberAsync(int id, string number);

        Task<string?> UpdateGuidePhoneNumberAsync(int id, string o, string n);

        Task<string?> AddGuideRegionAsync(int id, string region);

        Task<bool> DeleteGuideRegionAsync(int id, string region);

        Task<string?> UpdateGuideRegionAsync(int id, string o, string n);
    }
}
