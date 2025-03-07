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
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public List<Lesson> GetAll()
        {
            return _lessonDal.GetAll();
        }

        public Lesson GetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _lessonDal.Delete(id);
        }

        public void TInsert(Lesson entity)
        {
            _lessonDal.Insert(entity);
        }

        public void TUpdate(Lesson entity)
        {
            _lessonDal.Update(entity);
        }
    }
}
