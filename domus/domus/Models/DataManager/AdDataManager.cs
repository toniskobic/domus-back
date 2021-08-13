using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class AdDataManager : IDataRepository<Ad>
    {
        readonly domusContext _domusContext;

        public AdDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<Ad> GetAll()
        {
            return _domusContext.Ads.ToList();
        }

        public Ad Get(long id)
        {
            var dormitory = _domusContext.Ads
                .SingleOrDefault(b => b.Id == id);

            return dormitory;
        }

        public void Add(Ad entity)
        {
            _domusContext.Ads.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(Ad entityToUpdate, Ad entity)
        {
            entityToUpdate = _domusContext.Ads
                .Include(a => a.User)
                .Include(a => a.AdType)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(Ad entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
