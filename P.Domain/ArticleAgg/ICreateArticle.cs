namespace P.Domain.ArticleAgg;

public interface ICreateArticle
{
    string Title { get; set; }
    string ShortDescription { get; set; }
    string Image { get; set; }
    string Content { get; set; }
    long ArticleCategoryId { get; set; }
}