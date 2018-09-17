using BAL.PTT.Plan;
using DTO.PTT;
using DTO.PTT.Plan;
using DTO.PTT.Report;
using DTO.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    [RoutePrefix("api/PlanSpecPO")]
    public class PlanSpecPOController : ApiController
    {
        Logger logger = new Logger("PlanSpecPOController");
        T_Planing_SpecPOBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {            
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_SpecPODTO dto = null;
            List<T_Planing_SpecPODTO> objList = null;

            try
            {
                var context = HttpContext.Current;
                
                dto = ConvertX.GetReqeustFormExactly<T_Planing_SpecPODTO>();
                bal = new T_Planing_SpecPOBAL();

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
        [Route("GetPlan")]
        public HttpResponseMessage GetPlan()
        {
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_SpecPODTO dto = null;

            try
            {
                var context = HttpContext.Current;
                dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();
                bal = new T_Planing_SpecPOBAL();

                logger.debug("View dto:" + dto.ToString());
                dto = bal.FindByObjHistory(dto);

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
            T_Planing_SpecPODTO dto = null;
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;
                List<ResponseDTO> responseList = Validate(context);

                if (responseList.Count == 0)
                {
                    dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();
                    bal = new T_Planing_SpecPOBAL();

                    string UserID = context.Request.Form["UserID"];
                    if (ObjUtil.isEmpty(UserID))
                    {
                        throw new Exception("UserID is require");
                    }
                    dto.CreateBy = UserID;
                    dto.UpdateBy = UserID;
                    string currentDate = string.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString("##00")
                                                         , DateTime.Now.Month.ToString("##00")
                                                         , DateTime.Now.Year.ToString("####0000"));
                    string startDate = dto.EventDate;
                    string endDate = dto.EventDate;

                    if (dto.PlanType == "2") // spec
                    {
                        dto.SpecSDate = startDate;
                        dto.SpecEDate = endDate;
                    }
                    else if (dto.PlanType == "3")  // PO
                    {
                        dto.POSDate = startDate;
                        dto.POEDate = endDate;
                    }
                    else if (dto.PlanType == "4") // Action
                    {
                        dto.ActionSDate = startDate;
                        dto.ActionEDate = endDate;
                    }

                    logger.debug("Add dto:" + dto.ToString());
                    response.statusCode = bal.Add(dto);
                    response.statusText = "ADD";
                }
                else
                {
                    response.statusCode = false;
                    response.statusText = "Validate fail";
                    response.data = responseList;
                }
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
            bal = new T_Planing_SpecPOBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;

                T_Planing_SpecPODTO dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

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

        [HttpPost]
        [Route("UpdatePlan")]
        public HttpResponseMessage UpdatePlan()
        {
            bal = new T_Planing_SpecPOBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;

                T_Planing_SpecPODTO dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                logger.debug("UpdatePlan dto:" + dto.ToString());
                response.statusCode = bal.UpdateNewPlan(dto);
            }
            catch (Exception ex)
            {
                logger.error("UpdatePlan error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
        
        public List<ResponseDTO> Validate(HttpContext context)
        {
            T_Planing_SpecPODTO dto = null;

            DateTime activeDate = new DateTime();
            DateTime lastDate = new DateTime();
            DateTime lastSpecDate = new DateTime();
            DateTime lastPODate = new DateTime();
            DateTime lastActionDate = new DateTime();
            double lastComplete = 0;

            T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();

            List<ResponseDTO> reponseList = new List<ResponseDTO>();
            T_Planing_SpecPODTO orgDto = null;
            ResponseDTO responseDto = null;

            dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

            activeDate = ConvertX.ToDate(ConvertX.MMddYY(dto.EventDate));
            
            orgDto = bal.FindByCurrentStatus(dto);
            logger.debug("Validate orgDto:" + orgDto.ToString());
            
            if (orgDto != null)
            {
                lastSpecDate = ConvertX.ToDate(orgDto.SpecEDate);
                lastPODate = ConvertX.ToDate(orgDto.POEDate);
                lastActionDate = ConvertX.ToDate(orgDto.ActionEDate);
                if (dto.PlanType == "2") // spec
                {
                    lastDate = lastSpecDate;
                    lastComplete = ConvertX.ToDouble(orgDto.SpecComplete);
                }
                else if (dto.PlanType == "3")  // PO
                {
                    lastDate = lastPODate;
                    lastComplete = ConvertX.ToDouble(orgDto.POComplete);
                }
                else if (dto.PlanType == "4") // Action
                {
                    lastDate = lastActionDate;
                    lastComplete = ConvertX.ToDouble(orgDto.ActionComplete);
                }

                if (activeDate <= lastDate)
                {
                    responseDto = new ResponseDTO();
                    responseDto.status = false;
                    responseDto.text = "Date must more than " + string.Format("{0}/{1}/{2}", lastDate.Day, lastDate.Month, lastDate.Year) + "";
                    responseDto.classElement = "txtEventDate";
                    reponseList.Add(responseDto);
                }

                if (dto.PlanType == "3" && activeDate.Year <= lastSpecDate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
                {
                    responseDto = new ResponseDTO();
                    responseDto.status = false;
                    responseDto.text = "PO week more than Spec week (" + string.Format("{0}/{1}/{2}", lastSpecDate.Day, lastSpecDate.Month, lastSpecDate.Year) + ")";
                    responseDto.classElement = "txtEventDate";
                    reponseList.Add(responseDto);
                }

                if (dto.PlanType == "4" && activeDate.Year <= lastPODate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastPODate))
                {
                    responseDto = new ResponseDTO();
                    responseDto.status = false;
                    responseDto.text = "Action week more than PO week (" + string.Format("{0}/{1}/{2}", lastPODate.Day, lastPODate.Month, lastPODate.Year) + ")";
                    responseDto.classElement = "txtEventDate";
                    reponseList.Add(responseDto);

                }

                if (dto.PlanType == "4" && activeDate.Year <= lastSpecDate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
                {
                    responseDto = new ResponseDTO();
                    responseDto.status = false;
                    responseDto.text = "Action week more than Spec week (" + string.Format("{0}/{1}/{2}", lastSpecDate.Day, lastSpecDate.Month, lastSpecDate.Year) + ")";
                    responseDto.classElement = "txtEventDate";
                    reponseList.Add(responseDto);

                }

                if (ConvertX.ToDouble(dto.Complete) < lastComplete)
                {
                    responseDto = new ResponseDTO();
                    responseDto.status = false;
                    responseDto.text = "Value more than " + lastComplete.ToString() + "";
                    responseDto.classElement = "txtComplete";
                    reponseList.Add(responseDto);

                }
            }
            return reponseList;
        }
    }
}