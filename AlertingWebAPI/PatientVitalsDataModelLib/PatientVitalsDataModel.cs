using System;
using EntityContractsLib;

namespace PatientVitalsDataModelLib
{
	public class PatientVitalsData : EntityBase
	{
		public Decimal Temperature { get; set; }
		public int Spo2 { get; set; }
		public int PulseRate { get; set; }
        public DateTime TimeStamp { get;  }

        public PatientVitalsData(string id,Decimal temperature,int spo2,int pulseRate)
		{
			Id = id;
			Temperature = temperature;
			Spo2 = spo2;
			PulseRate = pulseRate;
            TimeStamp = DateTime.Now;
		}
	}
}
