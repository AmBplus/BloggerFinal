using P.Domain.ArticleAgg;

namespace P.Application.Contracts.Article;

public interface IArticleApplication
{
    IEnumerable<ArticleViewModel> List();
    List<ArticleViewModel> GetListOfArticleViewModel();

    // List<ArticleBaseViewModel> listBaseViewModels();
    void Add(ICreateArticle command);
    void Update(IUpdateArticle updateCategoryArticle);
    UpdateArticle? GetUpdateArticleById(long id);
    void ReStatus(long id);
}                                     