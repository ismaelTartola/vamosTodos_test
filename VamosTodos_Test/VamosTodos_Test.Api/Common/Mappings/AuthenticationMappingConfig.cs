
using VamosTodos_Test.Domain.User;
using Mapster;

namespace VamosTodos_Test.Presentation.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        /*config.NewConfig<UserAggregateRoot, UserResponseDto>()
            .Map(dest => dest.FirstName, src => src.FirstName.Value)
            .Map(dest => dest.LastName, src => src.LastName.Value)
            .Map(dest => dest.Email, src => src.Email.Value);

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.RefreshToken, src => src.RefreshToken)
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.User, src => src.User);*/
    }
}