using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Proprietaire: User
    {
        [Key]
        public int IdProprio { get; set; }

        [Display(Name = "Nom du propriétaire"), Required(ErrorMessage = "*"), MaxLength(255)]
        public string nomProprio { get; set; }

        [Display(Name = "Contact du propriétaire"), Required(ErrorMessage ="*")]
        public string contactProprio { get; set; }

        public virtual ICollection<Bien> propriete { get; set; } 


    }
}