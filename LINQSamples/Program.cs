using System;
using System.Linq;
using LINQSamples.Data;

namespace LINQSamples
{
    class ProductModel
    {
        public string Name { get; set; }
        public float? Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.ToList();
                //var products = db.Products.Select(p => p.ProductName).ToList();
                var products = db.Products.Select(p => new ProductModel
                {
                    Name = p.ProductName,
                    Price = p.UnitPrice
                }).ToList();
                foreach (var p in products)
                {
                    Console.WriteLine(p.Name+ " " +p.Price);
                }
            }
           
        }
    }
}
