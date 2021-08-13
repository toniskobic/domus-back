using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class EventTypeDataManager : IDataRepository<EventType>
    {
        readonly domusContext _domusContext;

        public EventTypeDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<EventType> GetAll()
        {
            return _domusContext.EventTypes.ToList();
        }

        public EventType Get(long id)
        {
            var eventType = _domusContext.EventTypes
                .SingleOrDefault(b => b.Id == id);

            return eventType;
        }

        public void Add(EventType entity)
        {
            _domusContext.EventTypes.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(EventType entityToUpdate, EventType entity)
        {
            entityToUpdate = _domusContext.EventTypes
                .Include(a => a.Events)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            _domusContext.SaveChanges();
        }

        public void Delete(EventType entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
