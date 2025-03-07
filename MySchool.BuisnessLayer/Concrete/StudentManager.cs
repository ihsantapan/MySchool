using MySchool.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public List<Student> GetAll()
        {
            return _studentDal.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _studentDal.Delete(id);
        }

        public void TInsert(Student entity)
        {
            _studentDal.Insert(entity);
        }

        public void TUpdate(Student entity)
        {
            _studentDal.Update(entity);
        }
    }
}
