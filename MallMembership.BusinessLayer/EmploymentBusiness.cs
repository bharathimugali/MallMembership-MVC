using MallMembership.Entities;
using System;
using MallMemebership.DataLayer;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.BusinessLayer
{
    public class EmploymentBusiness : IEmploymentBusiness
    {
        private readonly IEmploymentDL _employmentDL;
        public EmploymentBusiness(IEmploymentDL employmentDL)
        {
            _employmentDL = employmentDL;
        }
        
        public bool AddEmploymentBL(EmploymentInfo employmentInfo)
        {
            try
            {
                bool result = _employmentDL.AddEmploymentDA(employmentInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmploymentInfo GetEmploymentByIdBL(int id)
        {
            try
            {
                EmploymentInfo employmentInfo = _employmentDL.GetEmploymentByIdDA(id);
                return employmentInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmploymentBL(EmploymentInfo employmenInfo)
        {
            try
            {
                bool result = _employmentDL.UpdateEmploymentDA(employmenInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
