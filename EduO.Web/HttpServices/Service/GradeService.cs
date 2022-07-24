using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class GradeService : IBaseService<GradeDto>
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public GradeService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<GradeDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("grades/getallasync");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var grades = JsonSerializer.Deserialize<List<GradeDto>>(content, _options);
            return grades;
        }

        public async Task<GradeDto> GetByIdAsync(object id)
        {
            var url = Path.Combine($"grades/getbyidasync/{id}");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var grade = JsonSerializer.Deserialize<GradeDto>(content, _options);
            return grade;
        }

        public async Task CreateAsync(GradeDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("grades/createasync", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task Update(GradeDto entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("grades/UpdateAsync", entity.Id.ToString());

            var putResult = await _client.PutAsync(url, bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task Delete(object id)
        {
            var url = Path.Combine($"grades/DeleteAsync/{id}");

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
