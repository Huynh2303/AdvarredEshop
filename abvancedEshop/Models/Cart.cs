namespace abvancedEshop.Models
{
    public class Cart
    {
        // tao ra danh sach
        public List<CartLline> line { get; set; } = new List<CartLline>();
        // them san pham vao danh sach
        public void AddItem(Product product, int quantity)
        {
            CartLline? lines = line.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (lines == null)
            {
                line.Add(new CartLline
                {
                    Product = product,
                    Quantity = quantity
                });

            }
            else
            {
                lines.Quantity += quantity;
            }

        }
        // xoa san pham
        public void RemoveLine(Product product) => line.RemoveAll(p => p.Product.ProductId == product.ProductId);
        // tinh tong tien
        public decimal ComputeTotalValue() => (decimal)line.Sum(p => p.Product?.ProductPrice * (1 - p.Product.ProductDiscount)*p.Quantity);
        //
        public void Clear() => line.Clear();
        //



    }

    public class CartLline
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }

    }
}
