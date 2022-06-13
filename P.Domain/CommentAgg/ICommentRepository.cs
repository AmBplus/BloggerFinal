namespace P.Domain.CommentAgg;

public interface ICommentRepository
{
    void AddAndSave(Comment comment);
    void Save();
}