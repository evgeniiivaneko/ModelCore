using System;
using System.Collections.Generic;
using System.Text;
using ModelCore.DataAccess.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace ModelCore.DataAccess
{
    public class ImageRepository : IRepository<Image>
    {
        private Boolean isDispose = false;
        private readonly CatalogContext catalogContext;
        public ImageRepository()
        {
            catalogContext = new CatalogContext();
        }
        public ImageRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Image item)
        {
            catalogContext.Image.Add(item);
        }

        public void Delete(int id)
        {
            Image image = this.GetById(id);
            if (image != null)
                catalogContext.Image.Remove(image);
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

        public IEnumerable<Image> GetAll()
        {
            return catalogContext.Image.ToList();
        }

        public Image GetById(int id)
        {
            return catalogContext.Image.FirstOrDefault(x => x.PkImageId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Image item)
        {
            catalogContext.Entry<Image>(item).State = EntityState.Modified;
        }
    }
}
