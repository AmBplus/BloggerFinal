using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P.Domain.CommentAgg;

namespace P.Infrastructure.EfCore.Mapping;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Comments");
        builder.Property(x => x.Id);
        builder.Property(x => x.ArticleId);
        builder.Property(x => x.Email).HasMaxLength(80);
        builder.Property(x => x.Message).HasMaxLength(500);
        builder.Property(x => x.Name).HasMaxLength(150);
        builder.Property(x => x.Status);
        builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
    }
}