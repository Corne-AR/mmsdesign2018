using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.IO
{
    public class Products
    {
        public string Category { get; set; }
        public string Name { get; set; }

        public Products(string Category, string Name)
        {
            this.Category = Category;
            this.Name = Name;
        }
    }
}
