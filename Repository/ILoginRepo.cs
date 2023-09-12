using Microsoft.EntityFrameworkCore;
using SampleJWTApp.Models;

namespace SampleJWTApp.Repository
{
    public interface ILoginRepo
    {
        public Customer GetCustomerCredential(CustomerLogin login);
    }
}

