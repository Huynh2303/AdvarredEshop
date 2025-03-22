namespace abvancedEshop.Models.ViewModel
{
    public class PagingInfor
    {
              public int TotalItem { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrenPage { get; set; }
        public int TotalPages => ItemPerPage >0 ?  (int)Math.Ceiling((decimal)TotalItem / ItemPerPage) : 1;
    }
}
