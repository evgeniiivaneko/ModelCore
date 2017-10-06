using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCore.DataAccess.Interface;


namespace ModelCore.DataAccess
{
    public class TypeRepository : IRepository<Type>
    {
        private Boolean idDisposed = false;
        private readonly CatalogContext catalogContext;

        public TypeRepository()
        {
            catalogContext = new CatalogContext();
        }

        public TypeRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Type item)
        {
            catalogContext.Type.Add(item);
        }

        public void Delete(int id)
        {
            Type type = this.GetById(id);
            if (type != null)
            {
                catalogContext.Type.Remove(type);
            }
        }
        /// <summary>
        /// Метод для закрытия подключения к базе данных
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(Boolean disposing)
        {
            if (!this.idDisposed)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
            }
            this.idDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Type> GetAll()
        {
            return catalogContext.Type.ToList();
        }

        public Type GetById(int id)
        {
            return catalogContext.Type.FirstOrDefault(x => x.PK_TypeId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Type item)
        {
            catalogContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
