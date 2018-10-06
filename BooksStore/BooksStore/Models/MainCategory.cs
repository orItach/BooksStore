using System;
using System.Collections.Generic;
using System.Text;

namespace BooksStore.Models
{
    public class MainCategory
    {
        public MainCategory()
        {
            SubCategories = new List<SubCategory>();
        }

        public string Topic { get; set; }

        public List<SubCategory> SubCategories { get; set; }
        
    }
}
