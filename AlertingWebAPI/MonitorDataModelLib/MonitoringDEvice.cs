using EntityContractsLib;

namespace MonitorDataModelLib
{
    public class MonitoringDevice : EntityBase
    {
        public string Model { get; set; }
        public bool IsAssigned { get; set; } = false;

        public MonitoringDevice(string id, string model)
        {
            Model = model;
            Id = id;
        }
    }
}
