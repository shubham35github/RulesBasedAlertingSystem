using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityContractsLib;
namespace ValidatorContractsLib
{
    public interface IValidate<T> where T : EntityBase
    {
        T VitalsData { get; set; }
        List<string> Validator();
    }
}
