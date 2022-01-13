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
    public class UomController : ControllerBase
    {


        private static List<Uom> UomList = DataGenerator.UomList;
        public UomController()
        {
            
        }

        /************************************* GET *********************************************/

        //GET api/uoms
        [HttpGet]
        public List<Uom> GetUoms()
        {
            return UomList;
        }

        //GET api/uoms/1
        [HttpGet("{id}")]
        public Uom UomById(int id)
        {
            var uom = UomList.Where(b => b.uomId == id).SingleOrDefault();
            return uom;
        }




        //api/Uoms?id=3
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //      var uom = UomList.Where(b => b.uomId == Convert.ToInt32(id)).SingleOrDefault();
        //    return uom;
        //}


        /************************************* POST *********************************************/



        //POST api/uoms
        [HttpPost]
        public IActionResult CreateUom([FromBody] Uom newUom)
        {
            var uom = UomList.SingleOrDefault(b => b.uomCode == newUom.uomCode); //check if we already have that uomCode in our list
            if (uom is not null)
                return BadRequest();

            UomList.Add(newUom);
            return Ok(UomList); //http 200 
        }



        /************************************* PUT *********************************************/



        //PUT api/uoms/id
        [HttpPut("{id}")]
        public IActionResult Update(Uom newUom)
        {
            var ourRecord = UomList.SingleOrDefault(g => g.uomId == newUom.uomId);
            if (ourRecord != null)
            {
                //if the value is not default, it means user already tried to update it.
                //We can use input value. Otherwise, use recorded value and don't change it
                ourRecord.uomId = newUom.uomId != default ? newUom.uomId : ourRecord.uomId;
                ourRecord.uomCode = newUom.uomCode != default ? newUom.uomCode : ourRecord.uomCode;
                ourRecord.description = newUom.description != default ? newUom.description : ourRecord.description;
                return Ok(UomList); //http 200 
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
            var ourRecord = UomList.SingleOrDefault(b => b.uomId == id); //is it exist?
            if (ourRecord is null)
                return BadRequest();

            UomList.Remove(ourRecord);
            return Ok(UomList); //http 200 
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateDescription(int id, string description)
        {
            var ourRecord = UomList.SingleOrDefault(u => u.uomId == id);
            if (ourRecord != null)
            {

                UomList.SingleOrDefault(g => g.uomId == id).description = description;
                return Ok(UomList); //http 200 
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
