using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Asp.Net.Mvc5.Models;
using Vidly_Asp.Net.Mvc5.ViewModels;

namespace Vidly_Asp.Net.Mvc5.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new Vidly_Asp.Net.Mvc5.ViewModels.NewCustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            return Content("");
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}