using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleJWTApp.Models;
using SampleJWTApp.Services;

namespace SampleJWTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService=loginService;
        }

        [HttpPost]
        public IActionResult Login(CustomerLogin login)
        {
            IActionResult response = Unauthorized();

            var customer = _loginService.GetCustDetails(login);

            if (customer != null)
            {
                var tokenString = _loginService.GenerateJSONWebToken(login);

                response = Ok(new LoginResponse { token = tokenString, User_Id = login.Username,});
            }

            return response;
        }
    }
}
