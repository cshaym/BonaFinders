using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.EthicalReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Services
{
    public class EthicalReviewService
    {
        private readonly Guid _userId;
        public EthicalReviewService(Guid userId)
        {
            _userId = userId;
        }
        public EthicalReviewService() { }

        // Create Method
        public bool CreateEthicalReview(ERCreate model)
        {
            var entity =
                new EthicalReview()
                {
                    Id = _userId,
                    EthicalOrganizationId = model.EthicalOrganizationId,
                    EthicalReviewTitle = model.EthicalReviewTitle,
                    EthicalReviewText = model.EthicalReviewText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EthicalReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // For Dropdown
        public List<EthicalOrganization> GetEthicalOrganizationsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.EthicalOrganizations;
                return query.ToList();
            }
        }

        // Read All: Method
        public IEnumerable<ERListItem> GetEthicalReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .EthicalReviews
                        .Select(
                            e =>
                                new ERListItem
                                {
                                    OrganizationName = e.EthicalOrganization.EthicalOrganizationName,
                                    EthicalReviewTitle = e.EthicalReviewTitle,
                                    EthicalReviewText = e.EthicalReviewText
                                }
                        );

                return query.ToList();
            }
        }

        // Read Single: Get by id
        public ERDetail GetEthicalReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EthicalReviews
                        .Single(e => e.EthicalReviewId == id && e.Id == _userId);
                return
                    new ERDetail
                    {
                        EthicalReviewId = entity.EthicalReviewId,
                        EthicalOrganizationId = entity.EthicalOrganizationId,
                        EthicalReviewTitle = entity.EthicalReviewTitle,
                        EthicalReviewText = entity.EthicalReviewText
                    };
            }
        }
               

    }
}
