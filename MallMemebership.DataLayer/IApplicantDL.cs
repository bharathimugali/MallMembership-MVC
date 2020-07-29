using System;
using System.Collections.Generic;
using System.Text;
using MallMembership.Entities;

namespace MallMemebership.DataLayer
{
   public interface IApplicantDL
    {
        bool AddApplicantDA(ApplicantInfo applicantInfo);
        ApplicantInfo GetRecentApplicantDA();
        ApplicantInfo GetApplicantByIdDA(int id);
        bool UpdateApplicantDA(ApplicantInfo applicantInfo);
     

        List<CustomApplicant> GetApplicants();
    }
}
