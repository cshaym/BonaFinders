using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.TipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Services
{
    public class TipService
    {
        private readonly Guid _userId;
        public TipService(Guid userId)
        {
            _userId = userId;
        }
        public TipService() { }   //

        // Create Method
        public bool CreateTip(TCreate model)
        {
            var entity =
                new Tip()
                {
                    Id = _userId,
                    Title = model.Title,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tips.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read All: GetTips() Method
        public IEnumerable<TListItem> GetTips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tips
                        //.Where(e => e.Id == _userId) Reason: Anyone can view the Index pages of the tables but only Users logged in can use CRUD 
                        .Select(
                            e =>
                                new TListItem
                                {
                                    TipId = e.TipId,
                                    Title = e.Title,
                                    Text = e.Text
                                }
                        );

                return query.ToList();
            }
        }

        // Read Single: Get by id
        public TDetail GetTipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tips
                        .Single(e => e.TipId == id && e.Id == _userId);
                return
                    new TDetail
                    {
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }

        // Update
        public bool UpdateTip(TEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tips
                        .Single(e => e.TipId == id && e.Id == _userId);

                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteTip(int tipId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tips
                        .Single(e => e.TipId == tipId && e.Id == _userId);

                ctx.Tips.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
