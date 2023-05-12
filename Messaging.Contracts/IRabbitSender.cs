using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts
{
    public interface IRabbitSender
    {
        void PublishMessage<T>(T entity, string key) where T : class;
    }
}
