using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Comment;

namespace MasterArticleBlogger.Areas.Adminstrator.Pages.CommentManagement;

public class IndexModel : PageModel
{
    public IndexModel(ICommentApplication commentApplication)
    {
        CommentApplication = commentApplication;
    }

    public List<CommentViewModel> Comments { get; set; }
    private ICommentApplication CommentApplication { get; }

    public void OnGet()
    {
        Comments = CommentApplication.GetAllViewModels();
    }

    public RedirectToPageResult OnPostConfirmComment(long id)
    {
        CommentApplication.ConfirmOrActive(id);
        return RedirectToPage();
    }

    public RedirectToPageResult OnPostRemoveComment(long id)
    {
        CommentApplication.RemoveComment(id);
        return RedirectToPage();
    }
}