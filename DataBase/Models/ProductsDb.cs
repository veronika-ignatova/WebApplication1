using Core.Entities;

namespace DataBase.Models
{
    internal class ProductsDb
    {
        public List<Product>? Products { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
