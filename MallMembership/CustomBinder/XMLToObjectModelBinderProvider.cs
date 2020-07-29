using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallMembership.CustomBinder
{
    public class XMLToObjectModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            
            var receivedContentType = HttpContext.Current.Request.ContentType.ToLower();
            if (receivedContentType != "text/xml")
            {
                return null;
            }

            return new XMLToObjectModelBinder();
        }
    }
}