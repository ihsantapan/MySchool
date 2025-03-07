using MyAssignment.BuisnessLayer.Abstract;
using MyAssignment.BuisnessLayer.Concrete;
using MyAssignmentSubmission.BuisnessLayer.Concrete;
using MyClass.BuisnessLayer.Concrete;
using MyExamResult.BuisnessLayer.Concrete;
using MyLesson.BuisnessLayer.Abstract;
using MyLesson.BuisnessLayer.Concrete;
using MyPrincipal.BuisnessLayer.Abstract;
using MyPrincipal.BuisnessLayer.Concrete;
using MySchool.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.Concrete;
using MySchool.BuisnessLayer.Mapping;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DataAccessLayer.Context;
using MySchool.DataAccessLayer.EntityFramework;
using MyStudent.BuisnessLayer.Abstract;
using MyStudent.BuisnessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MySchoolDbContext>();

builder.Services.AddAutoMapper(typeof(GeneralMapping));


builder.Services.AddScoped<IClassDal, EFClassDal>();
builder.Services.AddScoped<IClassService, ClassManager>();

builder.Services.AddScoped<IAssignmentDal, EFAssigmentDal>();
builder.Services.AddScoped<IAssignmentService, AssignmentManager>();

builder.Services.AddScoped<IAssignmentSubmissionDal, EFAssigmentSubmissionDal>();
builder.Services.AddScoped<IAssignmentSubmissionService, AssignmentSubmissionManager>();

builder.Services.AddScoped<IExamDal, EFExamDal>();
builder.Services.AddScoped<IExamService, ExamManager>();

builder.Services.AddScoped<IExamResultDal, EFExamResultDal>();
builder.Services.AddScoped<IExamResultService, ExamResultManager>();

builder.Services.AddScoped<ILessonDal, EFLessonDal>();
builder.Services.AddScoped<ILessonService, LessonManager>();

builder.Services.AddScoped<IPrincipalDal, EFPrincipalDal>();
builder.Services.AddScoped<IPrincipalService, PrincipalManager>();

builder.Services.AddScoped<ISchoolDal, EFSchoolDal>();
builder.Services.AddScoped<ISchoolService, SchoolManager>();

builder.Services.AddScoped<IStudentDal, EFStudentDal>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddScoped<ITeacherDal, EFTeacherDAl>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
