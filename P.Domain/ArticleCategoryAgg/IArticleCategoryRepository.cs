namespace P.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    public List<ArticleCategory> GetAll();
    void Add(ArticleCategory entity);
    ArticleCategory Getby(long id);
    void Save();
    bool ExitsBy(string Title);
}