using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.EthicalModels
{
    public class ECreate
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name of Organization")]    
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Please use 50 or less characters in this field.")]
        public string EthicalOrganizationName { get; set; }

        [Display(Name = "Cruelty Free/ Vegan")]
        public bool CrueltyFree { get; set; }

        [Display(Name = "Sustainable/ Eco-friendly")]
        public bool Sustainable { get; set; }

        [Display(Name = "Diverse/ Inclusive")]
        public bool Diverse { get; set; }

        [Display(Name = "Based In")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "Please use 30 or less characters in this field.")]
        public string ECountry { get; set; }

        [Display(Name = "Needs Improvement")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(300, ErrorMessage = "Please use 300 or less characters in this field.")]
        public string EImprove { get; set; }
    }
}
