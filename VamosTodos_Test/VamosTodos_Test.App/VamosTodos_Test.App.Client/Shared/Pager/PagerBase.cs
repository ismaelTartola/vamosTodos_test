
using Microsoft.AspNetCore.Components;

namespace VamosTodos_Test.App.Client.Shared.Pager;

public class PagerBase<T> : ComponentBase 
	where T : class
{
	[Parameter]
	public CustomPagedList<T>? PagedResult { get; set; }

	[Parameter]
	public Action<int> PageChanged { get; set; } = null!;

	public int GetPagesNumber()
	{
		if(PagedResult is null)
			return 0;

		var rest = PagedResult.TotalCount % PagedResult.PageSize;

		if (rest == 0)
			return PagedResult.TotalCount / PagedResult.PageSize;

		return (PagedResult.TotalCount / PagedResult.PageSize) + 1;
	}

	protected void PagerButtonClicked(int page)
	{
		PageChanged?.Invoke(page);
	}
}
