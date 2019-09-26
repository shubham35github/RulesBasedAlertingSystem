using System;
using System.Globalization;
using EntityContractsLib;

namespace PatientDataModelLib
{
    public class PatientDetails : EntityBase
    {

        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public bool IsAssigned { get; set; } = false;


        public PatientDetails(string id, string name, DateTime dob)
        {
            Id = id;
            Name = name;
            Dob = dob;

        }
     
    }
   
}
    