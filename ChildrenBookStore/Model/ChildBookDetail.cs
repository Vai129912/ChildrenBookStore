using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Model
{
    public class ChildBookDetail
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string category_name { get; set; }
        public string book_authorname { get; set; }
        public int book_price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
