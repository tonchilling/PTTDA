<%@ WebHandler Language="C#" Class="DropDownListHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Util;
using DTO.Util;
using BAL.PTT.Util;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT.Plan;
using DTO.PTT;

using DTO.PTT.Admin;

public class DropDownListHandler : IHttpHandler, IRequiresSessionState
{

    UserDTO UserLOGIN = null;

    public void ProcessRequest (HttpContext context) {
        List<DropDownListDTO> results = null ;
        List<Select2DTO> select2Results = null ;
        JavaScriptSerializer json;

        var jsonString = "";
        if (context.Request.Form.Count > 0)
        {
            UserLOGIN = AppConfig.GetUserLogin();

            if (context.Request.Form["DropDrownType"] != null)
            {

                switch (context.Request.Form["DropDrownType"])
                {
                    case "TypeOfPipeline": results = GetTypeOfPipeLine(context.Request.Form["RegionID"]
                                                                  , context.Request.Form["AssetOwnerID"]
                                                                  , context.Request.Form["RouteID"]);
                        break;
                    case "AssetOwner": results = GetAssetOwnerByRouteCode(context.Request.Form["RegionID"],
                        context.Request.Form["PipelineID"]
                        , context.Request.Form["RouteID"]);
                        break;
                    case "AssetOwnerByRouteCode": results = GetAssetOwnerByRouteCode(context.Request.Form["RegionID"],
                        context.Request.Form["PipelineID"]
                        ,context.Request.Form["RouteID"]);
                        break;

                    case "RouteCode": results = GetRouteCode(context.Request.Form["RegionID"],
                                                             context.Request.Form["PipelineID"],
                                                              context.Request.Form["AssetOwnerID"]);
                        break;


                    case "Region": results = GetRegion(context.Request.Form["PipelineID"],
                                                        context.Request.Form["AssetOwnerID"],
                                                        context.Request.Form["RouteID"]);
                        break;

                    case "LoadSelect2": select2Results = GetSelecc2ObjList(context.Request.Form["TableName"]);
                        break;




                }



                json = new JavaScriptSerializer();

                if (context.Request.Form["DropDrownType"] == "LoadSelect2")
                {
                         jsonString = json.Serialize(select2Results);
                }
                else
                {
                    jsonString = json.Serialize(results);

                }
                context.Response.Write(jsonString);


            }else if(context.Request.Form["table"]!=null)
            {
                results = GetData(context.Request.Form["table"]);
                json = new JavaScriptSerializer();
                jsonString = json.Serialize(results);
                context.Response.Write(jsonString);

            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

    List<DropDownListDTO> GetTypeOfPipeLine(string regionID,string assetOwnerID,string routeID)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try
        {
            bal = new DropDownListBAL();
            dataList = bal.TypeOfPipelineByObjList(UserLOGIN.UserID, regionID, assetOwnerID, routeID);

        }
        catch (Exception ex) { }
        finally
        {

        }

        return dataList;



    }

    List<DropDownListDTO> GetRouteCode(string regionID,string pipelineID,string assetOwnerID)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try
        {
            bal = new DropDownListBAL();
            dataList = bal.RouteCodeByObjList(UserLOGIN.UserID, regionID, pipelineID, assetOwnerID);

        }
        catch (Exception ex) { }
        finally
        {

        }

        return dataList;



    }


    List<DropDownListDTO> GetRegion(string pipelineID, string assetOwnerID, string routeID)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try
        {

            bal = new DropDownListBAL();
            dataList = bal.RegionByObjList(UserLOGIN.UserID,pipelineID, assetOwnerID, routeID);

        }
        catch (Exception ex) { }
        finally
        {

        }

        return dataList;



    }

    List<DropDownListDTO> GetAssetOwner(string typeOfPipelineID)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try
        {
            bal = new DropDownListBAL();
            dataList = bal.AssetOwnerByObjList(typeOfPipelineID);

        }
        catch (Exception ex) { }
        finally
        {

        }

        return dataList;



    }


    List<DropDownListDTO> GetAssetOwnerByRouteCode(string regionID,string pipelineID,string routeID)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try
        {
            bal = new DropDownListBAL();
            dataList = bal.AssetOwnerByRouteCodeObjList(UserLOGIN.UserID, regionID, pipelineID, routeID);

        }
        catch (Exception ex) { }
        finally
        {

        }

        return dataList;



    }


    List<Select2DTO> GetSelecc2ObjList(string tableName)
    {
        List<Select2DTO> dataList = null;
        DropDownListBAL bal = null;
        try {
            bal = new DropDownListBAL();
            dataList = bal.Select2ByObjList(tableName);

        }
        catch (Exception ex) { }
        finally {

        }

        return dataList;



    }



    List<DropDownListDTO> GetData(string tableName)
    {
        List<DropDownListDTO> dataList = null;
        DropDownListBAL bal = null;
        try {
            bal = new DropDownListBAL();
            dataList = bal.FindByObjList(tableName, UserLOGIN.UserID);

        }
        catch (Exception ex) { }
        finally {

        }

        return dataList;



    }


}