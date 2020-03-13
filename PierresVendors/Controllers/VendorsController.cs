using Microsoft.AspNetCore.Mvc;
using PierresVendors.Models;
using System.Collections.Generic;
using System;

namespace PierresVendors.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors/{vendorsId}/orders/new")]
    public ActionResult New(int id)
    {
      Vendor vendor = Vendor.Find(id);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorsId}/orders/{orderId}")]
    public ActionResult Show(int vendorID, int orderID)
    {
      Order order = Order.Find(orderID);
      Vendor vendor = Vendor.Find(vendorID);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    [HttpPost("/vendors/{vendorsId}/orders/{orderId}")]
    public ActionResult Delete(int orderID)
    {
      List<Order> orders = Order.GetAll();
      int indexToDelete = orders.FindIndex(order => order.Id == orderID);
      orders.RemoveAt(indexToDelete);
      return RedirectToAction("Show", "Vendor");
    }
  }
}