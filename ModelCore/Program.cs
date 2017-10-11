using System;
using ModelCore.DataAccess;
using ModelCore.UnitOfWork;
using System.Drawing;
namespace ModelCore
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {



                using (UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork())
                {
                    foreach (Brand brand in unitOfWork.Brand.GetAll())
                    {
                        Console.WriteLine(brand.ToString());
                        Console.WriteLine("--------------------------------------------");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
