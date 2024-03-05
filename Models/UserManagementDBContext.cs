using Microsoft.EntityFrameworkCore;

namespace ERP_user_management_sys.Models
{
    public class UserManagementDBContext(DbContextOptions<UserManagementDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Role> Roles { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Feature> Features { get; set; }
    }
}
