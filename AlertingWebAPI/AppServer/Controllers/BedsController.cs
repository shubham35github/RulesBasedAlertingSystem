using BedDataModelLib;
using DataModelDataContextLib;
using DataModelFileReader;
using DataModelFileWriterLib;
using GenericRepositoryLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryContractsLib;
using System.Collections.Generic;
using System.Linq;

namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    public class BedsController : ControllerBase
    {
        //private IRepository<BedData> _bedsRepository = new GenericRepository<BedData>(
        //    new DataModelDataContext<BedData>(
        //        new DataModelFileReader<BedData>("beds.txt"),
        //        new DataModelFileWriter<BedData>("beds.txt")));

        private IRepository<BedData> _bedsRepository = null;

        public BedsController(IRepository<BedData> bedsRepository)
        {
            _bedsRepository = bedsRepository;
        }

        [HttpGet]
        public List<BedData> GetBeds()
        {
            return _bedsRepository.List().Where(x => !x.IsAssigned).ToList();
        }

        [HttpGet("{bedId}")]
        public BedData GetBed(string bedId)
        {
            return _bedsRepository.GetById(bedId);
        }

        [HttpPost]
        public void AddBed([FromBody] BedData entity)
        {
            _bedsRepository.Add(entity);
        }

        [HttpPut("{bedId}")]
        public void UpdateBedData(string bedId, [FromBody] BedData entity)
        {
            _bedsRepository.Update(bedId, entity);
        }

        [HttpDelete("{bedId}")]
        public void DeleteBed(string bedId)
        {
            _bedsRepository.Delete(bedId);
        }
    }
}
