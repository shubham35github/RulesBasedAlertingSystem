using System.Collections.Generic;

namespace DataReaderContractsLib
{
    public interface IDataReader<out T>
    {
        IEnumerable<T> GetRecords();
    }
}
