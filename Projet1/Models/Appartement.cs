using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Appartement
    {
        public int idBien { get; set; }
        public int nbrchambre { get; set; }
        public int nbrdouche { get; set; }
        public int nbresallon { get; set; }

        [ForeignKey("Bien")]
        public int idKeyBien { get; set; }

    }
}