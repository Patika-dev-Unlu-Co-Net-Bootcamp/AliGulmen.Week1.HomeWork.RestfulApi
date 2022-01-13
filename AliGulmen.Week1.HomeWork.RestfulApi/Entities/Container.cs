using System;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
    /*
     * Containers defines the products we have in our stock. 
     * A container information should includes; 
     * unit information (uomId)
     * quantity of unit (quantity)
     * product in container (productId)
     * where it is located (locationId)
     * weight information (weight)
     * and creationDate to calculate expiration date (expiration date = creationDate + lifeTime)
     */
    public class Container
    {
        public int containerId { get; set; }
        public int productId { get; set; }
        public int uomId { get; set; }
        public int quantity { get; set; }
        public int locationId { get; set; }
        public int weight { get; set; }
        public DateTime creationDate { get; set; }

    }
}
