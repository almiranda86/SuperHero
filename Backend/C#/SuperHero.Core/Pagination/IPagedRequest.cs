namespace SuperHero.Core.Pagination
{
    public interface IPagedRequest
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
