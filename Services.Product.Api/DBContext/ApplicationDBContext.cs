using Microsoft.EntityFrameworkCore;


namespace Services.Product.Api.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option): base(option)
        {

        }

        public DbSet<Services.Product.Api.Models.Product> Products { get; set; }
    }
}
