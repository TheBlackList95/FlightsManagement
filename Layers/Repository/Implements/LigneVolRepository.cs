using Microsoft.EntityFrameworkCore;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.DatabaseContexts;
using SuiviDesVols.Layers.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuiviDesVols.Layers.Repository.Implements
{
    public class LigneVolRepository : IGenericRepository<LigneVol>
    {
        private readonly AppDbContext context;

        public LigneVolRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<LigneVol> GetAll(Expression<Func<LigneVol, bool>> filter = null)
        {
           return context.LigneVols
                        .Include(p => p.Agence)
                        .Include(p => p.AeroportDepart)
                        .Include(p => p.AeroportArrivee)
                        .Include(p => p.Avion)
                        .Include(p => p.VolOptions)
                        .Include(p => p.Vols)
                        .ToList();
        }

        public LigneVol GetById(Guid id)
        {
            return context.LigneVols
                .Include(p => p.Agence)
                .Include(p => p.AeroportDepart)
                .Include(p => p.AeroportArrivee)
                .Include(p => p.Avion)
                .Include(p => p.VolOptions)
                .Include(p => p.Vols)
                .Include(p => p.AeroportDepart.Ville)
                .Include(p => p.AeroportArrivee.Ville)
                .SingleOrDefault(p => p.Id.Equals(id));
        }

        public int Insert(LigneVol entity)
        {
            context.LigneVols.Add(entity);
            return context.SaveChanges();
        }

        public int Update(LigneVol entity)
        {
            var obj = context.LigneVols.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }
    }
}
