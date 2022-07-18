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

    }
}
