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
    public class AssignmentSubmissionManager : IAssignmentSubmissionService
    {
        private readonly IAssigmentSubmissionDal _assigmentSubmissionDal;

        public AssignmentSubmissionManager(IAssigmentSubmissionDal assigmentSubmissionDal)
        {
            _assigmentSubmissionDal = assigmentSubmissionDal;
        }

        public List<AssignmentSubmission> GetAll()
        {
            return _assigmentSubmissionDal.GetAll();
        }

        public AssignmentSubmission GetById(int id)
        {
            return _assigmentSubmissionDal.GetById(id);
        }

        public void TDelete(int id)
        {
            _assigmentSubmissionDal.Delete(id);
        }

        public void TInsert(AssignmentSubmission entity)
        {
            _assigmentSubmissionDal.Insert(entity);
        }

        public void TUpdate(AssignmentSubmission entity)
        {
            _assigmentSubmissionDal.Update(entity);
        }
    }
}
