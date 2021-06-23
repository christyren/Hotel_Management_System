using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
   public interface IUserService
    {
        Task<UserLoginResponseModel> Login(string email, string password);
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);
    }
}
