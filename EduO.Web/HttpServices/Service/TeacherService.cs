using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class TeacherService : IBaseService<TeacherDto>
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public TeacherService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Teachers/getallasync");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var Teachers = JsonSerializer.Deserialize<List<TeacherDto>>(content, _options);
            return Teachers;
        }

        public async Task<TeacherDto> GetByIdAsync(object id)
        {
            var url = Path.Combine($"Teachers/getbyidasync/{id}");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var Teacher = JsonSerializer.Deserialize<TeacherDto>(content, _options);
            return Teacher;
        }

        public async Task CreateAsync(TeacherDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Teachers/createasync", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task Update(TeacherDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Teachers/UpdateAsync", entity.Id.ToString());

            var putResult = await _client.PutAsync(url, bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task Delete(object id)
        {
            var url = Path.Combine($"Teachers/DeleteAsync/{id}");

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
