using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.Contracts
{
    public interface IDataAccessBase<T>
    {
        //CRUD
        IQueryable<T> StatusAll(bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
