using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase

    {


        private static List<Container> ContainerList = DataGenerator.ContainerList;


        public ContainerController()
        {
           
        }

        /************************************* GET *********************************************/

        //GET api/containers
        [HttpGet]
        public List<Container> GetContainers()
        {
            return ContainerList;
        }

        //GET api/containers/1
        [HttpGet("{id}")]
        public Container ContainerById(int id)
        {
            var container = ContainerList.Where(b => b.containerId == id).SingleOrDefault();
            return container;
        }




        //api/Containers?id=3
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //      var container = ContainerList.Where(b => b.containerId == Convert.ToInt32(id)).SingleOrDefault();
        //    return container;
        //}


        /************************************* POST *********************************************/



        //POST api/containers
        [HttpPost]
        public IActionResult CreateContainer([FromBody] Container newContainer)
        {
            var container = ContainerList.SingleOrDefault(b => b.productId == newContainer.productId); //check if we already have that productId in our list
            if (container is not null)
                return BadRequest();

            ContainerList.Add(newContainer);
            return Ok(ContainerList); //http 200 
        }



        /************************************* PUT *********************************************/



        //PUT api/containers/id
        [HttpPut("{id}")]
        public IActionResult Update(Container newContainer)
        {
            var ourRecord = ContainerList.SingleOrDefault(g => g.containerId == newContainer.containerId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.containerId = newContainer.containerId != default ? newContainer.containerId : ourRecord.containerId;
                ourRecord.productId = newContainer.productId != default ? newContainer.productId : ourRecord.productId;
                ourRecord.uomId = newContainer.uomId != default ? newContainer.uomId : ourRecord.uomId;
                ourRecord.quantity = newContainer.quantity != default ? newContainer.quantity : ourRecord.quantity;
                ourRecord.locationId = newContainer.locationId != default ? newContainer.locationId : ourRecord.locationId;
                ourRecord.weight = newContainer.weight != default ? newContainer.weight : ourRecord.weight;
                ourRecord.creationDate = newContainer.creationDate != default ? newContainer.creationDate : ourRecord.creationDate;
                return Ok(ContainerList); //http 200 
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
            var ourRecord = ContainerList.SingleOrDefault(b => b.containerId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest();

            ContainerList.Remove(ourRecord);
            return Ok(ContainerList); //http 200 
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateAvailability(int id, int locationId)
        {
            var ourRecord = ContainerList.SingleOrDefault(u => u.containerId == id);
            if (ourRecord != null)
            {

                ContainerList.SingleOrDefault(g => g.containerId == id).locationId = locationId;
                return Ok(ContainerList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
