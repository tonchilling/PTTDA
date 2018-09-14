using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Plan;
using DTO.PTT.Plan;
using DTO.PTT.Report;
using System.Data;
/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Plan
{
    public class T_PlaningBAL : BaseBL
    {
        bool isCan = false;
        T_PlaningDAO dao = null;

        public T_PlaningBAL()
        {
            dao = new T_PlaningDAO();
        }



        public override bool Action()
        {
            dao = new T_PlaningDAO();

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
                Log((dto as T_PlaningDTO).Page, "Error", ex.ToString());
            }
            return isCan;
        }


        public  bool UpdateReview(object dto)
        {
            bool isCan = false;

            try
            {

                isCan = dao.UpdateReview(dto);
            }
            catch (Exception ex)
            {
                Log((dto as T_PlaningDTO).Page, "Error", ex.ToString());
            }
            return isCan;
        }


        public bool Add(object planObj
                        , object coatingRepairObj
                       , List<object> coatingDefectObj
                        , List<object> pipeDefectObj
                        , List<object> environmentObj)
        {
            bool isCan = false;

            try
            {

                isCan = dao.Add(planObj, coatingRepairObj, coatingDefectObj, pipeDefectObj, environmentObj);
            }
            catch (Exception ex)
            {
                Log((planObj as T_PlaningDTO).Page, "Error", ex.ToString());
            }
            return isCan;
        }



        public override bool Update(object dto)
        {
            return dao.Update(dto);
        }

        public override bool Delete(object dto)
        {
            return dao.Delete(dto);
        }

        public  bool ClearAlll(object dto)
        {
            return dao.ClearAll(dto);
        }

        public override System.Data.DataTable FindByAll()
        {
            
            return dao.FindByAll();
        }

        public T_PlaningDTO FindByPK(object dto)
        {


            // return null;
            return dao.FindByPK(dto);


        }

        public List<ExportPlanHeader> CaptionPlanAll ()
        {


            // return null;
            return dao.ExportCaptionPlan();


        }



        public List<ColumnReportDTO> GetGraphProgress(object dto)
        {

            List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
            ColumnReportDTO rptGraph = null;
            List<DataPoint> dataPoint = null;
            List<ProgressGraphDto> graphAllList = null;

            List<ProgressGraphDto> graphAllTempList = null;

            // return null;
           graphAllList= dao.GetGraphProgress(dto);

           if (graphAllList != null)
           {


               //รอดำเนินการ
               graphAllTempList = graphAllList.Where(plan => plan.status=="1").ToList();

               if (graphAllTempList != null && graphAllTempList.Count>0)
               {
                   rptGraph = new ColumnReportDTO();
                    rptGraph.type=graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                     {

                         dataPoint.Add(new DataPoint(tempDto.Complete,tempDto.RegionName));
                    
                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
               }


               //เสร็จ
               graphAllTempList = graphAllList.Where(plan => plan.status == "2").ToList();

               if (graphAllTempList != null && graphAllTempList.Count > 0)
               {
                   rptGraph = new ColumnReportDTO();
                   rptGraph.type = graphAllTempList[0].type;
                   rptGraph.name = graphAllTempList[0].name;
                   rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                   rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                   dataPoint = new List<DataPoint>();
                   foreach (ProgressGraphDto tempDto in graphAllTempList)
                   {

                       dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                   }

                   rptGraph.dataPoints = dataPoint;

                   resultList.Add(rptGraph);
               }


               //เลื่อแผน
               graphAllTempList = graphAllList.Where(plan => plan.status == "3").ToList();

               if (graphAllTempList != null && graphAllTempList.Count > 0)
               {
                   rptGraph = new ColumnReportDTO();
                   rptGraph.type = graphAllTempList[0].type;
                   rptGraph.name = graphAllTempList[0].name;
                   rptGraph.showInLegend = "true";//graphAllTempList[0].showInLegend;
                   rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                   dataPoint = new List<DataPoint>();
                   foreach (ProgressGraphDto tempDto in graphAllTempList)
                   {

                       dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                   }

                   rptGraph.dataPoints = dataPoint;

                   resultList.Add(rptGraph);
               }


               //เลยกำหนด
               graphAllTempList = graphAllList.Where(plan => plan.status == "4").ToList();

               if (graphAllTempList != null && graphAllTempList.Count > 0)
               {
                   rptGraph = new ColumnReportDTO();
                   rptGraph.type = graphAllTempList[0].type;
                   rptGraph.name = graphAllTempList[0].name;
                   rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                   rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                   dataPoint = new List<DataPoint>();
                   foreach (ProgressGraphDto tempDto in graphAllTempList)
                   {

                       dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                   }

                   rptGraph.dataPoints = dataPoint;

                   resultList.Add(rptGraph);
               }

           
           }


           return resultList;


        }


        public SummaryPlanReport GetReportSummaryPlanOverAllObjList(object dto)
        {

            SummaryPlanReport result = new SummaryPlanReport();

            List<DonutGraphReportDTO> resultList = new List<DonutGraphReportDTO>();
            DonutGraphReportDTO rptGraph = null;
            List<DataPoint> dataPoint = null;
            List<ProgressGraphDto> graphAllList = null;

            List<ProgressGraphDto> graphAllTempList = null;

            // return null;
            result = dao.GetReportSummaryPlanOverAll(dto);
            graphAllList = result.RawGraphReport;

            // Graph 1
            if (graphAllList != null)
            {

                if (graphAllList != null && graphAllList.Count > 0)
                {



                    rptGraph = new DonutGraphReportDTO();
                    rptGraph.startAngle = "60";
                    rptGraph.innerRadius = "60";
                    rptGraph.indexLabel= "{label} - #percent%";
                    rptGraph.type = graphAllList[0].type;
                    rptGraph.toolTipContent = "<b>{label}:</b> {y} (#percent%)";

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.name,tempDto.color));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.DonutGraphReport = resultList;


            // Graph 2
            resultList = new List<DonutGraphReportDTO>();

            graphAllList = result.RawRiskGraphBeforeReport;

           
            if (graphAllList != null)
            {

                if (graphAllList != null && graphAllList.Count > 0)
                {



                    rptGraph = new DonutGraphReportDTO();
                    rptGraph.startAngle = "60";
                    rptGraph.innerRadius = "60";
                    rptGraph.indexLabel = "{label} - #percent%";
                    rptGraph.type = graphAllList[0].type;
                    rptGraph.toolTipContent = "<b>{label}:</b> {y} (#percent%)";

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.name, tempDto.color));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.DonutGraphRiskBeforeReport = resultList;




            // Graph 21
            resultList = new List<DonutGraphReportDTO>();

            graphAllList = result.RawRiskGraphCoatingTypeReport;

            
            if (graphAllList != null)
            {

                if (graphAllList != null && graphAllList.Count > 0)
                {



                    rptGraph = new DonutGraphReportDTO();
                    rptGraph.startAngle = "60";
                    rptGraph.innerRadius = "60";
                    rptGraph.indexLabel = "{label} - #percent%";
                    rptGraph.type = graphAllList[0].type;
                    rptGraph.toolTipContent = "<b>{label}:</b> {y} (#percent%)";

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.name, tempDto.color));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.DonutGraphCoatingTypeReport = resultList;


            // Graph 3
            resultList = new List<DonutGraphReportDTO>();

            graphAllList = result.RawRiskGraphAfterReport;


            if (graphAllList != null)
            {

                if (graphAllList != null && graphAllList.Count > 0)
                {



                    rptGraph = new DonutGraphReportDTO();
                    rptGraph.startAngle = "60";
                    rptGraph.innerRadius = "60";
                    rptGraph.indexLabel = "{label} - #percent%";
                    rptGraph.type = graphAllList[0].type;
                    rptGraph.toolTipContent = "<b>{label}:</b> {y} (#percent%)";

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.name, tempDto.color));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.DonutGraphRiskAfterReport = resultList;


            // Graph 31
            resultList = new List<DonutGraphReportDTO>();

            graphAllList = result.RawRiskGraphPipelineTypeReport;


            if (graphAllList != null)
            {

                if (graphAllList != null && graphAllList.Count > 0)
                {



                    rptGraph = new DonutGraphReportDTO();
                    rptGraph.startAngle = "60";
                    rptGraph.innerRadius = "60";
                    rptGraph.indexLabel = "{label} - #percent%";
                    rptGraph.type = graphAllList[0].type;
                    rptGraph.toolTipContent = "<b>{label}:</b> {y} (#percent%)";

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.name, tempDto.color));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.DonutGraphPipelineTypeReport = resultList;



            return result;


        }


        public SummaryPlanReport GetReportSummaryPlanRiskObjList(object dto)
        {

            SummaryPlanReport result = new SummaryPlanReport();

            List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
            ColumnReportDTO rptGraph = null;
            List<DataPoint> dataPoint = null;
            List<ProgressGraphDto> graphAllList = null;

            List<ProgressGraphDto> graphAllTempList = null;

            // return null;
            result = dao.GetReportSummaryPlanRisk(dto);
            graphAllList = result.RawGraphReport;
            if (graphAllList != null)
            {


                //Low
                graphAllTempList = graphAllList.Where(plan => plan.status == "1").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0";//[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //Medium
                graphAllTempList = graphAllList.Where(plan => plan.status == "2").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //Heigh
                graphAllTempList = graphAllList.Where(plan => plan.status == "3").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    //rptGraph.markerSize = graphAllTempList[0].markerSize;
                    // rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";//graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


               

            }

            result.GraphReport = resultList;


            return result;


        }



        public SummaryPlanReport GetReportSummaryCompletelyObjList(object dto)
        {

            SummaryPlanReport result = new SummaryPlanReport();

            List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
            ColumnReportDTO rptGraph = null;
            List<DataPoint> dataPoint = null;
            List<ProgressGraphDto> graphAllList = null;

            List<ProgressGraphDto> graphAllTempList = null;

            // return null;
            result = dao.GetReportSummaryCompletelyAll(dto);
            graphAllList = result.RawGraphReport;
            if (graphAllList != null)
            {


                //รอดำเนินการ
                graphAllTempList = graphAllList.Where(plan => plan.status == "1").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //เสร็จ
                graphAllTempList = graphAllList.Where(plan => plan.status == "2").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //เลื่อแผน
                graphAllTempList = graphAllList.Where(plan => plan.status == "3").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    //rptGraph.markerSize = graphAllTempList[0].markerSize;
                    // rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";//graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //Q1
                graphAllTempList = graphAllList.Where(plan => plan.status == "4").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }



                //Q2
                graphAllTempList = graphAllList.Where(plan => plan.status == "5").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

                //Q3
                graphAllTempList = graphAllList.Where(plan => plan.status == "6").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //Q4
                graphAllTempList = graphAllList.Where(plan => plan.status == "7").OrderBy(plan => Convert.ToInt32(plan.RegionCode)).ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }

            result.GraphReport = resultList;


            return result;


        }

        public List<ColumnReportDTO> GetReportSummaryPlanObjList(object dto)
        {

            List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
            ColumnReportDTO rptGraph = null;
            List<DataPoint> dataPoint = null;
            List<ProgressGraphDto> graphAllList = null;

            List<ProgressGraphDto> graphAllTempList = null;

            // return null;
            graphAllList = dao.GetReportSummaryPlan(dto);

            if (graphAllList != null)
            {


                //รอดำเนินการ
                graphAllTempList = graphAllList.Where(plan => plan.status == "1").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //เสร็จ
                graphAllTempList = graphAllList.Where(plan => plan.status == "2").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //เลื่อแผน
                graphAllTempList = graphAllList.Where(plan => plan.status == "3").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    //rptGraph.markerSize = graphAllTempList[0].markerSize;
                   // rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";//graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }


                //เลยกำหนด
                graphAllTempList = graphAllList.Where(plan => plan.status == "4").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;
                    
                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }



                //Q1
                graphAllTempList = graphAllList.Where(plan => plan.status == "5").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

                //Q2
                graphAllTempList = graphAllList.Where(plan => plan.status == "6").ToList();

                if (graphAllTempList != null && graphAllTempList.Count > 0)
                {
                    rptGraph = new ColumnReportDTO();
                    rptGraph.type = graphAllTempList[0].type;
                    rptGraph.name = graphAllTempList[0].name;
                    rptGraph.markerType = graphAllTempList[0].markerType;
                    rptGraph.markerSize = graphAllTempList[0].markerSize;
                    rptGraph.markerColor = graphAllTempList[0].markerColor;
                    rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
                    rptGraph.yValueFormatString = "#0 '%'";//graphAllTempList[0].yValueFormatString;

                    dataPoint = new List<DataPoint>();
                    foreach (ProgressGraphDto tempDto in graphAllTempList)
                    {

                        dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

                    }

                    rptGraph.dataPoints = dataPoint;

                    resultList.Add(rptGraph);
                }

            }


            return resultList;


        }

        public List<SummaryRepaireDTO> GetReportSummaryRepaireObjList(object dto)
        {


            // return null;
            return dao.GetReportSummaryRepaire(dto);
        }

        public SummaryRepaireAll GetReportSummaryRepaireTableAndGraph(object dto)
        {

            ColumnReportDTO rptGraph = null;
            SummaryRepaireAll result = new SummaryRepaireAll();
            List<DataPoint> dataPoint = new List<DataPoint>();
            List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();

            result = dao.GetReportSummaryRepaireTableAndGraph(dto);
            rptGraph = new ColumnReportDTO();
            rptGraph.type = "column";
            rptGraph.name = "Region";
            rptGraph.color = result.GraphData[0].color;
             rptGraph.indexLabel = "{y}";
            rptGraph.showInLegend = "true";// graphAllTempList[0].showInLegend;
            rptGraph.yValueFormatString = "#0";//[0].yValueFormatString;

            dataPoint = new List<DataPoint>();
            foreach (ProgressGraphDto tempDto in result.GraphData)
            {

                dataPoint.Add(new DataPoint(tempDto.Complete, tempDto.RegionName));

            }

            rptGraph.dataPoints = dataPoint;

            resultList.Add(rptGraph);

            result.Graph = resultList;

            return result;


        }



        public List<QuaterlyReportDTO> GetReportQuaterlyObjList(object dto)
        {


            // return null;
            return dao.GetReportQuaterly(dto);
        }


      
        public  List<T_PlaningDTO> FindByObjList(object dto) 
        {

           
           // return null;
            return dao.FindByObjList(dto);
        }



        public TPlaningAllDTO GetInspectionPlanAll(string PID,string uploadPath,string actionPath)
        {
            TPlaningAllDTO dtoResult = dao.GetInspectionPlanAll(PID, uploadPath, actionPath);

            // return null;
            return dtoResult;
        }



        public List<T_PlaningDTO> FindByObjListV2(object dto)
        {
            List<T_PlaningDTO> planResult = dao.FindByObjListV2(dto);

            T_PlaningDTO requestObj = (T_PlaningDTO)dto;
            List<MonthAndWeek> WM = null;
            foreach (T_PlaningDTO tempDto in planResult)
            {

            
                #region Spec

                if (tempDto.SpecSDate != null && tempDto.SpecEDate != null
                    && tempDto.SpecSDate != "" && tempDto.SpecEDate != "")
                {

                    CalulateWeek(tempDto, requestObj, tempDto.SpecSDate, tempDto.SpecEDate, "2",null);
                   
                }
                #endregion
                #region PO

                if (tempDto.POSDate!=null && tempDto.POEDate!=null 
                    && tempDto.POSDate != "" && tempDto.POEDate != "")
                {
                    CalulateWeek(tempDto, requestObj, tempDto.POSDate, tempDto.POEDate, "3", null);
                }
                #endregion
                #region Action

                if (tempDto.ActionSDate != null && tempDto.ActionEDate != null
                    && tempDto.ActionSDate != "" && tempDto.ActionEDate != "")
                {
                    CalulateWeek(tempDto, requestObj, tempDto.ActionSDate, tempDto.ActionEDate, "4", null);
                }
                #endregion

            }
            // return null;
            return planResult;
        }


        public Byte[] ExportPlanForExcel(object dto,string desPath,string fileName)
        {

            Byte[] reusult = null;
             BAL.PTT.Report.ExportToExcelBAL exportBal = new BAL.PTT.Report.ExportToExcelBAL();
            BAL.PTT.Report.ExportToExcel2BAL export2Bal = new BAL.PTT.Report.ExportToExcel2BAL();
            ExportPlanReport exportPlanReport = null;
            List<ExportPlaningDTO> planResult = null;
            List<ExportPlanHeader> planHeaderResult = null;
            List<MonthAndWeek> WM = null;
            string PID = "";
            DataRow dr = null;
            DataTable dtGroup = new DataTable();
            DataTable dtDetail = new DataTable();

            string fullPath = "";
            dtGroup.Columns.Add("PipelineID");
            dtGroup.Columns.Add("PipelineName");




            dtDetail.Columns.Add("PipelineID");
            dtDetail.Columns.Add("PipelineName");
            dtDetail.Columns.Add("Row");
            dtDetail.Columns.Add("RouteCode");
            dtDetail.Columns.Add("KP");
            dtDetail.Columns.Add("RegionName");
            dtDetail.Columns.Add("DIGFromName");
            dtDetail.Columns.Add("RiskScoreName");
            dtDetail.Columns.Add("Progress");

            dtDetail.Columns.Add("SpecSWeek");
            dtDetail.Columns.Add("POSWeek");
            dtDetail.Columns.Add("ActionSWeek");


            dtDetail.Columns.Add("SpecComplete");
            dtDetail.Columns.Add("POComplete");
            dtDetail.Columns.Add("ActionComplete");


            dtDetail.Columns.Add("SpecTotal");
            dtDetail.Columns.Add("POTotal");
            dtDetail.Columns.Add("ActionTotal");

            T_PlaningDTO requestObj = (T_PlaningDTO)dto;


            PID = requestObj.PID;

            requestObj.PID = "";
            exportPlanReport = dao.ExportPlanToReport(requestObj);

            planResult = exportPlanReport.Data;
            planHeaderResult = exportPlanReport.Header;

            string[] PIDs = null;
            PIDs = PID.Split(',');

            planResult = planResult.Where(p => PIDs.Contains(p.PID)).ToList();
            List<ExportPlaningDTO> pipeLineList = planResult.GroupBy(r => new { Col1 = r.PipelineID, Col2 = r.PipelineName })
       .Select(g => g.OrderBy(r => r.PipelineName).First()).ToList();

          


          

            foreach (ExportPlaningDTO tempDto in pipeLineList)
            {
                dr = dtGroup.NewRow();
                dr["PipelineID"] = tempDto.PipelineID;
                dr["PipelineName"] = tempDto.PipelineName;
                dtGroup.Rows.Add(dr);
            }


                int row = 1;
            foreach (ExportPlaningDTO tempDto in planResult)
            {

                dr = dtDetail.NewRow();

                dr["PipelineID"] = tempDto.PipelineID;
                dr["PipelineName"] = tempDto.PipelineName;
                dr["Row"] = row.ToString();
                dr["RouteCode"] = tempDto.RouteCode;
                //dr["Section"] = tempDto.Section;
                dr["KP"] = tempDto.KP;
                dr["RegionName"] = tempDto.RegionCode;
                dr["DIGFromName"] = tempDto.DIGFrom;
                dr["RiskScoreName"] = tempDto.RiskScoreName;
                dr["SpecComplete"] = tempDto.SpecComplete;
                dr["POComplete"] = tempDto.POComplete;
                dr["ActionComplete"] = tempDto.ActionComplete;
                
                dr["Progress"] = (tempDto.Progress=="1"?"Plan":"Actual");



                WM = DTO.Util.ConvertX.GetWeeks(tempDto.SpecSDate, tempDto.SpecEDate);


                if (WM != null && WM.Count > 0)
                {
                    dr["SpecSWeek"] = CalStartWeek(WM[0]);
                    dr["SpecTotal"] = WM.Count();
                }


                WM = DTO.Util.ConvertX.GetWeeks(tempDto.POSDate, tempDto.POEDate);


                if (WM != null && WM.Count > 0)
                {
                    dr["POSWeek"] = CalStartWeek(WM[0]);
                    dr["POTotal"] = WM.Count();
                }


                WM = DTO.Util.ConvertX.GetWeeks(tempDto.ActionSDate, tempDto.ActionEDate);

                if (WM != null && WM.Count > 0)
                {
                    dr["ActionSWeek"] = CalStartWeek(WM[0]);
                    dr["ActionTotal"] = WM.Count();
                }


                dtDetail.Rows.Add(dr);
                row++;


            }





            // reusult = exportBal.ExportPlan(planHeaderResult, dtGroup, dtDetail, desPath, fileName);


            reusult = export2Bal.ExportPlan(planHeaderResult, dtGroup, dtDetail, desPath, fileName);

            // return null;
            return reusult;
        }


        int CalStartWeek(MonthAndWeek temp)
        {
            int startWeek = 0;




            if (temp.Month == 1)
            {
                startWeek = temp.Month + (temp.Week - 1);
            }
            else {
                startWeek = ((temp.Month-1)* 4) + (temp.Week);
            }

           

            return startWeek;
        }

        public List<ExportPlaningDTO> ExportPlan(object dto)
        {
            List<ExportPlaningDTO> planResult = dao.ExportPlan(dto);

            T_PlaningDTO requestObj = (T_PlaningDTO)dto;
            List<MonthAndWeek> WM = null;
            foreach (ExportPlaningDTO tempDto in planResult)
            {


                #region Spec

                if (tempDto.SpecSDate != null && tempDto.SpecEDate != null
                    && tempDto.SpecSDate != "" && tempDto.SpecEDate != "")
                {

                    CalulateWeek(tempDto, requestObj, tempDto.SpecSDate, tempDto.SpecEDate, "2", null);

                }
                #endregion
                #region PO

                if (tempDto.POSDate != null && tempDto.POEDate != null
                    && tempDto.POSDate != "" && tempDto.POEDate != "")
                {
                    CalulateWeek(tempDto, requestObj, tempDto.POSDate, tempDto.POEDate, "3", null);
                }
                #endregion
                #region Action

                if (tempDto.ActionSDate != null && tempDto.ActionEDate != null
                    && tempDto.ActionSDate != "" && tempDto.ActionEDate != "")
                {
                    CalulateWeek(tempDto, requestObj, tempDto.ActionSDate, tempDto.ActionEDate, "4", null);
                }
                #endregion

            }
            // return null;
            return planResult;
        }



        public T_PlaningDTO CalulateWeek(T_PlaningDTO tempDto, T_PlaningDTO requestObj, string stDate, string enDate, string planType,string lastPreviousDate)
        {
            string specPlanColor = "#7ac0ec;";
            string poPlanColor = "#55b4f0;";
            string actionPlanColor = "#329fe4;";

            string specActualColor = "#72e181;";
            string poActualColor = "#4fdb62;";
            string actionActualColor = "#26c83d;";

            string overColor = "#f7f930";


            string planColor = "";


          

         /*    if (value == 1) {
                return "background:#7ac0ec;"
            } else if (value == 2 &&  row.Progress=='1') {
                return "background:#7ac0ec;"
            } else if (value == 2 &&  row.Progress=='2') {
                return "background:#72e181;"
            } 
            
            else if (value == 3 &&  row.Progress=='1') {
                return "background:#55b4f0;"
            }else if (value == 3 &&  row.Progress=='2') {
                return "background:#4fdb62;"
            }  
            
            else if (value == 4 &&  row.Progress=='1') {
                return "background:#329fe4;"
            }else if (value == 4 &&  row.Progress=='2') {
                return "background:#26c83d;"
            }
            */

            List<MonthAndWeek> WM = null;

            List<MonthAndWeek> duplidateWeek = null;

                WM = DTO.Util.ConvertX.GetWeeks(stDate, enDate).Where(ww => (ww.Year.ToString() == requestObj.Year)).ToList();

                duplidateWeek = DTO.Util.ConvertX.GetWeeks(lastPreviousDate, stDate);


                if (planType == "2")
                {
                    tempDto.SpecWeeks = duplidateWeek.Count==1 ? WM.Count - 1 : WM.Count;

                   
                }
                else if (planType == "3")
                {
                    tempDto.POWeeks = duplidateWeek.Count == 1 ? WM.Count - 1 : WM.Count;
                }
                else if (planType == "4")
                {
                    tempDto.ActionWeeks = duplidateWeek.Count == 1 ? WM.Count - 1 : WM.Count;
                }

                    foreach (MonthAndWeek tempWeek in WM)
                    {

                        
                            if (planType == "2")
                            {
                                if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.SpecOrgEDate).Year) && (tempDto.Progress == "2"))
                                {
                                    planColor = string.Format("{0}_{1}", planType, overColor);
                                      
                                }
                                 else {
                                     planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? specPlanColor : specActualColor);
                                        
                                 }
                            }
                            else if (planType == "3")
                            {
                                if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.POOrgEDate).Year) && (tempDto.Progress == "2"))
                                {
                                    planColor = string.Format("{0}_{1}", planType, overColor);
                                       
                                     }
                                 else {
                                     planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? poPlanColor : poActualColor);
                                 }
                            }
                            else if (planType == "4")
                            {
                                if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.ActionOrgEDate).Year) && (tempDto.Progress == "2"))
                                   {
                                       planColor = string.Format("{0}_{1}", planType, overColor);
                                  

                                      }
                                 else {
                                     planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? actionPlanColor : actionActualColor);
                                 }
                            }
                       


                        if (tempWeek.Month == 1)
                        {
                            //'jan_1=1,color'
                            if (tempDto.jan_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.jan_1 = planType;
                                tempDto.jan_1color = planColor;
                            }
                            else if (tempDto.jan_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.jan_2 = planType;
                                tempDto.jan_2color = planColor;
                            }
                            else if (tempDto.jan_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.jan_3 = planType;
                                tempDto.jan_3color = planColor;
                            }
                            else if (tempDto.jan_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.jan_4 = planType;
                                tempDto.jan_4color = planColor;
                            }

                          
                        }

                        else if (tempWeek.Month == 2)
                        {
                            if (tempDto.feb_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.feb_1 = planType;
                                tempDto.feb_1color = planColor;
                            }
                            else if (tempDto.feb_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.feb_2 = planType;
                                tempDto.feb_2color = planColor;
                            }
                            else if (tempDto.feb_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.feb_3 = planType;
                                tempDto.feb_3color = planColor;
                            }
                            else if (tempDto.feb_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.feb_4 = planType;
                                tempDto.feb_4color = planColor;
                            }
                        }
                        else if (tempWeek.Month == 3)
                        {
                            if (tempDto.mar_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.mar_1 = planType;
                                tempDto.mar_1color = planColor;
                            }
                            else if (tempDto.mar_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.mar_2 = planType;
                                tempDto.mar_2color = planColor;
                            }
                            else if (tempDto.mar_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.mar_3 = planType;
                                tempDto.mar_3color = planColor;
                            }
                            else if (tempDto.mar_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.mar_4 = planType;
                                tempDto.mar_4color = planColor;
                            }

                        }

                        else if (tempWeek.Month == 4)
                        {
                            if (tempDto.apr_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.apr_1 = planType;
                                tempDto.apr_1color = planColor;
                            }
                            else if (tempDto.apr_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.apr_2 = planType;
                                tempDto.apr_2color = planColor;
                            }
                            else if (tempDto.apr_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.apr_3 = planType;
                                tempDto.apr_3color = planColor;
                            }
                            else if (tempDto.apr_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.apr_4 = planType;
                                tempDto.apr_4color = planColor;
                            }
                        }

                        else if (tempWeek.Month == 5)
                        {
                            if (tempDto.may_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.may_1 = planType;
                                tempDto.may_1color = planColor;
                            }
                            else if (tempDto.may_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.may_2 = planType;
                                tempDto.may_2color = planColor;
                            }
                            else if (tempDto.may_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.may_3 = planType;
                                tempDto.may_3color = planColor;
                            }
                            else if (tempDto.may_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.may_4 = planType;
                                tempDto.may_4color = planColor;
                            }

                        }
                        else if (tempWeek.Month == 6)
                        {
                            if (tempDto.jun_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.jun_1 = planType;
                                tempDto.jun_1color = planColor;
                            }
                            else if (tempDto.jun_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.jun_2 = planType;
                                tempDto.jun_2color = planColor;
                            }
                            else if (tempDto.jun_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.jun_3 = planType;
                                tempDto.jun_3color = planColor;
                            }
                            else if (tempDto.jun_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.jun_4 = planType;
                                tempDto.jun_4color = planColor;
                            }

                        }

                       

                        else if (tempWeek.Month == 7)
                        {
                            if (tempDto.jul_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.jul_1 = planType;
                                tempDto.jul_1color = planColor;
                            }
                            else if (tempDto.jul_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.jul_2 = planType;
                                tempDto.jul_2color = planColor;
                            }
                            else if (tempDto.jul_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.jul_3 = planType;
                                tempDto.jul_3color = planColor;
                            }
                            else if (tempDto.jul_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.jul_4 = planType;
                                tempDto.jul_4color = planColor;
                            }

                        }
                        else if (tempWeek.Month == 8)
                        {
                            if (tempDto.aug_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.aug_1 = planType;
                                tempDto.aug_1color = planColor;
                            }
                            else if (tempDto.aug_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.aug_2 = planType;
                                tempDto.aug_2color = planColor;
                            }
                            else if (tempDto.aug_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.aug_3 = planType;
                                tempDto.aug_3color = planColor;
                            }
                            else if (tempDto.aug_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.aug_4 = planType;
                                tempDto.aug_4color = planColor;
                            }

                        }
                        else if (tempWeek.Month == 9)
                        {
                            if (tempDto.sep_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.sep_1 = planType;
                                tempDto.sep_1color = planColor;
                            }
                            else if (tempDto.sep_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.sep_2 = planType;
                                tempDto.sep_2color = planColor;
                            }
                            else if (tempDto.sep_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.sep_3 = planType;
                                tempDto.sep_3color = planColor;
                            }
                            else if (tempDto.sep_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.sep_4 = planType;
                                tempDto.sep_4color = planColor;
                            }
                        }

                        else if (tempWeek.Month == 10)
                        {
                            if (tempDto.oct_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.oct_1 = planType;
                                tempDto.oct_1color = planColor;
                            }
                            else if (tempDto.oct_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.oct_2 = planType;
                                tempDto.oct_2color = planColor;
                            }
                            else if (tempDto.oct_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.oct_3 = planType;
                                tempDto.oct_3color = planColor;
                            }
                            else if (tempDto.oct_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.oct_4 = planType;
                                tempDto.oct_4color = planColor;
                            }

                        }


                        else if (tempWeek.Month == 11)
                        {
                            if (tempDto.nov_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.nov_1 = planType;
                                tempDto.nov_1color = planColor;
                            }
                            else if (tempDto.nov_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.nov_2 = planType;
                                tempDto.nov_2color = planColor;
                            }
                            else if (tempDto.nov_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.nov_3 = planType;
                                tempDto.nov_3color = planColor;
                            }
                            else if (tempDto.nov_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.nov_4 = planType;
                                tempDto.nov_4color = planColor;
                            }
                        }

                        else if (tempWeek.Month == 12)
                        {
                            if (tempDto.dec_1 == null && tempWeek.Week == 1)
                            {
                                tempDto.dec_1 = planType;
                                tempDto.dec_1color = planColor;
                            }
                            else if (tempDto.dec_2 == null && tempWeek.Week == 2)
                            {
                                tempDto.dec_2 = planType;
                                tempDto.dec_2color = planColor;
                            }
                            else if (tempDto.dec_3 == null && tempWeek.Week == 3)
                            {
                                tempDto.dec_3 = planType;
                                tempDto.dec_3color = planColor;
                            }
                            else if (tempDto.dec_4 == null && tempWeek.Week == 4)
                            {
                                tempDto.dec_4 = planType;
                                tempDto.dec_4color = planColor;
                            }
                        }
                  

            }

                    return tempDto;
        
        
        }


        public ExportPlaningDTO CalulateWeek(ExportPlaningDTO tempDto, T_PlaningDTO requestObj, string stDate, string enDate, string planType, string lastPreviousDate)
        {
            string specPlanColor = "#7ac0ec;";
            string poPlanColor = "#55b4f0;";
            string actionPlanColor = "#329fe4;";

            string specActualColor = "#72e181;";
            string poActualColor = "#4fdb62;";
            string actionActualColor = "#26c83d;";

            string overColor = "#f7f930";


            string planColor = "";




            /*    if (value == 1) {
                   return "background:#7ac0ec;"
               } else if (value == 2 &&  row.Progress=='1') {
                   return "background:#7ac0ec;"
               } else if (value == 2 &&  row.Progress=='2') {
                   return "background:#72e181;"
               } 

               else if (value == 3 &&  row.Progress=='1') {
                   return "background:#55b4f0;"
               }else if (value == 3 &&  row.Progress=='2') {
                   return "background:#4fdb62;"
               }  

               else if (value == 4 &&  row.Progress=='1') {
                   return "background:#329fe4;"
               }else if (value == 4 &&  row.Progress=='2') {
                   return "background:#26c83d;"
               }
               */

            List<MonthAndWeek> WM = null;

            List<MonthAndWeek> duplidateWeek = null;

            WM = DTO.Util.ConvertX.GetWeeks(stDate, enDate).Where(ww => (ww.Year.ToString() == requestObj.Year)).ToList();

            duplidateWeek = DTO.Util.ConvertX.GetWeeks(lastPreviousDate, stDate);


            if (planType == "2")
            {
                tempDto.SpecWeeks = duplidateWeek.Count == 1 ? WM.Count - 1 : WM.Count;


            }
            else if (planType == "3")
            {
                tempDto.POWeeks = duplidateWeek.Count == 1 ? WM.Count - 1 : WM.Count;
            }
            else if (planType == "4")
            {
                tempDto.ActionWeeks = duplidateWeek.Count == 1 ? WM.Count - 1 : WM.Count;
            }

            foreach (MonthAndWeek tempWeek in WM)
            {


                if (planType == "2")
                {
                    if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.SpecOrgEDate).Year) && (tempDto.Progress == "2"))
                    {
                        planColor = string.Format("{0}_{1}", planType, overColor);

                    }
                    else
                    {
                        planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? specPlanColor : specActualColor);

                    }
                }
                else if (planType == "3")
                {
                    if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.POOrgEDate).Year) && (tempDto.Progress == "2"))
                    {
                        planColor = string.Format("{0}_{1}", planType, overColor);

                    }
                    else
                    {
                        planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? poPlanColor : poActualColor);
                    }
                }
                else if (planType == "4")
                {
                    if ((tempWeek.Year != DTO.Util.ConvertX.ToDate(tempDto.ActionOrgEDate).Year) && (tempDto.Progress == "2"))
                    {
                        planColor = string.Format("{0}_{1}", planType, overColor);


                    }
                    else
                    {
                        planColor = string.Format("{0}_{1}", planType, tempDto.Progress == "1" ? actionPlanColor : actionActualColor);
                    }
                }



                if (tempWeek.Month == 1)
                {
                    //'jan_1=1,color'
                    if (tempDto.jan_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.jan_1 = planType;
                      
                    }
                    else if (tempDto.jan_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.jan_2 = planType;
                      
                    }
                    else if (tempDto.jan_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.jan_3 = planType;
                      
                    }
                    else if (tempDto.jan_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.jan_4 = planType;
                        
                    }


                }

                else if (tempWeek.Month == 2)
                {
                    if (tempDto.feb_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.feb_1 = planType;
                      
                    }
                    else if (tempDto.feb_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.feb_2 = planType;
                      
                    }
                    else if (tempDto.feb_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.feb_3 = planType;
                      
                    }
                    else if (tempDto.feb_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.feb_4 = planType;
                      
                    }
                }
                else if (tempWeek.Month == 3)
                {
                    if (tempDto.mar_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.mar_1 = planType;
                       
                    }
                    else if (tempDto.mar_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.mar_2 = planType;
                       
                    }
                    else if (tempDto.mar_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.mar_3 = planType;
                      
                    }
                    else if (tempDto.mar_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.mar_4 = planType;
                       
                    }

                }

                else if (tempWeek.Month == 4)
                {
                    if (tempDto.apr_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.apr_1 = planType;
                     
                    }
                    else if (tempDto.apr_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.apr_2 = planType;
                       
                    }
                    else if (tempDto.apr_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.apr_3 = planType;
                        
                    }
                    else if (tempDto.apr_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.apr_4 = planType;
                       
                    }
                }

                else if (tempWeek.Month == 5)
                {
                    if (tempDto.may_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.may_1 = planType;
                       
                    }
                    else if (tempDto.may_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.may_2 = planType;
                        
                    }
                    else if (tempDto.may_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.may_3 = planType;
                       
                    }
                    else if (tempDto.may_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.may_4 = planType;
                       
                    }

                }
                else if (tempWeek.Month == 6)
                {
                    if (tempDto.jun_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.jun_1 = planType;
                        
                    }
                    else if (tempDto.jun_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.jun_2 = planType;
                       
                    }
                    else if (tempDto.jun_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.jun_3 = planType;
                      
                    }
                    else if (tempDto.jun_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.jun_4 = planType;
                        
                    }

                }



                else if (tempWeek.Month == 7)
                {
                    if (tempDto.jul_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.jul_1 = planType;
                      
                    }
                    else if (tempDto.jul_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.jul_2 = planType;
                       
                    }
                    else if (tempDto.jul_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.jul_3 = planType;
                       
                    }
                    else if (tempDto.jul_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.jul_4 = planType;
                      
                    }

                }
                else if (tempWeek.Month == 8)
                {
                    if (tempDto.aug_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.aug_1 = planType;
                       
                    }
                    else if (tempDto.aug_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.aug_2 = planType;
                        
                    }
                    else if (tempDto.aug_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.aug_3 = planType;
                        
                    }
                    else if (tempDto.aug_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.aug_4 = planType;
                        
                    }

                }
                else if (tempWeek.Month == 9)
                {
                    if (tempDto.sep_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.sep_1 = planType;
                       
                    }
                    else if (tempDto.sep_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.sep_2 = planType;
                       
                    }
                    else if (tempDto.sep_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.sep_3 = planType;
                      
                    }
                    else if (tempDto.sep_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.sep_4 = planType;
                       
                    }
                }

                else if (tempWeek.Month == 10)
                {
                    if (tempDto.oct_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.oct_1 = planType;
                       
                    }
                    else if (tempDto.oct_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.oct_2 = planType;
                       
                    }
                    else if (tempDto.oct_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.oct_3 = planType;
                       
                    }
                    else if (tempDto.oct_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.oct_4 = planType;
                       
                    }

                }


                else if (tempWeek.Month == 11)
                {
                    if (tempDto.nov_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.nov_1 = planType;
                       
                    }
                    else if (tempDto.nov_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.nov_2 = planType;
                       
                    }
                    else if (tempDto.nov_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.nov_3 = planType;
                        
                    }
                    else if (tempDto.nov_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.nov_4 = planType;
                       
                    }
                }

                else if (tempWeek.Month == 12)
                {
                    if (tempDto.dec_1 == null && tempWeek.Week == 1)
                    {
                        tempDto.dec_1 = planType;
                       
                    }
                    else if (tempDto.dec_2 == null && tempWeek.Week == 2)
                    {
                        tempDto.dec_2 = planType;
                       
                    }
                    else if (tempDto.dec_3 == null && tempWeek.Week == 3)
                    {
                        tempDto.dec_3 = planType;
                        
                    }
                    else if (tempDto.dec_4 == null && tempWeek.Week == 4)
                    {
                        tempDto.dec_4 = planType;
                        
                    }
                }


            }

            return tempDto;


        }

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}