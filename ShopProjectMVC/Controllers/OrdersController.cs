using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;

namespace ShopProjectMVC.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("user") == null)
        {
            return RedirectToAction("Login", "User");
        }
        var orders = _orderService.GetOrders(1).ToList();
        return View(orders);
    }
}
