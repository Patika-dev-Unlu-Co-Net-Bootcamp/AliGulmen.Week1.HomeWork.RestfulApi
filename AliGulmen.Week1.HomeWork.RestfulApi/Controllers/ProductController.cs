using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase

      
    {
        private static List<Product> ProductList = DataGenerator.ProductList;
        private static List<Container> ContainerList = DataGenerator.ContainerList;

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
        public Product GetProductById(int id)
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




        /************************************* Linked Tables ********************************************/
        
        //GET api/products/1/Containers
        [HttpGet("{id}/Containers")]
        public List<Container> GetContainersByProduct(int id)
        {
            List<Container> containers = ContainerList.Where(b => b.productId == id).ToList();
            return containers;
        }


    }
}
