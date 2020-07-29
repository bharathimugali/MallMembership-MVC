using MallMembership.CustomFilter;
using MallMembership.Entities;
using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallMembership.Controllers
{
    public class HomeController : Controller
    {
        public XmlResult Index()
        {
            IApplicantDL _applicantDL = new ApplicantDL();
            List<CustomApplicant> applicants = _applicantDL.GetApplicants() ;
            return new XmlResult(applicants);
        }

        public CsvActionResult<CustomApplicant> csvIndex()
        {
            IApplicantDL _applicantDL = new ApplicantDL();
            List<CustomApplicant > applicants = _applicantDL.GetApplicants();
            return new CsvActionResult<CustomApplicant>(applicants, "ApplicantDetails.csv");
        }


    }
}