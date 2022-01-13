namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
    /*
    * locations are the places where containers can be located
    * rotationId defines the type of location to check rotation availability for containers
   */
    public class Location
    {
        public int locationId { get; set; }
        public string locationName { get; set; }
        public int rotationId { get; set; }
    }
}
