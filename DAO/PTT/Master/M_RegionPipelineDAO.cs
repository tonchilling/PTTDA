using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.PTT.Master;
using System.Data.SqlClient;
using DTO.Util;

namespace DAO.PTT.Master
{
    public class M_RegionPipelineDAO : PTTDB
    {
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
                SqlConnection conn = OpenConnection();
                command = new SqlCommand("select * from dbo.fn_M_Region_PipelineTable()", conn);
                command.CommandType = CommandType.Text;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    objList = ConvertX.GetListFromDataReader<M_RegionPipelineDTO>(reader).ToList();
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
