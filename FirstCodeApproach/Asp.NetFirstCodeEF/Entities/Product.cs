namespace Asp.NetFirstCodeEF.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryID { get; set; }

        public string ? Quality { get;set; }
    }
}
