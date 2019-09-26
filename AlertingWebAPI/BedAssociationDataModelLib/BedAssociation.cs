using EntityContractsLib;

namespace BedAssociationDataModelLib
{
    public class BedAssociation : EntityBase
    {
        public string BedId { get; set; }
        public string PatientId { get; set; }
        public string MonitorId { get; set; }

        public BedAssociation(string id, string bedId, string patientId, string monitorId)
        {
            BedId = bedId;
            PatientId = patientId;
            MonitorId = monitorId;
            Id = id;
        }
    }
}
