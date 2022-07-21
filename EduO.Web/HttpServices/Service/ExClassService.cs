using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class ExClassService : IBaseService<ExClassDto>
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ExClassService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<ExClassDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("exClass/getallasync");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var ExClassDtos = JsonSerializer.Deserialize<List<ExClassDto>>(content, _options);
            return ExClassDtos;
        }

        public async Task<ExClassDto> GetByIdAsync(params object?[]? id)
        {
            var url = Path.Combine($"exClass/getbyidasync/{id}");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var ExClassDtos = JsonSerializer.Deserialize<ExClassDto>(content, _options);
            return ExClassDtos;
        }

        public async Task CreateAsync(ExClassDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("exClass/createasync", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task Update(ExClassDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("grades/update", entity.Id.ToString());

            var putResult = await _client.PutAsync(url, bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task Delete(params object?[]? id)
        {
            var url = Path.Combine($"exClass/delete/{id}");

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
