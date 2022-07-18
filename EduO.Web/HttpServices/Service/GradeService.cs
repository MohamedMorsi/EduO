using EduO.Core.Dtos;
using EduO.Web.HttpServices.Contract;
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


    }
}
