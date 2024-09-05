using db_course_design.Services;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using AutoMapper.Execution;
using db_course_design.Services.impl;

namespace db_course_design.Controllers
{
    /*业务逻辑（用户个人信息）：
         普通用户个人中心界面
    api/
        Profile/
            user/
                {id}/
                    GET             - 获取指定ID的普通用户信息
                    name/{name}/
                        PUT         - 修改指定ID的普通用户的用户名
                    picture/
                        PUT         - 修改指定ID的普通用户的头像
                    gender/{gender}/
                        PUT         - 修改指定ID的普通用户的性别
                    phone/
                        add/{number}/
                            POST    - 增加指定ID的普通用户的手机号码
                        delete/{number}/
                            DELETE  - 删除指定ID的普通用户的手机号码
                        modify/{old},{new}/
                            PUT     - 修改指定ID的普通用户的手机号码
      业务逻辑（导游个人信息）：
         导游个人中心界面
    api/
        Profile/
            guide/
                {id}/
                    GET             - 获取指定ID的导游信息
                    name/{name}/
                        PUT         - 修改指定ID的导游的用户名
                    picture/
                        PUT         - 修改指定ID的导游的头像
                    gender/{gender}/
                        PUT         - 修改指定ID的导游的性别
                    intro/{intro}/
                        PUT         - 修改指定ID的导游的介绍
                    price/{price}/
                        PUT         - 修改指定ID的导游的价格
                    phone/
                        add/{numbers}/
                            POST    - 增加指定ID的导游的手机号码
                        delete/{numbers}/
                            DELETE  - 删除指定ID的导游的手机号码
                        modify/{old},{new}/
                            PUT     - 修改指定ID的导游的手机号码
                    regions/
                        add/{region}/
                            POST    - 增加指定ID的导游的地区
                        delete/{region}/
                            DELETE  - 删除指定ID的导游的地区
                        modify/{old},{new}/
                            PUT     - 修改指定ID的导游的地区
      业务逻辑（管理员个人信息）：
         管理员个人中心界面
    api/
        Profile/
            admin/
                {id}/
                    GET             - 获取指定ID的管理员信息
                    name/{name}/
                        PUT         - 修改指定ID的管理员信息
                    password/{password}/
                        PUT         - 修改指定ID的管理员信息
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        /*
         业务逻辑：user信息的增删改查

         
         */
        /*--添加用户信息--*/
        [HttpPost("user/add")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserRequest userRequest)
        {
            var addedUser = await _profileService.AddUserAsync(userRequest);
            if (addedUser == null)
            {
                return BadRequest(new { Message = "Failed to add user" });
            }

            // 返回添加用户信息
            return Ok(addedUser);
        }

        /*--修改用户信息--*/
        [HttpPut("user/update/{UserId}")]
        public async Task<IActionResult> UpdateUserAsync(int UserId, [FromBody] UserRequest userRequest)
        {
            var updatedUser = await _profileService.UpdateUserAsync(UserId, userRequest);
            if (updatedUser == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(updatedUser);
        }

        /*--删除用户信息--*/
        [HttpDelete("user/del/{UserId}")]
        public async Task<IActionResult> DeleteUserAsync(int UserId)
        {
            var result = await _profileService.DeleteUserAsync(UserId);
            if (!result)
            {
                return NotFound(new { Message = "User not found" });
            }
            return NoContent();
        }
        [HttpGet("user/all")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var guides = await _profileService.GetAllUsersAsync();

            return Ok(guides);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            var profile = await _profileService.GetUserProfileAsync(id);

            if (profile == null)
                return NotFound("No user found with id " + id);
            return Ok(profile);
        }

        [HttpPut("user/{id}/{item}/{value}")]
        public async Task<IActionResult> UpdateUserProfile(int id, string item, string value)
        {
            var target = await _profileService.UpdateUserProfileAsync(id, item, value);

            if (target == null)
                return BadRequest("Cannot update item '" + item + "' of user " + id);
            return Ok(target);
        }

        [HttpPut("user/{id}/picture")]
        public async Task<IActionResult> UpdateUserAvatar(int id, [FromForm] IFormFile avatar)
        {
            var updated = await _profileService.UpdateUserAvatarAsync(id, avatar);

            if (updated.code != 0)
                return BadRequest(updated);
            return Ok(updated);
        }

        [HttpPost("user/{id}/phone/add/{number}")]
        public async Task<IActionResult> AddUserPhoneNumber(int id, string number)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _profileService.AddUserPhoneNumberAsync(id, number);

            if (target == null)
                return BadRequest("Cannot add number " + number + " for user " + id);
            return CreatedAtAction(nameof(GetUserProfileById), new { id });
        }

