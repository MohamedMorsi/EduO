﻿using AutoMapper;
using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<UserRegistrationModel, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

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