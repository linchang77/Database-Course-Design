using AutoMapper;
using AutoMapper.Execution;
using db_course_design.Common;
using db_course_design.DTOs;
using db_course_design.Profiles;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace db_course_design.Services.impl
{
    public class UserRequest
    {
        public string? UserName { get; set; }

        public DateTime? RegistrationTime { get; set; }

        public string? Password { get; set; }

        public string? ProfilePicture { get; set; }

        public string? UserGender { get; set; }

    }

    public class ProfileService : IProfileService
    {
        private readonly ModelContext _context;

        public IMapper _mapper { get; }

        public ProfileService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProfileProfile>()).CreateMapper();
        }

        public async Task<UserProfileResponse?> GetUserProfileAsync(int id)
        {
            var profile = (await _context.Users
                .Where(p => p.UserId == id)
                .Include(p => p.UserPhoneNumbers)
                .ToListAsync())[0];

            if (profile == null)
                return null;
            return _mapper.Map<UserProfileResponse>(profile);
        }

        public async Task<GuideProfileResponse?> GetGuideProfileAsync(byte id)
        {
            var profile = (await _context.Guides
                .Where(p => p.GuideId == id)
                .Include(p => p.GuidePhoneNumbers)
                .Include(p => p.GuideRegions)
                .ToListAsync())[0];

            if (profile == null)
                return null;
            return _mapper.Map<GuideProfileResponse>(profile);
        }

        public async Task<AdminProfileResponse?> GetAdminProfileAsync(decimal id)
        {
            var profile = await _context.Admins.FindAsync(id);

            if (profile == null)
                return null;
            return _mapper.Map<AdminProfileResponse>(profile);
        }

        public async Task<UserProfileResponse?> UpdateUserProfileAsync(int id, string item, string value)
        {
            try
            {
                var target = await _context.Users.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.UserName = value; 
                        break;
                    case "picture":
                        target.ProfilePicture = value; 
                        break;
                    case "gender":
                        target.UserGender = value;
                        break;
                    default:
                        return null;
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<UserProfileResponse>(target);
            }
            catch
            {
                return null;
            }
        }
        
        public async Task<GuideProfileResponse?> UpdateGuideProfileAsync(byte id, string item, string value)
        {
            try
            {
                var target = await _context.Guides.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.GuideName = value;
                        break;
                    case "picture":
                        target.ProfilePicture = value;
                        break;
                    case "gender":
                        target.GuideGender = value;
                        break;
                    case "intro":
                        target.GuideIntroduction = value;
                        break;
                    case "price":
                        target.GuidePrice = Convert.ToDecimal(value);
                        break;
                    default:
                        return null;
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<GuideProfileResponse>(target);
            }
            catch
            {
                return null;
            }
        }

        public async Task<AdminProfileResponse?> UpdateAdminProfileAsync(decimal id, string item, string value)
        {
            try
            {
                var target = await _context.Admins.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.AdminName = value;
                        break;
                    default:
                        return null;
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<AdminProfileResponse>(target);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> AddUserPhoneNumberAsync(int id, string number)
        {
            try
            {
                var record = new UserPhoneNumber
                {
                    UserId = id,
                    PhoneNumber = number
                };
                _context.UserPhoneNumbers.Add(record);
                await _context.SaveChangesAsync();
                return record.PhoneNumber;
            }
            catch 
            { 
                return null; 
            }
        }

        public async Task<bool> DeleteUserPhoneNumberAsync(int id, string number)
        {
            var record = await _context.UserPhoneNumbers.FindAsync(id, number);

            if (record == null) 
                return false;

            _context.UserPhoneNumbers.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> AddGuidePhoneNumberAsync(byte id, string number)
        {
            try
            {
                var record = new GuidePhoneNumber
                {
                    GuideId = id,
                    PhoneNumber = number
                };
                _context.GuidePhoneNumbers.Add(record);
                await _context.SaveChangesAsync();
                return record.PhoneNumber;
            }
            catch 
            { 
                return null; 
            }
        }

        public async Task<bool> DeleteGuidePhoneNumberAsync(byte id, string number)
        {
            var record = await _context.GuidePhoneNumbers.FindAsync(number, id);

            if (record == null)
                return false;

            _context.GuidePhoneNumbers.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> AddGuideRegionAsync(byte id, string region)
        {
            try
            {
                var record = new GuideRegion
                {
                    GuideId = id,
                    GuidedRegion = region
                };
                _context.GuideRegions.Add(record);
                await _context.SaveChangesAsync();
                return record.GuidedRegion;
            }
            catch 
            { 
                return null; 
            }
        }

        public async Task<bool> DeleteGuideRegionAsync(byte id, string region)
        {
            var record = await _context.GuideRegions.FindAsync(id, region);

            if (record == null)
                return false;

            _context.GuideRegions.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
        /*--获取所有用户信息--*/
        public async Task<ICollection<UserProfileResponse>> GetAllUsersAsync()
        {
            return await _context.Users.Select(c => _mapper.Map<UserProfileResponse>(c)).ToListAsync();
        }
        /*--添加用户信息--*/
        public async Task<UserProfileResponse> AddUserAsync(UserRequest userRequest)
        {
            userRequest.Password = SaltedPassword.HashPassword(userRequest.Password, SaltedPassword.salt);
            var user = _mapper.Map<User>(userRequest);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserProfileResponse>(userRequest);
        }


        /*--修改用户信息--*/
        public async Task<UserProfileResponse> UpdateUserAsync(int UserId, UserRequest userRequest)
        {
            userRequest.Password = SaltedPassword.HashPassword(userRequest.Password, SaltedPassword.salt);
            var user = await _context.Users.FindAsync(UserId);

            if (user == null)
            {
                return null;
            }

            _mapper.Map(userRequest, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserProfileResponse>(user);
        }
        /*--删除用户信息--*/
        public async Task<bool> DeleteUserAsync(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