        [HttpDelete("user/{id}/phone/delete/{number}")]
        public async Task<IActionResult> DeleteUserPhoneNumber(int id, string number)
        {
            var deleted = await _profileService.DeleteUserPhoneNumberAsync(id, number);

            if (!deleted)
                return BadRequest("Cannot delete number " + number + " for user " + id);
            return NoContent();
        }

        [HttpPut("user/{id}/phone/modify/{o},{n}")]
        public async Task<IActionResult> UpdateUserPhoneNumber(int id, string o, string n)
        {
            var deleted = await _profileService.DeleteUserPhoneNumberAsync(id, o);

            if (!deleted)
                return BadRequest("Cannot update number " + o + " for user " + id);

            var target = await _profileService.AddUserPhoneNumberAsync(id, n);

            if (target == null) 
                return BadRequest("Cannot update number " + o + " for user " + id);
            return Ok(target);
        }

        [HttpGet("guide/{id}")]
        public async Task<IActionResult> GetGuideProfileById(byte id)
        {
            var profile = await _profileService.GetGuideProfileAsync(id);

            if (profile == null)
                return NotFound("No user found with id " + id);
            return Ok(profile);
        }

        [HttpPut("guide/{id}/{item}/{value}")]
        public async Task<IActionResult> UpdateGuideProfile(byte id, string item, string value)
        {
            var target = await _profileService.UpdateGuideProfileAsync(id, item, value);

            if (target == null)
                return BadRequest("Cannot update item '" + item + "' of guide " + id);
            return Ok(target);
        }

        [HttpPut("guide/{id}/picture")]
        public async Task<IActionResult> UpdateGuideAvatar(byte id, [FromForm] IFormFile avatar)
        {
            var updated = await _profileService.UpdateGuideAvatarAsync(id, avatar);

            if (updated.code != 0)
                return BadRequest(updated);
            return Ok(updated);
        }

        [HttpPost("guide/{id}/phone/add/{number}")]
        public async Task<IActionResult> AddGuidePhoneNumber(byte id, string number)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _profileService.AddGuidePhoneNumberAsync(id, number);

            if (target == null)
                return BadRequest("Cannot add number " + number + " for guide " + id);
            return CreatedAtAction(nameof(GetGuideProfileById), new { id });
        }

        [HttpDelete("guide/{id}/phone/delete/{number}")]
        public async Task<IActionResult> DeleteGuidePhoneNumber(byte id, string number)
        {
            var deleted = await _profileService.DeleteGuidePhoneNumberAsync(id, number);

            if (!deleted)
                return BadRequest("Cannot delete number " + number + " for guide " + id);
            return NoContent();
        }

        [HttpPut("guide/{id}/phone/modify/{o},{n}")]
        public async Task<IActionResult> UpdateGuidePhoneNumber(byte id, string o, string n)
        {
            var deleted = await _profileService.DeleteGuidePhoneNumberAsync(id, o);

            if (!deleted)
                return BadRequest("Cannot update number " + o + " for guide " + id);

            var target = await _profileService.AddGuidePhoneNumberAsync(id, n);

            if (target == null)
                return BadRequest("Cannot update number " + o + " for guide " + id);
            return Ok(target);
        }

        [HttpPost("guide/{id}/regions/add/{region}")]
        public async Task<IActionResult> AddGuideRegion(byte id, string region)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _profileService.AddGuideRegionAsync(id, region);

            if (target == null)
                return BadRequest("Cannot add region " + region + " for guide " + id);
            return CreatedAtAction(nameof(GetGuideProfileById), new { id });
        }

        [HttpDelete("guide/{id}/regions/delete/{region}")]
        public async Task<IActionResult> DeleteGuideRegion(byte id, string region)
        {
            var deleted = await _profileService.DeleteGuideRegionAsync(id, region);

            if (!deleted)
                return BadRequest("Cannot delete region " + region + " for guide " + id);
            return NoContent();
        }

        [HttpPut("guide/{id}/regions/modify/{o},{n}")]
        public async Task<IActionResult> UpdateGuideRegion(byte id, string o, string n)
        {
            var deleted = await _profileService.DeleteGuideRegionAsync(id, o);

            if (!deleted)
                return BadRequest("Cannot update region " + o + " for guide " + id);

            var target = await _profileService.AddGuideRegionAsync(id, n);

            if (target == null)
                return BadRequest("Cannot update region " + o + " for guide " + id);
            return Ok(target);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetAdminProfileById(decimal id)
        {
            var profile = await _profileService.GetAdminProfileAsync(id);

            if (profile == null)
                return NotFound("No user found with id " + id);
            return Ok(profile);
        }

        [HttpPut("admin/{id}/{item}/{value}")]
        public async Task<IActionResult> UpdateAdminProfile(decimal id, string item, string value)
        {
            var target = await _profileService.UpdateAdminProfileAsync(id, item, value);

            if (target == null)
                return BadRequest("Cannot update item '" + item + "' of admin " + id);
            return Ok(target);
        }
    }
}
