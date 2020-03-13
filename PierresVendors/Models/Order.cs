using System;
using System.Collections.Generic;

namespace PierresVendors.Models
{
  public class Order
  {
    public string Title {get;set;}
    public string Description {get;set;}
    public int Price {get;set;}
    public string Day {get;set;}
    public string Reoccurring {get;set;}
    public int Id {get;}
    private static int _count = 0;

    private static List<Order> _orders = new List<Order> {};

    public Order(string title, string description, int price, string day, string reoccurring)
    {
      Title = title;
      Description = description;
      Price = price;
      Day = day;
      Reoccurring = reoccurring;
      _orders.Add(this);
      Id = _count;
      _count++;
    }

    public static List<Order> GetAll()
    {
      return _orders;
    }
    
    public static Order Find(int id)
    {
      int index = _orders.FindIndex(order => order.Id == id);
      return _orders[index];
    }
  }
}