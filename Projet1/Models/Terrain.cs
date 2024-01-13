using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Terrain: Bien
    {
        [Display(Name = "Type Terrain"), Required(ErrorMessage = "*")]
        public string typeTerrain { get; set; }
    }
}