using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataWriterContractsLib;
using Newtonsoft.Json;

namespace DataModelFileWriterLib
{

	public class DataModelFileWriter<T> : IDataWriter<T>
	{
		private readonly string _sourcePath;

		public DataModelFileWriter(string sourcePath)
		{
			_sourcePath = sourcePath;

		}
		public void WriteRecords(IEnumerable<T> records)
		{
			using (StreamWriter writer = new StreamWriter(_sourcePath))
			{
				foreach (var record in records)
				{
					writer.WriteLine(JsonConvert.SerializeObject(record));
				}
			}

		}

		public void WriteRecord(T record)
		{
			using (StreamWriter writer = new StreamWriter(_sourcePath, true))
			{
				writer.WriteLine(JsonConvert.SerializeObject(record));
			}
		}
	}
}