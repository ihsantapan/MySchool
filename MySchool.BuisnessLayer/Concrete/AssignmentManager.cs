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
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssigmentDal _assigmentDal;

        public AssignmentManager(IAssigmentDal assigmentDal)
        {
            _assigmentDal = assigmentDal;
        }

        public List<Assignment> GetAll()
        {
            return _assigmentDal.GetAll();
        }

        public Assignment GetById(int id)
        {
            return _assigmentDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _assigmentDal.Delete(id);
        }

        public void TInsert(Assignment entity)
        {
            _assigmentDal.Insert(entity);
        }

        public void TUpdate(Assignment entity)
        {
            _assigmentDal.Update(entity);
        }
    }
}
