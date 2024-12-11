namespace SRED.IO.Task1.Api.Controllers;

public class Page<T> where T : class
{
    public int TotalPage { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public List<T> List { get; set; }
}

public class PageParam
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    // public Sort Type { get; set; }
    public string Filters { get; set; } = "";
}

public class FilterColumn
{
    public string Column { get; set; }
    public string Predicate { get; set; }
}