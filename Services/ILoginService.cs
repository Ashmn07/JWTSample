using SampleJWTApp.Models;

namespace SampleJWTApp.Services
{
    public interface ILoginService
    {
        public Customer GetCustDetails(CustomerLogin login);

        public String GenerateJSONWebToken(CustomerLogin customerInfo);
    }
}
