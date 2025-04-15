using Application.Users.CreateUser;
using WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}