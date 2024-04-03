using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Constraint;


namespace ServicesProvider.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;    
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
      
      


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
        /// <summary>
        /// Used to create New Access token with Resfresh token
        /// </summary>

        [HttpPut("GenerateTokenByRefreshToken")]
        public async Task<ActionResult> NewTokenByRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var UserPrinciple = User;
            BaseResponce result = await _accountService.GenerateTokenByRefreshToken(refreshTokenDTO.UserId, refreshTokenDTO.RefreshToken);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Used to expire current refresh token
        /// </summary>

        [HttpDelete("RevokeRefreshToken/{UserId:required:appGuid}")]
        public async Task<ActionResult> RevokeRefreshToken(string UserId)
        {
            BaseResponce result = await _accountService.RevokeRefreshToken(UserId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }


        [HttpGet("ResendVerificationEmail/{Email:required:email}")]
        public async Task<ActionResult> ResendEmailVerificationToken(string Email)
        {

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
        /// <summary>
        /// Used to create new password if you forget old one.
        /// </summary>
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
        /// <summary>
        /// Used to verify user email to create new password
        /// </summary>
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
        /// <summary>
        /// Used to update password if you remember old password
        /// </summary>
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

        /// <summary>
        /// Another way to change user password with email verification
        /// </summary>
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

        /// <summary>
        /// Verify Email to change the password
        /// </summary>
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
