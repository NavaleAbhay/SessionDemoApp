using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;
using SessionDemo.Services;

namespace SessionDemo.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        this._productService=productService;
    }

    public IActionResult Index()
    {
        ViewData["allProducts"]=_productService.GetAllProducts();
        return View();
    }
}
    