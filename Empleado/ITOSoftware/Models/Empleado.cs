using System.ComponentModel.DataAnnotations;
using ITOSOFTWARE.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITOSOFTWARE.Models{
    public class Empleado{
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Id_Dependencia")]
        public int Dependencia { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
    }
}