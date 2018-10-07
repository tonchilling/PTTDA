using DAO.PTT.Master;
using DTO.PTT.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BAL.PTT.Master
{
    public class M_RegionPipelineBAL : BaseBL
    {
        M_RegionPipelineDAO dao = null;
        public M_RegionPipelineBAL()
        {
            dao = new M_RegionPipelineDAO();
        }

        public override bool Action()
        {
            throw new NotImplementedException();
        }

        public override bool Add(object data)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(object data)
        {
            throw new NotImplementedException();
        }

        public override DataTable FindByAll()
        {
            throw new NotImplementedException();
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public override bool Update(object data)
        {
            throw new NotImplementedException();
        }

        public List<M_RegionPipelineDTO> getRegionPipeline()
        {
            List<M_RegionPipelineDTO> objList = new List<M_RegionPipelineDTO>();
            try
            {
                objList = dao.getRegionPipeline();
            }
            catch (Exception ex)
            {
                Log("getRegionPipeline", "Error", ex.ToString());
            }
            return objList;
        }
    }
}
