﻿namespace BlazorWebShop.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}
