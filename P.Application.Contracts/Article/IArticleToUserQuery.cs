namespace P.Application.Contracts.Article;

public interface IArticleToUserQuery
{
    List<ArticleToUserMiniViewModel> GetListArticleToUserMiniViewModel();
    List<ArticleToUserFullViewModel> GetListArticleToUserFullViewModel();
    ArticleToUserFullViewModel? GetArticleToUserFullViewModel(long id);
}