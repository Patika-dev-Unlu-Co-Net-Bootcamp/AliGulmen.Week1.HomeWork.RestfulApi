using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week1.HomeWork.RestfulApi.Entities
{
    /*
     * UOM : Unit of Measurement; a quantity used as a standard of measurement. 
     * In this project, UOM used to quantify the inventory items.
     * Box(BX), Carton(CTN), Piece(PC), Pack(PK),
    */
    public class Uom
    {
        [Required]
        public int uomId { get; set; }

        [Required]
        public string uomCode { get; set; }
        public string description { get; set; }
    }
}
