using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.Repository
{
    public interface IParticipantRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetParticipants(long id);
        TEntity GetParticipant(long eventId, string userId);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
