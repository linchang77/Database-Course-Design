using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Profiles;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<GuideProfileResponse?> GetGuideProfileAsync(decimal id)
        {
            var profile = await _context.Guides.FindAsync(id);

            if (profile == null)
                return null;
            return _mapper.Map<GuideProfileResponse>(profile);
        }

        public async Task<AdminProfileResponse?> GetAdminProfileAsync(byte id)
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
        
        public async Task<GuideProfileResponse?> UpdateGuideProfileAsync(int id, string item, object value)
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

        public async Task<AdminProfileResponse?> UpdateAdminProfileAsync(int id, string item, object value)
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
    }
}
