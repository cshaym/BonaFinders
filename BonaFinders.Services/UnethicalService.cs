using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.UnethicalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Services
{
    public class UnethicalService
    {
        private readonly Guid _userId;
        public UnethicalService(Guid userId)
        {
            _userId = userId;
        }
        public UnethicalService() { }   //

        // Create Method
        public bool CreateUnethicalOrganization(UCreate model)
        {
            var entity =
                new UnethicalOrganization()
                {
                    Id = _userId,
                    UnethicalOrganizationName = model.UnethicalOrganizationName,
                    FastFashion = model.FastFashion,
                    Exploitation = model.Exploitation,
                    Sweatshop = model.Sweatshop,
                    Copyright = model.Copyright,
                    UCountry = model.UCountry,
                    UImprove = model.UImprove
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UnethicalOrganizations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read All: GetUnethicalOrganizations() Method
        public IEnumerable<UListItem> GetUnethicalOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UnethicalOrganizations
                        .Select(
                            e =>
                                new UListItem
                                {
                                    UnethicalOrganizationId = e.UnethicalOrganizationId,
                                    UnethicalOrganizationName = e.UnethicalOrganizationName,
                                    FastFashion = e.FastFashion,
                                    Exploitation = e.Exploitation,
                                    Sweatshop = e.Sweatshop,
                                    Copyright = e.Copyright,
                                    UCountry = e.UCountry,
                                    UImprove = e.UImprove
                                }
                        );

                return query.ToList();
            }
        }

        // Read Single: Get by id
        public UDetail GetUnethicalOrganizationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UnethicalOrganizations
                        .Single(e => e.UnethicalOrganizationId == id && e.Id == _userId);
                return
                    new UDetail
                    {
                        UnethicalOrganizationName = entity.UnethicalOrganizationName,
                        FastFashion = entity.FastFashion,
                        Exploitation = entity.Exploitation,
                        Sweatshop = entity.Sweatshop,
                        Copyright = entity.Copyright,
                        UCountry = entity.UCountry,
                        UImprove = entity.UImprove
                    };
            }
        }

        // Update
        public bool UpdateUnethicalOrganization(UEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UnethicalOrganizations
                        .Single(e => e.UnethicalOrganizationId == id && e.Id == _userId);

                entity.UnethicalOrganizationName = model.UnethicalOrganizationName;
                entity.FastFashion = model.FastFashion;
                entity.Exploitation = model.Exploitation;
                entity.Sweatshop = model.Sweatshop;
                entity.Copyright = model.Copyright;
                entity.UCountry = model.UCountry;
                entity.UImprove = model.UImprove;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteUnethicalOrganization(int unethicalOrganizationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UnethicalOrganizations
                        .Single(e => e.UnethicalOrganizationId == unethicalOrganizationId && e.Id == _userId);

                ctx.UnethicalOrganizations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }





    }
}
