namespace abvancedEshop.Models.ViewModel
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public PagingInfor PagingInfor { get; set; } = new PagingInfor();
    }
}
