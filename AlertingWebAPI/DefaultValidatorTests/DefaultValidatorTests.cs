using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientVitalsDataModelLib;
using ValidatorContractsLib;
using DefaultValidatorLib;
namespace DefaultValidatorTests
{
    [TestClass]
    public class DefaultValidatorTests
    {
        private static PatientVitalsData _patientVitalsData;
        private static IValidate<PatientVitalsData> _validator;

        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _patientVitalsData = new PatientVitalsData("P12445",90,67,200);
            _validator = new DefaultValidator();
            _validator.VitalsData = _patientVitalsData;
        }

        [TestMethod]
        public void Given_Vitals_When_Validate_Is_Called_Generate_AnomaliesList()
        {
           var testAnomaliesList = _validator.Validator();
           Assert.AreEqual(3,testAnomaliesList.Count);


        }
    }
}
