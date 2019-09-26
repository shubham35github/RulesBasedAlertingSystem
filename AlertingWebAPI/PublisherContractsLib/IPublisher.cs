using SubscriberContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherContractsLib
{
    public interface IPublisher
    {
        void RegisterSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void NotifySubscribers();
    }
}
