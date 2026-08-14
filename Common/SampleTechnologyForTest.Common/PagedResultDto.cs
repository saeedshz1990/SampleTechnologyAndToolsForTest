namespace SampleTechnologyForTest.Common
{
    public class PagedResultDto<T> where T : class
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; } = 5;
        public int PageNumber { get; set; } = 10;
        public int PageSize { get; set; } = 10;
    }
}
