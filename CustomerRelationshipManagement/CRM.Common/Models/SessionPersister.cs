using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CRM.Common.Models
{
   public static class SessionPersister
    {
        public static int userID=0;
        public static string sessionValue;
        public static IEnumerable<Menu> _MenuList;
        public static int _userID
        {
            get
            {
                if (HttpContext.Current.Session["_UserID"] == null)
                {
                    return userID;
                }
                else
                {
                    sessionValue = HttpContext.Current.Session["_UserID"].ToString();
                    if (sessionValue != null && sessionValue != string.Empty)
                        userID= Convert.ToInt32(sessionValue);
                }
                return userID;
            }
            set
            {
                HttpContext.Current.Session["_UserID"] = value;
            }
        }
        public static IEnumerable<Menu> MenuList
        {
            get
            {
                if (HttpContext.Current.Session["_Menu"] == null)
                {
                    return _MenuList;
                }
                else
                {
                    _MenuList = (IEnumerable<Menu>)HttpContext.Current.Session["_Menu"];
                }
                    return _MenuList;
            }
            set
            {
                HttpContext.Current.Session["_Menu"] = value;
            }
        }
    }
}
