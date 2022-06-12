namespace P.Domain.ArticleAgg;

public interface IArticleRepository
{
    List<IArticleViewModel> GetAllByViewModel();
    List<T> GetAllByViewModelGeneric<T>() where T : IArticleViewModel, new();

    List<Article> GetAll();
    T? GetUpdateArticle<T>(long id) where T : IUpdateArticle, new();
    void Add(Article entity);
    Article Getby(long id);
    void Save();
}