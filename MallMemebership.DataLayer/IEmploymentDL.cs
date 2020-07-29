using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMemebership.DataLayer
{
    public interface IEmploymentDL
    {
        bool AddEmploymentDA(EmploymentInfo employmentInfo);
        EmploymentInfo GetEmploymentByIdDA(int id);
        bool UpdateEmploymentDA(EmploymentInfo employmentInfo);
    }
}
