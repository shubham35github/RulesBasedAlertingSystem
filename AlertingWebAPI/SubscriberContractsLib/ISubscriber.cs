using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberContractsLib
{
    public interface ISubscriber
    {
        void Update(List<string> anamolies);
    }
}
