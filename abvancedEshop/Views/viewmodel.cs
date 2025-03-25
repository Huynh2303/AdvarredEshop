using abvancedEshop.Models;

namespace abvancedEshop.Views
{
    public class viewmodel
    {
    
        public class CheckoutViewModel
        {
            public Cart Cart { get; set; } // Giỏ hàng
            public Chechout Chechout { get; set; } // Thông tin thanh toán
        }
    }
}

