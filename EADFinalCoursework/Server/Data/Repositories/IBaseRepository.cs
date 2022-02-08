using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> FindAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> SaveChangesAsync();
    }
}
