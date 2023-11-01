namespace PIMTools.AnLNM.Helper
{
    public class PaginationParameter
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? Search { get; set; } = string.Empty;
        public string? Sort { get; set; } = string.Empty;
    }
}
