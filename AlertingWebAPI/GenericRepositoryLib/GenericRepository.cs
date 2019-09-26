using System;
using RepositoryContractsLib;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataContextContractsLib;
using EntityContractsLib;

namespace GenericRepositoryLib
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        public List<T> Temp { get; set; }
        private readonly IDataContext<T> _dataContext;

        public GenericRepository(IDataContext<T> dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<T> List()
        {
            return _dataContext.GetAll().ToList();
        }

        public void Add(T entity)
        {
            _dataContext.WriteOne(entity);
        }

        public void Delete(string id)
        {
            Temp = _dataContext.GetAll().ToList();
            if (Temp.Exists(x => x.Id == id))
            {
                Temp.Remove(Temp.First(x => x.Id == id));
            }

            _dataContext.WriteAll(Temp);
        }

        public void Update(string id, T entity)
        {
            Delete(id);
            Add(entity);
        }

        public T GetById(string id)
        {

              return _dataContext.GetAll().First(x => x.Id == id);

        }
    }

}