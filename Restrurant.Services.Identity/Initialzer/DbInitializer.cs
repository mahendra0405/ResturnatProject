using Duende.IdentityServer.Validation;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Restrurant.Services.Identity.DbContexts;
using Restrurant.Services.Identity.Models;

namespace Restrurant.Services.Identity.Initialzer
{
    public  class DbInitializer: IDbInitializer
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDBContext db, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public void Initialize()
        {
           if(_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber="1111111111",
                FirstName="Mahee",
                LastName="Admin"
            };
            _userManager.CreateAsync(adminUser,"Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1=_userManager.AddClaimsAsync(adminUser, new System.Security.Claims.Claim[]
            {
                new System.Security.Claims.Claim(JwtClaimTypes.Name,adminUser.FirstName + " "+ adminUser.LastName),
                new System.Security.Claims.Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new System.Security.Claims.Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new System.Security.Claims.Claim(JwtClaimTypes.Role,SD.Admin)
            }).Result ;

            ApplicationUser customerUser = new ApplicationUser
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1111111111",
                FirstName = "Leeku",
                LastName = "Cust"
            };
            _userManager.CreateAsync(customerUser, "Cust123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new System.Security.Claims.Claim[]
            {
                new System.Security.Claims.Claim(JwtClaimTypes.Name,customerUser.FirstName + " "+ customerUser.LastName),
                new System.Security.Claims.Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new System.Security.Claims.Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new System.Security.Claims.Claim(JwtClaimTypes.Role,SD.Customer)
            }).Result;
        }
    }
}
