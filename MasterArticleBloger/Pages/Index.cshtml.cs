using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Article;

namespace MasterArticleBlogger.Pages;

public class IndexModel : PageModel
{
    public IndexModel(IArticleToUserQuery articleToUserQuery)
    {
        ArticleToUserQuery = articleToUserQuery;
    }

    private IArticleToUserQuery ArticleToUserQuery { get; }
    public List<ArticleToUserMiniViewModel> Articles { get; set; }

    public void OnGet()
    {
        Articles = ArticleToUserQuery.GetListArticleToUserMiniViewModel();
    }
}