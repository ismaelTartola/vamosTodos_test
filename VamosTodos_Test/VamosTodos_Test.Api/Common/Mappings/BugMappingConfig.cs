
using Mapster;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Bug.Querys.GetBugsPagedBy;

namespace VamosTodos_Test.Presentation.Common.Mappings;

public class BugMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
		config.NewConfig<GetBugByPagedRequest, GetBugsByPagedQuery>()
		   .Map(dest => dest.UserId, src => src.UserId)
		   .Map(dest => dest.ProjectId, src => src.ProjectId)
		   .Map(dest => dest.StartDate, src => src.StartDate)
		   .Map(dest => dest.EndDate, src => src.EndDate)
		   .Map(dest => dest.Page, src => src.Page)
		   .Map(dest => dest.PageSize, src => src.PageSize);
	}
}