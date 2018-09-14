using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO.PTT.Admin;
using DTO.Util;
using BAL.PTT.Admin;
using System.Web.Script.Serialization;
using BAL.PTT.Util;
using System.Net.Http.Formatting;


namespace API.Controllers
{
    [RoutePrefix("api/UserAPI")]
    public class UserController : ApiController
    {
        PTTLDap lDap = null;
        UserDTO dto = null;
        JavaScriptSerializer json = null;
        string jsonString = "";
        UserDTO tempDTO = null;
        HttpResponseMessage httpResponseMsg = null;
        ResposeType response = null;
        string[] userTypeName = { "PTT", "PTT", "PTT", "Other" };
        string EncryptKey = System.Configuration.ConfigurationSettings.AppSettings["EncryptKey"];

        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Login()
        {


            try
            {
                json = new JavaScriptSerializer();
                response = new ResposeType();
                lDap = new PTTLDap();
                tempDTO = ConvertX.GetReqeustForm<UserDTO>();
                bool isAutorize = true;
                tempDTO.LDAP = true;
                if (tempDTO.UserType == "0" || tempDTO.UserType == "1" || tempDTO.UserType == "2")
                {
                    tempDTO.LDAP = lDap.Authenticated(userTypeName[ConvertX.ToInt(tempDTO.UserType)], tempDTO.UserLogin, tempDTO.Password);
                }
                //bool isAutorize = true;
                if (isAutorize && tempDTO.LDAP)
                {
                    dto = ConvertX.GetReqeustForm<UserDTO>();
                    dto.Password = DTO.Util.DEncrypt.encrypt(dto.Password, EncryptKey);
                    UserBAL bal = new UserBAL();
                    dto = bal.UserLogin(dto);

                    dto.LDAP = tempDTO.LDAP;
                   
                    jsonString = json.Serialize(dto);
                }
                else if (!tempDTO.LDAP)
                {
                    dto = new UserDTO();
                    dto.LDAP = tempDTO.LDAP;
                }

              
                if (dto != null)
                {
                    response.statusCode = true;
                    response.statusText = "Login Success";
                    response.data = dto;
                    httpResponseMsg = Request.CreateResponse(HttpStatusCode.OK, response);
                    /* httpResponseMsg.StatusCode = HttpStatusCode.OK;
                     httpResponseMsg.ReasonPhrase = "SUCCESS";
                     httpResponseMsg.Content = new StringContent(json.Serialize(dto), System.Text.Encoding.UTF8, "application/json");
                     */
                }
                else
                {
                    response.statusCode = false;
                    response.statusText = "Login Failed";
                    response.data = dto;
                    httpResponseMsg = Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {

                response.statusCode = false;
                response.statusText = "Login Failed";
                httpResponseMsg = Request.CreateResponse(HttpStatusCode.OK, response);
            }
            finally
            { }

            return httpResponseMsg;


        }

    }
}
