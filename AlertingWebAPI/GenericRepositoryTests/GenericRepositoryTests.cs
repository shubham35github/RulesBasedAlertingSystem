using System;
using System.Collections.Generic;
using System.Linq;
using DataContextContractsLib;
using EntityContractsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GenericRepositoryLib;
using RepositoryContractsLib;
namespace GenericRepositoryTests
{
    public class DemoEntity : EntityBase
    {

    }

    [TestClass]
    public class GenericRepositoryTests
    {
        private static IRepository<DemoEntity> _genericRepository;
        private static DemoEntity _demoEntity;
        private static Mock<IDataContext<DemoEntity>> _mockObj;
        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _demoEntity = new DemoEntity();
            _mockObj = new Mock<IDataContext<DemoEntity>>();
            _genericRepository = new GenericRepository<DemoEntity>(_mockObj.Object);

        }

        [TestMethod]
        public void When_List_Is_Invoked_It_should_call_GetAll_Method()
        {
            _genericRepository.List();
            _mockObj.Verify(obj => obj.GetAll(),Times.AtLeast(1));

        }
        [TestMethod]
        public void When_Add_Is_Invoked_It_Should_Call_WriteOne_Method()
        {
            _genericRepository.Add(_demoEntity);
            _mockObj.Verify(obj => obj.WriteOne(_demoEntity), Times.Exactly(1));

        }
        [TestMethod]
        public void When_Delete_Is_Invoked_It_Should_Call_GetAll_and_WriteAll()
        {
            
            _genericRepository.Delete(_demoEntity.Id);
            _mockObj.Verify(obj=>obj.WriteAll(new List<DemoEntity>()),Times.Exactly(1));
        }
    }
}
