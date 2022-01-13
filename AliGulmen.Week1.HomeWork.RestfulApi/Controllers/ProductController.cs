using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase

      
    {
        private static List<Product> ProductList = new List<Product>() {
            new Product { productId = 1, productCode = "87965493291", description = "Prod1",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 2, productCode = "87965493292", description = "Prod2",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 3, productCode = "87965493293", description = "Prod3",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 4, productCode = "87965493294", description = "Prod4",rotationId = 2,isActive =true ,lifeTime = 365 },
            new Product { productId = 5, productCode = "87965493295", description = "Prod5",rotationId = 2,isActive =false ,lifeTime = 365 },
            new Product { productId = 6, productCode = "87965493296", description = "Prod6",rotationId = 2,isActive =true ,lifeTime = 365 },
            new Product { productId = 7, productCode = "87965493297", description = "Prod7",rotationId = 3,isActive =true ,lifeTime = 365 },
            new Product { productId = 8, productCode = "87965493298", description = "Prod8",rotationId = 4,isActive =true ,lifeTime = 365 }
           
        };


        public ProductController()
        { }

        /************************************* GET *********************************************/

        //GET api/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            return ProductList;
        }

        //GET api/products/1
        [HttpGet("{id}")]
        public Product ProductById(int id)
        {
            var product = ProductList.Where(b => b.productId == id).SingleOrDefault();
            return product;
        }




        //api/Products?id=3
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //      var product = ProductList.Where(b => b.productId == Convert.ToInt32(id)).SingleOrDefault();
        //    return product;
        //}


        /************************************* POST *********************************************/



        //POST api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            var product = ProductList.SingleOrDefault(b => b.productCode == newProduct.productCode); //check if we already have that productCode in our list
            if (product is not null)
                return BadRequest();

            ProductList.Add(newProduct);
            return Ok(ProductList); //http 200 
        }



        /************************************* PUT *********************************************/



        //PUT api/products/id
        [HttpPut("{id}")]
        public IActionResult Update(Product newProduct)
        {
            var ourRecord = ProductList.SingleOrDefault(g => g.productId == newProduct.productId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.productId = newProduct.productId != default ? newProduct.productId : ourRecord.productId;
                ourRecord.productCode = newProduct.productCode != default ? newProduct.productCode : ourRecord.productCode;
                ourRecord.description = newProduct.description != default ? newProduct.description : ourRecord.description;
                ourRecord.rotationId = newProduct.rotationId != default ? newProduct.rotationId : ourRecord.rotationId;
                ourRecord.isActive = newProduct.isActive != default ? newProduct.isActive : ourRecord.isActive;
                ourRecord.lifeTime = newProduct.lifeTime != default ? newProduct.lifeTime : ourRecord.lifeTime;
                return Ok(ProductList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }


        /************************************* DELETE *********************************************/


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var ourRecord = ProductList.SingleOrDefault(b => b.productId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest();

            ProductList.Remove(ourRecord);
            return Ok(ProductList); //http 200 
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateAvailability(int id, bool isActive)
        {
            var ourRecord = ProductList.SingleOrDefault(u => u.productId == id);
            if (ourRecord != null)
            {

                ProductList.SingleOrDefault(g => g.productId == id).isActive = isActive;
                return Ok(ProductList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
