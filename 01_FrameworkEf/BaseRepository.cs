using System.Linq.Expressions;
using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace _01_FrameworkEf;

public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : BaseModel<TKey>
{
    private DbContext Context;

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public List<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        Context.Add<T>(entity);
    }

    public T GetBy(TKey id)
    {
        return Context.Find<T>(id);
    }

    public bool CheckExits(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Any(expression);
    }

    public void Save()
    {
        Context.SaveChanges();
    }
}