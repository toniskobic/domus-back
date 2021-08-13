using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class AdTypeDataManager : IDataRepository<AdType>
    {
        readonly domusContext _domusContext;

        public AdTypeDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<AdType> GetAll()
        {
            return _domusContext.AdTypes.ToList();
        }

        public AdType Get(long id)
        {
            var adType = _domusContext.AdTypes
                .SingleOrDefault(b => b.Id == id);

            return adType;
        }

        public void Add(AdType entity)
        {
            _domusContext.AdTypes.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(AdType entityToUpdate, AdType entity)
        {
            entityToUpdate = _domusContext.AdTypes
                .Include(a => a.Ads)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(AdType entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
