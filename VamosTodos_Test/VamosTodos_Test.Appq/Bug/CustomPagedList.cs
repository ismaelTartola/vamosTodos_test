namespace VamosTodos_Test.App.Bug;

public sealed record CustomPagedList<T>
	(List<T>? Items, int Page, int PageSize, int TotalCount) 
	where T : class
{
	public bool HasNextPage => Page * PageSize < TotalCount;

	public bool HasPreviusPage => PageSize > 1;
}
