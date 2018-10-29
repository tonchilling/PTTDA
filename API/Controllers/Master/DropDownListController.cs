using BAL.PTT.Util;
using DTO.PTT.Util;
using DTO.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/DropDownList")]
    public class DropDownListController : ApiController
    {
        Logger logger = new Logger("DropDownListController");

        [HttpPost]
        [Route("GetTableData")]
        public HttpResponseMessage GetTableData()
        {
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                string tableName = context.Request.Form["table"];
                string userID = context.Request.Form["UserID"];
                
                logger.debug("DropDownList GetTableData input : tableName[" + tableName + "] UserID[" + userID + "]");

                DropDownListBAL bal = new DropDownListBAL();                
                List<DropDownListDTO> dataList = bal.FindByObjList(tableName, userID);

                response.statusCode = true;
                response.data = dataList;
            }
            catch (Exception ex)
            {
                logger.error("DropDownList GetTableData error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }        
    }
}