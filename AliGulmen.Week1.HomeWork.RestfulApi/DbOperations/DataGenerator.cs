using AliGulmen.Week1.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;

namespace AliGulmen.Week1.HomeWork.RestfulApi.DbOperations
{

    /*
     * We are not going to use database in this example
     * So, we will define some accessible lists here.
     * It will allow us to access different entities' data as we do on dbs.
     */
    public class DataGenerator
    {


        /*
         * This list includes Uoms
         */
        public static List<Uom> UomList = new List<Uom>() {
            new Uom { uomId = 1, uomCode = "Pk", description = "Package" },
            new Uom { uomId = 2, uomCode = "Pc", description = "Piece" },
            new Uom { uomId = 3, uomCode = "Box", description = "Box" },
            new Uom { uomId = 4, uomCode = "Ctn", description = "Carton" }
           
        };




        /*
         * This list includes Rotations
         * Category A, Category B, Category C (CatA > Cat B > Cat C)
         */
        public static List<Rotation> RotationList = new List<Rotation>() {
            new Rotation { rotationId = 1, rotationCode = "Cat A"},
            new Rotation { rotationId = 2, rotationCode = "Cat B" },
            new Rotation { rotationId = 3, rotationCode = "Cat C" },
            new Rotation { rotationId = 4, rotationCode = "Cat D" }
        };



        /*This list includes Locations
         * locationName =  xxyyzz 
        * xx = side (left=01, right=02)
        * yy = vertical cell (floor)
        * zz = horizontal cell (slot) */

        public static List<Location> LocationList = new List<Location>() {
            new Location { locationId = 1, locationName = "010101", rotationId = 1 },
            new Location { locationId = 2, locationName = "010102", rotationId = 2 },
            new Location { locationId = 3, locationName = "010103", rotationId = 3 },
            new Location { locationId = 4, locationName = "010201", rotationId = 1 },
            new Location { locationId = 5, locationName = "010202", rotationId = 2 },
            new Location { locationId = 6, locationName = "010203", rotationId = 3 },
            new Location { locationId = 7, locationName = "020101", rotationId = 1 },
            new Location { locationId = 8, locationName = "020102", rotationId = 2 },
            new Location { locationId = 9, locationName = "020103", rotationId = 3 },
            new Location { locationId = 10, locationName = "020201", rotationId = 1 },
            new Location { locationId = 11, locationName = "020202", rotationId = 2 },
            new Location { locationId = 12, locationName = "020203", rotationId = 3 }
        };



         /*
          * This list includes Products
          */
        public static List<Product> ProductList = new List<Product>() {
            new Product { productId = 1, productCode = "87965493291", description = "Prod1",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 2, productCode = "87965493292", description = "Prod2",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 3, productCode = "87965493293", description = "Prod3",rotationId = 1,isActive =true ,lifeTime = 365 },
            new Product { productId = 4, productCode = "87965493294", description = "Prod4",rotationId = 2,isActive =true ,lifeTime = 365 },
            new Product { productId = 5, productCode = "87965493295", description = "Prod5",rotationId = 2,isActive =false ,lifeTime = 365 },
            new Product { productId = 6, productCode = "87965493296", description = "Prod6",rotationId = 2,isActive =true ,lifeTime = 365 },
            new Product { productId = 7, productCode = "87965493297", description = "Prod7",rotationId = 3,isActive =true ,lifeTime = 365 },
            new Product { productId = 8, productCode = "87965493298", description = "Prod8",rotationId = 4,isActive =true ,lifeTime = 365 }

        };



        /*
         * This list includes Containers
         */
        public static List<Container> ContainerList = new List<Container>() {
            new Container { containerId = 1, productId = 1, uomId = 1,quantity = 200,locationId =1 ,weight = 300, creationDate=DateTime.Today.AddDays(-100) },
            new Container { containerId = 2, productId = 1, uomId = 1,quantity = 100,locationId =5 ,weight = 250, creationDate=DateTime.Today.AddDays(-45) },
            new Container { containerId = 3, productId = 3, uomId = 2,quantity = 150,locationId =3 ,weight = 400, creationDate=DateTime.Today.AddDays(-15) },
            new Container { containerId = 4, productId = 4, uomId = 2,quantity = 150,locationId =6 ,weight = 300, creationDate=DateTime.Today.AddDays(-1) },
            new Container { containerId = 5, productId = 4, uomId = 2,quantity = 150,locationId =7 ,weight = 300, creationDate=DateTime.Today.AddDays(-97) },
            new Container { containerId = 6, productId = 6, uomId = 2,quantity = 240,locationId =8 ,weight = 240, creationDate=DateTime.Today.AddDays(-16) },
            new Container { containerId = 7, productId = 7, uomId = 2,quantity = 300,locationId =11 ,weight = 500, creationDate=DateTime.Today.AddDays(-16) },
            new Container { containerId = 8, productId = 8, uomId = 3,quantity = 140,locationId =9 ,weight = 250, creationDate=DateTime.Today.AddDays(-78) }

        };

    }
}
