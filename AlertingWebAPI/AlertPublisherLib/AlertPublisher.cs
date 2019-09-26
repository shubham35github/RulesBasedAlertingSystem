using PublisherContractsLib;
using SubscriberContractsLib;
using System.Collections.Generic;

namespace AlertPublisherLib
{
    public class AlertPublisher : IPublisher
    {
        public List<ISubscriber> Subscribers { get; }
        private List<string> _anamolies;

        public AlertPublisher()
        {
            Subscribers = new List<ISubscriber>();
        }

        public void NotifySubscribers()
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update(_anamolies);
            }
        }

        public void RegisterSubscriber(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        public void SetAnamolies(List<string> anamolies)
        {
            _anamolies = anamolies;
            NotifySubscribers();
        }
    }
}
