using P.Application.Contracts.Comment;
using P.Domain.CommentAgg;

namespace P.Application.Comment;

public class CommentApplication : ICommentApplication
{
    public CommentApplication(ICommentRepository commentRepository)
    {
        CommentRepository = commentRepository;
    }

    private ICommentRepository CommentRepository { get; }

    public void AddAndSave(AddComment comment)
    {
        CommentRepository.AddAndSave(new Domain.CommentAgg.Comment(comment.Name, comment.Email,
            comment.Message, comment.ArticleId));
    }

    public List<CommentViewModel> GetAllViewModels()
    {
        return CommentRepository.GetList<CommentViewModel>();
    }

    public void RemoveComment(long id)
    {
        Domain.CommentAgg.Comment? comment = CommentRepository.Get(id);
        comment?.ChangeStatus(Statuses.Cancel);
        CommentRepository.Save();
    }

    public void ConfirmOrActive(long id)
    {
        Domain.CommentAgg.Comment? comment = CommentRepository.Get(id);
        comment?.ChangeStatus(Statuses.Confirm);
        CommentRepository.Save();
    }
}