
using VamosTodos_Test.Application.Contracts.User;

namespace VamosTodos_Test.Application.Contracts.Bug;

public sealed record GetUsersResponse(List<UserDto> Users);
