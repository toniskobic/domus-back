using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class ParticipantDataManager : IDataRepository<Participant>
    {
        readonly domusContext _domusContext;

        public ParticipantDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<Participant> GetAll()
        {
            return _domusContext.Participants.ToList();
        }

        public Participant Get(long id)
        {
            var entity = _domusContext.Participants
                .SingleOrDefault(b => b.EventId == id);

            return entity;
        }

        public void Add(Participant entity)
        {
            _domusContext.Participants.Add(entity);
            _domusContext.SaveChanges();
        }

        public void Update(Participant entityToUpdate, Participant entity)
        {
            entityToUpdate = _domusContext.Participants
                .Include(a => a.Event)
                .Include(a => a.User)
                .Single(b => b.UserId == entityToUpdate.UserId);

            entityToUpdate.Explanation = entity.Explanation;
            entityToUpdate.Accepted = entity.Accepted;
            entityToUpdate.Declined = entity.Declined;

            _domusContext.SaveChanges();
        }

        public void Delete(Participant entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
