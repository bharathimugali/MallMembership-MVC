using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MallMembership.CustomBinder
{
    /// <summary>
    /// Custom modelbinder reponsible
    /// </summary>
    public class XMLToObjectModelBinder : IModelBinder
    {
        /// <summary>
        /// This is responsible for generating
        /// </summary>
        /// <param name="controllerContext">controllerContext</param>
        /// <param name="bindingContext">bindingContext</param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
               
                var model = bindingContext.ModelType;
                var data = new XmlSerializer(model);
                //get the data from Inputstream ex- xml data that is posted
                var receivedStream = controllerContext.HttpContext.Request.InputStream;
                return data.Deserialize(receivedStream);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError("Error", "Received Model cannot be serialized");
                return null;
            }
        }
    }
}