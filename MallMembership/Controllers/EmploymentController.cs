using MallMembership.BusinessLayer;
using MallMembership.CustomFilter;
using MallMembership.Entities;
using MallMembership.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MallMembership.MallWorkflowStages;

namespace MallMembership.Controllers
{
   
    [MallWorflowFilter((int)WorkflowStages.AddressInfo, (int)WorkflowStages.EmploymentInfo)]
    public class EmploymentController : Controller
    {
        private readonly IStageBusiness getStageBusiness = new StageBusiness();
        private readonly IEmploymentBusiness _employmentBusiness ;
       public EmploymentController(IEmploymentBusiness employmentBusiness)
        {
            _employmentBusiness = employmentBusiness;
        }

        /// <summary>
        /// This is responsible for displaying form for adding and editing employment details
        /// </summary>
        /// <returns></returns>
        public ActionResult EmploymentInfo()
        {
            int highestCompletedStage = getStageBusiness.GetCompletedStage((int)Session["id"]);
            if (highestCompletedStage >= (int)WorkflowStages.EmploymentInfo)
            {
                EmploymentInfo employmentInfo = _employmentBusiness.GetEmploymentByIdBL((int)Session["id"]);
                return View(employmentInfo);
            }
            return View();
        }

        /// <summary>
        /// This is responsible for adding and editing employment details into database
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEmploymentInfo(EmploymentInfo employmentInfo)
        {
           
                employmentInfo.ApplicantId = (int)Session["id"];
                _employmentBusiness.AddEmploymentBL(employmentInfo);
            
            return RedirectToAction(Constants.MembershipInfo, "Membership");
        }
    }
}