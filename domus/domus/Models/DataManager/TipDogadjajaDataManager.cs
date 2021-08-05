using domus.Models.DTO;
using domus.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DataManager
{
    public class TipDogadjajaDataManager : IDataRepository<TipDogadjaja, TipDogadjajaDto>
    {
        readonly domusContext _domusContext;

        public TipDogadjajaDataManager(domusContext domus)
        {
            _domusContext = domus;
        }

        public IEnumerable<TipDogadjaja> GetAll()
        {
            return _domusContext.TipoviDogadjaja.ToList();
        }

        public TipDogadjajaDto GetDto(long id)
        {
            _domusContext.ChangeTracker.LazyLoadingEnabled = true;

            using (var context = new domusContext())
            {
                var tipDogadjaja = context.TipoviDogadjaja
                    .SingleOrDefault(b => b.TipDogadjajaId == id);

                return TipDogadjajaDtoMapper.MapToDto(tipDogadjaja);
            }
        }

        public void Add(TipDogadjaja entity)
        {
            _domusContext.TipoviDogadjaja.Add(entity);
            _domusContext.SaveChanges();
        }
    }
}
