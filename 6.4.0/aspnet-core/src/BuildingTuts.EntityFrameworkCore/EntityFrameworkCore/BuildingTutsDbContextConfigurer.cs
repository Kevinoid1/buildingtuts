using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BuildingTuts.EntityFrameworkCore
{
    public static class BuildingTutsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BuildingTutsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BuildingTutsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
