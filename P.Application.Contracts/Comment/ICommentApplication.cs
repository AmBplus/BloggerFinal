namespace P.Application.Contracts.Comment;

public interface ICommentApplication
{
    void AddAndSave(AddComment comment);
    List<CommentViewModel> GetAllViewModels();
    void RemoveComment(long id);
    void ConfirmOrActive(long id);
}