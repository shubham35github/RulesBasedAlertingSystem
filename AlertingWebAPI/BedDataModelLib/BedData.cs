using EntityContractsLib;
using MonitorDataModelLib;
using PatientDataModelLib;

namespace BedDataModelLib
{
    public class BedData : EntityBase
    {
        public string Model { get; set; }
        public bool IsAssigned { get; set; } = false;

        public BedData(string id, string model)
        {
            Id = id;
            Model = model;
        }
    }
}
