using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int containerId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public int uomId { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public int locationId { get; set; }
        
        //weight is optional
        public int weight { get; set; }

        [Required]
        public DateTime creationDate { get; set; }

    }
}
