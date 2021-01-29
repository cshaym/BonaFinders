using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.EthicalReviewModels
{
    public class ERDetail
    {
        public int EthicalReviewId { get; set; }

        public string Id { get; set; }

        public int EthicalOrganizationId { get; set; }

        [Display(Name = "Title")]
        public string EthicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        public string EthicalReviewText { get; set; }
    }
}
