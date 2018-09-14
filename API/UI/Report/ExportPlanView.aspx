<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

      <link href="<%= ResolveUrl("~/css/bootstrap.min.css") %>" rel="stylesheet">
       <link href="<%= ResolveUrl("~/Css/easyui.css") %>" rel="stylesheet" type="text/css" />

   

    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/bluebird/3.3.5/bluebird.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js" integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.5/jspdf.min.js"></script>
       <script src="<%= ResolveUrl("~/Js/jquery.easyui.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Js/datagrid-groupview.js") %>" type="text/javascript"></script>


      <script>
          var lastWeek = 0;
          var createplan = "0";
            var currentDate='<%= DateTime.Now.Day.ToString("##00")+"/"+ DateTime.Now.Month.ToString("##00")+"/"+ DateTime.Now.Year.ToString("####0000")   %>'; 
  var currentYear='<%= DateTime.Now.Year.ToString("####0000")   %>'; 


          var currentURL = "<%= ResolveUrl("~/ASHX/Plan/T_PlaningHandler.ashx") %>"; 
             var userAutorizeURL= "<%= ResolveUrl("~/ASHX/PageControlHandler.ashx")%>";

    </script>
</head>
<body>
    <input type="button" id="create_pdf" value="Generate PDF">

    <form class="form" style="max-width: none; width: 1005px;">



        <h2 style="color: #0094ff">Hello</h2>
        <h3>a bit about this Project:</h3>

          <div class="row" style="padding-top:10px;">
                <div class="col-sm-12">
        <p style="font-size: large">
            I will demonstrate how to generate PDF file of your HTML page with CSS using JavaScript and J query.
        </p>
       
 </div>
          </div>
     <div class="row" style="padding-top:10px;">
                <div class="col-sm-12">

                    <table>
            <tbody>
                <tr>
                    <th>Company</th>
                    <th>Contact</th>
                    <th>Country</th>
                </tr>
                <tr>
                    <td>Alfreds Futterkiste</td>
                    <td>Maria Anders</td>
                    <td>Germany</td>
                </tr>
                <tr>
                    <td>Centro comercial Moctezuma</td>
                    <td>Francisco Chang</td>
                    <td>Mexico</td>
                </tr>
                <tr>
                    <td>Ernst Handel</td>
                    <td>Roland Mendel</td>
                    <td>Austria</td>
                </tr>
                <tr>
                    <td>Island Trading</td>
                    <td>Helen Bennett</td>
                    <td>UK</td>
                </tr>
                <tr>
                    <td>Laughing Bacchus Winecellars</td>
                    <td>Yoshi Tannamuri</td>
                    <td>Canada</td>
                </tr>
                <tr>
                    <td>Magazzini Alimentari Riuniti</td>
                    <td>Giovanni Rovelli</td>
                    <td>Italy</td>
                </tr>
            </tbody>
        </table>

      
          </div>
          </div>


    </form>


</body>

</html>
<script>


    var w = screen.width;
        var
         form = $('.form'),
         cache_width = form.width(),
         a4 = [w, 595.28]; // for a4 size paper width and height

        $('#create_pdf').on('click', function () {
            $('body').scrollTop(0);
           createPDF();
        });
        //create pdf
        function createPDF() {
            getCanvas().then(function (canvas) {
                var
                 img = canvas.toDataURL("image/png"),
                 doc = new jsPDF({
                     orientation: 'landscape',
                     unit: 'mm',
                     format: 'a3'
                 });
                doc.addImage(img, 'JPEG', 20, 20);
                doc.save('bhavdip-html-to-pdf.pdf');
                form.width(cache_width);
            });
        }

        // create canvas object
        function getCanvas() {
         //   form.width((a4[0] * 1.33333) - 80).css('max-width', 'none');
            return html2canvas(form, {
                imageTimeout: 2000,
                removeContainer: true
            });
        }

</script>
<script>
    /*
 * jQuery helper plugin for examples and tests
 */
    (function ($) {
        $.fn.html2canvas = function (options) {
            var date = new Date(),
            $message = null,
            timeoutTimer = false,
            timer = date.getTime();
            html2canvas.logging = options && options.logging;
            html2canvas.Preload(this[0], $.extend({
                complete: function (images) {
                    var queue = html2canvas.Parse(this[0], images, options),
                    $canvas = $(html2canvas.Renderer(queue, options)),
                    finishTime = new Date();

                    $canvas.css({ position: 'absolute', left: 0, top: 0 }).appendTo(document.body);
                    $canvas.siblings().toggle();

                    $(window).click(function () {
                        if (!$canvas.is(':visible')) {
                            $canvas.toggle().siblings().toggle();
                            throwMessage("Canvas Render visible");
                        } else {
                            $canvas.siblings().toggle();
                            $canvas.toggle();
                            throwMessage("Canvas Render hidden");
                        }
                    });
                    throwMessage('Screenshot created in ' + ((finishTime.getTime() - timer) / 1000) + " seconds<br />", 4000);
                }
            }, options));

            function throwMessage(msg, duration) {
                window.clearTimeout(timeoutTimer);
                timeoutTimer = window.setTimeout(function () {
                    $message.fadeOut(function () {
                        $message.remove();
                    });
                }, duration || 2000);
                if ($message)
                    $message.remove();
                $message = $('<div ></div>').html(msg).css({
                    margin: 0,
                    padding: 10,
                    background: "#000",
                    opacity: 0.7,
                    position: "fixed",
                    top: 10,
                    right: 10,
                    fontFamily: 'Tahoma',
                    color: '#fff',
                    fontSize: 12,
                    borderRadius: 12,
                    width: 'auto',
                    height: 'auto',
                    textAlign: 'center',
                    textDecoration: 'none'
                }).hide().fadeIn().appendTo('body');
            }
        };
    })(jQuery);



    $(document).ready(function () {

      
       

        //getCanvas().then(function (canvas) {
        //    var
        //     img = canvas.toDataURL("image/png"),
        //     doc = new jsPDF({
        //         unit: 'px',
        //         format: 'a3'
        //     });
        //    doc.addImage(img, 'JPEG', 20, 20);
        //    doc.save('bhavdip-html-to-pdf.pdf');
        //    form.width(cache_width);
        //});


    });




</script>

