using P.Domain.CommentAgg;

namespace P.Application.Contracts.Comment;

public class CommentViewModel : ICommentViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public byte Status { get; set; }
    public string CreationDate { get; set; }
    public string Article { get; set; }
}