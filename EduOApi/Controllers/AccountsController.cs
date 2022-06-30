using AutoMapper;
using EduO.Api.Services.Contracts;
using EduO.Core.Dtos;
using EduO.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EduO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; 
        private readonly IAuthService _authService;

        public AccountsController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IAuthService authService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationFormDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();


            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            //await _userManager.AddToRoleAsync(user, "Visitor");
            return StatusCode(201);
        }


        //Implementing Authentication with ASP.NET Core Identity
        #region Implementing Authentication with ASP.NET Core Identity
        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginModel userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(userModel);
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
        //    if (result.Succeeded)
        //    {
        //        return Ok(result);
        //    }

        //    //var user = await _userManager.FindByEmailAsync(userModel.Email);
        //    //if (user != null &&
        //    //    await _userManager.CheckPasswordAsync(user, userModel.Password))
        //    //{
        //    //    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
        //    //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
        //    //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

        //    //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
        //    //        new ClaimsPrincipal(identity));

        //    //    return Ok(user);
        //    //}
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid UserName or Password");
        //        return BadRequest(userModel);
        //    }
        //}
        #endregion

        //Implementing Authentication With JWt
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _authService.GetSigningCredentials();
            var claims = _authService.GetClaims(user);
            var tokenOptions = _authService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //     await _signInManager.SignOutAsync();

        //    return Ok();
        //}

    }
}
