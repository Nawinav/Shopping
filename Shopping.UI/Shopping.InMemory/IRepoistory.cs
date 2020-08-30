using Shopping.Core.Models;

namespace Shopping.InMemory
{
    public interface IRepoistory<T> where T : BaseEntity
    {
        void commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}