using System;
using System.Collections.Generic;
using System.Text;
using MallMembership.Entities;
using MallMemebership.DataLayer;

namespace MallMembership.BusinessLayer
{
   public class ApplicantBusiness:IApplicantBusiness
    {
        private readonly IApplicantDL _applicantDL = new ApplicantDL();
       
        
        public bool AddApplicantBL(ApplicantInfo applicantInfo)
        {
            try
            {
                bool result = _applicantDL.AddApplicantDA(applicantInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateApplicantBL(ApplicantInfo applicantInfo)
        {
            try
            {
                bool result = _applicantDL.UpdateApplicantDA(applicantInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicantInfo GetRecentApplicantBL()
        {
            try
            {
                ApplicantInfo applicantInfo = _applicantDL.GetRecentApplicantDA();
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ApplicantInfo GetApplicantByIdBL(int id)
        {
            try
            {
                ApplicantInfo applicantInfo = _applicantDL.GetApplicantByIdDA(id);
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
