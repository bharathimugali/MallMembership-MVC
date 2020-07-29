using MallMembership.BusinessLayer;
using MallMembership.Entities;
using MallMembership.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static MallMembership.MallWorkflowStages;

namespace MallMembership.CustomFilter
{
    /// <summary>
    /// Custom Action Filter that controls the redirection based on highest Completed stage
    /// </summary>
    public class MallWorflowFilter : FilterAttribute, IActionFilter
    {
      
        private readonly int minRequiredStage;
        private readonly int currentStage;
        private readonly IApplicantBusiness _applicantBusiness=new ApplicantBusiness();
        private int highestCompletedStage;
       
        public MallWorflowFilter(int minReq, int curr)
        {
            this.minRequiredStage = minReq;
            this.currentStage = curr;
          
        }
        
        IStageBusiness _stageBusiness = new StageBusiness();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ApplicantId = filterContext.HttpContext.Session["id"];
            if (ApplicantId!= null)
            {
                highestCompletedStage = _stageBusiness.GetCompletedStage((int)ApplicantId);
                if(filterContext.HttpContext.Request.RequestType=="POST" && currentStage>highestCompletedStage)
                {
                    _stageBusiness.UpdateCompleteStage((int)ApplicantId,currentStage);
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
         
            if (filterContext.HttpContext.Session["id"] == null)
            {
                if (currentStage != (int)WorkflowStages.ApplicantInfo)
                {
                    
                    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new RedirectResult(urlHelper.Action(Constants.ApplicantInfo, "Applicant"));
                }
            }
            else
            {
                
                ApplicantInfo applicant = _applicantBusiness.GetApplicantByIdBL((int)filterContext.HttpContext.Session["id"]);
                highestCompletedStage = applicant.HighestCompletedStage;
                filterContext.HttpContext.Session["high"] = highestCompletedStage;
                if (minRequiredStage ==highestCompletedStage)
                {

                }
               else if (minRequiredStage > highestCompletedStage)
                {
                    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                    switch (minRequiredStage)
                    {
                        case 10:
                            filterContext.Result = new RedirectResult(urlHelper.Action(Constants.ApplicantInfo, "Applicant"));
                            break;
                        case 20:
                            filterContext.Result = new RedirectResult(urlHelper.Action(Constants.AddressInfo, "Address"));
                            break;
                        case 30:
                            filterContext.Result = new RedirectResult(urlHelper.Action(Constants.EmploymentInfo, "Employment"));
                            break;
                        case 40:
                            filterContext.Result = new RedirectResult(urlHelper.Action(Constants.MembershipInfo, "Membership"));
                            break;
                    }
                }
            }

               
            
          }
}
}
    
