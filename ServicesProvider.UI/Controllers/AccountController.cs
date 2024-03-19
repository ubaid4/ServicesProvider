using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Constraint;


namespace AuthJwt.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;    
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        /// <summary>
        /// Used to create user account
        /// </summary>
        /// <param name="signupDTO"></param>
        /// <returns></returns>


        [HttpPost("SignUp")]
        public async Task<IActionResult> Signup(SignupDTO signupDTO)
        {
            BaseResponce result = await _accountService.SignUp(signupDTO);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPut("SignIn")]
        public async Task<ActionResult> SignIn(LoginDTO loginDTO)
        {
            _logger.LogWarning("new sign in of user: "+loginDTO.UserName);
            BaseResponce result = await _accountService.SignIn(loginDTO);
            if(result.IsSuccess==false)
            {
                
                return BadRequest(result);
            }   
         
            return Ok(result);
        }

        [HttpPut("GenerateTokenByRefreshToken")]
        public async Task<ActionResult> NewTokenByRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            BaseResponce result = await _accountService.GenerateTokenByRefreshToken(refreshTokenDTO.UserId, refreshTokenDTO.RefreshToken);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("RevokeRefreshToken/{UserId:required}")]
        public async Task<ActionResult> RevokeRefreshToken(string UserId)
        {
            BaseResponce result = await _accountService.RevokeRefreshToken(UserId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }


        [HttpGet("ResendVerificationEmail/{Email:required}")]
        public async Task<ActionResult> ResendEmailVerificationToken(string Email)
        {
            if (!ParamConstrains.IsValidEmail(Email))
            {
                return BadRequest(new BaseResponce { IsSuccess = false, Message = "Failed to send Email", Errors = new List<string> { "Email address is not correct" } }) ;
            }

            BaseResponce result = await _accountService.ResendEmailVerificationToken(Email);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("VerifyEmail")]
        public async Task<ActionResult> VerifyEmail(VerifyEmailDTO VerificationData)
        {
            BaseResponce result = await _accountService.VerifyEmail(VerificationData.UserId, VerificationData.Token);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword(string Email)
        {
            BaseResponce result = await _accountService.ForgetPassword(Email);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("VerifyForgetPassword")]
        public async Task<ActionResult> VerifyForgetPassword(VerifiyPasswordUpdateDTO VerifyForgetPasswordDTO)
        {
            BaseResponce result = await _accountService.VerifyForgetPassword(VerifyForgetPasswordDTO);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("ChangePasswordWithOld")]
        public async Task<ActionResult> ChangePasswordWithOld(ResetPasswordDTO ResetPasswordDTO)
        {
            BaseResponce result = await _accountService.ChangePasswordWithOld(ResetPasswordDTO);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("ChangePasswordWithEmailVerification")]
        public async Task<ActionResult> TokenForChangePassword(string UserId)
        {
            BaseResponce result = await _accountService.CreatePasswordChangeToken(UserId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("VerifyTokenForChangePassword")]
        public async Task<ActionResult> VerifyTokenForChangePassword(VerifyChangePasswordDTO VerifyChangePasswordDTO)
        {
            BaseResponce result = await _accountService.VerifyPasswordChangeToken(VerifyChangePasswordDTO);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[HttpPut("SignOut")]
        //public async Task<ActionResult> SignOut()
        //{
        //    IdentityResult result = await _accountService.SignOut();
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    return Ok();
        //}
    }
}
