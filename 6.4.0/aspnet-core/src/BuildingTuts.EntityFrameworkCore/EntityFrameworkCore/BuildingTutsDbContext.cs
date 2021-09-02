using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BuildingTuts.Authorization.Roles;
using BuildingTuts.Authorization.Users;
using BuildingTuts.MultiTenancy;
using BuildingTuts.Academy;

namespace BuildingTuts.EntityFrameworkCore
{
    public class BuildingTutsDbContext : AbpZeroDbContext<Tenant, Role, User, BuildingTutsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BuildingTutsDbContext(DbContextOptions<BuildingTutsDbContext> options)
            : base(options)
        {
        }
        //db set has to do with creating tables in your database
        public DbSet<AcademyStudents> Students { get; set; }
    }
}
