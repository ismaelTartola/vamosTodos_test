
using VamosTodos_Test.Application.Abstractions.Services;

namespace VamosTodos_Test.Infraestructure.Common;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
