using MySchool.DataAccessLayer.Abstract;
using MySchool.DataAccessLayer.Context;
using MySchool.DataAccessLayer.Repositories;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DataAccessLayer.EntityFramework
{
    public class EFExamDal : GenericRepository<Exam>, IExamDal
    {
        public EFExamDal(MySchoolDbContext context) : base(context)
        {

        }
    }
}
