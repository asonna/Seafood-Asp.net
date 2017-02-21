using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SonOfCodSeafood.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
            //public ApplicationDbContext(): base("DefaultConnection") - role
            public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Member> Members { get; set; }

    }
}
