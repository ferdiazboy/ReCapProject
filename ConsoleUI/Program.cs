using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //Listedeki tüm araçları sıralama
            Console.WriteLine("---Galerideki Araçlar---\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine();

            //Kullanıcıdan alınan Id'ye göre araç sıralam
            Console.WriteLine("---Id'ye göre araç sıralama--- ");
            Console.Write("Araç no giriniz(1-4):");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var car in carManager.GetById(id))
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);

            //Araç Ekleme
            Console.WriteLine("---Araç Ekleme---");
            System.Threading.Thread.Sleep(3000);
            Car car1 = new Car()
            {
                Id = 5,
                BrandId = 5,
                ColorId = 3,
                DailyPrice = 500,
                ModelYear = 2020,
                Description = "Audi A4-Otomatik"
            };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);

            // Araç Güncelleme
            Console.WriteLine("---Araç Güncelleme(1 Nolu)---");
            System.Threading.Thread.Sleep(3000);
            Car car2 = new Car()
            {
                Id = 1,
                BrandId = 6,
                ColorId = 2,
                DailyPrice = 400,
                ModelYear = 2021,
                Description = "Honda Civic-Otomatik"
            };
            carManager.Update(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);


            // Araç Silme 
            Console.WriteLine("---Araç Silme(5 Nolu)---");
            System.Threading.Thread.Sleep(3000);
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
        }
    }
}
