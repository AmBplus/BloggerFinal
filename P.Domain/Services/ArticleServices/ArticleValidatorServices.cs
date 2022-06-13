using P.Domain.ArticleAgg;
using P.Domain.Exceptions;

namespace P.Domain.Services.ArticleServices;

public class ArticleValidatorServices : IArticleValidatorServices
{
    public ArticleValidatorServices(IArticleRepository articleRepository)
    {
        ArticleRepository = articleRepository;
    }

    private IArticleRepository ArticleRepository { get; }

    public void CheckArticleNullOrEmptyField(Article article)
    {
        if (article == null || string.IsNullOrWhiteSpace(article.ArticleCategoryId.ToString()) ||
            string.IsNullOrWhiteSpace(article.Title) || string.IsNullOrWhiteSpace(article.ShortDescription))
            throw new NullOrEmptyException("Null OR Empty Field Or Sender Model");
    }

    public void CheckEmptyOrNullField(string fieldName)
    {
        if (string.IsNullOrWhiteSpace(fieldName))
            throw new NullOrEmptyException(fieldName);
    }

    public void CheckExitField(string fieldName)
    {
        if (ArticleRepository.CheckExits(fieldName)) throw new DuplicateFieldException(fieldName);
    }

    public void CheckAllBySendArticle(Article article)
    {
        CheckArticleNullOrEmptyField(article);
    }

    public void CheckAllBySendFieldOfArticle(Article article)
    {
        CheckNullArticle(article);
        CheckEmptyOrNullField(article.Title);
        CheckExitField(article.Title);
        CheckEmptyOrNullField(article.ShortDescription);
        CheckEmptyOrNullField(article.ArticleCategoryId.ToString());
    }

    public void CheckNullArticle(Article article)
    {
        if (article == null) throw new NullReferenceException(nameof(article));
    }

    public void CheckCategoryIdValid(long id)
    {
        if (id < 1) throw new ArgumentOutOfRangeException("Category Id Out Of range");
    }
}