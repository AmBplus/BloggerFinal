using System.ComponentModel.DataAnnotations;
using P.Domain.ArticleAgg;

namespace P.Application.Contracts.Article;

public class UpdateArticle : IUpdateArticle
{
    [Required] [MinLength(6)] public string Title { get; set; }
    [Required] [MinLength(6)] public string ShortDescription { get; set; }
    [Required] [MinLength(3)] public string Image { get; set; }
    [Required] [MinLength(6)] public string Content { get; set; }

    [Required]
    [RegularExpression("^[1-9]+[0-9]*$")]
    public long ArticleCategoryId { get; set; }

    [Required]
    [RegularExpression("^[1-9]+[0-9]*$")]
    public long Id { get; set; }
}