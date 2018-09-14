using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;


    /// <summary>
    /// Summary description for BaseServices
    /// </summary>
    public  class AppConfig 
{

 

          public static  UserDTO GetUserLogin()
    {
              UserDTO userDto=null;
        if (HttpContext.Current.Session["UserLogin"] != null)
        {
            userDto=(UserDTO)HttpContext.Current.Session["UserLogin"];
        }

              return userDto;
      
    }



}

