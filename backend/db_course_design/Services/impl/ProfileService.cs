using AutoMapper;
using AutoMapper.Execution;
using db_course_design.DTOs;
using db_course_design.Profiles;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace db_course_design.Services.impl
{
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
            var profile = await _context.Users.FindAsync(id);

            if (profile == null)
                return null;
            return _mapper.Map<UserProfileResponse>(profile);
        }

        public async Task<GuideProfileResponse?> GetGuideProfileAsync(byte id)
        {
            var profile = await _context.Guides.FindAsync(id);

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

        public async Task<UserProfileResponse?> UpdateUserProfileAsync(int id, string item, object value)
        {
            try
            {
                var target = await _context.Users.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.UserName = (string?)value; 
                        break;
                    case "password":
                        target.Password = (string?)value;
                        break;
                    case "picture":
                        target.ProfilePicture = (string?)value; 
                        break;
                    case "gender":
                        target.UserGender = (string?)value;
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
        
        public async Task<GuideProfileResponse?> UpdateGuideProfileAsync(byte id, string item, object value)
        {
            try
            {
                var target = await _context.Guides.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.GuideName = (string?)value;
                        break;
                    case "password":
                        target.Password = (string?)value;
                        break;
                    case "picture":
                        target.ProfilePicture = (string?)value;
                        break;
                    case "gender":
                        target.GuideGender = (string?)value;
                        break;
                    case "intro":
                        target.GuideIntroduction = (string?)value;
                        break;
                    case "price":
                        target.GuidePrice = (decimal?)value;
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

        public async Task<AdminProfileResponse?> UpdateAdminProfileAsync(decimal id, string item, object value)
        {
            try
            {
                var target = await _context.Admins.FindAsync(id);
                if (target == null)
                    throw new Exception();
                switch (item)
                {
                    case "name":
                        target.AdminName = (string?)value;
                        break;
                    case "password":
                        target.Password = (string?)value;
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

        public async Task<string?> UpdateUserPhoneNumbersAsync(int id, string o, string n)
        {
            var record = await _context.UserPhoneNumbers.FindAsync(id, o);

            if (record == null)
                return null;

            record.PhoneNumber = n;
            await _context.SaveChangesAsync();
            return record.PhoneNumber;
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
            var record = await _context.GuidePhoneNumbers.FindAsync(id, number);

            if (record == null)
                return false;

            _context.GuidePhoneNumbers.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> UpdateGuidePhoneNumberAsync(byte id, string o, string n)
        {
            var record = await _context.GuidePhoneNumbers.FindAsync(id, o);

            if (record == null)
                return null;

            record.PhoneNumber = n;
            await _context.SaveChangesAsync();
            return record.PhoneNumber;
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

        public async Task<string?> UpdateGuideRegionAsync(byte id, string o, string n)
        {
            var record = await _context.GuideRegions.FindAsync(id, o);

            if (record == null)
                return null;

            record.GuidedRegion = n;
            await _context.SaveChangesAsync();
            return record.GuidedRegion;
        }
    }
}
