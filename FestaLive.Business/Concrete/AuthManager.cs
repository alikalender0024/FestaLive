using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Aspects.Autofac.Logging;
using FestaLive.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using FestaLive.Core.Entities.Concrete;
using FestaLive.Core.Utilities.Results;
using FestaLive.Core.Utilities.Security.Hashing;
using FestaLive.Core.Utilities.Security.Jwt;
using FestaLive.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class AuthManager(IUserService userService, ITokenHelper tokenHelper) : IAuthService
    {
        private readonly IUserService _userService = userService;
        ITokenHelper _tokenHelper = tokenHelper;

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetOperationClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToChechk = _userService.GetByMail(userForLoginDto.Email);
            if (userToChechk==null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToChechk.Data.PasswordHash, userToChechk.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToChechk.Data, UserMessages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true,
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);

        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data!=null)
            {
                return new ErrorDataResult<User>(UserMessages.UserAlreadyExisits);
            }
            return new SuccessResult();
        }
    }
}
