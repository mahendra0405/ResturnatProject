using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restrurant.Services.Identity.Models;

namespace Restrurant.Services.Identity.DbContexts
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> otpion): base(otpion)
        {

        }
    }
}
