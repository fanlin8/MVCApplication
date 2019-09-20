using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductFromDB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int Inventory { get; set; }
    }
}
