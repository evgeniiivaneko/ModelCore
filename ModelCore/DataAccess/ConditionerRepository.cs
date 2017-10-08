using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModelCore.DataAccess.Interface;

namespace ModelCore.DataAccess
{
    public class ConditionerRepository : IRepository<Conditioner>
    {
        private readonly CatalogContext catalogContext;
        private Boolean isDispose = false;
        public ConditionerRepository()
        {
            catalogContext = new CatalogContext();
        }
        public ConditionerRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Conditioner item)
        {
            catalogContext.Conditioner.Add(item);
        }

        public void Delete(int id)
        {
            Conditioner conditioner = this.GetById(id);
            if(conditioner != null)
            {
                catalogContext.Conditioner.Remove(conditioner);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!isDispose)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
                isDispose = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Conditioner> GetAll()
        {
            return catalogContext.Conditioner.ToList();
        }

        public Conditioner GetById(int id)
        {
            return catalogContext.Conditioner.FirstOrDefault(x => x.FK_ProductId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Conditioner item)
        {
            catalogContext.Entry<Conditioner>(item).State = EntityState.Modified;
        }
    }
}
