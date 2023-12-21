using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Studio
    {
        public int idBien { get; set; }


        [ForeignKey("Bien")]
        public int idKeyBien { get; set; }
    }
}