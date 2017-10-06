using System;
using ModelCore.DataAccess;

namespace ModelCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using (CatalogContext catalog = new CatalogContext())
            {
                BrandRepository brandRepository = new BrandRepository(catalog);

                foreach(var brand in brandRepository.GetAll())
                {
                    Console.WriteLine(brand.ToString());
                }

                TypeRepository typeRepository = new TypeRepository(catalog);

                foreach(Type type in typeRepository.GetAll())
                {
                    Console.WriteLine($"{type.PK_TypeId}.{type.Name}{Environment.NewLine}{type.Description}");
                }
            }

            Console.ReadLine();
        }
    }
}
