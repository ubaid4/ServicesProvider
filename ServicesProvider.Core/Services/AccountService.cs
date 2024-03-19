using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Account;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public AccountService( IAccountRepository accountRepository, IJwtService jwtService, IUserService userService, IUserRepository userRepository) 
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
            _userService = userService;
            _userRepository = userRepository;
        }

        public async Task<BaseResponce> ChangePasswordWithOld(ResetPasswordDTO ResetPasswordDTO)
        {
          AppUser User=await _userService.GetUserById(ResetPasswordDTO.UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }
          IdentityResult result= await _accountRepository.ChangePasswordWithOld(User,ResetPasswordDTO);
            if (!result.Succeeded)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Password Change Failed", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce()
            {
                IsSuccess = true,
                Message = "Password Changed Successfully",
            };
            
        }

        public async Task<BaseResponce> ForgetPassword(string Email)
        {

            AppUser User = await _userService.GetUserByEmail(Email);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }

            String Token = await _accountRepository.ForgetPasswordToken(User);
            if (Token == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Token Generation Failed" };
            }
            return new TokenResponceDTO()
            {
                IsSuccess = true,
                UserId = User.Id.ToString(),
                Token = Token,
                Message = "Token Generated Successfully"
            };
        }

        public async Task<BaseResponce> ResendEmailVerificationToken(string Email)
        {
            AppUser User=await _userService.GetUserByEmail(Email);
            if(User==null)
            {
                return new BaseResponce
                {
                    IsSuccess=false,
                    Message="User Not Found"
                };
            }

            string responce= await _accountRepository.GenerateEmailVerificationToken(User);
            if (responce == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Token Generation Failed" };
            }
            return new TokenResponceDTO()
            {
                IsSuccess = true,
                UserId = User.Id.ToString(),
                Token = responce,
                Message="Token Generated Successfully"
            };
            
        }

        public async Task<BaseResponce> SignIn(LoginDTO loginDTO)
        {
            AppUser User=await _userService.GetUserByName(loginDTO.UserName) 
                ?? (await _userService.GetUserByEmail(loginDTO.UserName)); 
  
            if(User==null)
            {
                return new SignInResponceDTO
                {
                    IsSuccess=false,
                    Message="Invalid UserName or Password"
                };
            }

            SignInResult result=await _accountRepository.SignIn(User,loginDTO.Password);
            SignInResponceDTO responce= new SignInResponceDTO();
            if (!result.Succeeded)
            {
                responce.IsSuccess = false;
                responce.Message = "Invalid UserName or Password";
                return responce;
            }
            if (result.IsLockedOut)
            {
                responce.IsSuccess = false;
                responce.Message = "Your Account is Locked";
                return responce;
            }
            if (result.IsNotAllowed)
            {
                responce.IsSuccess = false;
                responce.Message = "Your Account is Not Allowed,Please verify you email";
                return responce;
            }
           
           
            (responce.Token,responce.TokenExpiration )=await _jwtService.GenerateJwtToken(User);
            (responce.RefreshToken,responce.RefreshTokenExpiration)= await _jwtService.GenerateRefreshToken(User);
            
            responce.IsSuccess = true;
            responce.Message = "Login Successfully";
            responce.UserId = User.Id;  
            return responce;
        }

        public Task<IdentityResult> SignOut()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponce> SignUp(SignupDTO signupDTO)
        {
            AppUser User= new AppUser()
            {
                UserName=signupDTO.UserName,
                Email=signupDTO.Email,
                ProfileImage="default.png",
                Address="Not set",
            };

            IdentityResult result=await _accountRepository.SignUp(User, signupDTO.Password);
            if (!result.Succeeded)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Creation Failed",
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }
            string Token=await _accountRepository.GenerateEmailVerificationToken(User);
            if (Token == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Token Generation Failed" };
            }

            return new TokenResponceDTO()
            {
                IsSuccess = true,
                Message = "Token Generated Successfully",
                Token = Token,
                UserId = User.Id.ToString()

            };
        }

        public async Task<BaseResponce> CreatePasswordChangeToken(string UserId)
        {
            AppUser User = await _userService.GetUserById(UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
               
            }
            string Token = await _accountRepository.GeneratePasswordChangeToken(User);
            if (Token == null)
            {
                return new TokenResponceDTO() { IsSuccess = false, Message = "Token Generation Failed" };
            }
            return new TokenResponceDTO()
            {
                IsSuccess = true,
                Token = Token,
                UserId = User.Id.ToString(),
                Message = "Token Generated Successfully"
            };

            
        }

        public async Task<BaseResponce> VerifyEmail(string UserId, string Token)
        {
            AppUser User=await _userService.GetUserById(UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };

            }
            IdentityResult result =await _accountRepository.VerifyEmail(User, Token);
            if (!result.Succeeded)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Email Verification Failed", Errors = result.Errors.Select(x => x.Description).ToList() };

            }

            return new BaseResponce()
            {
                IsSuccess = true,
                Message = "Account Verified Successfully",


            };
          
        }

        public async Task<BaseResponce> VerifyForgetPassword(VerifiyPasswordUpdateDTO VerifyForgetPasswordDTO)
        {
            AppUser User = await _userService.GetUserById(VerifyForgetPasswordDTO.UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }
            IdentityResult result = await _accountRepository.VerifyForgetPassword(User, VerifyForgetPasswordDTO);
            if (!result.Succeeded)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Password Reset Failed", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce()
            {
                IsSuccess = true,
                Message = "Password Reset Successfully",
            };
        }

        public async Task<BaseResponce> VerifyPasswordChangeToken(VerifyChangePasswordDTO VerifyChangePasswordDTO)
        {
           AppUser User=await _userService.GetUserById(VerifyChangePasswordDTO.UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }
            IdentityResult result = await _accountRepository.VerifyPasswordChangeToken(User, VerifyChangePasswordDTO);
            if (!result.Succeeded)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Password Reset Failed", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce()
            {
                IsSuccess = true,
                Message = "Password Reset Successfully",
            };

        }

        public async Task<BaseResponce> GenerateTokenByRefreshToken(string UserId, string RefreshToken)
        {
            AppUser User =await _userService.GetUserById(UserId);
            if (User == null)
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }

           if(!_jwtService.IsRefreshTokenValid(User, RefreshToken))
            {
                return new BaseResponce
                {
                    IsSuccess = false,
                    Message = "Invalid Refresh Token"
                };

            }
            SignInResponceDTO responce = new SignInResponceDTO();
            (responce.Token, responce.TokenExpiration) = await _jwtService.GenerateJwtToken(User);
            (responce.RefreshToken, responce.RefreshTokenExpiration) = await _jwtService.GenerateRefreshToken(User);
            responce.IsSuccess = true;
            responce.Message = "Token Generated Successfully";
            responce.UserId = User.Id;
            return responce; 
        }

        public async Task<BaseResponce> RevokeRefreshToken(string UserId)
        {
            AppUser User = await _userService.GetUserById(UserId);
            if (User == null)
            {
                new BaseResponce
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }
            User.RefreshToken = string.Empty;
            User.RefreshTokenExpiration = DateTimeOffset.Now;
            await _userRepository.UpdateUser(User);
            return new BaseResponce
            {
                IsSuccess = true,
                Message = "Refresh Token Revoked Successfully"
            };

        }
    }
}
