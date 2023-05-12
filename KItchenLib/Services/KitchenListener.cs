using Kitchen.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Services;

internal class KitchenListener
{
    internal void OrderUpdated(KitchenOrderDto order)
    {
        Console.WriteLine($"Order: {order.Id} updated");
    }
}
