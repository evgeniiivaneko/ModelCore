using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCore.DataAccess.Interface;

namespace ModelCore.DataAccess
{
    /// <summary>
    /// Класс, представляющий абстрактную сущноть для работы с таблицой Brand
    /// Реализован по паттерну Repository
    /// </summary>
    public class BrandRepository : IRepository<Brand>
    {
        private Boolean idDisposed = false;
        private readonly CatalogContext catalogContext;
        public BrandRepository()
        {
            catalogContext = new CatalogContext();
        }
        public BrandRepository(CatalogContext _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }
        /// <summary>
        /// Метод добавления записи в таблицу Brand
        /// </summary>
        /// <param name="item">Добавляемая запись</param>
        public void Create(Brand item)
        {
            //Проверка на уникальность записи
            if (!catalogContext.Brand.Contains(item))
            {
                //Добавление записи в таблицу
                catalogContext.Brand.Add(item);
            }
        }
        /// <summary>
        /// Метод удаления записи из таблицы Brand по Id
        /// </summary>
        /// <param name="id">Идентификатор записи в таблице</param>
        public void Delete(int id)
        {
            Brand brand = this.GetById(id);
            if (brand != null)
            {
                catalogContext.Brand.Remove(brand);
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
        /// <summary>
        /// Метод для освобождения неуправляемых ресурсов
        /// В данном случае для закрытия подключения к Базе данных
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Метод получения всех записей в таблице Brand
        /// </summary>
        /// <returns>Возвращает колекцию записей в таблице Brand</returns>
        public IEnumerable<Brand> GetAll()
        {
            return catalogContext.Brand.ToList();
        }
        /// <summary>
        /// Метод получение записи из таблицы Brand по Id
        /// </summary>
        /// <param name="id">Идентификационный номер записи в таблице(Int32)</param>
        /// <returns>возвращает запись из таблицы или значение null, если запись не найдена</returns>
        public Brand GetById(int id)
        {
            return catalogContext.Brand.FirstOrDefault(item => item.PK_BrandId == id);
        }
        /// <summary>
        /// Метод сохранения изменений в базе данных
        /// </summary>
        public void Save()
        {
            catalogContext.SaveChanges();
        }
        /// <summary>
        /// Метод обновления содержимого таблицы
        /// </summary>
        /// <param name="item">Объект с обновленными свойствами</param>
        public void Update(Brand item)
        {
            catalogContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
