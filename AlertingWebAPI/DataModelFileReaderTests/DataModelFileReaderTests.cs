using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModelFileReader;
using EntityContractsLib;
using DataReaderContractsLib;
namespace DataModelFileReaderTests
{
	public class Demo : EntityBase
	{

	}

	[TestClass]
	public class DataModelFileReaderTests
	{
		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void Given_SourcePath_When_GetRecords_Is_Invoked_Exception_Is_Raised()
		{
			IDataReader<Demo> dataReader = new DataModelFileReader<Demo>("sample.txt");
			dataReader.GetRecords();
		}
	}
}
