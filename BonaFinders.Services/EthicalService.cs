using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.EthicalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Services
{
    public class EthicalService
    {
        private readonly Guid _userId;
        public EthicalService(Guid userId)
        {
            _userId = userId;
        }
        public EthicalService() { }

        // Create Method
        public bool CreateEthicalOrganization(ECreate model)
        {
            var entity =
                new EthicalOrganization()
                {
                    Id = _userId,
                    EthicalOrganizationName = model.EthicalOrganizationName,
                    CrueltyFree = model.CrueltyFree,
                    Sustainable = model.Sustainable,
                    Diverse = model.Diverse,
                    ECountry = model.ECountry,
                    EImprove = model.EImprove
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EthicalOrganizations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read All: GetEthicalOrganizations() Method
        public IEnumerable<EListItem> GetEthicalOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .EthicalOrganizations
                        .Select(
                            e =>
                                new EListItem
                                {
                                    EthicalOrganizationId = e.EthicalOrganizationId,
                                    EthicalOrganizationName = e.EthicalOrganizationName,
                                    CrueltyFree = e.CrueltyFree,
                                    Sustainable = e.Sustainable,
                                    Diverse = e.Diverse,
                                    ECountry = e.ECountry,
                                    EImprove = e.EImprove
                                }
                        );

                return query.ToList();
            }
        }

        // Read Single: Get by id
        public EDetail GetEthicalOrganizationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EthicalOrganizations
                        .Single(e => e.EthicalOrganizationId == id && e.Id == _userId);
                return
                    new EDetail
                    {
                        EthicalOrganizationName = entity.EthicalOrganizationName,
                        CrueltyFree = entity.CrueltyFree,
                        Sustainable = entity.Sustainable,
                        Diverse = entity.Diverse,
                        ECountry = entity.ECountry,
                        EImprove = entity.EImprove
                    };
            }
        }

        // Update
        public bool UpdateEthicalOrganization(EEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EthicalOrganizations
                        .Single(e => e.EthicalOrganizationId == id && e.Id == _userId);

                entity.EthicalOrganizationName = model.EthicalOrganizationName;
                entity.CrueltyFree = model.CrueltyFree;
                entity.Sustainable = model.Sustainable;
                entity.Diverse = model.Diverse;
                entity.ECountry = model.ECountry;
                entity.EImprove = model.EImprove;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteEthicalOrganization(int ethicalOrganizationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EthicalOrganizations
                        .Single(e => e.EthicalOrganizationId == ethicalOrganizationId && e.Id == _userId);

                ctx.EthicalOrganizations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }


}
