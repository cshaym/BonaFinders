using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.EthicalReviewModels
{
    public class ERCreate
    {
        public int EthicalReviewId { get; set; }

        public string Id { get; set; }

        [ForeignKey(nameof(EthicalOrganization))] 
        public int EthicalOrganizationId { get; set; }
        public virtual EthicalOrganization EthicalOrganization { get; set; }

        // Do not need [Required] in models
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Please use 50 or less characters in this field.")]
        [Display(Name = "Title")]
        public string EthicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(5000, ErrorMessage = "Please use 5000 or less characters in this field.")]
        public string EthicalReviewText { get; set; }
    }
}
