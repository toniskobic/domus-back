using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class EventDataManager : IDataRepository<Event>
    {
        readonly domusContext _domusContext;

        public EventDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<Event> GetAll()
        {
            return _domusContext.Events
                .Include(a => a.User)
                .Include(a => a.EventType)
                .Include(a => a.Participants)
                .Where(a => a.DateTo < DateTime.Now);   
        }

        public Event Get(long id)
        {
            var entity = _domusContext.Events.Include(a => a.Participants).ThenInclude(a => a.User).Include(a => a.User).Include(a => a.EventType)
                .SingleOrDefault(b => b.Id == id);

            return entity;
        }

        public void Add(Event entity)
        {
            _domusContext.Events.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(Event entityToUpdate, Event entity)
        {
            entityToUpdate = _domusContext.Events
                .Include(a => a.User)
                .Include(a => a.EventType)
                .Include(a => a.Participants)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(Event entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
