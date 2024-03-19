using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(AppUser UserData,string password);
        Task<SignInResult> SignIn(AppUser User, string Password,bool IsPersistent=false,bool LockOutOnFailure=true);
        Task<string> GenerateEmailVerificationToken(AppUser User);
        Task<IdentityResult> VerifyEmail(AppUser User, string Token);
        Task<string> ForgetPasswordToken(AppUser User);
        Task<IdentityResult> VerifyForgetPassword(AppUser User,VerifiyPasswordUpdateDTO VerifyForgetPasswordDTO);
        Task<IdentityResult> ChangePasswordWithOld(AppUser User,ResetPasswordDTO ResetPasswordDTO);
        Task<string> GeneratePasswordChangeToken(AppUser User);
        Task<IdentityResult> VerifyPasswordChangeToken(AppUser User,VerifyChangePasswordDTO VerifyChangePasswordDTO);
        Task<BaseResponce> SignOut();
    }
}
