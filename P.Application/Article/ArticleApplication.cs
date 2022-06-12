using P.Application.Contracts.Article;
using P.Domain.ArticleAgg;

namespace P.Application.Article;

public class ArticleApplication : IArticleApplication
{
    protected ArticleApplication()
    {
    }

    public ArticleApplication(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    private IArticleRepository _articleRepository { get; }

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
        (command.Title, command.ShortDescription, command.Image,
            command.ArticleCategoryId, command.Content));
    }

    public void Update(IUpdateArticle updateArticle)
    {
        Domain.ArticleAgg.Article findArticle = _articleRepository.Getby(updateArticle.Id);
        findArticle.Update(updateArticle.Title, updateArticle.ShortDescription,
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