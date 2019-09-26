using System.Collections.Generic;

namespace DataContextContractsLib
{
    public interface IDataContext<T>
    {
        IEnumerable<T> GetAll();
        void WriteOne(T record);
        void WriteAll(IEnumerable<T> records);
    }
}
