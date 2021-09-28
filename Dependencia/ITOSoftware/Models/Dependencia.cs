using System.ComponentModel.DataAnnotations;
using ITOSOFTWARE.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITOSOFTWARE.Models{
    public class Dependencia{
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
    }
}