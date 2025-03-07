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
    public class SchoolManager : ISchoolService
    {
        private readonly ISchoolDal _schoolDal;


        public SchoolManager(ISchoolDal schoolDal)
        {
            _schoolDal = schoolDal;
        }

        public List<School> GetAll()
        {
            return _schoolDal.GetAll();
        }

        public School GetById(int id)
        {
            return _schoolDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _schoolDal.Delete(id);
        }

        public void TInsert(School entity)
        {
            _schoolDal.Insert(entity);
        }

        public void TUpdate(School entity)
        {
            _schoolDal.Update(entity);
        }
    }
}
