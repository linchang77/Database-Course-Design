using AutoMapper;
using db_course_design.DTOs;

namespace db_course_design.Services
{
    public interface IProfileService
    {
        IMapper _mapper { get; }

        Task<UserProfileResponse?> GetUserProfileAsync(int id);

        Task<GuideProfileResponse?> GetGuideProfileAsync(byte id);

        Task<AdminProfileResponse?> GetAdminProfileAsync(decimal id);

        Task<UserProfileResponse?> UpdateUserProfileAsync(int id, string item, string value);

        Task<GuideProfileResponse?> UpdateGuideProfileAsync(byte id, string item, string value);

        Task<AdminProfileResponse?> UpdateAdminProfileAsync(decimal id, string item, string value);

        Task<string?> AddUserPhoneNumberAsync(int id, string number);

        Task<bool> DeleteUserPhoneNumberAsync(int id, string number);

        Task<string?> AddGuidePhoneNumberAsync(byte id, string number);

        Task<bool> DeleteGuidePhoneNumberAsync(byte id, string number);

        Task<string?> AddGuideRegionAsync(byte id, string region);

        Task<bool> DeleteGuideRegionAsync(byte id, string region);
    }
}
