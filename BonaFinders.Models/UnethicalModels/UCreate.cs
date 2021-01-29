using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.UnethicalModels
{
    public class UCreate
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name of Organization")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Please use 50 or less characters in this field.")]
        public string UnethicalOrganizationName { get; set; }

        [Display(Name = "Is Fast Fashion")]
        public bool FastFashion { get; set; }

        [Display(Name = "Exploitation of Labour")]
        public bool Exploitation { get; set; }

        [Display(Name = "Sweatshop Labour/ Child Labour")]
        public bool Sweatshop { get; set; }

        [Display(Name = "Copyright Infringement/ Stolen Designs")]
        public bool Copyright { get; set; }

        [Display(Name = "Based In")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "Please use 30 or less characters in this field.")]
        public string UCountry { get; set; }

        [Display(Name = "Needs Improvement")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(300, ErrorMessage = "Please use 300 or less characters in this field.")]
        public string UImprove { get; set; }
    }
}
