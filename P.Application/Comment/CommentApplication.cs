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
}