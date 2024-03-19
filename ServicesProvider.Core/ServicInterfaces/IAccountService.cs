using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IAccountService
    {
       Task<BaseResponce> SignUp(SignupDTO SignupDTO);
       Task<BaseResponce> SignIn(LoginDTO LoginDTO);
        Task<BaseResponce>  GenerateTokenByRefreshToken(string UserId, string RefreshToken);
        Task<BaseResponce>  RevokeRefreshToken(String UserId);
        Task<BaseResponce> ResendEmailVerificationToken(string Email);
        Task<BaseResponce> VerifyEmail(string UserId, string Token);
        Task<BaseResponce> ForgetPassword(string Email);
        Task<BaseResponce> VerifyForgetPassword(VerifiyPasswordUpdateDTO VerifyForgetPasswordDTO);  
        Task<BaseResponce> ChangePasswordWithOld(ResetPasswordDTO ResetPasswordDTO);
        Task<BaseResponce> CreatePasswordChangeToken(string UserId);
        Task<BaseResponce> VerifyPasswordChangeToken(VerifyChangePasswordDTO VerifyChangePasswordDTO);
        Task<IdentityResult> SignOut();

    }
}
