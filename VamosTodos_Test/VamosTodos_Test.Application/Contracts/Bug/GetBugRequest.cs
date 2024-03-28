
namespace VamosTodos_Test.Application.Contracts.Bug;

public record GetBugRequest
{
    public Guid ProjectId { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    public DateTime EndDate { get; set; } = DateTime.MinValue;

    public bool InvalidRequest => (ProjectId == Guid.Empty
        && UserId == Guid.Empty
        && StartDate == DateTime.MinValue
        && EndDate == DateTime.MinValue);

    public bool ValidRequest => !InvalidRequest;
}
