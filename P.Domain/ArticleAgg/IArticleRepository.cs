using _01_Framework.Infrastructure;

namespace P.Domain.ArticleAgg;

public interface IArticleRepository : IRepository<long, Article>
{
    List<IArticleViewModel> GetAllByViewModel();
    List<T> GetAllByViewModelGeneric<T>() where T : IArticleViewModel, new();        
    T? GetUpdateArticle<T>(long id) where T : IUpdateArticle, new();
}