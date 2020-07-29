using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MallMembership
{
    public static class MallWorkflowStages
    {
        public enum WorkflowStages
        {
            Begin=0,
            ApplicantInfo=10,
            AddressInfo=20,
            EmploymentInfo=30,
            MembershipInfo=40

        }
    }
}