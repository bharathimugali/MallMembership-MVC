using MallMembership.BusinessLayer;
using MallMembership.CustomFilter;
using MallMembership.Entities;
using MallMembership.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static MallMembership.MallWorkflowStages;

namespace MallMembership.Controllers
{
    [MallWorflowFilter((int)WorkflowStages.Begin,(int)WorkflowStages.ApplicantInfo)]
    public class ApplicantController : Controller
    {
        private readonly IApplicantBusiness _applicantBusiness;
  
        public ApplicantController(IApplicantBusiness applicantBusiness)
        {
            _applicantBusiness = applicantBusiness;
        }

        /// <summary>
        /// This is responsible for displaying form for adding and editing applicant details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApplicantInfo()
        {
            try
            {
                if (Session["id"] == null)
                {
                    return View();
                }
                else
                {
                    ApplicantInfo applicantInfo = _applicantBusiness.GetApplicantByIdBL((int)Session["id"]);
                    return View(applicantInfo);
                }
            }
            catch(Exception ex)
            {
                return View(Constants.ErrorView);
            }

        }

        /// <summary>
        /// This is responsible for adding and editing applicant details into database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddApplicantInfo([Bind(Include = "FirstName,LastName,PhoneNumber,Email")]ApplicantInfo applicantInfo)
        {
            if (ModelState.IsValid)
            {

                applicantInfo.UserAgent = HttpContext.Request.UserAgent;
                applicantInfo.ContentType = HttpContext.Request.ContentType;
                applicantInfo.IPAddress = HttpContext.Request.UserHostAddress;
                
                var val = Session["id"];
                if (val == null)
                {
                    if (_applicantBusiness.AddApplicantBL(applicantInfo))
                    {
                        ApplicantInfo applicant = _applicantBusiness.GetRecentApplicantBL();
                        Session["id"] = applicant.ApplicantId;
                    }
                }
                else
                {
                    _applicantBusiness.UpdateApplicantBL(applicantInfo);
                }

                return RedirectToAction(Constants.AddressInfo, "Address");
            }
            return View(Constants.ApplicantInfo);
        }
       
           
        }
    }
