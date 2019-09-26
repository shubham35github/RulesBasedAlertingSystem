using AlertPublisherLib;
using BedAssociationDataModelLib;
using DataContextContractsLib;
using Microsoft.AspNetCore.Mvc;
using PatientVitalsDataModelLib;
using RepositoryContractsLib;
using SubscriberContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using BedDataModelLib;
using ValidatorContractsLib;

namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    public class IcuController : ControllerBase
    {
	    private readonly AlertPublisher _alertPublisher;
	    private readonly IDataContext<PatientVitalsData> _patientVitalsDataContext;
        private readonly IRepository<BedAssociation> _bedAssociationRepository;
	    private readonly IValidate<PatientVitalsData> _validate;
        private readonly BedsController _bedsController;
        private readonly MonitorsController _monitorsController;
        private readonly PatientsController _patientsController;

        public IcuController(
            IDataContext<PatientVitalsData> patientVitalsDataContext,
            IRepository<BedAssociation> bedAssociationRepository,
            IValidate<PatientVitalsData> validate,
            BedsController bedsController,
            MonitorsController monitorsController,
            PatientsController patientsController)
        {
            _patientVitalsDataContext = patientVitalsDataContext;
            _bedAssociationRepository = bedAssociationRepository;
            _validate = validate;
            _bedsController = bedsController;
            _patientsController = patientsController;
            _monitorsController = monitorsController;
            _alertPublisher = new AlertPublisher();
        }

        [HttpGet("beds")]
        public IEnumerable<BedAssociation> GetBedAssociations()
        {
            return _bedAssociationRepository.List();
        }

        [HttpGet("beds/{associationId}")]
        public BedAssociation GetBedAssociation(string associationId)
        {
            return _bedAssociationRepository.GetById(associationId);
        }

        [HttpPost("beds/{associationId}")]
        public void AdmitPatient(string associationId, [FromBody] BedAssociation bedAssociation)
        {
            // patient admission
            UpdateIsAssigned(bedAssociation, true);
            _bedAssociationRepository.Add(bedAssociation);			
        }

        [HttpDelete("beds/{associationId}")]
        public void DischargePatient(string associationId)
        {
            // patient discharge
            var bedAssociation = GetBedAssociation(associationId);
            UpdateIsAssigned(bedAssociation, false);
            _bedAssociationRepository.Delete(associationId);
        }

        [HttpPost("beds/{bedId}/values")]
        public void WritePatientVitals(string bedId, [FromBody] PatientVitalsData value)
        {
            // dump patient's monitored values
            _patientVitalsDataContext.WriteOne(value);
        }

        [HttpGet("beds/{bedId}/validate")]
        public List<string> GetAnomalies(string bedId)
        {
            _validate.VitalsData = _patientVitalsDataContext.GetAll().Where(x=>x.Id == bedId).OrderByDescending(x=>x.TimeStamp).First(); 
	       return _validate.Validator();
        }

        [HttpPut("beds/alerts")]
        public void UpdateSubscriber([FromBody] List<string> anamolies)
        {
            // add anomalies
            _alertPublisher.SetAnamolies(anamolies);            
        }

        [HttpPost("beds/alerts")]
        public void AddSubscriber([FromBody] ISubscriber subscriber)
        {
            _alertPublisher.RegisterSubscriber(subscriber);
        }

        [HttpDelete("beds/alerts")]
        public void DeleteSubscriber([FromBody] ISubscriber subscriber)
        {
            _alertPublisher.RemoveSubscriber(subscriber);
        }
        private void UpdateIsAssigned(BedAssociation bedAssociation, bool isAssigned)
        {
            var bed = _bedsController.GetBed(bedAssociation.BedId);
            var patient = _patientsController.GetPatient(bedAssociation.PatientId);
            var monitor = _monitorsController.GetMonitor(bedAssociation.MonitorId);

            bed.IsAssigned = isAssigned;
            _bedsController.UpdateBedData(bed.Id, bed);

            patient.IsAssigned = isAssigned;
            _patientsController.UpdatePatientDetails(patient.Id, patient);

            monitor.IsAssigned = isAssigned;
            _monitorsController.UpdateMonitor(monitor.Id, monitor);
        }

    }
}
