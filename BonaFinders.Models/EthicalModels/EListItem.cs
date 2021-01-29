using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.EthicalModels
{
    public class EListItem
    {
        public int EthicalOrganizationId { get; set; }
        public string Id { get; set; }

        [Display(Name = "Name of Organization")]
        public string EthicalOrganizationName { get; set; }

        [Display(Name = "Cruelty Free/ Vegan")]
        public bool CrueltyFree { get; set; }

        [Display(Name = "Sustainable/ Eco-friendly")]
        public bool Sustainable { get; set; }

        [Display(Name = "Diverse/ Inclusive")]
        public bool Diverse { get; set; }

        [Display(Name = "Based In")]
        public string ECountry { get; set; }

        [Display(Name = "Needs Improvement")]
        public string EImprove { get; set; }

        [Display(Name = "Review")]
        public virtual ICollection<EthicalReview> EthicalReviews { get; set; }
    }
}
