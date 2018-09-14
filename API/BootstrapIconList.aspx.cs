using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO.Util;
using DTO.PTT.Services;
public partial class BootstrapIconList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        GPServer request = new GPServer();
        spatialReference spR=new spatialReference();
        List<features> featList=new List<features>();
        features feat=new features();
        geometry geometry=new geometry();
        geometry.x="748874.9600000003";
        geometry.y="1425623.8499999999}";
        feat.geometry=geometry;

        featList.Add(feat);
        spR.wkid="32647";
        request.geometryType = "esriGeometryPoint";
        request.spatialReference = spR;
        request.features = featList;
        string url = "http://pipelinegis/arcgis/rest/services/GEOPROCESSING/DA_LOCATE_KP_FROM_SERIES/GPServer";
        ConvertX.GetRequest(url, request);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
       
    }
}