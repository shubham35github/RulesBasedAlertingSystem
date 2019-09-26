using Microsoft.AspNetCore.Mvc;
using MonitorDataModelLib;
using RepositoryContractsLib;
using System.Collections.Generic;
using System.Linq;

namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    public class MonitorsController : ControllerBase
    {
        private IRepository<MonitoringDevice> _monitorsRepository = null;

        public MonitorsController(IRepository<MonitoringDevice> monitorsRepository)
        {
            _monitorsRepository = monitorsRepository;
        }

        [HttpGet]
        public IEnumerable<MonitoringDevice> GetMonitors()
        {
            return _monitorsRepository.List().Where(x => !x.IsAssigned);
        }

        [HttpGet("{monitorId}")]
        public MonitoringDevice GetMonitor(string monitorId)
        {
            return _monitorsRepository.GetById(monitorId);
        }

        [HttpPost]
        public void AddMonitor([FromBody] MonitoringDevice entity)
        {
            _monitorsRepository.Add(entity);
        }

        [HttpPut("{monitorId}")]
        public void UpdateMonitor(string monitorId, [FromBody] MonitoringDevice entity)
        {
            _monitorsRepository.Update(monitorId, entity);
        }

        [HttpDelete("{monitorId}")]
        public void DeleteMonitor(string monitorId)
        {
            _monitorsRepository.Delete(monitorId);
        }
    }
}
