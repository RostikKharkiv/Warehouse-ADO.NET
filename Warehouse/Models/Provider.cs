using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Provider
    {
        private static int countId = 0;
        public int ProviderId { get; set; }
        public string Name { get; set; }

        public Provider()
        {
            ProviderId = countId++;
        }

        public override string ToString()
        {
            return $"Id: {ProviderId}; Name: {Name}";
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
