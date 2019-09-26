using Microsoft.AspNetCore.Mvc;
using PatientDataModelLib;
using RepositoryContractsLib;
using System.Collections.Generic;
using System.Linq;

namespace AppServer.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IRepository<PatientDetails> _patientsRepository = null;

        public PatientsController(IRepository<PatientDetails> patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        [HttpGet]
        public IEnumerable<PatientDetails> GetPatients()
        {
            return _patientsRepository.List().Where(x => !x.IsAssigned);
        }

        [HttpGet("{patientId}")]
        public PatientDetails GetPatient(string patientId)
        {
            return _patientsRepository.GetById(patientId);
        }

        [HttpPost]
        public void AddPatient([FromBody] PatientDetails entity)
        {
            _patientsRepository.Add(entity);
        }

        [HttpPut("{patientId}")]
        public void UpdatePatientDetails(string patientId, [FromBody] PatientDetails entity)
        {
            _patientsRepository.Update(patientId, entity);
        }

        [HttpDelete("{patientId}")]
        public void DeletePatient(string patientId)
        {
            _patientsRepository.Delete(patientId);
        }
    }
}