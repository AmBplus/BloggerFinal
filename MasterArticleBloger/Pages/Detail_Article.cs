using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Article;
using P.Application.Contracts.Comment;

namespace MasterArticleBloger.Pages;

public class Detail_ArticleModel : PageModel
{
    private IArticleToUserQuery articleToUserQuery { get; set; }
    public ArticleToUserFullViewModel Article { get; set; }
    [BindProperty] public AddComment Comment { get; set; }
    private ICommentApplication CommentApplication { get; }
    public static string CommentStatus { get; set; }

    public Detail_ArticleModel(IArticleToUserQuery articleToUserQuery, ICommentApplication commentApplication)
    {
        this.articleToUserQuery = articleToUserQuery;
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
        Article = articleToUserQuery.GetArticleToUserFullViewModel(id);
        if (Article == null) return;
    }
}