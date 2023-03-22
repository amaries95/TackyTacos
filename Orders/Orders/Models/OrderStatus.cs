namespace Orders.Models;
internal enum OrderStatus
{
    Received,
    Paid,
    Processing,
    ReadyForCustomerPickup,
    CollectedByCustomer,
    ReadyForCollectionByAgent,
    CollectedByAgent,
    OutForDelivery,
    Delivered,
    Completed,
    Cancelled
}
