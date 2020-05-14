using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new ProductRepository();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetALL();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public  void Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(prod);
            }
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Product prod)
        {
            prod.PoductId = id;
            if (ModelState.IsValid)
            {
                productRepository.Update(prod);
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          productRepository.Delete(id);
        }
    }
}