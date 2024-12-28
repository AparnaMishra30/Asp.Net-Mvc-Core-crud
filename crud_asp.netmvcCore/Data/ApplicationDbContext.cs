using crud_asp.netmvcCore.Models;
using crud_asp.netmvcCore.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace crud_asp.netmvcCore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
