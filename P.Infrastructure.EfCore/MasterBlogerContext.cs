using System.Reflection;
using Microsoft.EntityFrameworkCore;
using P.Domain.ArticleAgg;
using P.Domain.ArticleCategoryAgg;
using P.Domain.CommentAgg;

namespace P.Infrastructure.EfCore;

public class MasterBlogerContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public MasterBlogerContext(DbContextOptions<MasterBlogerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
        //modelBuilder.ApplyConfiguration(new ArticleMaping());
        //modelBuilder.ApplyConfiguration(new CommentMapping());
        Assembly assembly = typeof(MasterBlogerContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}