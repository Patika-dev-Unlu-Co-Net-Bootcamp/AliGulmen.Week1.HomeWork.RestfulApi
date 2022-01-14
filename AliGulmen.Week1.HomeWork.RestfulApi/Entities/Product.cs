using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
	/*
	 * The product shows the list of materials produced in the facility.
	 * Every product has a rotation which defines the cycle of product.
	 * lifeTime might be used to check expiration date 
	 * isActive can be used to disable checking of that products
	 */
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
}
