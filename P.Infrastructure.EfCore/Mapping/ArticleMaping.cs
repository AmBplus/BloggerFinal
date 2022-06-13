using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P.Domain.ArticleAgg;

namespace P.Infrastructure.EfCore.Mapping;

public class ArticleMaping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ArticleCategoryId);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title);
        builder.Property(x => x.Content);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.Image);
        builder.Property(x => x.ShortDescription);
        builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        builder.HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
    }
}