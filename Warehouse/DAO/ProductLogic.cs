using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.DAO
{
    public class ProductLogic
    {
        public void ShowAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    List<Product> products = db.Products.ToList();

                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Products does not exist.");
                }
            }
        }

        public void AddProduct(string name, int providerId, Category category, double cost, int count)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Product product = new Product() { 
                        Name = name, 
                        ProviderId = providerId,
                        Category = category,
                        Cost = cost,
                        Count = count
                    };

                    db.Products.Add(product);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Error! Some fields are empty or invalid.");
            }

        }

        public Product FindProductByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Product product = db.Products.Find(id);
                    return product;
                }
                catch
                {
                    Console.WriteLine("Error! Product with same name does not exist.");
                    return new Product();
                }

            }
        }

        public List<Product> FindByProductName(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.Products.Where(x => x.Name == name).ToList();

                }
                catch
                {
                    Console.WriteLine("Error! Products with same name does not exist.");
                    return new List<Product>();
                }

            }
        }

        public List<Product> FindProductByCount(int count)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.Products.Where(x => x.Count >= count).ToList();

                }
                catch
                {
                    Console.WriteLine("Error! Products with same count does not exist.");
                    return new List<Product>();
                }

            }
        }

        public void RemoveByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.Remove(FindProductByID(id));
                    db.SaveChanges();
                }
                catch 
                {
                    Console.WriteLine("Error! Product with same id does not exist.");
                }
            }
        }

        public void UpdateById(int id, string name, int providerId = -1, Category category = Category.None, double cost = -1, int count = -1)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Product product = FindProductByID(id);
                    if (name != "" || name != null)
                        product.Name = name;
                    if (providerId != -1)
                        product.ProviderId = providerId;
                    if (category != Category.None)
                        product.Category = category;
                    if (cost >= 0)
                        product.Cost = cost;
                    if (count >= 0)
                        product.Count = count;
                    db.Products.Update(product);
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Error! Product with same id does not exist.");
                }
            }
        }
    }
}
