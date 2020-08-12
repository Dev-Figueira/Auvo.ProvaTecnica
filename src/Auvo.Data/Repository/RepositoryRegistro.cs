using Auvo.Busness.Interfaces;
using Auvo.Busness.Models;
using Auvo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auvo.Data.Repository
{
    public class RegistroRepository : Repository<Registro>, IRegistroRepository
    {
        public RegistroRepository(AuvoDbContext context) : base(context) { }

        public async Task<Registro> ObterRegistroPonto(Guid id)
        {
            return await Db.Registro.AsNoTracking().Include(f => f.Ponto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Registro>> ObterRegistrosPonto()
        {
            return await Db.Registro.AsNoTracking().Include(f => f.Ponto)
                .OrderBy(p => p.NomeDoColaborador).ToListAsync();
        }

        public async Task<IEnumerable<Registro>> ObterRegistrosPorPonto(Guid pontoId)
        {
            return await Buscar(p => p.PontoId == pontoId);
        }
    }
}
