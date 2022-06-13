using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Article;
using P.Application.Contracts.Comment;

namespace MasterArticleBlogger.Pages;

public class DetailArticleModel : PageModel
{
    private IArticleToUserQuery ArticleToUserQuery { get; set; }
    public ArticleToUserFullViewModel? Article { get; set; }
    [BindProperty] public AddComment Comment { get; set; }
    private ICommentApplication CommentApplication { get; }
    public static string CommentStatus { get; set; }

    public DetailArticleModel(IArticleToUserQuery articleToUserQuery, ICommentApplication commentApplication)
    {
        ArticleToUserQuery = articleToUserQuery;
        CommentApplication = commentApplication;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            CommentApplication.AddAndSave(Comment);
            CommentStatus = "Succeed";
        }

        return RedirectToPage(Comment.ArticleId);
    }

    public void OnGet(long id)
    {
        Article = ArticleToUserQuery.GetArticleToUserFullViewModel(id);
        if (Article == null) return;
    }
}