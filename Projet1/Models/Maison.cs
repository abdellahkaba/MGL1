using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Maison: Bien
    {
        [Display(Name = "Nombre de chambre"), Required(ErrorMessage = "*")] 
        public int nbrChambre { get; set; }

        // Propriété de navigation vers la classe Appartement
        public virtual List<Appartement> ListeAppartements { get; set; } = new List<Appartement>();

        //Propriété de la navigation vers la classe Appartement
        public virtual List<Studio> ListeStudios { get; set; } = new List<Studio>();

    }
}