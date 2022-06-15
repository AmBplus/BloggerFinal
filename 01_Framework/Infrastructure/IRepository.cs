using System.Linq.Expressions;
using _01_Framework.Domain;

namespace _01_Framework.Infrastructure;

public interface IRepository<in TKey,T> where T:BaseModel<TKey>
{
    List<T> GetAll();
    void Add(T entity);
    T GetBy(TKey id);
    bool CheckExits(Expression<Func<T,bool>> expression);
    void Save();
}