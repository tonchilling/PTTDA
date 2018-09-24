using BAL.PTT.Master;
using DTO.PTT.Master;
using DTO.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Position")]
    public class M_PositionController : ApiController
    {
        Logger logger = new Logger("M_PositionController");
        M_PositionBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            bal = new M_PositionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            List<M_PositionDTO> dataList = new List<M_PositionDTO>();
            
            M_PositionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_PositionDTO>();

                logger.debug("Search dto:" + dto.ToString());
                dataList = bal.FindByObjList(dto);
                response.statusCode = true;
                response.data = dataList;
            }
            catch (Exception ex)
            {
                logger.error("Search error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
        
        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            bal = new M_PositionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_PositionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_PositionDTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                logger.debug("Add dto:" + dto.ToString());
                response.statusCode = bal.Add(dto);
            }
            catch (Exception ex)
            {
                logger.error("Add error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
        
        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new M_PositionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_PositionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_PositionDTO>();

                logger.debug("Delete dto:" + dto.ToString());
                response.statusCode = bal.Delete(dto);
            }
            catch (Exception ex)
            {
                logger.error("Delete error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
    }
}