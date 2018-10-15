<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="TestAPI.aspx.cs" Inherits="TestAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <script type="text/javascript">

      var curStep;


      var currentURL = 'http://tapi.estarpcl.com/RealQCAPI/api/AddDetailInspec';
      curStep = $(".form-group");

      $(document).ready(function () {
          
          $('.btnSave').on('click', function (e) {
              var tab_type = $('#api_tab').val();
              console.log('--> tab_type :', tab_type);
              if ('02' == tab_type) {
                  var formData = new FormData();
                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "01");
                  formData.append("PID", "194");
                  formData.append("AreaOwner", "1");
                  formData.append("North", "1");
                  formData.append("East", "1");
                  formData.append("Brand", "1");
                  formData.append("Model", "1");
                  formData.append("SN", "1");
                  formData.append("SoildType", "1");
                  formData.append("BacteriaAPB", "1");
                  formData.append("BacteriaSRB", "1");
                  formData.append("PH", "1");
                  formData.append("DigLength", "1");
                  formData.append("Underground_Foc", "1");
                  formData.append("Underground_OtherPipline", "1");
                  formData.append("Underground_Powerline", "1");
                  formData.append("Underground_Etc", "1");
                  formData.append("DepthOfCover", "1");
                  formData.append("MoreDetail", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("PipelineSection", "1");

                  var undergroundList = [];
                  var record = {};
                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.PID = "194";
                  record.UID = "1";
                  record.Value = "1";
                  record.CreateBy = "1";
                  record.UpdateBy = "1";
                  record.Status = "1";
                  undergroundList.push(record);

                  formData.append("objList", JSON.stringify(undergroundList));
                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionSitePreparation/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('03' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("No", "1");
                  formData.append("CollectDate", "1");
                  formData.append("CollectHour", "1");
                  formData.append("CollectMinute", "1");
                  formData.append("WetTemp", "1");
                  formData.append("DryTemp", "1");
                  formData.append("SteelSurfaceTemp", "1");
                  formData.append("DewPoint", "1");
                  formData.append("RelativeHumidity", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("UserID", "11");
                  
                  //var recordList = [];
                  //var record = {};
                  


                  //recordList.push(record);

                  formData.append("objList", JSON.stringify(undergroundList));
                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanWeatherCollection/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('04' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("CoatingTypeID", "060E4C8B-6F44-4AD7-A078-4BB9B14EA5CE");
                  formData.append("FieldJoinTypeID", "1");
                  formData.append("RepairLength", "1");
                  formData.append("CoatingThickness", "1");
                  formData.append("Degree", "1");
                  formData.append("DegreeLength", "1");
                  formData.append("WaterCondense", "1");
                  formData.append("HolidayTest", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("Status", "1");
                  formData.append("DefectImgUrl", "1");
                  formData.append("UserID", "11");


                  var recordList = [];
                  var record = {};

                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.ID = "1";
                  record.PID = "194";
                  record.No = "1";
                  record.DefectTypeID = "1";
                  record.DisWidth = "1";
                  record.DisLength = "1";
                  record.DegreeFrom = "1";
                  record.DegreeLength = "1";
                  record.DegreePosition = "1";
                  record.RiskScore = "1";
                  record.Remark = "1";
                  record.FileName = "1";
                  record.CreateDate = "1";
                  record.CreateBy = "1";
                  record.UpdateDate = "1";
                  record.UpdateBy = "1";
                  record.Status = "1";
                  record.Row_State = "1";
                  
                  recordList.push(record);

                  formData.append("defectList", JSON.stringify(recordList));

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      formData.append('picture', inputFiles[i].files[0]);
                  }

                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionBFRemoval/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('05' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("PH", "1");
                  formData.append("DefectNumber", "1");
                  formData.append("Brand", "1");
                  formData.append("Model", "1");
                  formData.append("SN", "1");
                  formData.append("Defect", "1");
                  formData.append("DefectLength", "1");
                  formData.append("Guage", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("Status", "1");
                  formData.append("Degree", "1");
                  formData.append("DegreeLength", "1");
                  formData.append("DefectImgUrl", "1");
                  formData.append("WallThicknessImgUrl", "1");
                  formData.append("UserID", "11");

                  var recordList = [];
                  var record = {};

                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.ID = "1";
                  record.PID = "194";
                  record.ItemNo = "1";
                  record.DefectTypeID = "1";
                  record.DegreePosition = "1";
                  record.SizeW = "1";
                  record.SizeL = "1";
                  record.SizeD = "1";
                  record.PipeDefect1 = "1";
                  record.PipeDefect2 = "1";
                  record.PipeDefect3 = "1";
                  record.PipeDefect4 = "1";
                  record.FromDistance = "1";
                  record.Length = "1";
                  record.RiskScore = "1";
                  record.Remark = "1";
                  record.RepaireMethod = "1";
                  record.FileName = "1";
                  record.CreateBy = "1";
                  record.UpdateBy = "1";
                  record.Status = "1";

                  recordList.push(record);

                  formData.append("defectInputList", JSON.stringify(recordList));

                  recordList = [];
                  record = {};

                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.ID = "1";
                  record.PID = "194";
                  record.ItemNo = "1";
                  record.PositionNo = "1";
                  record.ClockPosition0 = "1";
                  record.ClockPosition90 = "1";
                  record.ClockPosition135 = "1";
                  record.ClockPosition180 = "1";
                  record.ClockPosition225 = "1";
                  record.ClockPosition270 = "1";
                  record.Remark = "1";
                  record.CreateBy = "1";
                  record.UpdateBy = "1";
                  record.Status = "1";

                  formData.append("wallThicknessInputList", JSON.stringify(recordList));

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      formData.append('picture_1', inputFiles[i].files[0]);
                  }

                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionAfterRemoval/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('06' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("SurfaceType", "1");
                  formData.append("SurfaceBrand", "1");
                  formData.append("SurfaceModel", "1");
                  formData.append("CoatingBrand", "1");
                  formData.append("CoatingTypeID", "1");
                  formData.append("CoatingModel", "1");
                  formData.append("Remark", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("Status", "1");
                  formData.append("UserID", "11");

                  var recordList = [];
                  var record = {};

                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.PID = "194";
                  record.No = "1";
                  record.InfoType = "1";
                  record.InfoDate = "1";
                  record.PartA = "1";
                  record.PartB = "1";
                  record.Solvent = "1";
                  record.Remark = "1";
                  record.CreateBy = "1";
                  record.UpdateBy = "1";
                  record.FileSize = "1";
                  
                  recordList.push(record);

                  formData.append("coatingInfomationList", JSON.stringify(recordList));

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      formData.append('picture_1', inputFiles[i].files[0]);
                  }

                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionAppliedCoating/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('07' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("DryDFTEquipment", "1");
                  formData.append("DryBrand", "1");
                  formData.append("DryModel", "1");
                  formData.append("DrySN", "1");
                  formData.append("HolidayTestMethod", "1");
                  formData.append("HolidayBrand", "1");
                  formData.append("HolidayModel", "1");
                  formData.append("HolidaySN", "1");
                  formData.append("HolidayTestVoltage", "1");
                  formData.append("HolidayRemark", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("Status", "1");
                  formData.append("UserID", "11");

                  var recordList = [];
                  var record = {};

                  record.TPID = "04A15E7D-923B-4819-A53A-BF8E9462BE9D";
                  record.ID = "1";
                  record.PID = "194";
                  record.No = "1";
                  record.PositionNo = "1";
                  record.RepairType = "1";
                  record.ClockPosition1 = "1";
                  record.ClockPosition2 = "1";
                  record.ClockPosition3 = "1";
                  record.ClockPosition4 = "1";
                  record.AVGDFT = "1";
                  record.CreatedBy = "1";
                  record.UpdatedBy = "1";
                  record.Status = "1";

                  recordList.push(record);

                  formData.append("DryFilmList", JSON.stringify(recordList));

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      formData.append('picture_1', inputFiles[i].files[0]);
                  }

                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionAfterAppliedCoating/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else if ('08' == tab_type) {
                  var formData = new FormData();

                  formData.append("TPID", "04A15E7D-923B-4819-A53A-BF8E9462BE9D");
                  formData.append("ID", "1");
                  formData.append("PID", "194");
                  formData.append("IssueDate", "1");
                  formData.append("Remark", "1");
                  formData.append("Approval1", "1");
                  formData.append("Approval2", "1");
                  formData.append("Approval3", "1");
                  formData.append("ApprovalDate1", "1");
                  formData.append("ApprovalDate2", "1");
                  formData.append("ApprovalDate3", "1");
                  formData.append("CreatedBy", "1");
                  formData.append("UpdatedBy", "1");
                  formData.append("Status", "1");
                  formData.append("UserID", "11");

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      formData.append('picture_1', inputFiles[i].files[0]);
                  }

                  console.log('--> formData :', formData);

                  $.ajax({
                      url: 'http://localhost:3613/api/PlanActionSiteRecovery/Add',
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {
                          console.log('--> result :', result);
                          $('#api_result').val(JSON.stringify(result));
                      },
                      error: function (err) {
                          $('#api_result').val(err.statusText);
                      }
                  });
              }
              else {

                  var formData = new FormData();

                  var inputFiles = $('input[type="file"]');

                  for (var i = 0; i < inputFiles.length; i++) {
                      // formData.append('picture', inputFiles[i].files[0]);

                  }

                  formData.append("user_id", "1");
                  formData.append("token", "1");
                  formData.append("inspection_detail_id", "1");
                  formData.append("post_defect_id", "1");
                  formData.append("id_defect_list", "1");
                  formData.append("remark", "remark");
                  formData.append("picture", "picture");
                  formData.append("reference", "1");
                  formData.append("status", "1");
                  formData.append("other", "other");
                  formData.append("round", "1");
                  formData.append("room_id", "1");
                  formData.append("piority", "piority");
                  formData.append("id", "id");


                  $.ajax({
                      url: currentURL,
                      type: "POST",
                      data: formData,
                      contentType: false,
                      processData: false,
                      success: function (result) {

                          BAlert('Saved', 'Save data successfully!.');

                          formData = null;

                          var obj = JSON.parse(result)
                          //  LoadDefectTable(obj, tab);
                          // Search();
                          // LoadDropdownlist();
                          //   $(".myModal").modal('hide');
                          // ClearControl();

                      },
                      error: function (err) {
                          alert(err.statusText)
                      }
                  });
              }
          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <input id="File1" type="file" />
    <select id="api_tab">
        <option value="02">Site Preparation</option>
        <option value="03">Weather Collection</option>
        <option value="04">Before Removal</option>
        <option value="05">After Removal</option>
        <option value="06">Applied Coating</option>
        <option value="07">After Applied Coating</option>
        <option value="08">Site Recovery</option>
    </select>
    <button type="button" class="btn btn-lg bg-success btnSave">บันทึก</button>
    <br/>
    <textarea rows="20" cols="200" id="api_result"></textarea>
    
</asp:Content>

