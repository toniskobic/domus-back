using domus.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class ParticipantDataManager : IParticipantRepository<Participant>
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

        public Participant GetParticipant(long eventId, string userId)
        {
            var entity = _domusContext.Participants
                .SingleOrDefault(b => b.EventId == eventId && b.UserId == userId);

            return entity;
        }

        public IEnumerable<Participant> GetParticipants(long id)
        {
            return _domusContext.Participants.Where(b => b.EventId == id).ToList();
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
                .Single(b => b.UserId == entityToUpdate.UserId && b.EventId == entityToUpdate.EventId);

            if(entity.Explanation != null) entityToUpdate.Explanation = entity.Explanation;
            if(entity.Accepted) entityToUpdate.Accepted = entity.Accepted;
            if(entity.Declined) entityToUpdate.Declined = entity.Declined;

            _domusContext.SaveChanges();
        }

        public void Delete(Participant entity)
        {
            _domusContext.Remove(entity);
            _domusContext.SaveChanges();
        }
    }
}
