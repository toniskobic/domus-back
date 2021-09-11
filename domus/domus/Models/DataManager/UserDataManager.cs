using domus.Authentication;
using domus.Models;
using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class UserDataManager : IDataRepository<ApplicationUser>
    {
        readonly domusContext _domusContext;

        public UserDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _domusContext.Users.Include(a => a.Dormitory);
        }

        public ApplicationUser Get(long id)
        {
            string text = id.ToString();
            var adType = _domusContext.Users
                .SingleOrDefault(b => b.Id == text);

            return adType;
        }

        public void Add(ApplicationUser entity)
        {
            _domusContext.Users.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(ApplicationUser entityToUpdate, ApplicationUser entity)
        {
            entityToUpdate = _domusContext.Users
                .Include(a => a.Dormitory)
                .Include(a => a.Participants)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Locked = entity.Locked;

            _domusContext.SaveChanges();
        }

        public void Delete(ApplicationUser entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
