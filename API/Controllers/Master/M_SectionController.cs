﻿using BAL.PTT.Master;
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
    [RoutePrefix("api/Section")]
    public class M_SectionController : ApiController
    {
        Logger logger = new Logger("M_SectionController");
        M_SectionBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage LoadList()
        {
            bal = new M_SectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            List<M_SectionDTO> dataList = new List<M_SectionDTO>();
            
            M_SectionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_SectionDTO>();

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
        [Route("FindByRouteCode")]
        public HttpResponseMessage FindByRouteCode()
        {
            bal = new M_SectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            M_SectionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_SectionDTO>();

                logger.debug("FindByRouteCode dto:" + dto.ToString());
                M_SectionDTO obj = bal.FinByRouteCodeName(dto);
                response.statusCode = true;
                response.data = obj;
            }
            catch (Exception ex)
            {
                logger.error("FindByRouteCode error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            bal = new M_SectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_SectionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_SectionDTO>();
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
            bal = new M_SectionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_SectionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_SectionDTO>();

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