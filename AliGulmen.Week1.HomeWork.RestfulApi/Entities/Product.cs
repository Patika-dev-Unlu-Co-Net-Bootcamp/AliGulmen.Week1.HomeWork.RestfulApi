namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
    /*
	 * The product shows the list of materials produced at the facility.
	 * Every product has a rotation which defines the cycle of product.
	 * lifeTime might be used to check expiration date 
	 * isActive can be used to disable checking of that products
	 */
    public class Product
    {
		public int productId { get; set; }
		public string productCode { get; set; }
		public string prodDesc { get; set; }
		public int rotationId { get; set; }
		public int isActive { get; set; }
		public int lifeTime { get; set; }

	}
}
