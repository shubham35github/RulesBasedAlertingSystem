using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationControlLib.Models
{
    public class BedData
    {
        #region Property
        public string Model { get; set; }
        public bool IsAssigned { get; set; } = false;
        public string Id { get; set; }
        #endregion
    }
}
