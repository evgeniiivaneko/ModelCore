using System;
using ModelCore.DataAccess;

namespace ModelCore
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (CatalogContext catalog = new CatalogContext())
                {
                    BrandRepository brandRepository = new BrandRepository(catalog);

                    foreach (var brand in brandRepository.GetAll())
                    {
                        Console.WriteLine(brand.ToString());
                    }

                    TypeRepository typeRepository = new TypeRepository(catalog);

                    foreach (Type type in typeRepository.GetAll())
                    {
                        Console.WriteLine($"{type.PK_TypeId}.{type.Name}{Environment.NewLine}{type.Description}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
