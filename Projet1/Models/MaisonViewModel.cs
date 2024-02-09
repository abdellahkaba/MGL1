using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class MaisonViewModel
    {
        [Key]
        public int IdBien { get; set; }
        [Display(Name = "Description du bien"), Required(ErrorMessage = "*"), MaxLength(1000, ErrorMessage = "La taille maximale est de 1000")]
        public string descriptionBien { get; set; }

        [Display(Name = "Superficie du bien")]

        public float? superficieBien { get; set; }

        [Display(Name = "Localité du bien")]
        public string lacaliteBien { get; set; }

        [Display(Name = "Nombre de Salle d'eau"), Required(ErrorMessage = "*")]
        public int nbrSalleEau { get; set; }

        [Display(Name = "Nombre de cuisine"), Required(ErrorMessage = "*")]
        public int nbrCuisine { get; set; }

        [Display(Name = "Nombre de toilette"), Required(ErrorMessage = "*")]
        public int nbrToilette { get; set; }

        public int? IdProprio { get; set; }

        [ForeignKey("IdProprio")]
        public virtual Proprietaire Proprietaire { get; set; }

        [Display(Name = "Nombre de chambre"), Required(ErrorMessage = "*")]
        public int nbrChambre { get; set; }

        // Propriété de navigation vers la classe Appartement
        public virtual List<Appartement> ListeAppartements { get; set; } = new List<Appartement>();

        //Propriété de la navigation vers la classe Appartement
        public virtual List<Studio> ListeStudios { get; set; } = new List<Studio>();

    }
} 