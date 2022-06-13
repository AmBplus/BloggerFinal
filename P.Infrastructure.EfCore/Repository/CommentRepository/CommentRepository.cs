using System.Globalization;
using Microsoft.EntityFrameworkCore;
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

    public List<T> GetList<T>() where T : ICommentViewModel, new()
    {
        return Context.Comments.Include(x => x.Article).Select(x =>
            new T
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title,
                Message = x.Message,
                Name = x.Name,
                Status = x.Status
            }
        ).ToList();
    }

    public Comment? Get(long id)
    {
        return Context.Comments.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        Context.SaveChanges();
    }
}