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
    public class VolRepository : IGenericRepository<Vol>
    {
        private readonly AppDbContext context;

        public VolRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Vol> GetAll(Expression<Func<Vol, bool>> filter = null)
        {
           return context.Vols
                .Include(p => p.OptionsChoisies)
                .Include(p => p.LigneVol)
                .Include(p => p.LigneVol.VolOptions)
                .ToList();
        }

        public Vol GetById(Guid id)
        {
            return context.Vols
                .Include(p => p.LigneVol)
                .Include(p => p.LigneVol.VolOptions)
                .SingleOrDefault(p => p.Id.Equals(id));
        }

        public int Insert(Vol entity)
        {
            context.Vols.Add(entity);
            return context.SaveChanges();
        }

        public int Update(Vol entity)
        {
            var obj = context.Vols.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }
    }
}
