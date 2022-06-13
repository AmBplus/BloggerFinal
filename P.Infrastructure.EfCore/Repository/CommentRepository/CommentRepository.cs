using P.Domain.CommentAgg;

namespace P.Infrastructure.EfCore.Repository.CommentRepository;

public class CommentRepository : ICommentRepository
{
    public CommentRepository(MasterBlogerContext context)
    {
        Context = context;
    }

    private MasterBlogerContext Context { get; }

    public void AddAndSave(Comment comment)
    {
        Context.Comments.Add(comment);
        Save();
    }

    public void Save()
    {
        Context.SaveChanges();
    }
}