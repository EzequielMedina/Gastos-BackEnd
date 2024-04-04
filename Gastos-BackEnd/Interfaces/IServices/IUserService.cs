using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface IUserService
    {
        ResponseBase NewUser(UserRequest request);
        ResponseBase UserAuth(AuthRequest req);
    }
}
