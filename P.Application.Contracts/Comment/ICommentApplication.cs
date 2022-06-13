namespace P.Application.Contracts.Comment;

public interface ICommentApplication
{
    void AddAndSave(AddComment comment);
}