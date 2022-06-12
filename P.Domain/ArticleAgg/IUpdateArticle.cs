namespace P.Domain.ArticleAgg;

public interface IUpdateArticle : ICreateArticle
{
    long Id { get; set; }
}