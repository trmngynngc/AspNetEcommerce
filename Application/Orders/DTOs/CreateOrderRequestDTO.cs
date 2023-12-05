﻿namespace Application.Orders;

public class CreateOrderRequestDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string? Note { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
}
