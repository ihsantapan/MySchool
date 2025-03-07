using AutoMapper;
using MySchool.BuisnessLayer.Concrete;
using MySchool.DtoLayer.Dtos.Assigment;
using MySchool.DtoLayer.Dtos.AssigmentDtos;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.DtoLayer.Dtos.AssignmentSubmissionDtos;
using MySchool.DtoLayer.Dtos.Class;
using MySchool.DtoLayer.Dtos.ClassDtos;
using MySchool.DtoLayer.Dtos.ExamDtos;
using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.DtoLayer.Dtos.LessonDtos;
using MySchool.DtoLayer.Dtos.PrincipalDtos;
using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.SchoolDtos;
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
            CreateMap<Class,ClassResultDto>().ReverseMap();
            CreateMap<Class,ClassGetByIdDto>().ReverseMap();

            CreateMap<Assignment, AssignmentCreateDto>().ReverseMap();
            CreateMap<Assignment, AssignmentUpdateDto>().ReverseMap();
            CreateMap<Assignment, AssignmentResultDto>().ReverseMap();
            CreateMap<Assignment, AssignmentGetByIdDto>().ReverseMap();

            CreateMap<AssignmentSubmission, AssignmentSubmissionCreateDto>().ReverseMap();
            CreateMap<AssignmentSubmission, AssignmentSubmissionUpdateDto>().ReverseMap();
            CreateMap<AssignmentSubmission, AssignmentSubmissionResultDto>().ReverseMap();
            CreateMap<AssignmentSubmission, AssignmentSubmissionGetByIdDto>().ReverseMap();

            CreateMap<Exam, ExamCreateDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();
            CreateMap<Exam, ExamResultDto>().ReverseMap();
            CreateMap<Exam, ExamGetByIdDto>().ReverseMap();

            CreateMap<ExamResult, ExamResultCreateDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultUpdateDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultResultDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultGetByIdDto>().ReverseMap();

            CreateMap<Lesson, LessonCreateDto>().ReverseMap();
            CreateMap<Lesson, LessonUpdateDto>().ReverseMap();
            CreateMap<Lesson, LessonResultDto>().ReverseMap();
            CreateMap<Lesson, LessonGetByIdDto>().ReverseMap();

            CreateMap<Principal, PrincipalCreateDto>().ReverseMap();
            CreateMap<Principal, PrincipalUpdateDto>().ReverseMap();
            CreateMap<Principal, PrincipalResultDto>().ReverseMap();
            CreateMap<Principal, PrincipalGetByIdDto>().ReverseMap();

            CreateMap<School, SchoolCreateDto>().ReverseMap();
            CreateMap<School, SchoolUpdateDto>().ReverseMap();
            CreateMap<School, SchoolResultDto>().ReverseMap();
            CreateMap<School, SchoolGetByIdDto>().ReverseMap();

            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<Student, StudentResultDto>().ReverseMap();
            CreateMap<Student, StudentGetByIdDto>().ReverseMap();

            CreateMap<Teacher, TeacherCreateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
            CreateMap<Teacher, TeacherResultDto>().ReverseMap();
            CreateMap<Teacher, TeacherGetByIdDto>().ReverseMap();

        }
    }
}
