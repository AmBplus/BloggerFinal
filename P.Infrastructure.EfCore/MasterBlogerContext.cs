﻿using Microsoft.EntityFrameworkCore;
using P.Domain.ArticleAgg;
using P.Domain.ArticleCategoryAgg;
using P.Infrastructure.EfCore.Mapping;

namespace P.Infrastructure.EfCore;

public class MasterBlogerContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }

    public MasterBlogerContext(DbContextOptions<MasterBlogerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
        modelBuilder.ApplyConfiguration(new ArticleMaping());
        base.OnModelCreating(modelBuilder);
    }
}