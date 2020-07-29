using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.BusinessLayer
{
   public interface IEmploymentBusiness
    {
        bool AddEmploymentBL(EmploymentInfo employmentInfo);
        EmploymentInfo GetEmploymentByIdBL(int id);
        bool UpdateEmploymentBL(EmploymentInfo employmenInfo);
    }
}
