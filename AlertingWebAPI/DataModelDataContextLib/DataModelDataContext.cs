using System.Collections.Generic;
using DataContextContractsLib;
using DataReaderContractsLib;
using DataWriterContractsLib;

namespace DataModelDataContextLib
{
	public class DataModelDataContext<T> : IDataContext<T>
	{
		private IDataReader<T> _reader;
		private IDataWriter<T> _writer;

		public DataModelDataContext(IDataReader<T> reader, IDataWriter<T> writer)
		{
			_reader = reader;
			_writer = writer;
		}

		public IEnumerable<T> GetAll()
		{
			return _reader.GetRecords();
		}

		public void WriteOne(T record)
		{
			_writer.WriteRecord(record);
		}

		public void WriteAll(IEnumerable<T> records)
		{
			_writer.WriteRecords(records);
		}
	}
}