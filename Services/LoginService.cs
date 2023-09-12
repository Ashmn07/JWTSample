using Microsoft.IdentityModel.Tokens;
using SampleJWTApp.Models;
using SampleJWTApp.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleJWTApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _repo;
        private readonly IConfiguration _config;

        public LoginService(ILoginRepo repo, IConfiguration config)
        {
            _repo = repo;
            _config=config;
        }

        public Customer GetCustDetails(CustomerLogin login)
        {
            Customer customer = null;
            customer = _repo.GetCustomerCredential(login);
            return customer;
        }

        public String GenerateJSONWebToken(CustomerLogin customerInfo)
        {
            if (customerInfo is null)
            {
                throw new ArgumentNullException(nameof(customerInfo));
            }
            List<Claim> claims = new List<Claim>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            claims.Add(new Claim("Username", customerInfo.Username));
            if (customerInfo.IsEmployee == 0)
            {
                claims.Add(new Claim("role", "admin"));
            }
            else
            {
                claims.Add(new Claim("role", "customer"));

            }
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
