using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Errors;
using ShopApi.IdentityExetentions;
using ShopCore.Domain;
using ShopCore.Dtos;
using ShopCore.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        private readonly IJsonToken _jsonToken;
        public AccountController(UserManager<AppUser> userManager, IJsonToken jsonToken, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jsonToken = jsonToken;
        }
        [HttpPost("UserLogin")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user,loginDto.Password,false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto { Email = user.Email, Token = _jsonToken.CreateToken(user), DisplayName = user.DisplayName };
           
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {

            var user = await _userManager.FindByEmailFromClaimPrinciple(HttpContext.User);

            return new UserDto { Email = user.Email, Token = _jsonToken.CreateToken(user), DisplayName = user.DisplayName };
        }

        [HttpGet("EmailExits")]
        public async Task<ActionResult<bool>> IfEmailExits([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) !=null;
        }
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
          
            var user = await _userManager.FindByEmailWithAddressAsync(HttpContext.User);
            var address = new AddressDto
            {
                City = user.Address.City,
                Country = user.Address.Country,
                FirstName = user.Address.FirstName,
                LastName = user.Address.LastName,
                Street = user.Address.Street
            };
            return address;
        }
        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {

            var user = await _userManager.FindByEmailWithAddressAsync(HttpContext.User);

            var newAddress = new Address
            {
                City = address.City,
                Country = address.Country,
                FirstName = address.FirstName,
                LastName = address.LastName,
                Street = address.Street
            };
            user.Address = newAddress;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                address.Street = newAddress.Street;
                address.Country = newAddress.Country;
                address.FirstName = newAddress.FirstName;
                address.LastName = newAddress.LastName;
                address.City = newAddress.City;
                return Ok(address);

            }
            return BadRequest("Technical problem occured while updating User"+user.DisplayName);

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser(RegisterDto RegisterDto)
        {
            var user = new AppUser()
            {
                DisplayName = RegisterDto.DisplayName,
                Email = RegisterDto.EmailAddress,
                UserName = RegisterDto.EmailAddress
            };
            var ifExits = await _userManager.FindByEmailAsync(RegisterDto.EmailAddress);
            if (ifExits != null)
            {
                return BadRequest(new ApiResponse(400));
            }
            else
            {
                var result = await _userManager.CreateAsync(user, RegisterDto.Password);
                if (!result.Succeeded) return BadRequest(new ApiResponse(400));

                return new UserDto
                {
                    DisplayName = RegisterDto.DisplayName,
                    Email = RegisterDto.EmailAddress,
                    Token = _jsonToken.CreateToken(user)

                };
            }
        }


    }

}
