using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Web.HttpServices.Contract
{
    public interface IGradeService
    {
        Task<List<GradeDto>> GetGrades();
        Task CreateGrade(GradeDto grade);
    }
}
