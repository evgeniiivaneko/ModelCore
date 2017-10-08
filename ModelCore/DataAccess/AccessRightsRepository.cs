using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModelCore.DataAccess.Interface;
namespace ModelCore.DataAccess
{
    public class AccessRightsRepository : IRepository<AccessRights>
    {
        private readonly CatalogContext catalogContext;
        private Boolean isDispose = false;
        public AccessRightsRepository()
        {
            catalogContext = new CatalogContext();
        }
        public AccessRightsRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(AccessRights item)
        {
            catalogContext.AccessRights.Add(item);
        }

        public void Delete(int id)
        {
            AccessRights accessRights = this.GetById(id);
            if (accessRights != null)
            {
                catalogContext.AccessRights.Remove(accessRights);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!this.isDispose)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
                this.isDispose = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AccessRights> GetAll()
        {
            return catalogContext.AccessRights.ToList();
        }

        public AccessRights GetById(int id)
        {
            return catalogContext.AccessRights.FirstOrDefault(x => x.PK_AccessRightsId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(AccessRights item)
        {
            catalogContext.Entry<AccessRights>(item).State = EntityState.Modified;
        }
    }
}
