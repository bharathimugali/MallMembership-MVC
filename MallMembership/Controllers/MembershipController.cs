using MallMembership.BusinessLayer;
using MallMembership.CustomFilter;
using MallMembership.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallMembership.Controllers
{
    
    [MallWorflowFilter((int)MallWorkflowStages.WorkflowStages.EmploymentInfo, (int)MallWorkflowStages.WorkflowStages.MembershipInfo)]
    public class MembershipController : Controller
    {
        private readonly IEmploymentBusiness _employmentBusiness;
        public MembershipController(IEmploymentBusiness employmentBusiness)
        {
            _employmentBusiness = employmentBusiness;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult MembershipInfo()
        {

          EmploymentInfo employmentInfo=  _employmentBusiness.GetEmploymentByIdBL((int)Session["id"]);
            if(employmentInfo.EmploymentType=="UnEmployed")
            {
                ViewBag.Message = "You are not Eligible for Mall Membership";
            }
            else
            {
                ViewBag.Message = "Congratulations! You are a Member";
            }
           
            Session.Clear();
            return View();
        }

        
    }
}