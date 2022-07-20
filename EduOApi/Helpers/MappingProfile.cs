using AutoMapper;
using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ExClass
            CreateMap<ExClassDto, ExClass>().ReverseMap();


            //User
            CreateMap<UserRegistrationFormDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
            .ForMember(u => u.Password, opt => opt.MapFrom(x => x.Password));

            //Grade
            CreateMap<GradeDto, Grade>().ReverseMap();

            //Student
            CreateMap<Student, StudentDetailsDto>()
                .ForMember(dst => dst.GradeName, opt => opt.MapFrom(src => src.Grade.Name));
            CreateMap<StudentDto, Student>();
                //.ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}