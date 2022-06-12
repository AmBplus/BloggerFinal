namespace P.Domain.ArticleAgg;

public interface IArticleViewModel
{
    long Id { get; set; }
    string Title { get; set; }
    string ArticleCategory { get; set; }
    bool IsDeleted { get; set; }
    string CreationDate { get; set; }
}