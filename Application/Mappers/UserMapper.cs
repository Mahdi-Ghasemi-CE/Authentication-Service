using AutoMapper;
using Domain.Entities.Users;

namespace Application.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
