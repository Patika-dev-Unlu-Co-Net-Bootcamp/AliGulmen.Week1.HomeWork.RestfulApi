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

        //Get all records
        //GET api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            if (ProductList.Count == 0)
                return NotFound("There is not any record in the list!");
            return Ok(ProductList);
        }



        //GET api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = new Product();
            product = ProductList.Where(b => b.productId == id).SingleOrDefault();
            if (product == null)
                return NotFound("This product is not exists!");
            return Ok(product);
        }

        //Get all containers for selected product
        //GET api/products/1/Containers
        [HttpGet("{id}/Containers")]
        public IActionResult GetContainersByProduct(int id)
        {
            var containers = ContainerList
                                        .Where(b => b.productId == id)
                                        .OrderBy(b => b.containerId)
                                        .ToList();
            if (containers == null)
                return NotFound("There is no container belongs to this product!");
            return Ok(containers); //http 200
        }


        //Get all products belongs to specific rotation
        //GET api/products/list?rotationId=1
        [HttpGet("list")]
        public IActionResult GetProductsByRotation([FromQuery] int rotationId)
        {

            var products = ProductList.Where(b => b.rotationId == rotationId).ToList();
            if (products.Count == 0)
                return NotFound("There is no product belongs to this rotation!");

            return Ok(products); //http 200
        }


        /************************************* POST *********************************************/



        //POST api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            if (newProduct is null) //if the user not send any data, we will return bad request
                return BadRequest("No data entered!");

            //check if we already have this product in our list
            var product = ProductList.SingleOrDefault(b => b.productCode == newProduct.productCode); //check if we already have that productCode in our list

            if (product is not null)
                return BadRequest("You already have this product in your list!");

            ProductList.Add(newProduct);
            return Created("~api/products", newProduct); //http 201
        }



        /************************************* PUT *********************************************/


        //Update all informations
        //PUT api/products/id
        [HttpPut("{id}")]
        public IActionResult Update(Product newProduct)
        {

            if (newProduct is null)
                return BadRequest("No data entered!");


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
            }
            else
            {
                return NotFound("There is no record to update");
            }

            return Ok(ProductList); //http 200 
        }


        /************************************* DELETE *********************************************/


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var ourRecord = ProductList.SingleOrDefault(b => b.productId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest("There is no record to delete!");

            ProductList.Remove(ourRecord);
            return NoContent(); //http 204 
        }



        /************************************* PATCH *********************************************/

        //udate rotationCode information
        //PATCH api/products/id
        [HttpPatch("{id}")]
        public IActionResult UpdateAvailability(int id, bool isActive)
        {
            var ourRecord = ProductList.SingleOrDefault(u => u.productId == id);
            if (ourRecord != null)
            {

                ProductList.SingleOrDefault(g => g.productId == id).isActive = isActive;
            }
            else
            {
                return NotFound("There is no record to update");
            }
            return NoContent(); //http 204

        }






    }
}
