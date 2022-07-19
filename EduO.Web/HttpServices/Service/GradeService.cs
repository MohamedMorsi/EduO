using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
using System.Text;
using System.Text.Json;

namespace EduO.Web.HttpServices.Service
{
    public class GradeService : IGradeService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public GradeService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<List<GradeDto>> GetGrades()
        {
            var response = await _client.GetAsync("grades");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var grades = JsonSerializer.Deserialize<List<GradeDto>>(content, _options);
            return grades;
        }


        public async Task CreateGrade(GradeDto grade)
        {
            var content = JsonSerializer.Serialize(grade);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("grades", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<GradeDto> GetGrade(int id)
        {
            var url = Path.Combine($"grades/{id}");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var grade = JsonSerializer.Deserialize<GradeDto>(content, _options);
            return grade;
        }
        public async Task UpdateGrade(GradeDto grade)
        {
            var content = JsonSerializer.Serialize(grade);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("grades", grade.Id.ToString());

            var putResult = await _client.PutAsync(url, bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task DeleteGrade(int id)
        {
            var url = Path.Combine($"grades/{id}");

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
