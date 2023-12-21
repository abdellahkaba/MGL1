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

        [Display(Name = "Nombre de Salle"), Required(ErrorMessage = "*")]
        public int nbrSalleEau { get; set;}

        [Display(Name = "Nombre de cuisine"), Required(ErrorMessage = "*")]
        public int nbrCuisine { get; set; }

        [Display(Name = "Nombre de toilette"), Required(ErrorMessage = "*")]
        public int nbrToilette { get; set; }
    }
}