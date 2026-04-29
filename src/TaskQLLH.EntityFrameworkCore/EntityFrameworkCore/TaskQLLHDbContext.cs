using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TaskQLLH.Authorization.Roles;
using TaskQLLH.Authorization.Users;
using TaskQLLH.MultiTenancy;
using TaskQLLH.ClassRooms;

namespace TaskQLLH.EntityFrameworkCore
{
    public class TaskQLLHDbContext : AbpZeroDbContext<Tenant, Role, User, TaskQLLHDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        
        public TaskQLLHDbContext(DbContextOptions<TaskQLLHDbContext> options)
            : base(options)
        {
        }
    }
}
