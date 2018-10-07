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
    [RoutePrefix("api/RegionPipeline")]
    public class M_RegionPipelineController : ApiController
    {
        Logger logger = new Logger("M_RegionPipelineController");
        M_RegionPipelineBAL bal = null;

        [HttpPost]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            bal = new M_RegionPipelineBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            List<M_RegionPipelineDTO> dataList = new List<M_RegionPipelineDTO>();
            
            response.statusCode = false;
            try
            {
                dataList = bal.getRegionPipeline();
                response.statusCode = true;
                response.data = dataList;
            }
            catch (Exception ex)
            {
                logger.error("M_RegionPipelineController GetAll error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }        
    }
}