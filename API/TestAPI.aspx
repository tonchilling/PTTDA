<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="TestAPI.aspx.cs" Inherits="TestAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <script type="text/javascript">

      var curStep;


      var currentURL = 'http://tapi.estarpcl.com/RealQCAPI/api/AddDetailInspec';
      curStep = $(".form-group");

      $(document).ready(function () {


          $('.btnSave').on('click', function (e) {

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



          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <input id="File1" type="file" />
        <button type="button" class="btn btn-lg bg-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
      


</asp:Content>

