using AliGulmen.Week1.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Controllers
{
	[Route("api/[controller]s")]
	[ApiController]
	public class RotationController : ControllerBase
	{

		private static List<Rotation> RotationList = DataGenerator.RotationList;
		private static List<Location> LocationList = DataGenerator.LocationList;
		private static List<Product> ProductList = DataGenerator.ProductList;

		public RotationController()
		{ }

		/************************************* GET *********************************************/

		//Get all records
		//GET api/rotations
		[HttpGet]
		public IActionResult GetRotations()
		{
			if (RotationList.Count == 0)
				return NotFound("There is not any record in the list!");

			return Ok(RotationList);
		}


		//Get only one record from list
		//GET api/rotations/1
		[HttpGet("{id}")]
		public IActionResult GetRotationById(int id)
		{
			var rotation = new Rotation();
			rotation = RotationList.Where(b => b.rotationId == id).SingleOrDefault();
			if (rotation == null)
				return NotFound("This rotation is not exists!");
			return Ok(rotation);
		}


		//Get locations by rotation
		//GET api/rotations/1/Locations
		[HttpGet("{id}/Locations")]
		public IActionResult GetLocationsByRotation(int id)
		{
			var locations = LocationList.Where(b => b.rotationId == id).ToList();
			if (locations.Count == 0)
				return NotFound("There is no location defined with this rotation!");


			return Ok(locations);
		}


		//Get products by rotation
		//GET api/rotations/1/Products
		[HttpGet("{id}/Products")]
		public IActionResult GetProductsByRotation(int id)
		{
			var products = ProductList.Where(b => b.rotationId == id).ToList();
			if (products.Count == 0)
				return NotFound("There is no product defined with this rotation!");


			return Ok(products); //http 200
		}



		/************************************* POST *********************************************/



		//POST api/rotations
		[HttpPost]
		public IActionResult CreateRotation([FromBody] Rotation newRotation)
		{
			if (newRotation is null) //if the user not send any data, we will return bad request
				return BadRequest("No data entered!");


			//check if we already have this rotation in our list
			var rotation = RotationList.SingleOrDefault(b => b.rotationCode == newRotation.rotationCode); //check if we already have that rotationCode in our list

			
			if (rotation is not null)
				return BadRequest("You already have this rotation in your list!");

			RotationList.Add(newRotation);
			return Created("~api/rotations", newRotation); //http 201
		}



		/************************************* PUT *********************************************/


		//Update all informations
		//PUT api/rotations/id
		[HttpPut("{id}")]
		public IActionResult Update(Rotation newRotation)
		{

			if (newRotation is null)
				return BadRequest("No data entered!");

			var ourRecord = RotationList.SingleOrDefault(g => g.rotationId == newRotation.rotationId);
			if (ourRecord != null)
			{
				//if the value is not default, it means user already tried to update it.
				//We can use input value. Otherwise, use recorded value and don't change it
				ourRecord.rotationId = newRotation.rotationId != default ? newRotation.rotationId : ourRecord.rotationId;
				ourRecord.rotationCode = newRotation.rotationCode != default ? newRotation.rotationCode : ourRecord.rotationCode;
				
			}
			else
			{
				return NotFound("There is no record to update");
			}

			return Ok(RotationList); //http 200 
		}


		/************************************* DELETE *********************************************/

		//DELETE api/rotations/id
		[HttpDelete("{id}")]

		public IActionResult Delete(int id)
		{
			var ourRecord = RotationList.SingleOrDefault(b => b.rotationId == id); //is it exist?
			if (ourRecord is null)
				return BadRequest("There is no record to delete!");

			RotationList.Remove(ourRecord);
			return NoContent(); //http 204 
		}



		/************************************* PATCH *********************************************/

		//udate rotationCode information
		//PATCH api/rotations/id
		[HttpPatch("{id}")]
		public IActionResult UpdateCode(int id, string code)
		{
			var ourRecord = RotationList.SingleOrDefault(u => u.rotationId == id);
			if (ourRecord != null)
			{
				RotationList.SingleOrDefault(g => g.rotationId == id).rotationCode = code;
			}
			else
			{
				return NotFound("There is no record to update");
			}
			return NoContent(); //http 204

		}





	}
}
