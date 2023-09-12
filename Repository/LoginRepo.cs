using SampleJWTApp.Models;

namespace SampleJWTApp.Repository
{
    public class LoginRepo : ILoginRepo
    {
        private readonly LoanwfContext _context;

        public LoginRepo(LoanwfContext context)
        {
            _context = context;
        }
        public Customer GetCustomerCredential(CustomerLogin login)
        {
            return _context.Customers.SingleOrDefault(x => x.Cname == login.Username);
        }
    }
}
