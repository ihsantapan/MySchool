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
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public List<Exam> GetAll()
        {
            return _examDal.GetAll();
        }

        public Exam GetById(int id)
        {
            return _examDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _examDal.Delete(id);
        }

        public void TInsert(Exam entity)
        {
            _examDal.Insert(entity);
        }

        public void TUpdate(Exam entity)
        {
            _examDal.Update(entity);
        }
    }
}
