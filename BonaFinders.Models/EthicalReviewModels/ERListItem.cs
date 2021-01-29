using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.EthicalReviewModels
{
    public class ERListItem
    {
        public int EthicalReviewId { get; set; }

        public string Id { get; set; }

        // This name doesnt need to match the EthicalOrganizationName in order to represent it
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Display(Name = "Title")]
        public string EthicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        public string EthicalReviewText { get; set; }
    }
}
