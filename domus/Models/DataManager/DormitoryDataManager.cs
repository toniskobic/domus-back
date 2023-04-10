using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class DormitoryDataManager : IDataRepository<Dormitory>
    {
        readonly domusContext _domusContext;

        public DormitoryDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<Dormitory> GetAll()
        {
            return _domusContext.Dormitories.Include(a => a.City);
        }

        public Dormitory Get(long id)
        {
            var dormitory = _domusContext.Dormitories
                .SingleOrDefault(b => b.Id == id);

            return dormitory;
        }

        public void Add(Dormitory entity)
        {
            _domusContext.Dormitories.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(Dormitory entityToUpdate, Dormitory entity)
        {
            entityToUpdate = _domusContext.Dormitories
                .Include(a => a.Users)
                .Include(a => a.City)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(Dormitory entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
