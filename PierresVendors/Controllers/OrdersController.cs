using Microsoft.AspNetCore.Mvc;
using PierresVendors.Models;
using System.Collections.Generic;
using System;

namespace PierresVendors.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/orders/{orderId}/albums/new")]
    public ActionResult New(int id)
    {
      Order order = Order.Find(id);
      return View(order);
    }

    [HttpGet("/orders/{orderId}/albums/{albumId}")]
    public ActionResult Show(int orderID, int albumID)
    {
      Album album = Album.Find(albumID);
      Order order = Order.Find(orderID);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("order", order);
      return View(model);
    }

    [HttpPost("/orders/{orderId}/albums/{albumId}")]
    public ActionResult Delete(int albumID)
    {
      List<Order> albums = Order.GetAll();
      int indexToDelete = albums.FindIndex(album => album.Id == albumID);
      albums.RemoveAt(indexToDelete);
      return RedirectToAction("Show", "Order");
    }
  }
}