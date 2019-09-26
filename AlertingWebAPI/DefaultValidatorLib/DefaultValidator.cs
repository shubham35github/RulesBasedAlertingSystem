using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorContractsLib;
using PatientVitalsDataModelLib;
using  Resources;
namespace DefaultValidatorLib
{

    public class DefaultValidator:IValidate<PatientVitalsData>
    {
        public PatientVitalsData VitalsData { get; set; }
        private readonly List<string> _anomalies = new List<string>();

      
        public List<string> Validator()
	    {
            _anomalies.Clear();
            CheckTemperature();
            CheckPulseRate();
            CheckSpo2();
		   return _anomalies;

	    }
	    private void CheckTemperature()
	    {
            if(VitalsData.Temperature < Constants.TemperatureValidMin || VitalsData.Temperature > Constants.TemperatureValidMax)
                _anomalies.Add($"{nameof(VitalsData.Temperature)}");
        }

	    private void CheckPulseRate()
	    {
           
             if(VitalsData.PulseRate < Constants.PulseRateValidMin || VitalsData.PulseRate > Constants.PulseRateValidMax)
                 _anomalies.Add($"{nameof(VitalsData.PulseRate)}");
        }

	    private void CheckSpo2()
	    {
           
            if (VitalsData.Spo2 < Constants.Spo2ValidMin || VitalsData.Spo2 > Constants.Spo2ValidMax)
                _anomalies.Add($"{nameof(VitalsData.Spo2)}");
        }
	}
}
