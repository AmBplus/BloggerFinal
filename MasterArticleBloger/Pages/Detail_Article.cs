using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Article;

namespace MasterArticleBloger.Pages;

public class Detail_ArticleModel : PageModel
{
    private IArticleToUserQuery articleToUserQuery { get; set; }
    public ArticleToUserFullViewModel Article { get; set; }

    public Detail_ArticleModel(IArticleToUserQuery articleToUserQuery)
    {
        this.articleToUserQuery = articleToUserQuery;
    }

    public void OnGet(long id)
    {
        Article = articleToUserQuery.GetArticleToUserFullViewModel(id);
        if (Article==null)
        {
                        return;
        }
    }
}