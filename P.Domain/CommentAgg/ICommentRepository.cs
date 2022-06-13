namespace P.Domain.CommentAgg;

public interface ICommentRepository
{
    void AddAndSave(Comment comment);
    List<T> GetList<T>() where T : ICommentViewModel, new();
    Comment? Get(long id);
    void Save();
}