using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;
using Microsoft.AspNetCore.Http;
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
        public List<Location> GetLocations()
        {
            return LocationList;
        }

        //GET api/locations/1
        [HttpGet("{id}")]
        public Location LocationById(int id)
        {
            var location = LocationList.Where(b => b.locationId == id).SingleOrDefault();
            return location;
        }




        //api/Locations?id=3
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //      var location = LocationList.Where(b => b.locationId == Convert.ToInt32(id)).SingleOrDefault();
        //    return location;
        //}


        /************************************* POST *********************************************/



        //POST api/locations
        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location newLocation)
        {
            var location = LocationList.SingleOrDefault(b => b.locationName == newLocation.locationName); //check if we already have that locationName in our list
            if (location is not null)
                return BadRequest();

            LocationList.Add(newLocation);
            return Ok(LocationList); //http 200 
        }



        /************************************* PUT *********************************************/



        //PUT api/locations/id
        [HttpPut("{id}")]
        public IActionResult Update(Location newLocation)
        {
            var ourRecord = LocationList.SingleOrDefault(g => g.locationId == newLocation.locationId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.locationId = newLocation.locationId != default ? newLocation.locationId : ourRecord.locationId;
                ourRecord.locationName = newLocation.locationName != default ? newLocation.locationName : ourRecord.locationName;
                ourRecord.rotationId = newLocation.rotationId != default ? newLocation.rotationId : ourRecord.rotationId;
                return Ok(LocationList); //http 200 
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
            var ourRecord = LocationList.SingleOrDefault(b => b.locationId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest();

            LocationList.Remove(ourRecord);
            return Ok(LocationList); //http 200 
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateRotation(int id, int rotationId)
        {
            var ourRecord = LocationList.SingleOrDefault(u => u.locationId == id);
            if (ourRecord != null)
            {

                LocationList.SingleOrDefault(g => g.locationId == id).rotationId = rotationId;
                return Ok(LocationList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
