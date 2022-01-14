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
        public IActionResult GetContainers()
        {
            if (ContainerList.Count == 0)
                return NotFound("There is not any record in the list!");

            return Ok(ContainerList);
        }

        //GET api/containers/1
        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var container = ContainerList.Where(b => b.containerId == id).SingleOrDefault();
            if (container == null)
                return NotFound("This container is not exists!");
            return Ok(container);
        }


        //Get all containers by max weight ordered by weight
        //GET api/products/list?maxWeight=100
        [HttpGet("list")]
        public IActionResult GetContainersByMaxWeight([FromQuery] int maxWeight)
        {

            var containers = ContainerList
                                    .Where(b => b.weight <= maxWeight)
                                    .OrderBy(b => b.weight)
                                    .ToList();
            if (containers.Count == 0)
                return NotFound("There is no container lighter than the value entered!");

            return Ok(containers); //http 200
        }




        /************************************* POST *********************************************/



        //POST api/containers
        [HttpPost]
        public IActionResult CreateContainer([FromBody] Container newContainer)
        {
            if (newContainer is null) //if the user not send any data, we will return bad request
                return BadRequest("No data entered!");


            var container = ContainerList.SingleOrDefault(b => b.productId == newContainer.productId); //check if we already have that productId in our list
            if (container is not null)
                return BadRequest("You already have this container in your list!");

            ContainerList.Add(newContainer);
            return Created("~api/containers", newContainer); //http 201 
        }



        /************************************* PUT *********************************************/


        //Update all informations
        //PUT api/containers/id
        [HttpPut("{id}")]
        public IActionResult Update(Container newContainer)
        {
            if (newContainer is null)
                return BadRequest("No data entered!");

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
               
            }
            else
            {
                return NotFound("There is no record to update");
            }
            return Ok(ContainerList); //http 200 

        }


        /************************************* DELETE *********************************************/

        //DELETE api/rotations/id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var ourRecord = ContainerList.SingleOrDefault(b => b.containerId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest("There is no record to delete!");

            ContainerList.Remove(ourRecord);
            return NoContent(); //http 204
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateAvailability(int id, int locationId)
        {
            var ourRecord = ContainerList.SingleOrDefault(u => u.containerId == id);
            if (ourRecord != null)
            {

                ContainerList.SingleOrDefault(g => g.containerId == id).locationId = locationId;
            }
            else
            {
                return NotFound("There is no record to update");
            }
            return NoContent(); //http 204


        }
    }
}
