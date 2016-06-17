using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>()
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return ProductsController.products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = ProductsController.products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult PostProduct(Product product)
        {
            ProductsController.products.Add(product);
            return Created(Url.Link("DefaultApi", new { id = product.Id }), product);
        }
    }
}
