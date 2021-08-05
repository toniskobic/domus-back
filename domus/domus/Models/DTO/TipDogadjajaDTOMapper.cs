using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Models.DTO
{
    public static class TipDogadjajaDtoMapper
    {
        public static TipDogadjajaDto MapToDto(TipDogadjaja tipDogadjaja)
        {
            return new TipDogadjajaDto()
            {
                TipDogadjajaId = tipDogadjaja.TipDogadjajaId,
                Naziv = tipDogadjaja.Naziv
            };
        }
    }
}
