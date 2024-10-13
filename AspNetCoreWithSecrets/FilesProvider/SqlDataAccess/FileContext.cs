using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithSecrets.FilesProvider.SqlDataAccess;

public class FileContext : DbContext
{
    public FileContext(DbContextOptions<FileContext> options) : base(options)
    { }

    public DbSet<FileDescription> FileDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileDescription>().HasKey(m => m.Id);
        base.OnModelCreating(modelBuilder);
    }
}