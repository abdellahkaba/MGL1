using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }

        [Display(Name = "Prénom"), Required(ErrorMessage = "*")]

        public string prenom { get; set; }

        [Display(Name = "Nom"), Required(ErrorMessage = "*")]

        public string nom { get; set; }

        [Display(Name = "Login"), Required(ErrorMessage = "*")]

        public string login { get; set; }

        [Display(Name = "Mot de pass"), Required(ErrorMessage = "*")]

        public string password { get;set; }
    }
}