using System;
using System.Collections.Generic;

namespace PierresVendors.Models
{
  public class Vendor
  {
    private static List<Vendor> _vendors = new List<Vendor>{};
    private static int _count = 0;
    public string Name {get;set;}

    public string Description {get;set;}
    public int Id {get;}
    public List<Order> Orders {get;set;}

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      _vendors.Add(this);
      Id = _count++;
      Orders = new List<Order>{};
    }

    public static List<Vendor> GetAll()
    {
      return _vendors;
    }

    public static void ClearAll()
    {
      _vendors.Clear();
    }

    public static Vendor Find(int id)
    {
      int index = _vendors.FindIndex(artist => artist.Id == id);
      return _vendors[index];
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }

}