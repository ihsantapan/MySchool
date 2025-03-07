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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public List<Teacher> GetAll()
        {
            return _teacherDal.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _teacherDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _teacherDal.Delete(id);
        }

        public void TInsert(Teacher entity)
        {
            _teacherDal.Insert(entity);
        }

        public void TUpdate(Teacher entity)
        {
            _teacherDal.Update(entity);
        }
    }
}
