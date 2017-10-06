﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ModelCore.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace ModelCore.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        private Boolean isDispose = false;
        private readonly CatalogContext catalogContext;

        public UserRepository()
        {
            catalogContext = new CatalogContext();
        }

        public UserRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;  
        }

        public void Create(User item)
        {
            catalogContext.User.Add(item);
        }

        public void Delete(int id)
        {
            User user = this.GetById(id);
            if (user != null)
            {
                catalogContext.User.Remove(user);
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

        public IEnumerable<User> GetAll()
        {
            return catalogContext.User.ToList();
        }

        public User GetById(int id)
        {
            return catalogContext.User
                .FirstOrDefault(x => x.PK_UserId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(User item)
        {
            catalogContext.Entry<User>(item).State = EntityState.Modified;
        }
    }
}
