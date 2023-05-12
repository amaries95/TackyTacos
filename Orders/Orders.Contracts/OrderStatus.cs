using System.ComponentModel;

namespace Orders.Contracts;
public enum OrderStatus
{
    Default = 0,

    [Description("Received")]
    Received,

    [Description("Paid")]
    Paid,

    [Description("Processing")]
    Processing,

    [Description("Ready For Customer Pickup")]
    ReadyForCustomerPickup,

    [Description("Collected By Customer")]
    CollectedByCustomer,

    [Description("Ready For Collection By Agent")]
    ReadyForCollectionByAgent,

    [Description("Collected By Agent")]
    CollectedByAgent,

    [Description("Out For Delivery")]
    OutForDelivery,

    [Description("Delivered")]
    Delivered,

    [Description("Completed")]
    Completed,

    [Description("Cancelled")]
    Cancelled,

    [Description("Never Collected")]
    NeverCollected
}