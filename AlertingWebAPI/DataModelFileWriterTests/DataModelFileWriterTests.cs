using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModelFileWriterLib;
using EntityContractsLib;
using DataWriterContractsLib;
namespace DataModelFileWriterTests

{
    public class TestDemoEntity : EntityBase
    {

    }

    [TestClass]
    public class DataModelFileWriterTests
    {
        private static IDataWriter<TestDemoEntity> _dataWriter;
        private static TestDemoEntity _demoEntity;
        private static string _sourcePath = "TestFile.txt";
        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _demoEntity = new TestDemoEntity();
            _dataWriter = new DataModelFileWriter<TestDemoEntity>(_sourcePath);
            _demoEntity.Id = "DemoId";
        }

        [TestMethod]
        public void Given_SourcePath_Check_Whether_WriteRecord_Writes_To_A_File()
        {
            _dataWriter.WriteRecord(_demoEntity);
            Assert.AreNotEqual(0,File.ReadAllLines(_sourcePath).Length);
        }
        [TestMethod]
        public void Given_SourcePath_Check_Whether_WriteRecords_Writes_To_A_File()
        {
            List<TestDemoEntity> demoList = new List<TestDemoEntity>();
            demoList.Add(_demoEntity);
            _dataWriter.WriteRecords(demoList);
            Assert.AreNotEqual(0, File.ReadAllLines(_sourcePath).Length);
        }



    }
}
