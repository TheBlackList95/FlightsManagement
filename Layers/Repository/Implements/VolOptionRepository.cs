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
    public class VolOptionRepository : IGenericRepository<VolOption>
    {
        private readonly AppDbContext context;

        public VolOptionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<VolOption> GetAll(Expression<Func<VolOption, bool>> filter = null)
        {
           return context.VolOptions.ToList();
        }

        public VolOption GetById(Guid id)
        {
            return context.VolOptions.SingleOrDefault(p => p.Id.Equals(id));
        }

        public int Insert(VolOption entity)
        {
            context.VolOptions.Add(entity);
            return context.SaveChanges();
        }

        public int Update(VolOption entity)
        {
            var obj = context.VolOptions.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }
    }
}
