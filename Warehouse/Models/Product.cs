using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAO;

namespace Warehouse.Models
{
    public class Product
    {
        ProviderLogic providers = new ProviderLogic();

        private static int countId = 0;
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public Category Category { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public bool IsAvialable => Count > 0;

        public Product()
        {
            ProductId = countId++;
            Name = null;
            Category = Category.None;
            Cost = 0.0;
            Count = 0;
        }

        public override string ToString()
        {
            return $"Id: {ProductId}; " +
                $"Name: {Name}; " +
                $"Provider: {providers.FindProviderByID(ProviderId).Name}; " +
                $"Category: {Category}; " +
                $"Cost: {Cost}; " +
                $"Count: {Count};";
        }

        [NotMapped]
        public static int CountId
        {
            set
            {
                countId = value;
            }
        }
    }
}
