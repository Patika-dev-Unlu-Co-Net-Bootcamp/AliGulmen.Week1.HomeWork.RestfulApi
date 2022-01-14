# Week 1

This homework includes a **REST API** for a simple warehouse system.

## Entities

There are 5 entities I used during the project. 
The short description ;
- **Uom** :
     * Unit of Measurement; a quantity used as a standard of measurement. 
     * In this project, UOM used to quantify the container items.
     * Box(BX), Carton(CTN), Piece(PC), Pack(PK)

- **Rotation** :
     * Measure the number of times inventory is sold or used in a time period.  
     * In this project, Rotation will be used to determine where containers should be placed in the warehouse.
     * Category A, Category B, Category C (CatA > Cat B > Cat C)
     * Cat A products should be placed easier places to reach which means Cat C products might be at the last position of warehouse

- **Location** :
     * Locations are the places where containers can be located
     * rotationId defines the type of location to check rotation availability for containers

- **Product** :
     *  The product shows the list of materials produced in the facility.
     * Every product has a rotation which defines the cycle of product.
	 * lifeTime might be used to check expiration date 
	 * isActive can be used to disable checking of that products

- **Containers** :
     * Containers defines the products we have in our stock. 
     * A container information should includes; 
     * unit information (uomId)
     * quantity of unit (quantity)
     * product in container (productId)
     * where it is located (locationId)
     * weight information (weight)
     * and creationDate to calculate expiration date (expiration date = creationDate + lifeTime)

## Data Generator
   - Database isn't used in this project.
   - So, I defined some accessible lists here. 
   - It will allow us to access different entities when we need in controllers. 

## Key Points

- Route Names are based on nouns and not verbs.
- Defined all necessary HTTP Methods for all entities (GET, POST, PUT, DELETE, PATCH)
- HTTP status codes returned as it describes [here](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design#get-methods)
- Required fields defined on Entities.
- Created Model Binding both FromBody and FromQuery

Some examples ;

- Listing some records
```c
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
```

- Defining required fields
```c
public class Product
	{
		[Required]
		public int productId { get; set; }

		[Required]
		public string productCode { get; set; }

		public string description { get; set; }
		public int rotationId { get; set; }

		[Required]
		public bool isActive { get; set; }

		public int lifeTime { get; set; }

	}
```
- Returning right http status codes
```c
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
```



## References 
[Microsoft RESTful web API design](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)

