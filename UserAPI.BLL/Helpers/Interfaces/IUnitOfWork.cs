using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Helpers
{
    public interface IUnitOfWork: IDisposable
    {
        void Add<T>(T entity) where T : class, IDbEntity;
        void Update<T>(T entity) where T : class, IDbEntity;
        void Remove<T>(T entity) where T : class, IDbEntity;
        IQueryable<T> Query<T>() where T : class, IDbEntity;
        void Commit();
        Task CommitAsync();
        void Attach<T>(T entity) where T : class, IDbEntity;
    }

}
