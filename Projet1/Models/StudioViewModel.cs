using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class StudioViewModel
    {
        [Key] 
        public int IdBien { get; set; }
        [Display(Name = "Description du bien"), Required(ErrorMessage = "*"), MaxLength(1000, ErrorMessage = "La taille maximale est de 1000")]
        public string descriptionBien { get; set; }

        [Display(Name = "Localité du bien")]
        public string lacaliteBien { get; set; }

        [Display(Name = "Nombre de Pièce"), Required(ErrorMessage = "*")]
        public int nbrPiece { get; set; }

        // Clé étrangère vers la classe Maison
        public int? MaisonId { get; set; }

        // Propriété de navigation vers la classe Maison
        public virtual Maison Maison { get; set; }

        public int? IdProprio { get; set; }

        [ForeignKey("IdProprio")]
        public virtual Proprietaire Proprietaire { get; set; }

    }
}