using System.Net;
using Application.Utils;
using Authentication_Service.Application.Interfaces;
using Authentication_Service.Application.Utils;
using AutoMapper;
using Domain.Entities.Users;

namespace Authentication_Service.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Add(UserRequest entity)
    {
        try
        {
            if (!_unitOfWork.Users.IsExistsUser(entity.Email, entity.Mobile))
            {
                // set values
                entity.IsActive = false;
                entity.RegisterDate = DateTime.Now;
                entity.VerifyCode = Random.Shared.Next(10000, 99999).ToString();
                entity.VerifyCodeCreateDate = DateTime.Now;
                entity.Password = HasheCodeHelper.Calculate256Hash(entity.Password);
                entity.Role = _unitOfWork.Roles.GetById(entity.RoleId);

                // map to user model
                var user = _mapper.Map<Domain.Entities.Users.User>(entity);

                _unitOfWork.Users.Add(user);

                //map to user response model
                var userResponse = _mapper.Map<UserResponse>(user);
                return new OperationResult(HttpStatusCode.OK, userResponse);
            }
            return new OperationResult(HttpStatusCode.NotAcceptable, "شماره تماس یا ایمیل وارد شده تکراری است !");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OperationResult(HttpStatusCode.BadRequest, e);
        }
    }

    public async Task<OperationResult> Get(int id)
    {
        try
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user is null)
            {
                return new OperationResult(HttpStatusCode.NotAcceptable, "متاسفانه اطلاعات خواسته شده یافت نشد.");
            }
            var userResponse = _mapper.Map<UserResponse>(user);

            return new OperationResult(HttpStatusCode.OK, userResponse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OperationResult(HttpStatusCode.BadRequest, e);
        }
    }

    public async Task<OperationResult> Remove(int id)
    {
        try
        {
            var user = _unitOfWork.Users.GetById(id);
            if (!(user is null))
            {
                // remove the user
                _unitOfWork.Users.Remove(user);

                return new OperationResult(HttpStatusCode.OK, "عملیات با موفقیت انجام شد.");
            }
            return new OperationResult(HttpStatusCode.NotAcceptable, "متاسفانه اطلاعات خواسته شده یافت نشد.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OperationResult(HttpStatusCode.BadRequest, e);
        }
    }

    public async Task<OperationResult> Update(UserRequest entity)
    {
        try
        {
            var user = _unitOfWork.Users.GetById(entity.UserId);
            if (!(user is null))
            {
                // set values
                user.Password = HasheCodeHelper.Calculate256Hash(entity.Password);
                user.Role = _unitOfWork.Roles.GetById(entity.RoleId);
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.Mobile = entity.Mobile;

                // update the model
                _unitOfWork.Users.Update(user);

                //map to user response model
                var userResponse = _mapper.Map<UserResponse>(user);
                return new OperationResult(HttpStatusCode.OK, userResponse);
            }
            return new OperationResult(HttpStatusCode.NotAcceptable, "متاسفانه اطلاعات خواسته شده یافت نشد.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OperationResult(HttpStatusCode.BadRequest, e);
        }
    }
}