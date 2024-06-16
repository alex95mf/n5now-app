using Microsoft.EntityFrameworkCore;

namespace n5now_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionsTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionDetail>()
                .HasOne(p => p.TipoPermisoDetalle)
                .WithMany() 
                .HasForeignKey(p => p.TipoPermiso);
        }
    }

    public class Permission
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }

    }

    public class PermissionDetail
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
        public PermissionType TipoPermisoDetalle { get; set; }

    }

    public class PermissionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
   
}
