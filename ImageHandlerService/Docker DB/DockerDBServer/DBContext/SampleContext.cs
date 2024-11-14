using Microsoft.EntityFrameworkCore;

namespace DockerDBServer.DBContext;

public class SampleContext : DbContext
{
    public SampleContext() { }

    public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=P@ss0rd;Host=localhost;Port=5432;Database=ImageHandlerServiceDB;");
}
