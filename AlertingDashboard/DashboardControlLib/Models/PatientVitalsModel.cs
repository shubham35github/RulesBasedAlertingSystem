using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardControlLib.Models
{
    public class PatientVitalsModel
    {
        public Decimal Temperature { get; set; }
        public int Spo2 { get; set; }
        public int PulseRate { get; set; }
        public string Id { get; set; }
    }
}
