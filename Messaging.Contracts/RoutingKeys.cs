using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts
{
    public static class RoutingKeys
    {
        public static string OrderUpdatePaid = "orders.update.paid";
        public static string OrdersUpdateWild = "orders.update.*";
        public static string OrderDetailsRequest = "orders.details.request";
        public static string OrderDetailsResponse = "orders.details.response";
    }
}
