using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class CourseTypeService : IBaseService<CourseTypeDto>
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CourseTypeService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<CourseTypeDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("CourseTypes/getallasync");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var CourseTypes = JsonSerializer.Deserialize<List<CourseTypeDto>>(content, _options);
            return CourseTypes;
        }

        public async Task<CourseTypeDto> GetByIdAsync(object id)
        {
            var url = Path.Combine($"CourseTypes/getbyidasync/{id}");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var CourseType = JsonSerializer.Deserialize<CourseTypeDto>(content, _options);
            return CourseType;
        }

        public async Task CreateAsync(CourseTypeDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("CourseTypes/createasync", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task Update(CourseTypeDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("CourseTypes/UpdateAsync", entity.Id.ToString());

            var putResult = await _client.PutAsync(url, bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task Delete(object id)
        {
            var url = Path.Combine($"CourseTypes/DeleteAsync/{id}");

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
