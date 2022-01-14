using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private static List<Location> LocationList = DataGenerator.LocationList;
        public LocationController()
        { }

        /************************************* GET *********************************************/

        //GET api/locations
        [HttpGet]
        public IActionResult GetLocations()
        {
            if (LocationList.Count == 0)
                return NotFound("There is not any record in the list!");

            return Ok(LocationList);
        }

        //Get only one record from list
        //GET api/locations/1
        [HttpGet("{id}")]
        public IActionResult LocationById(int id)
        {
            var location = new Location();
            location = LocationList.Where(b => b.locationId == id).SingleOrDefault();
            if (location == null)
                return NotFound("This location is not exists!");
            return Ok(location);
        }

        //Get all products belongs to specific rotation
        //GET api/products/list?rotationId=1
        [HttpGet("list")]
        public IActionResult GetProductsByRotation([FromQuery] int rotationId)
        {

            var locations = LocationList.Where(b => b.rotationId == rotationId).ToList();
            if (locations.Count == 0)
                return NotFound("There is no location belongs to this rotation!");

            return Ok(locations); //http 200
        }




        /************************************* POST *********************************************/



        //POST api/locations
        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location newLocation)
        {

            if (newLocation is null) //if the user not send any data, we will return bad request
                return BadRequest("No data entered!");

            var location = LocationList.SingleOrDefault(b => b.locationName == newLocation.locationName); //check if we already have that locationName in our list
            if (location is not null)
                return BadRequest("You already have this location in your list!");

            LocationList.Add(newLocation);
            return Created("~api/locations", newLocation); //http 201 
        }



        /************************************* PUT *********************************************/


        //Update all informations
        //PUT api/locations/id
        [HttpPut("{id}")]
        public IActionResult Update(Location newLocation)
        {

            if (newLocation is null)
                return BadRequest("No data entered!");

            var ourRecord = LocationList.SingleOrDefault(g => g.locationId == newLocation.locationId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.locationId = newLocation.locationId != default ? newLocation.locationId : ourRecord.locationId;
                ourRecord.locationName = newLocation.locationName != default ? newLocation.locationName : ourRecord.locationName;
                ourRecord.rotationId = newLocation.rotationId != default ? newLocation.rotationId : ourRecord.rotationId;
            }
            else
            {
                return NotFound("There is no record to update");
            }
            return Ok(LocationList); //http 200 

        }


        /************************************* DELETE *********************************************/

        //DELETE api/locations/id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var ourRecord = LocationList.SingleOrDefault(b => b.locationId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest("There is no record to delete!");

            LocationList.Remove(ourRecord);
            return NoContent(); //http 204 
        }



        /************************************* PATCH *********************************************/

        //udate rotationId information
        //PATCH api/locations/id
        [HttpPatch("{id}")]
        public IActionResult UpdateRotation(int id, int rotationId)
        {
            var ourRecord = LocationList.SingleOrDefault(u => u.locationId == id);
            if (ourRecord != null)
            {

                LocationList.SingleOrDefault(g => g.locationId == id).rotationId = rotationId;
               
            }
            else
            {
                return NotFound("There is no record to update");
            }
            return NoContent(); //http 204


        }
    }
}
