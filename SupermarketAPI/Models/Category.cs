using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Models
{
    public class Category
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public IList<Products> Products { get; set; } = new List<Products>();
    }
}
