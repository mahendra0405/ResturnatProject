using Microsoft.EntityFrameworkCore;

namespace Services.Product.Api.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option): base(option)
        {

        }
    }
}
