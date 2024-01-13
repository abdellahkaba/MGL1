using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Appartement: Bien
    {
        [Display(Name = "Nombre de salle"), Required(ErrorMessage = "*")]
        public int nbrSalle { get; set; }

        // Clé étrangère vers la classe Maison
        public int? MaisonId { get; set; }

        // Propriété de navigation vers la classe Maison
        public virtual Maison Maison { get; set; }



    }
}