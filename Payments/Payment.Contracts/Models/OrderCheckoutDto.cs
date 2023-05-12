namespace Payments.Contracts.Models;

public class OrderCheckoutDto
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
    //user info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    //payment information
    public string CardNumber { get; set; }
    public string CardName { get; set; }
    public string CardExpiration { get; set; }
    public string CvvCode { get; set; }
}