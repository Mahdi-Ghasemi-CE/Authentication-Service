using System.Net;
using Authentication_Service.Application.Interfaces;
using Authentication_Service.Application.Utils;

namespace Authentication_Service.Application.Services.User;

public class UserService:IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<OperationResult> Add(Domain.Users.User entity)
    {
        try
        {
             _unitOfWork.Users.Add(entity);
             return new OperationResult(HttpStatusCode.OK , entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OperationResult(HttpStatusCode.BadRequest , null);
        }
    }

    public Task<OperationResult> Remove(Domain.Users.User entity)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> Update(Domain.Users.User entity)
    {
        throw new NotImplementedException();
    }
}