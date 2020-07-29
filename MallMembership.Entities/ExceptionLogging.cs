using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.Entities
{
   public class ExceptionLogging
    {
        public int ExceptionId { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExceptionStackTrack { get; set; }
        public DateTime ExceptionLogTime { get; set; }
    }
}
