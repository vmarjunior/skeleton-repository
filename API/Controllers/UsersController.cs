using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySolution.Application.Constants;
using MySolution.Application.DTOs.User;
using MySolution.Application.Interfaces;
using MySolution.Application.QueryParameters;
using MySolution.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MySolution.API.Controllers
{
    [Authorize(Policy = AppPolicies.LimitedOrFullAccess)]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserQueryParameters queryParams)
        {
            var pagedResult = await _userService.GetAllAsync(queryParams);
            return Ok(pagedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Authorize(Policy = AppPolicies.FullAccess)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO userCreateDTO)
        {
            var user = await _userService.CreateAsync(userCreateDTO);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Authorize(Policy = AppPolicies.FullAccess)]
        [HttpPatch("update/roles/{id}")]
        public async Task<IActionResult> UpdateRoles(Guid id, [FromQuery][Required] ICollection<AppRole> appRoles)
        {
            await _userService.UpdateRolesAsync(id, appRoles);
            return NoContent();
        }

        [Authorize(Policy = AppPolicies.FullAccess)]
        [HttpPatch("update/profile/{id}")]
        public async Task<IActionResult> UpdateProfile(Guid id, [FromBody] UserUpdateProfileDTO userUpdateDTO)
        {
            await _userService.UpdateProfileAsync(id, userUpdateDTO);
            return NoContent();
        }

        [Authorize(Policy = AppPolicies.FullAccess)]
        [HttpPatch("update/password/{id}")]
        public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] UserUpdatePasswordDTO userUpdatePasswordDTO)
        {
            await _userService.UpdatePasswordAsync(id, userUpdatePasswordDTO);
            return NoContent();
        }

        [Authorize(Policy = AppPolicies.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}