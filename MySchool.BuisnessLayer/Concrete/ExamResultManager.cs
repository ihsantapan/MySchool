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
    public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultDal _examResultDal;

        public ExamResultManager(IExamResultDal examResultDal)
        {
            _examResultDal = examResultDal;
        }

        public List<ExamResult> GetAll()
        {
            return _examResultDal.GetAll();
        }

        public ExamResult GetById(int id)
        {
            return _examResultDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _examResultDal.Delete(id);
        }

        public void TInsert(ExamResult entity)
        {
            _examResultDal.Insert(entity);
        }

        public void TUpdate(ExamResult entity)
        {
            _examResultDal.Update(entity);
        }
    }
}
