using Microsoft.AspNetCore.Mvc;
using PierresVendors.Models;
using System.Collections.Generic;
using System;

namespace PierresVendors.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int id)
    {
      Order order = Order.Find(id);
      return View(order);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int orderID, int vendorID)
    {
      Vendor vendor = Vendor.Find(vendorID);
      Order order = Order.Find(orderID);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendor);
      model.Add("order", order);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Delete(int orderID)
    {
      List<Order> orders = Order.GetAll();
      int indexToDelete = orders.FindIndex(order => order.Id == orderID);
      orders.RemoveAt(indexToDelete);
      return RedirectToAction("Show", "Order");
    }
  }
}