using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class CityDataManager : IDataRepository<City>
    {
        readonly domusContext _domusContext;

        public CityDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<City> GetAll()
        {
            return _domusContext.Cities.ToList();
        }

        public City Get(long id)
        {
            var city = _domusContext.Cities
                .SingleOrDefault(b => b.Id == id);

            return city;
        }

        public void Add(City entity)
        {
            _domusContext.Cities.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(City entityToUpdate, City entity)
        {
            entityToUpdate = _domusContext.Cities
                .Include(a => a.Dormitories)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(City entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
