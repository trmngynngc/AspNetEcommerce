﻿namespace Domain;

public class CartDetail
{
    public Guid CartId { get; set; }
    public Cart.Cart Cart { get; set; }

    public Guid ProductId { get; set; }
    public Product.Product Product{ get; set; }

    public int Quantity { get; set; }
}
