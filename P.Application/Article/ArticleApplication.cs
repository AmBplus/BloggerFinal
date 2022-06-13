using P.Application.Contracts.Article;
using P.Domain.ArticleAgg;
using P.Domain.Services.ArticleServices;

namespace P.Application.Article;

public class ArticleApplication : IArticleApplication
{
    protected ArticleApplication(IArticleValidatorServices articleValidator)
    {
        this.articleValidator = articleValidator;
    }

    public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorServices articleValidator)
    {
        _articleRepository = articleRepository;
        this.articleValidator = articleValidator;
    }

    private IArticleRepository _articleRepository { get; }
    private IArticleValidatorServices articleValidator { get; }

    public IEnumerable<ArticleViewModel> List()
    {
        List<IArticleViewModel> result = _articleRepository.GetAllByViewModel();
        return result.Cast<ArticleViewModel>();
    }

    public List<ArticleViewModel> GetListOfArticleViewModel()
    {
        List<ArticleViewModel> result = _articleRepository.GetAllByViewModelGeneric<ArticleViewModel>();
        return result;
    }

    public void Add(ICreateArticle command)
    {
        _articleRepository.Add(new Domain.ArticleAgg.Article
        (articleValidator, command.Title, command.ShortDescription, command.Image,
            command.ArticleCategoryId, command.Content));
    }

    public void Update(IUpdateArticle updateArticle)
    {
        Domain.ArticleAgg.Article findArticle = _articleRepository.Getby(updateArticle.Id);
        findArticle.Update(articleValidator, updateArticle.Title, updateArticle.ShortDescription,
            updateArticle.Image, updateArticle.ArticleCategoryId, updateArticle.Content);
        _articleRepository.Save();
    }

    //public UpdateArticle GetUpdateArticleById(long id)
    //{
    //    IUpdateArticle? result = _articleRepository.GetUpdateArticle(id);
    //    return (UpdateArticle)result;
    //}
    public UpdateArticle? GetUpdateArticleById(long id)
    {
        UpdateArticle? result = _articleRepository.GetUpdateArticle<UpdateArticle>(id);
        return result;
    }

    public void ReStatus(long id)
    {
        Domain.ArticleAgg.Article findArticle = _articleRepository.Getby(id);
        findArticle.ChangeState(!findArticle.IsDeleted);
        _articleRepository.Save();
    }
}