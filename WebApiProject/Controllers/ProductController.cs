﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [ApiController]
    //[Route("[controller]s")] //También se puede así
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Products.Single(p=>p.Id.Equals(id));
        }
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = Products.Count + 1;
            Products.Add(model);
            return CreatedAtAction(
                "Get",new { id = model.Id },
                model
                );
        }

        public static List<Product> Products = new List<Product>{
            new Product
            {
                Id = 1,
                Name = "Guitarra eléctrica",
                Price = 1200,
                Description = "Idel para tocar jazz, blues, rock clásico y afines."
            },
            new Product
            {
                Id=2,
                Name = "Amplificador para guitarra eléctrica",
                Description = "Excelente amplificador con un sonido cálido"
            }
            };
    }
}
