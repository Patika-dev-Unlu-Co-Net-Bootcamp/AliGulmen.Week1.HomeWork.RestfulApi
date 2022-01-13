using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class RotationController : ControllerBase
    {
        private static List<Rotation> RotationList = new List<Rotation>() {
            new Rotation { rotationId = 1, rotationCode = "Cat A"},
            new Rotation { rotationId = 2, rotationCode = "Cat B" },
            new Rotation { rotationId = 3, rotationCode = "Cat C" },
            new Rotation { rotationId = 4, rotationCode = "Cat D" }
        };


        public RotationController()
        { }

        /************************************* GET *********************************************/

        //GET api/rotations
        [HttpGet]
        public List<Rotation> GetRotations()
        {
            return RotationList;
        }

        //GET api/rotations/1
        [HttpGet("{id}")]
        public Rotation RotationById(int id)
        {
            var rotation = RotationList.Where(b => b.rotationId == id).SingleOrDefault();
            return rotation;
        }




        //api/Rotations?id=3
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //      var rotation = RotationList.Where(b => b.rotationId == Convert.ToInt32(id)).SingleOrDefault();
        //    return rotation;
        //}


        /************************************* POST *********************************************/



        //POST api/rotations
        [HttpPost]
        public IActionResult CreateRotation([FromBody] Rotation newRotation)
        {
            var rotation = RotationList.SingleOrDefault(b => b.rotationCode == newRotation.rotationCode); //check if we already have that rotationCode in our list
            if (rotation is not null)
                return BadRequest();

            RotationList.Add(newRotation);
            return Ok(RotationList); //http 200 
        }



        /************************************* PUT *********************************************/



        //PUT api/rotations/id
        [HttpPut("{id}")]
        public IActionResult Update(Rotation newRotation)
        {
            var ourRecord = RotationList.SingleOrDefault(g => g.rotationId == newRotation.rotationId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.rotationId = newRotation.rotationId != default ? newRotation.rotationId : ourRecord.rotationId;
                ourRecord.rotationCode = newRotation.rotationCode != default ? newRotation.rotationCode : ourRecord.rotationCode;
                return Ok(RotationList); //http 200 
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
            var ourRecord = RotationList.SingleOrDefault(b => b.rotationId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest();

            RotationList.Remove(ourRecord);
            return Ok(RotationList); //http 200 
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateCode(int id, string code)
        {
            var ourRecord = RotationList.SingleOrDefault(u => u.rotationId == id);
            if (ourRecord != null)
            {

                RotationList.SingleOrDefault(g => g.rotationId == id).rotationCode = code;
                return Ok(RotationList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
