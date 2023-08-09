using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;
using Microsoft.AspNetCore.Http;
using SessionDemo.Services;
using SessionDemoApp.Helpers;

namespace SessionDemoApp.Controllers;

   public class ShoppingCartController : Controller
    {  
        private readonly IProductService _productService;
        
        public ShoppingCartController(IProductService productService ){        
            _productService=productService; 
        }
        public IActionResult Session(){  
            Cart theCart= SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            return View(theCart);
        }

        [HttpGet]
        public IActionResult  Add(int id){  
            Product theProduct=_productService.GetProductById(id);
            Item theItem=new Item();
            theItem.theProduct=theProduct;
            theItem.Quantity=0;
            return View(theItem);
        }  

        [HttpPost]
        public IActionResult Add(Item newItem){  

            var currentTime = DateTime.Now;
           // if (HttpContext.Session.Get<DateTime>(SessionKeyTime) == default)
            {
              //  HttpContext.Session.Set<DateTime>(SessionKeyTime, currentTime);
            }
            //Console.WriteLine("Current Time: {Time}", currentTime);
            //Console.WriteLine("Session Time: {Time}", HttpContext.Session.Get<DateTime>(currentTime));

            Cart theCart=null;

            theCart= SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            if(theCart ==null){
                theCart=new Cart();
            }
            theCart.Items.Add(newItem);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", theCart);
            return RedirectToAction("Session","shoppingcart");
        }  
        public IActionResult Remove(int  id){  
            Cart theCart= SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");  
            var found = theCart.Items.Find(x => x.theProduct.ID == id);
            if(found != null) theCart.Items.Remove(found);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", theCart);        
            return RedirectToAction("Session","ShoppingCart");
        }          
    }
