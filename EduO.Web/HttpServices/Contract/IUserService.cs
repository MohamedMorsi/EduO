using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Web.HttpServices.Contract
{
    public interface IUserService
    {
        Task<string> UploadUserImage(MultipartFormDataContent content);
    }
}
