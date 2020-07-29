using System;
using System.Collections.Generic;
using System.Text;
using MallMembership.Entities;

namespace MallMembership.BusinessLayer
{
   public interface IApplicantBusiness
    {
        bool AddApplicantBL(ApplicantInfo applicantInfo);
        ApplicantInfo GetApplicantByIdBL(int id);
        ApplicantInfo GetRecentApplicantBL();
        bool UpdateApplicantBL(ApplicantInfo applicantInfo);
  
    }
}
