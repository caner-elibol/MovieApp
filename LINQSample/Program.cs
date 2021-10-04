using LINQSample.Data;
using System;
using System.Linq;

namespace LINQSample
{
    class ProductModel
    {
        public string Name { get; set; }
        public short? Stok { get; set; }
        public float? Price { get; set; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            using (var db = new NorthwindContext())
            {
               
                var products = db.Products
                    .Select(p =>
              new ProductModel
              {
                  Name = p.ProductName,
                  Price = p.UnitPrice,
                  Stok=p.UnitsInStock
              })
                    .Where(p => p.Price > 10.0)
                    .OrderByDescending(p=>p.Stok)
                    .ToList();
                foreach (var p in products)
                    
                {
                    Console.WriteLine(p.Name +" "+p.Stok + " " +p.Price);
                }
            }
        }
        class Ders1
        {
            //var products = db.Products.Select(p =>
            //  new ProductModel
            //  {
            //      Name = p.ProductName,
            //      Price=p.UnitPrice
            //  }).ToList();

            //var product = db.Products.Select(p =>
            //    new ProductModel
            //    {
            //        Name = p.ProductName,
            //        Price = p.UnitPrice
            //    })
            //    .FirstOrDefault();

            //Console.WriteLine(product.Name+" "+product.Price);
                //foreach (var p in product)
                //{
                //    Console.WriteLine(p.Name +" "+p.Price);
                //}
        }
    }
}
