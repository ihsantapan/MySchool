using AutoMapper;
using MySchool.DtoLayer.Dtos.Assigment;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.DtoLayer.Dtos.Class;
using MySchool.DtoLayer.Dtos.ExamDtos;
using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.DtoLayer.Dtos.LessonDtos;
using MySchool.DtoLayer.Dtos.PrincipalDtos;
using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.StudentDtos;
using MySchool.DtoLayer.Dtos.TeacherDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Class,ClassCreateDto>().ReverseMap();
            CreateMap<Class,ClassUpdateDto>().ReverseMap();

            CreateMap<Assignment, AssignmentCreateDto>().ReverseMap();
            CreateMap<Assignment, AssignmentUpdateDto>().ReverseMap();

            CreateMap<AssignmentSubmission, AssignmentSubmissionCreateDto>().ReverseMap();
            CreateMap<AssignmentSubmission, AssignmentSubmissionUpdateDto>().ReverseMap();

            CreateMap<Exam, ExamCreateDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();

            CreateMap<ExamResult, ExamResultCreateDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultUpdateDto>().ReverseMap();

            CreateMap<Lesson, LessonCreateDto>().ReverseMap();
            CreateMap<Lesson, LessonUpdateDto>().ReverseMap();

            CreateMap<Principal, PrincipalCreateDto>().ReverseMap();
            CreateMap<Principal, PrincipalUpdateDto>().ReverseMap();

            CreateMap<School, SchoolCreateDto>().ReverseMap();
            CreateMap<School, SchoolUpdateDto>().ReverseMap();

            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<Teacher, TeacherCreateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();

        }
    }
}
