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
    public class ClassManager : IClassService
    {
        private readonly IClassDal _classDal;

        public ClassManager(IClassDal classDal)
        {
            _classDal = classDal;
        }

        public List<Class> GetAll()
        {
            return _classDal.GetAll();
        }

        public Class GetById(int id)
        {
            return _classDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _classDal.Delete(id);
        }

        public void TInsert(Class entity)
        {
            _classDal.Insert(entity);
        }

        public void TUpdate(Class entity)
        {
            _classDal.Update(entity);
        }
    }
}
