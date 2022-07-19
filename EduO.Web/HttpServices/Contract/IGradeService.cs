using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Web.HttpServices.Contract
{
    public interface IGradeService
    {
        Task<List<GradeDto>> GetGrades();
        Task CreateGrade(GradeDto grade);

        Task<GradeDto> GetGrade(int id);
        Task UpdateGrade(GradeDto grade);
        Task DeleteGrade(int id);
    }
}
