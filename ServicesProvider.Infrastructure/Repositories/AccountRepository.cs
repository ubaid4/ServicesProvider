using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;
        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> SignUp(AppUser UserData, string Password)
        {
            return await _userManager.CreateAsync(UserData, Password);
        }
        public async Task<SignInResult> SignIn(AppUser User,string Password,bool IsPersistent,bool LockOutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(User, Password, false, false);
        }

        public Task<BaseResponce> SignOut()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> ChangePasswordWithOld(AppUser User,ResetPasswordDTO ResetPasswordDTO)
        {

          return await _userManager.ChangePasswordAsync(User,ResetPasswordDTO.CurrentPassword,ResetPasswordDTO.NewPassword);
           
        }

        public async Task<string> ForgetPasswordToken(AppUser User)
        {
           return await _userManager.GeneratePasswordResetTokenAsync(User);
           
        }

        public async Task<string> GenerateEmailVerificationToken(AppUser User)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(User);
        }
        public async Task<IdentityResult> VerifyEmail(AppUser User, string Token)
        {
            return await _userManager.ConfirmEmailAsync(User, Token);
           
        }

        public async Task<IdentityResult> VerifyForgetPassword(AppUser User,VerifiyPasswordUpdateDTO VerifyForgetPasswordDTO)
        {
           return await _userManager.ResetPasswordAsync(User,VerifyForgetPasswordDTO.Token,VerifyForgetPasswordDTO.NewPassword);
            
          
        }
        public async Task<string> GeneratePasswordChangeToken(AppUser User)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(User);
            
          
        }
        public async Task<IdentityResult> VerifyPasswordChangeToken(AppUser User,VerifyChangePasswordDTO VerifyChangePasswordDTO)
        {
            return await _userManager.ResetPasswordAsync(User, VerifyChangePasswordDTO.Token, VerifyChangePasswordDTO.NewPassword);
            
           
        }
    }
}
