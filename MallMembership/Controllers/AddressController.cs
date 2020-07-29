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
   
    [MallWorflowFilter((int)WorkflowStages.ApplicantInfo, (int)WorkflowStages.AddressInfo)]
    public class AddressController : Controller
    {
        private readonly IStageBusiness getStageBusiness = new StageBusiness();
        private readonly IAddressBusiness _addressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }

        /// <summary>
        /// This is responsible for displaying form for adding and editing address details
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressInfo()
        {
            int highestCompletedStage = getStageBusiness.GetCompletedStage((int)Session["id"]);
            if(highestCompletedStage>=(int)WorkflowStages.AddressInfo)
            {
                AddressInfo addressInfo = _addressBusiness.GetAddressByIdBL((int)Session["id"]);
                Session["AddressId"] = addressInfo.AddressId;
                return View(addressInfo);
            }
            return View();
        }

        /// <summary>
        /// This is responsible for adding and editing address details into database
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAddressInfo([Bind(Include ="Country,State,City,Street")]AddressInfo addressInfo)
        {
            if (ModelState.IsValid)
            {
                addressInfo.ApplicantId = (int)Session["id"];
                _addressBusiness.AddAddressBL(addressInfo);

                return RedirectToAction(Constants.EmploymentInfo, "Employment");
            }
            return View(Constants.AddressInfo);
            
        }
    }
}