namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{

    /*
     * Rotation : Measure of the number of times inventory is sold or used in a time period such as a year.  
     * In this project, Rotation will be used to determine where containers should be placed in the warehouse.
     * Category A, Category B, Category C (CatA > Cat B > Cat C)
     * Cat A products should be placed easier places to reach which means Cat C products might be at the last point of warehouse
    */
    public class Rotation
    {
        public int rotationId { get; set; }
        public string rotationCode { get; set; }
    }
}
