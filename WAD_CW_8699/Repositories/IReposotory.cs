using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_8699_DAL.Repositories
{
    public interface IReposotory<T> where T:class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        bool Exists(int id);
    }
}
