using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
	[Route("api/[controller]s")]
	[ApiController]
	public class UomController : ControllerBase
	{

		/************************************* GET *********************************************/

		//Get the list of uoms
		private static List<Uom> UomList = DataGenerator.UomList;

		public UomController()
		{

		}



		//Get all records
		//GET api/uoms
		[HttpGet]
		public IActionResult GetUoms()
		{
			if (UomList.Count == 0)
				return NotFound("There is not any record in the list!");
			return Ok(UomList);
		}



		//Get only one record from list
		//GET api/uoms/1
		[HttpGet("{id}")]
		public IActionResult GetUomById(int id)
		{
			var uom = new Uom();

			uom = UomList.Where(b => b.uomId == id).SingleOrDefault();
			if (uom == null)
				return NotFound("This uom is not exists!");
			return Ok(uom);
		}





		/************************************* POST *********************************************/


		//Create new uom
		//POST api/uoms
		[HttpPost]
		public IActionResult CreateUom([FromBody] Uom newUom)
		{
				if (newUom is null) //if the user not send any data, we will return bad request
				return BadRequest("No data entered!");

			
			//check if we already have this uomCode in our list
			var uom = UomList.SingleOrDefault(b => b.uomCode == newUom.uomCode);

		
			if (uom is not null)
				return BadRequest("You already have this uomCode in your list!");


			UomList.Add(newUom);
			return Created("~api/uoms", newUom); //http 201 
		}



		/************************************* PUT *********************************************/


		//Update all informations
		//PUT api/uoms/id
		[HttpPut("{id}")]
		public IActionResult Update(Uom newUom)
		{

			if (newUom is null)
				return BadRequest("No data entered!");

			var ourRecord = UomList.SingleOrDefault(g => g.uomId == newUom.uomId);


			if (ourRecord != null)
			{
				//if the value is not default, it means user already tried to update it.
				//We can use input value. Otherwise, use recorded value and don't change it
				ourRecord.uomId = newUom.uomId != default ? newUom.uomId : ourRecord.uomId;
				ourRecord.uomCode = newUom.uomCode != default ? newUom.uomCode : ourRecord.uomCode;
				ourRecord.description = newUom.description != default ? newUom.description : ourRecord.description;

			}
			else
			{
				return NotFound("There is no record to update");
			}

			return NoContent(); //http 204 

		}

		/************************************* DELETE *********************************************/



		//DELETE api/uoms/id
		[HttpDelete("{id}")]

		public IActionResult Delete(int id)
		{
			var ourRecord = UomList.SingleOrDefault(b => b.uomId == id); //is it exist?
			if (ourRecord is null)
				return BadRequest("There is no record to delete!");

			UomList.Remove(ourRecord);
			return NoContent(); //http 204
		}



		/************************************* PATCH *********************************************/


		//udate description information
		//PATCH api/uoms/id
		[HttpPatch("{id}")]
		public IActionResult UpdateDescription(int id, string description)
		{
			var ourRecord = UomList.SingleOrDefault(u => u.uomId == id);
			if (ourRecord != null)
			{
				UomList.SingleOrDefault(g => g.uomId == id).description = description;
			}
			else
			{
				return NotFound("There is no record to update");
			}

			return NoContent(); //http 204
		}
	}
}
