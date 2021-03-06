﻿
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Core.Metadata.Edm;
using AutoMapper;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
       private ApplicationDbContext _context;

        public CustomersController()
        {
          _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
         _context.Dispose();
        }
       public ViewResult Index()
        {
         // var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View();
        }

        public ActionResult Details(int id)
        {
 var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

           if (customer == null)
                return HttpNotFound();
            
            return View(customer);
        }
        public ActionResult New()//customerForm
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)//model Binding//save
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New",viewmodel);
            }
            if (customer.Id == 0) 
            _context.Customers.Add(customer);
            else
            {
                  var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb); Save on the basis of key value pair
               // Mapper.Map(customer, customerInDb);
                 customerInDb.Name = customer.Name;
                 customerInDb.DOB = customer.DOB;
                 customerInDb.MembershipTypeId = customer.MembershipTypeId;
                 customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
            }
          _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewmodel);//overriding views
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}