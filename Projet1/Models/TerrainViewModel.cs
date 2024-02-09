using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class TerrainViewModel
    {
        [Key]
        public int IdBien { get; set; }
        [Display(Name = "Type Terrain"), Required(ErrorMessage = "*")]
        public string typeTerrain { get; set; }
        public string descriptionBien { get; set; }

        [Display(Name = "Superficie du bien")]

        public float? superficieBien { get; set; }

        [Display(Name = "Localité du bien")]
        public string lacaliteBien { get; set; }

        public int? IdProprio { get; set; }

        [ForeignKey("IdProprio")]
        public virtual Proprietaire Proprietaire { get; set; }


    }
}