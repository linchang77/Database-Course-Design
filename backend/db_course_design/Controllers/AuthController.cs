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
        //建立一个请求登录的表
        public class LoginRequest
        {
            public decimal UserID { get; set; }
            public string Password  { get; set; }
        }
        //获取上下文
        private readonly ModelContext _context;

        public AuthController(ModelContext context)
        {
            _context = context;
        }


        [HttpPost("login/admin")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequest loginRequest)
        {
            string i = loginRequest.Password;
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.AdminId == loginRequest.UserID 
                && a.Password == loginRequest.Password);

            if (admin == null)
            {
                return Ok(Result<string>.Error("Invalid credentials"));
            }

            return Ok(Result<string>.Success("Admin login successful"));
        }
    }
}

