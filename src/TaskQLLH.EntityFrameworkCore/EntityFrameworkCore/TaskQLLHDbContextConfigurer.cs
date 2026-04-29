using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TaskQLLH.EntityFrameworkCore
{
    public static class TaskQLLHDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TaskQLLHDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TaskQLLHDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
