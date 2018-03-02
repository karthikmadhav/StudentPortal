using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMPresentation.Models
{
    public class Menu
    {
        public int MID;
        public string MenuName;
        public string MenuURL;
        public int MenuParentID;
        public string ControllerName;
        public string ActionName;
        public string IconStyle;
    }
}