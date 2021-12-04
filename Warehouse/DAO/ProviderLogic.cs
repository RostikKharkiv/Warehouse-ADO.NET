using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.DAO
{
    public class ProviderLogic
    {
        public void ShowAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    List<Provider> providers = db.Providers.ToList();

                    foreach (var provider in providers)
                    {
                        Console.WriteLine(provider);
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Providers does not exist.");
                }
            }
        }

        public void AddProvider(string name)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Provider provider = new Provider()
                    {
                        Name = name
                    };

                    db.Providers.Add(provider);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Error! Some fields are empty or invalid.");
            }

        }

        public Provider FindProviderByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Provider provider = db.Providers.Find(id);
                    return provider;
                }
                catch
                {
                    Console.WriteLine("Error! Provider with same name does not exist.");
                    return new Provider();
                }

            }
        }

        public Provider FindByProviderName(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.Providers.Where(x => x.Name == name).FirstOrDefault();

                }
                catch
                {
                    Console.WriteLine("Error! Provider with same name does not exist.");
                    return new Provider();
                }

            }
        }

        public void RemoveByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.Remove(FindProviderByID(id));
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Error! Provider with same id does not exist");
                }
            }
        }

        public void UpdateById(int id, string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Provider provider = FindProviderByID(id);
                    if (name != "" || name != null)
                        provider.Name = name;
                    db.Providers.Update(provider);
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Error! Provider with same id does not exist");
                }
            }
        }
    }
}
