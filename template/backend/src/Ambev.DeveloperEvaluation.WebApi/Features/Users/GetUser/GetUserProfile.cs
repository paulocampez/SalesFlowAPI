using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        // Mapeamento de AuthenticateUserRequest para AuthenticateUserCommand
        CreateMap<GetUserResponse, GetUserCommand>();

        // Mapeamento de AuthenticateUserResult para AuthenticateUserResponse
        CreateMap<GetUserResult, GetUserResponse>();

        CreateMap<Guid, GetUserCommand>()
            .ConstructUsing(id => new GetUserCommand(id));
    }
}
