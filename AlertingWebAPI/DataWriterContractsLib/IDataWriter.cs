using System.Collections.Generic;

namespace DataWriterContractsLib
{
    public interface IDataWriter<in T>
    {
        void WriteRecords(IEnumerable<T> records);
        void WriteRecord(T record);
    }
}
