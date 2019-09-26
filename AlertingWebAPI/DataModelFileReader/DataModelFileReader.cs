using System.Collections.Generic;
using System.IO;
using DataReaderContractsLib;
using Newtonsoft.Json;
namespace DataModelFileReader
{
	public class DataModelFileReader<T> : IDataReader<T>
	{
		private string _sourcePath;


		public DataModelFileReader(string sourcePath)
		{
			_sourcePath = sourcePath;

		}
		public IEnumerable<T> GetRecords()
		{
			List<T> patientList = new List<T>();
			using (StreamReader reader = new StreamReader(_sourcePath))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					patientList.Add(JsonConvert.DeserializeObject<T>(line));

				}

				return patientList;
			}


		}
	}
}