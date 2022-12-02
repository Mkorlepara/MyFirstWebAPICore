using Microsoft.EntityFrameworkCore;
using MadhaviBookLibraryWebAPI.Models;
namespace MadhaviBookLibraryWebAPI.Data
{
    public class IssueDbContext :DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options):base(options)
        { }
        public DbSet<Issue> Issues { set; get; } 
    }
}
