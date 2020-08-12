using Auvo.Busness.Interfaces;
using Auvo.Busness.Models;
using Auvo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Auvo.Data.Repository
{
    public class PontoRepository : Repository<Ponto>, IPontoRepository
    {
        public PontoRepository(AuvoDbContext context) : base(context)
        {
        }

        public async Task<Ponto> ObterPontoRegistros(Guid id)
        {
            return await Db.Ponto.AsNoTracking()
                .Include(c => c.Registros)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
