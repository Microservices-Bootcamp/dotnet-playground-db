using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Products.Configurations;
using Products.Controllers.Dtos;
using Products.Database;

namespace Products.Controllers
{


    [Controller]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IConfiguration _configuration;
        private SimTechConfigurations _simTechConfigurations;
        private PlaygroundDb _db;

        public ProductsController(PlaygroundDb db, IWebHostEnvironment environment, IConfiguration configuration, IOptions<SimTechConfigurations> options)
        {
            _db = db;
            _environment = environment;
            _configuration = configuration;
            _simTechConfigurations = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            Console.WriteLine("Env: " + _environment.EnvironmentName);
            if (_configuration["ProductsAPIAllowed"] == "False")
            {
                return Ok("Not Allowed");
            }
            if (_environment.IsDevelopment())
            {
                if (string.IsNullOrEmpty(name))
                {
                    return Ok(_db.Products.ToList());
                }

                var product = await _db.Products.Where(item => item.Name == name).SingleOrDefaultAsync();

                if (product == null)
                    return BadRequest("products not found!");

                return Ok(product);
            }
            else
                return Ok("Not Allowed");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
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

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok("Product Created!");
        }
    }
}

