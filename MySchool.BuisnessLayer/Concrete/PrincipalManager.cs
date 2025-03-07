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
    public class PrincipalManager : IPrincipalService
    {
        private readonly IPrincipalDal _principalDal;

        public PrincipalManager(IPrincipalDal principalDal)
        {
            _principalDal = principalDal;
        }

        public List<Principal> GetAll()
        {
            return _principalDal.GetAll();
        }

        public Principal GetById(int id)
        {
            return _principalDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _principalDal.Delete(id);
        }

        public void TInsert(Principal entity)
        {
            _principalDal.Insert(entity);
        }

        public void TUpdate(Principal entity)
        {
            _principalDal.Update(entity);
        }
    }
}
