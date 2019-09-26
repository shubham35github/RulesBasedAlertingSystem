using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityContractsLib;

namespace RepositoryContractsLib
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> List();
        void Add(T entity);
        void Delete(string id);
        void Update(string id, T entity);
        T GetById(string id);
    }
}
