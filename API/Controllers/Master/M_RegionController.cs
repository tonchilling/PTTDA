﻿using BAL.PTT.Master;
using DTO.PTT;
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
    [RoutePrefix("api/Region")]
    public class M_RegionController : ApiController
    {
        Logger logger = new Logger("M_RegionController");
        M_RegionBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            bal = new M_RegionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            List<M_RegionDTO> dataList = new List<M_RegionDTO>();
            
            M_RegionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_RegionDTO>();

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
        [Route("Select")]
        public HttpResponseMessage Select()
        {
            bal = new M_RegionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            List<Select2DTO> dataList = new List<Select2DTO>();

            M_RegionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_RegionDTO>();

                logger.debug("Select dto:" + dto.ToString());
                dataList = bal.Select2ByObjList(dto);
                response.statusCode = true;
                response.data = dataList;
            }
            catch (Exception ex)
            {
                logger.error("Select error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            bal = new M_RegionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_RegionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_RegionDTO>();
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
            bal = new M_RegionBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            M_RegionDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<M_RegionDTO>();

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