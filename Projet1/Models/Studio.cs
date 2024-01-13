using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Studio: Bien
    {
        [Display(Name = "Nombre de Pièce"), Required(ErrorMessage = "*")]
        public int nbrPiece { get; set; }

        // Clé étrangère vers la classe Maison
        public int? MaisonId { get; set; }

        // Propriété de navigation vers la classe Maison
        public virtual Maison Maison { get; set; }
    }
}