using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
    /*
    * locations are the places where containers can be located
    * rotationId defines the type of location to check rotation availability for containers
   */
    public class Location
    {
        [Required]
        public int locationId { get; set; }

        [Required]
        public string locationName { get; set; }

        //rotationId is optional
        public int rotationId { get; set; }
    }
}
