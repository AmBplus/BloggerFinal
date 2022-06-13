namespace P.Domain.CommentAgg;

public interface ICommentViewModel
{
    long Id { get; set; }
    string Name { get; set; }
    string Message { get; set; }
    byte Status { get; set; }
    string CreationDate { get; set; }
    string Article { get; set; }
}