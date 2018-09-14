using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Plan;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;
using DTO.PTT.Report;
using DTO.PTT.Master;
namespace DAO.PTT.Plan
{
    public class T_PlaningDAO : PTTDB
    {

        List<T_PlaningDTO> objList = null;
        T_PlaningDTO obj = null;

        public override bool Add(object planObj)
        {



               List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {


                command = new SqlCommand(procName, conn, transaction);
             
                command.CommandType = CommandType.StoredProcedure;



                if (planObj != null)
                {
                    ((T_PlaningDTO)planObj).SpecSDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).SpecSDate);
                    ((T_PlaningDTO)planObj).SpecEDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).SpecEDate);

                    ((T_PlaningDTO)planObj).POSDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).POSDate);
                    ((T_PlaningDTO)planObj).POEDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).POEDate);


                    ((T_PlaningDTO)planObj).ActionSDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).ActionSDate);
                    ((T_PlaningDTO)planObj).ActionEDate = ConvertX.MMddYY(((T_PlaningDTO)planObj).ActionEDate);


                    parameterList.AddRange(GetParameters(procName, planObj, transaction).ToArray());

                    command.Parameters.AddRange(parameterList.ToArray());
                    if (((T_PlaningDTO)planObj).PID == null
                         || ((T_PlaningDTO)planObj).PID == "")
                    {
                        command.Parameters[0].Value = "";
                    }
                }
              
                command.ExecuteNonQuery();

                PID = command.Parameters[0].Value.ToString();

                if (((T_PlaningDTO)planObj).DeleteFiles != null && ((T_PlaningDTO)planObj).DeleteFiles.Length > 0)
                {
                    procName = "sp_T_Planing_Files_Delete";
                    foreach (var fileNo in ((T_PlaningDTO)planObj).DeleteFiles.Split(','))
                    {

                        command = new SqlCommand(procName, conn, transaction);

                        command.CommandType = CommandType.StoredProcedure;
                        if (fileNo != null)
                        {
                            T_Planing_File file = new T_Planing_File();
                            file.PID = PID;
                            file.No = fileNo;
                            parameterList = new List<SqlParameter>();
                            parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                            command.Parameters.AddRange(parameterList.ToArray());
                            //  command.Parameters[0].Value = "";
                        }

                        command.ExecuteNonQuery();


                    }
                }

                obj = (T_PlaningDTO)planObj;
                obj.PID = PID;
                procName = "sp_T_Planing_Files_Insert";
                if (obj.UploadFileList != null && obj.UploadFileList.Count>0)
                {
                    foreach (T_Planing_File file in obj.UploadFileList)
                  {
                      file.PID = PID;

                      command = new SqlCommand(procName, conn, transaction);
                    
                      command.CommandType = CommandType.StoredProcedure;
                      if (file != null)
                      {
                          parameterList = new List<SqlParameter>();
                          parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                          command.Parameters.AddRange(parameterList.ToArray());
                        //  command.Parameters[0].Value = "";
                      }
                    
                      command.ExecuteNonQuery();
                  }
                }

                transaction.Commit();


            }
            catch (Exception ex)
            {
                isCan = false;
                transaction.Rollback();
                throw new Exception(ex.Message);

            }
            finally
            {
                CloseConnection();

            }
            return isCan;
        }
        public  bool Add(object planObj
                        ,object coatingRepairObj
                       , List<object> coatingDefectObj
                        , List<object> pipeDefectObj
                        , List<object> environmentObj)
        {

            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Insert";
            string PID = "";
         

            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);

            command = new SqlCommand(procName, conn);
            command.Transaction = transaction;
            command.CommandType = CommandType.StoredProcedure;
            try
            {

                if (planObj != null)
                {

                    ((T_PlaningDTO)planObj).SpecSDate = ConvertX.MMddYY(obj.SpecSDate);
                    ((T_PlaningDTO)planObj).SpecEDate = ConvertX.MMddYY(obj.SpecEDate);

                    ((T_PlaningDTO)planObj).POSDate = ConvertX.MMddYY(obj.POSDate);
                    ((T_PlaningDTO)planObj).POEDate = ConvertX.MMddYY(obj.POEDate);


                    ((T_PlaningDTO)planObj).ActionSDate = ConvertX.MMddYY(obj.ActionSDate);
                    ((T_PlaningDTO)planObj).ActionEDate = ConvertX.MMddYY(obj.ActionEDate);


                    parameterList.AddRange(GetParameters(procName, planObj).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                if (planObj != null)
                {

                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

                PID = command.Parameters[0].Value.ToString();
                T_Planing_CoatingRepairDTO coatingRepairDTo = (T_Planing_CoatingRepairDTO)coatingRepairObj;

                procName = "sp_T_Planing_CoatingRepair_Insert";

                parameterList = new List<SqlParameter>();

                if (coatingRepairDTo != null)
                {
                  
                    coatingRepairDTo.PID = PID;
                    parameterList.AddRange(GetParameters(procName, coatingRepairDTo).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                if (coatingRepairDTo != null)
                {

                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();



            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            } 
            return isCan;
        }


        public  bool UpdateReview(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_UpdateReview", data);
            CloseConnection();
            return isCan;
        }


        public override bool Update(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Delete", data);
            CloseConnection();
            return isCan;
        }

        public  bool ClearAll(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_ClearAll", data);
            CloseConnection();
            return isCan;
        }


        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }


        public T_PlaningDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_PlaningDTO();

       
            dataTable = null;

            string procName = "sp_T_Planing_FindByPK";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    obj = ConvertX.GetListFromDataReader<T_PlaningDTO>(reader).ToList()[0];

                    obj.SpecSDate = ConvertX.DDMMYY(obj.SpecSDate);
                    obj.SpecEDate = ConvertX.DDMMYY(obj.SpecEDate);

                    obj.POSDate = ConvertX.DDMMYY(obj.POSDate);
                    obj.POEDate = ConvertX.DDMMYY(obj.POEDate);


                    obj.ActionSDate = ConvertX.DDMMYY(obj.ActionSDate);
                    obj.ActionEDate = ConvertX.DDMMYY(obj.ActionEDate);

                    reader.NextResult();

                    obj.UploadFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();

                }

               


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<ProgressGraphDto> GetGraphProgress(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ProgressGraphDto> objList = new List<ProgressGraphDto>();
            dataTable = null;

            string procName = "sp_T_Planing_ProgressGraph";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                   parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                   command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }



        public SummaryPlanReport GetReportSummaryPlanOverAll(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ProgressGraphDto> objList = new List<ProgressGraphDto>();
            dataTable = null;

            SummaryPlanReport resultDto = new SummaryPlanReport(); ;

            string procName = "sp_Report_T_Planing_SummaryPlanOverAllReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    resultDto.RawGraphReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.RawRiskGraphBeforeReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.RawRiskGraphCoatingTypeReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.RawRiskGraphAfterReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.RawRiskGraphPipelineTypeReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.OverAllTableReport = ConvertX.GetListFromDataReader<SummaryPlanOverAllProgressDto>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return resultDto;
        }


        public SummaryPlanReport GetReportSummaryPlanRisk(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ProgressGraphDto> objList = new List<ProgressGraphDto>();
            dataTable = null;

            SummaryPlanReport resultDto = new SummaryPlanReport(); ;

            string procName = "sp_Report_T_Planing_SummaryPlanRiskReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    resultDto.RawGraphReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                   resultDto.RiskTableReport=ConvertX.GetListFromDataReader<SummaryPlanRiskDto>(reader).ToList(); 

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return resultDto;
        }
     


        public SummaryPlanReport GetReportSummaryCompletelyAll(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ProgressGraphDto> objList = new List<ProgressGraphDto>();
            dataTable = null;

            SummaryPlanReport resultDto = new SummaryPlanReport(); ;

            string procName = "sp_Report_T_Planing_SummaryPlanReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    resultDto.RawGraphReport = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.TableReport = ConvertX.GetListFromDataReader<SummaryPlanByAssetOwnerDto>(reader).ToList();
                    reader.NextResult();
                    resultDto.regionList = ConvertX.GetListFromDataReader<M_RegionDTO>(reader).ToList();
                    reader.NextResult();
                    resultDto.SumaryCompletelyByRegionTable = ConvertX.GetListFromDataReader<SummaryCompletelyByRegionDto>(reader).ToList();
                   
                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return resultDto;
        }



        public List<ProgressGraphDto> GetReportSummaryPlan(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ProgressGraphDto> objList = new List<ProgressGraphDto>();
            dataTable = null;

            string procName = "sp_Report_T_Planing_SummaryPlanReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                      command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }



        public List<SummaryRepaireDTO> GetReportSummaryRepaire(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<SummaryRepaireDTO> objList = new List<SummaryRepaireDTO>();
            dataTable = null;

            string procName = "sp_Report_T_Planing_SummaryRepaire";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    //  parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    //  command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<SummaryRepaireDTO>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }





        public SummaryRepaireAll GetReportSummaryRepaireTableAndGraph(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            SummaryRepaireAll obj = new SummaryRepaireAll();
            dataTable = null;

            string procName = "sp_Report_T_Planing_SummaryRepaire";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                      parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                      command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    obj.Table = ConvertX.GetListFromDataReader<SummaryRepaireDTO>(reader).ToList();
                    reader.NextResult();
                    obj.GraphData = ConvertX.GetListFromDataReader<ProgressGraphDto>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;

        }

        public List<QuaterlyReportDTO> GetReportQuaterly(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<QuaterlyReportDTO> objList = new List<QuaterlyReportDTO>();
            dataTable = null;

            string procName = "sp_Report_T_Planing_Querterly";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                      parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                      command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<QuaterlyReportDTO>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;

        }

        public List<T_PlaningDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_PlaningDTO>();
            dataTable = null;

            string procName = "T_Planing_FindByFindByConditon";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

              objList=   ConvertX.GetListFromDataReader<T_PlaningDTO>(reader).ToList();
                  
                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

        public List<T_PlaningDTO> FindByObjListV2(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_PlaningDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_FindByFindByConditonV2";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<T_PlaningDTO>(reader).ToList();
                  


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

        public List<ExportPlaningDTO> ExportPlan(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ExportPlaningDTO> objList = new List<ExportPlaningDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_FindByFindByConditonV2";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<ExportPlaningDTO>(reader).ToList();


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

        public List<ExportPlanHeader> ExportCaptionPlan()
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ExportPlanHeader> result = null;


             dataTable = null;

            string procName = "sp_ExportPlan_Setting_FindAll";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();

                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    result = ConvertX.GetListFromDataReader<ExportPlanHeader>(reader).ToList();

                  

                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return result;

        }

        public ExportPlanReport ExportPlanToReport(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<ExportPlaningDTO> objList = new List<ExportPlaningDTO>();
            ExportPlanReport result = new ExportPlanReport();
              dataTable = null;

            string procName = "sp_T_Planing_FindByFindByConditonV2";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    result.Data= ConvertX.GetListFromDataReader<ExportPlaningDTO>(reader).ToList();

                    reader.NextResult();
                    result.Header= ConvertX.GetListFromDataReader<ExportPlanHeader>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return result;
        }


        public TPlaningAllDTO GetInspectionPlanAll(string PID,string uploadPath)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            TPlaningAllDTO obj = new TPlaningAllDTO();

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string procName = "sp_T_Planing_AllReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();

                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PID", PID));

                da.SelectCommand = command;
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    #region T_Planing
                    obj.T_PlaningDT=ds.Tables[0].Copy();
                obj.T_PlaningDT.TableName = "TPlaning";
                obj.T_Planing_FilesDT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[1].Copy(), "TPlaing_File", 2, uploadPath);
                obj.T_Planing_FilesDT.TableName = "TPlaing_File";
                    #endregion

                #region T_Planing_Action_SiteSurvey


                obj.T_Planing_SiteSurveyDT       = ds.Tables[2].Copy();
                obj.T_Planing_SiteSurveyDT.TableName = "Sitexurvey";
                obj.T_Planing_SiteSurvey_File1DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[3].Copy(), "TPlaing_File", 2, uploadPath);
                obj.T_Planing_SiteSurvey_File1DT.TableName = "TPlaing_File";
                obj.T_Planing_SiteSurvey_File2DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[4].Copy(), "TPlaing_File", 2, uploadPath);
                obj.T_Planing_SiteSurvey_File2DT.TableName = "TPlaing_File";
                #endregion

                #region  Site Preparation


                obj.T_Planing_SitePreparationDT = ds.Tables[5].Copy();
                obj.T_Planing_SitePreparationDT.TableName = "SitePreparation";

                obj.T_Planing_SitePreparation_FileDT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[6].Copy(), "TPlaing_File", 4, uploadPath);
                obj.T_Planing_SitePreparation_FileDT.TableName = "TPlaing_File";


                obj.T_Planing_SitePreparation_UnderDT = DTO.Util.ConvertX.ConvertToSitePreparationUnder(ds.Tables[7].Copy());
                obj.T_Planing_SitePreparationDT.TableName = "SitePreparation_under";

                obj.T_Planing_WeatherCollectionDT = ds.Tables[8].Copy();
                 

                    #endregion



                }
              


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;

        }
        public TPlaningAllDTO GetInspectionPlanAll(string PID, string uploadPath,string actionPath)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            TPlaningAllDTO obj = new TPlaningAllDTO();

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string procName = "sp_T_Planing_AllReport";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();

                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PID", PID));

                da.SelectCommand = command;
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    #region T_Planing
                    obj.T_PlaningDT = ds.Tables[0].Copy();
                    obj.T_PlaningDT.TableName = "TPlaning";
                    obj.T_Planing_FilesDT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[1].Copy(), "TPlaing_File", 2, uploadPath+"/" + PID);
                    obj.T_Planing_FilesDT.TableName = "TPlaing_File";
                    #endregion

                    #region T_Planing_Action_SiteSurvey


                    obj.T_Planing_SiteSurveyDT = ds.Tables[2].Copy();
                    obj.T_Planing_SiteSurveyDT.TableName = "Sitesurvey";
                    obj.T_Planing_SiteSurvey_File1DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[3].Copy(), "TPlaing_File", 2, actionPath + "/SiteSurvey/" + PID+"/1");
                    obj.T_Planing_SiteSurvey_File1DT.TableName = "TPlaing_File";
                    obj.T_Planing_SiteSurvey_File2DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[4].Copy(), "TPlaing_File", 2, actionPath + "/SiteSurvey/" + PID + "/2");
                    obj.T_Planing_SiteSurvey_File2DT.TableName = "TPlaing_File";
                    #endregion

                    #region  Site Preparation


                    obj.T_Planing_SitePreparationDT = ds.Tables[5].Copy();
                    obj.T_Planing_SitePreparationDT.TableName = "SitePreparation";

                    obj.T_Planing_SitePreparation_FileDT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[6].Copy(), "TPlaing_File", 4, actionPath + "/SitePreparation/" + PID + "/1");
                    obj.T_Planing_SitePreparation_FileDT.TableName = "TPlaing_File";


                    obj.T_Planing_SitePreparation_UnderDT = DTO.Util.ConvertX.ConvertToSitePreparationUnder(ds.Tables[7].Copy());
                    obj.T_Planing_SitePreparationDT.TableName = "SitePreparation_under";



                    #endregion

                    #region Weather Collection

                    obj.T_Planing_WeatherCollectionDT = ds.Tables[8].Copy();

                    #endregion

                    #region Before Coating Removal
                    obj.T_Planing_BFRemovalDT = ds.Tables[9].Copy();
                    obj.T_Planing_BFRemovalDT.TableName = "BeforeCoatingRemoval";


                    obj.T_Planing_BFRemoval_ConditionDT = ds.Tables[10].Copy();
                    obj.T_Planing_BFRemoval_ConditionDT.TableName = "BeforeCoatingRemoval_Condition";
                    obj.T_Planing_BFRemoval_ConditionDT.Columns.Add("File", typeof(byte[]));
                    foreach (DataRow drTemp in obj.T_Planing_BFRemoval_ConditionDT.Rows)
                    {

                        drTemp["FileName"] = string.Format(@"{0}/{1}", actionPath + "/BFRemoval/" + PID + "/3", drTemp["FileName"].ToString());
                    }



                   obj.T_Planing_BFRemoval_File1DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[11].Copy(), "TPlaing_File", 2, actionPath + "/BFRemoval/" + PID + "/1");
                    obj.T_Planing_BFRemoval_File1DT.TableName = "TPlaing_File";

                    obj.T_Planing_BFRemoval_File2DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[12].Copy(), "TPlaing_File", 2, actionPath + "/BFRemoval/" + PID + "/2");
                    obj.T_Planing_BFRemoval_File2DT.TableName = "TPlaing_File";

                    #endregion


                    #region After Coating Removal

                    obj.T_Planing_AFRemovalDT= ds.Tables[13].Copy();
                    obj.T_Planing_AFRemovalDT.TableName = "AfterCoatingRemoval";
                    obj.T_Planing_AFRemoval_DefectDT = ds.Tables[14].Copy();
                    obj.T_Planing_AFRemoval_DefectDT.TableName = "AfterCoatingRemoval_Defect";

                    foreach (DataRow drTemp in obj.T_Planing_AFRemoval_DefectDT.Rows)
                    {

                        drTemp["FileName"] = string.Format(@"{0}/{1}", actionPath + "/AfterRemoval/" + PID + "/1", drTemp["FileName"].ToString());
                    }



                    obj.T_Planing_AFRemoval_WallThicknessDT = ds.Tables[15].Copy();
                    obj.T_Planing_AFRemoval_WallThicknessDT.TableName = "AfterCoatingRemoval_WallThickness";



                    #endregion

                    #region AppliedCoating
                    obj.T_Planing_AppliedCoatingDT = ds.Tables[16].Copy();
                    obj.T_Planing_AppliedCoatingDT.TableName = "AppliedCoating";

                    obj.T_Planing_AppliedCoating_SurfaceProfileDT = ds.Tables[17].Copy();
                    obj.T_Planing_AppliedCoating_SurfaceProfileDT.TableName = "AppliedCoating_SurfaceProfile";

                    foreach (DataRow drTemp in obj.T_Planing_AppliedCoating_SurfaceProfileDT.Rows)
                    {

                        drTemp["FileName"] = string.Format(@"{0}/{1}", actionPath + "/AppliedCoating/" + PID + "/1", drTemp["FileName"].ToString());
                    }


                    obj.T_Planing_AppliedCoating_InformationDT = ds.Tables[18].Copy();
                    obj.T_Planing_AppliedCoating_InformationDT.TableName = "AppliedCoating_Information";


                    #endregion


                    #region After AppliedCoating
                    obj.T_Planing_AfterAppliedCoatingDT = ds.Tables[19].Copy();
                    obj.T_Planing_AfterAppliedCoatingDT.TableName = "AfterAppliedCoating";

                    obj.T_Planing_AfterAppliedCoating_DryFilmThicknessDT = ds.Tables[20].Copy();
                    obj.T_Planing_AfterAppliedCoating_DryFilmThicknessDT.TableName = "AfterAppliedCoating_DryFilmThickness";



                    obj.T_Planing_AfterAppliedCoating_File1DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[21].Copy(), "TPlaing_File", 2, actionPath + "/AfterAppliedCoating/" + PID + "/1");
                    obj.T_Planing_AfterAppliedCoating_File1DT.TableName = "TPlaing_File";

                    obj.T_Planing_AfterAppliedCoating_File2DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[22].Copy(), "TPlaing_File", 2, actionPath + "/AfterAppliedCoating/" + PID + "/2");
                    obj.T_Planing_AfterAppliedCoating_File2DT.TableName = "TPlaing_File";



                    #endregion


                    #region Site Recovery
                    obj.T_Planing_SiteRecoveryDT = ds.Tables[23].Copy();
                    obj.T_Planing_SiteRecoveryDT.TableName = "SiteRecovery";


                    obj.T_Planing_SiteRecovery_File1DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[24].Copy(), "TPlaing_File", 2, actionPath + "/SiteRecovery/" + PID + "/1");
                    obj.T_Planing_SiteRecovery_File1DT.TableName = "TPlaing_File";

                    obj.T_Planing_SiteRecovery_File2DT = DTO.Util.ConvertX.ConvertDatatableToReportFile(ds.Tables[25].Copy(), "TPlaing_File", 2, actionPath + "/SiteRecovery/" + PID + "/2");
                    obj.T_Planing_SiteRecovery_File2DT.TableName = "TPlaing_File";

                    #endregion
                }



            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;

        }

    }
}
