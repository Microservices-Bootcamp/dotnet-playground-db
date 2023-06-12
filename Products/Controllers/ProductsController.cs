﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Products.Configurations;
using Products.Controllers.Dtos;

namespace Products.Controllers
{


    [Controller]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IConfiguration _configuration;
        private SimTechConfigurations _simTechConfigurations;
        public ProductsController(IWebHostEnvironment environment, IConfiguration configuration, IOptions<SimTechConfigurations> options)
        {
            _environment = environment;
            _configuration = configuration;
            _simTechConfigurations = options.Value;
        }
        //List<string> products = new List<string> { "product A", "product B" };
        static List<Product> products = new List<Product> { new Product { Name = "Product A", Price = 100, Sku = "PA" } };

        [HttpGet]
        public IActionResult Get([FromHeader] string name)
        {
            Console.WriteLine("Env: " + _environment.EnvironmentName);
            if (_configuration["ProductsAPIAllowed"] == "False")
            {
                return Ok("Not Allowed");
            }
            if (_environment.IsDevelopment())
            {
                var product = products.Find(item => item.Name == name);

                if (product == null)
                    return BadRequest("products not found!");

                return Ok(product);
            }
            else
                return Ok("Not Allowed");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            Console.WriteLine(JsonSerializer.Serialize(HttpContext.Request.Headers)); 
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }
            

            product.Name = _simTechConfigurations.CompanyName;
            product.Sku = _simTechConfigurations.Size;
            products.Add(product);
            return Ok("Product Created!");
        }
    }
}

