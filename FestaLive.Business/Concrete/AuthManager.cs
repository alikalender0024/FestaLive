using FestaLive.Business.Abstract;
using FestaLive.Core.Entities.Concrete;
using FestaLive.Core.Utilities.Results;
using FestaLive.Core.Utilities.Security.Jwt;
using FestaLive.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Concrete
{
    public class AuthManager(IUserService userService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        ITokenHelper _tokenHelper;

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetOperationClaims(user).Data;
            var token = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(token);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}