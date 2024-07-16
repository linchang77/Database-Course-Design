using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;
using db_course_design.Common;
namespace db_course_design.Controler
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //加盐的值
        private string salt = "jleyrCCO8Z+JT5mez87yuw==";
        //建立一个请求登录的表
        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password  { get; set; }
        }
        //建立一个请求注册的表
        public class RegisterRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        //获取上下文
        private readonly ModelContext _context;

        public AuthController(ModelContext context)
        {
            _context = context;
        }

        /*业务逻辑：
         登录界面可以选择管理员登录还是用户登录还是导游登录，有三个身份的登录接口
         输入：用户名和密码
         输出：字符串
         注册界面可以选择管理员注册还是用户注册
         输入：用户名和密码
         输出：字符串
         */
        [HttpPost("login/user")]
        public async Task<IActionResult> UserLogin([FromBody] LoginRequest loginRequest)
        {
            var admin = await _context.Users
                .FirstOrDefaultAsync(a => a.UserName == loginRequest.UserName 
                && a.Password == SaltedPassword.HashPassword(loginRequest.Password,salt));

            if (admin == null)
            {
                return Ok(Result<string>.Error("Invalid credentials"));
            }

            return Ok(Result<string>.Success("User login successful"));
        }
        [HttpPost("login/admin")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequest loginRequest)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.AdminName == loginRequest.UserName
                && a.Password == SaltedPassword.HashPassword(loginRequest.Password, salt));
            if (admin == null)
            {
                return Ok(Result<string>.Error("Invalid credentials"));
            }

            return Ok(Result<string>.Success("Admin login successful"));
        }

        [HttpPost("login/guide")]
        public async Task<IActionResult> GuideLogin([FromBody] LoginRequest loginRequest)
        {
            var admin = await _context.Guides
                .FirstOrDefaultAsync(a => a.GuideName == loginRequest.UserName
                && a.Password == SaltedPassword.HashPassword(loginRequest.Password, salt));

            if (admin == null)
            {
                return Ok(Result<string>.Error("Invalid credentials"));
            }

            return Ok(Result<string>.Success("Guide login successful"));
        }

        // 管理员注册
        [HttpPost("register/admin")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterRequest registerRequest)
        {
            // 检查用户名是否已存在
            var existingUser = await _context.Admins
                .FirstOrDefaultAsync(u => u.AdminName == registerRequest.UserName);

            if (existingUser != null)
            {
                return Ok(Result<string>.Error("Admin already exists"));
            }

            // 创建新用户
            var newAdmin = new Admin
            {
                AdminName = registerRequest.UserName,
                Password = SaltedPassword.HashPassword(registerRequest.Password, salt)

            };

            _context.Admins.Add(newAdmin);
            await _context.SaveChangesAsync();

            return Ok(Result<string>.Success("Admin registered successfully"));
        }

        //用户注册
        [HttpPost("register/user")]
        public async Task<IActionResult> UserRegister([FromBody] RegisterRequest registerRequest)
        {
            // 检查用户名是否已存在
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == registerRequest.UserName);

            if (existingUser != null)
            {
                return Ok(Result<string>.Error("Username already exists"));
            }

            // 创建新用户
            var newUser = new User
            {
                UserName = registerRequest.UserName,
                Password = SaltedPassword.HashPassword(registerRequest.Password, salt),
                RegistrationTime = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(Result<string>.Success("User registered successfully"));
        }

        //导游注册
        [HttpPost("register/guide")]
        public async Task<IActionResult> GuideRegister([FromBody] RegisterRequest registerRequest)
        {
            // 检查用户名是否已存在
            var existingUser = await _context.Guides
                .FirstOrDefaultAsync(u => u.GuideName == registerRequest.UserName);

            if (existingUser != null)
            {
                return Ok(Result<string>.Error("Guide already exists"));
            }

            // 创建新用户
            var newguide = new Guide
            {
                GuideName = registerRequest.UserName,
                Password = SaltedPassword.HashPassword(registerRequest.Password, salt)
            };

            _context.Guides.Add(newguide);
            await _context.SaveChangesAsync();

            return Ok(Result<string>.Success("Guide registered successfully"));
        }
    }
}

