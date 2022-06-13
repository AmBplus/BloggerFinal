using P.Domain.ArticleAgg;

namespace P.Domain.Services.ArticleServices;

public interface IArticleValidatorServices
{
    void CheckArticleNullOrEmptyField(Article article);
    void CheckEmptyOrNullField(string fieldName);
    void CheckExitField(string fieldName);
    void CheckAllBySendArticle(Article article);
    void CheckAllBySendFieldOfArticle(Article article);
    void CheckNullArticle(Article article);
    void CheckCategoryIdValid(long id);
}