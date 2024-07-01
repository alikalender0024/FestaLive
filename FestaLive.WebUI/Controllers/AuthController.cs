using FestaLive.Business.Abstract;
using FestaLive.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return View(userForLoginDto);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return RedirectToAction("AboutList", "About");
            }
            return View(userForLoginDto);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return View(userForRegisterDto);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return RedirectToAction("AboutList", "About");
            }
            return View(userForRegisterDto);
        }
    }
}
