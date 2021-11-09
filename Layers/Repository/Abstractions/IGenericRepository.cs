using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Repository.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Guid id);
        int Insert(T entity);
        int Update(T entity);
    }
}
