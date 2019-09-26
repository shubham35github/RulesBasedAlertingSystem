
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModelDataContextLib;
using DataReaderContractsLib;
using DataWriterContractsLib;
using Moq;
using EntityContractsLib;
using DataContextContractsLib;
namespace DataModelDataContextTests
{

    public class DemoEntity : EntityBase
    {
        
    }

    [TestClass]
	public class DataModelDataContextTests
    {
        private static Mock<IDataReader<DemoEntity>> _mockReadObj;
        private static Mock<IDataWriter<DemoEntity>> _mockWriteObj;
        private static IDataContext<DemoEntity> _dataContext;
        private static DemoEntity _demo;

        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _mockReadObj = new Mock<IDataReader<DemoEntity>>();
            _mockWriteObj = new Mock<IDataWriter<DemoEntity>>();
            _dataContext = new DataModelDataContext<DemoEntity>(_mockReadObj.Object, _mockWriteObj.Object);
            _demo = new DemoEntity();

        }

        [TestMethod]
		public void When_GetAll_Invoked_Then_Expected_To_Call_GetRecords()
        {
          
           _dataContext.GetAll();
           _mockReadObj.Verify(obj => obj.GetRecords(),Moq.Times.Exactly(1));


        }
        [TestMethod]
        public void When_WriteOne_Invoked_Then_Expected_To_Call_WriteRecord()
        {
           
            _dataContext.WriteOne(_demo);
            _mockWriteObj.Verify(obj =>obj.WriteRecord(_demo), Moq.Times.Exactly(1));


        }
        [TestMethod]
        public void When_WriteAll_Invoked_Then_Expected_To_Call_WriteRecords()
        {

            
            _dataContext.WriteAll(new List<DemoEntity>());
            _mockWriteObj.Verify(obj => obj.WriteRecords(new List<DemoEntity>()), Moq.Times.Exactly(1));


        }
    }
}
