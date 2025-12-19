namespace Webshop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public bool Sex { get; set; }

        public Size Size { get; set; }
    }

    public enum Size
    {
        XS, S, M, L, XL, XXL
    }
}
