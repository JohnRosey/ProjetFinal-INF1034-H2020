﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Biblio.Models
{
   

    public class Livres 
    {
        public string Langue { get; set; }
        public string ISBN { get; set; }

        [Key]
        public int BookId { get; set; }

        [Required,StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Categorie { get; set; }
        [Required]
        
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
       ErrorMessage = "Author should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Auteur")]
        public string Author { get; set; }
       
        

        [Column("Year")]
        [Display(Name = "Date de publication")]
        [DataType(DataType.Date)]
        public DateTime publishYear
        { get; set; }

        public string Picture { get; set; }
    }
}

