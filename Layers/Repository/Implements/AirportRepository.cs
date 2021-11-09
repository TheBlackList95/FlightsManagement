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
    public class AirportRepository : IGenericRepository<Aeroport>
    {
        private readonly AppDbContext context;

        public AirportRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Aeroport> GetAll(Expression<Func<Aeroport, bool>> filter = null)
        {
           return context.Aeroports.ToList();
        }

        public Aeroport GetById(Guid id)
        {
            return context.Aeroports.SingleOrDefault(p => p.Id.Equals(id));
        }

        public int Insert(Aeroport entity)
        {
            context.Aeroports.Add(entity);
            return context.SaveChanges();
        }

        public int Update(Aeroport entity)
        {
            var obj = context.Aeroports.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }
    }
}
