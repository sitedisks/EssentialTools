using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;

        private Product[] products = { 
            new Product{Name="Kayak", Category="Watersports", Price=275M},
            new Product{Name="Lifejacket", Category="Watersports", Price=33m},
            new Product{Name="Soccer Ball", Category="Soccer", Price=19.50M},
            new Product{Name="Corner flag", Category="Soccer", Price=34.9M}
                                     };


        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            // DI: Dependency Injection 
            // Get rid of new keyword
            // IValueCalculator calc = new LinqValueCalculator();
            /*
            IKernel ninjectKernel = new StandardKernel(); // Use it as object
            // Tell Ninject that dependencies on IValueCalculator interface 
            // should be resoved by creating an instance of the LinqValueCalculator class
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // Use Ninject to create an object which do through the kernel Get method:
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            */

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
	}
}