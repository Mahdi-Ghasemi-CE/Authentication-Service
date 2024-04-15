using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Options = Authentication_Service.Application.Utils.Options;

namespace Authentication_Service.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly Options _options;
    public AppDbContext(IOptions<Options> options)
    {
        _options = options.Value;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuration database
        optionsBuilder.UseNpgsql(_options.DbConnection);
        
        base.OnConfiguring(optionsBuilder);
    }
}