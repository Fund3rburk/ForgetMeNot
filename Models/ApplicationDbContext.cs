using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForgetMeNot.Models;

namespace ForgetMeNot.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        public ApplicationDbContext() : base()
        {
        }
       
        public DbSet<Event> Event { get; set; }
    }
}
