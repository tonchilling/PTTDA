using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Util;
using DTO.PTT.Util;
using DTO.PTT;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Util
{
    public class DropDownListBAL : BaseBL
    {
        bool isCan = false;
        DropDownListDAO dao = null;

        public DropDownListBAL()
        {
            dao = new DropDownListDAO();
        }



        public override bool Action()
        {
            dao = new DropDownListDAO();

            return isCan;
        }

        public override bool Add(object dto)
        {
            bool isCan = false;

            try {

                isCan = dao.Add(dto);
            }
            catch (Exception ex)
            {
                Log((dto as DropDownListDTO).Page, "Error", ex.ToString());
            }
            return isCan;
        }

        public override bool Update(object dto)
        {
            return true;
        }

        public override bool Delete(object dto)
        {
            return true;
        }

        public override System.Data.DataTable FindByAll()
        {

            return null;
        }

        public  List<DropDownListDTO> FindByObjList(string tableName) 
        {

            return dao.FindByObjList(tableName);
        }
        public List<DropDownListDTO> FindByObjList(string tableName,string userID)
        {

            return dao.FindByObjList(tableName, userID);
        }

        public List<DropDownListDTO> AssetOwnerByObjList(string typeOfPipelineID)
        {

            return dao.AssetOwnerByObjList(typeOfPipelineID);
        }


        public List<DropDownListDTO> RegionByObjList(string createBy,string regionID, string assetOwnerID, string routeID)
        {

            return dao.RegionByObjList(createBy,regionID, assetOwnerID, routeID);
        }

        public List<DropDownListDTO> TypeOfPipelineByObjList(string createBy, string regionID, string assetOwnerID, string routeID) 
        {

            return dao.TypeOfPipelineByObjList( createBy,regionID, assetOwnerID, routeID);
        }


        public List<Select2DTO> Select2ByObjList(string tableName)
        {

            return dao.Select2ByObjList(tableName,null);
        }


        public List<DropDownListDTO> AssetOwnerByRouteCodeObjList(string createBy, string regionID, string pipelineID, string routeID)
        {

            return dao.AssetOwnerByRouteCodeObjList(createBy, regionID, pipelineID, routeID);
        }


        public List<DropDownListDTO> RouteCodeByObjList(string createBy, string regionID, string pipelineID, string assetOwnerID)
        {

            return dao.RouteCodeByObjList(createBy, regionID, pipelineID, assetOwnerID);
        }



        
     

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}