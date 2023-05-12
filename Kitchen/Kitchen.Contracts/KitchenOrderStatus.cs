using System.ComponentModel;

namespace Kitchen.Contracts;
public enum KitchenOrderStatus
{
    Default = 0,
    [Description("Processing")]
    Processing,
    [Description("Ready For Customer Pickup")]
    ReadyForCustomerPickup,
    [Description("Collected By Customer")]
    CollectedByCustomer,
    [Description("Ready For Collection By Agent")]
    ReadyForCollectionByAgent,
}
