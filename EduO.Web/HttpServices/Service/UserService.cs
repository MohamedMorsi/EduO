using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public UserService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<string> UploadUserImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("https://localhost:44325/api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:44325/", postContent);
                return imgUrl;
            }
        }
    }
}
