using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts
{
    public interface IListener
    {
        public string RoutingKey { get; }

        Task ProcessMessage(string message, string routingkey);
    }
}
