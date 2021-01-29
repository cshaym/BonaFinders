using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.UnethicalReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Services
{
    public class UnethicalReviewService
    {
        private readonly Guid _userId;
        public UnethicalReviewService(Guid userId)
        {
            _userId = userId;
        }
        public UnethicalReviewService() { }

        // Create Method
        public bool CreateUnethicalReview(URCreate model)
        {
            var entity =
                new UnethicalReview()
                {
                    Id = _userId,
                    UnethicalOrganizationId = model.UnethicalOrganizationId,
                    UnethicalReviewTitle = model.UnethicalReviewTitle,
                    UnethicalReviewText = model.UnethicalReviewText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UnethicalReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        // For Dropdown
        public List<UnethicalOrganization> GetUnethicalOrganizationsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.UnethicalOrganizations;
                return query.ToList();
            }
        }

        // Read All: Method
        public IEnumerable<URListItem> GetUnethicalReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UnethicalReviews
                        .Select(
                            e =>
                                new URListItem
                                {
                                    OrganizationName = e.UnethicalOrganization.UnethicalOrganizationName, // Great example (w/ models like UListItem)
                                    UnethicalReviewTitle = e.UnethicalReviewTitle,
                                    UnethicalReviewText = e.UnethicalReviewText
                                }
                        );

                return query.ToList();
            }
        }

        // Read Single: Get by id
        public URDetail GetUnethicalReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UnethicalReviews
                        .Single(e => e.UnethicalReviewId == id && e.Id == _userId);
                return
                    new URDetail
                    {
                        UnethicalReviewId = entity.UnethicalReviewId,
                        UnethicalOrganizationId = entity.UnethicalOrganizationId,
                        UnethicalReviewTitle = entity.UnethicalReviewTitle,
                        UnethicalReviewText = entity.UnethicalReviewText
                    };
            }
        }

        
    }
}
