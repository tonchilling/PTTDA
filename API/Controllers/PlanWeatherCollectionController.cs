using BAL.PTT.Plan;
using DTO.PTT.Plan;
using DTO.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    [RoutePrefix("api/PlanWeatherCollection")]
    public class PlanWeatherCollectionController : ApiController
    {
        Logger logger = new Logger("PlanWeatherCollectionController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["WeatherCollectionPath"];
        T_Planing_WeatherCollectionBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_WeatherCollectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_WeatherCollectionDTO dto = null;
            List<T_Planing_WeatherCollectionDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();

                logger.debug("Search dto:" + dto.ToString());
                objList = bal.FindByObjList(dto);

                response.statusCode = true;
                response.data = objList;
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
        [Route("View")]
        public HttpResponseMessage View()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_WeatherCollectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_WeatherCollectionDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();

                logger.debug("View dto:" + dto.ToString());
                dto = bal.FindByPK(dto);

                response.statusCode = true;
                response.data = dto;
            }
            catch (Exception ex)
            {
                logger.error("View error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            T_Planing_WeatherCollectionMobileBAL mobileBal = new T_Planing_WeatherCollectionMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_WeatherCollectionMobileDTO mobileDto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                mobileDto = ConvertX.GetReqeustFormExactly<T_Planing_WeatherCollectionMobileDTO>();

                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                mobileDto.CreateBy = UserID;
                mobileDto.UpdateBy = UserID;

                logger.debug("api/PlanWeatherCollection Add dto:" + mobileDto.ToString());
                response.statusCode = mobileBal.AddFromMobile(mobileDto);
                if (response.statusCode)
                {
                    response.statusText = "Success";
                } 
            }
            catch (Exception ex)
            {
                logger.error("api/PlanWeatherCollection Add error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_Planing_WeatherCollectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_WeatherCollectionDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();

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