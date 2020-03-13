using Microsoft.AspNetCore.Mvc;
using PierresVendors.Models;
using System.Collections.Generic;
using System;

namespace PierresVendors.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int orderID, int vendorID)
    {
      Vendor vendor = Vendor.Find(vendorID);
      Order order = Order.Find(orderID);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendor);
      model.Add("orders", order);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Delete(int orderID, int vendorID)
    {
      List<Vendor> vendors = Vendor.GetAll();
      int vendorIndexToDelet = vendors[vendorID].Orders.FindIndex(order => order.Id == orderID);
      List<Order> orders = Order.GetAll();
      int orderIndexToDelete = orders.FindIndex(order => order.Id == orderID);
      vendors[vendorID].Orders.RemoveAt(vendorIndexToDelet);
      orders.RemoveAt(orderIndexToDelete);
      return RedirectToAction($"Show({vendorID})", "Vendors");
    }
  }
}