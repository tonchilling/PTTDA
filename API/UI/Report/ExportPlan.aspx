<html>
<head>
    <title>Convert HTML To PDF</title>
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

    <script>
        var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_PlaningHandler.ashx") %>"; 

    </script>
</head>


<body>
    <input type="button" id="create_pdf" value="Generate PDF">

    <form class="form" style="max-width: none; width: 1005px;">


        <h2 style="color: #0094ff">Hello</h2>
        <h3>a bit about this Project:</h3>
        <p style="font-size: large">
            I will demonstrate how to generate PDF file of your HTML page with CSS using JavaScript and J query.
        </p>
       

        <table class="easyui-datagrid table-blue" title="">

            <thead data-options="frozen:true">
                <tr>

                    <th data-options="field:'ck',checkbox:true,width:120,align:'center'" rowspan="2">RC</th>
                    <th data-options="field:'Edit',width:80,align:'center',formatter:editFormat" rowspan="2">Edit</th>
                    <th data-options="field:'Delete',width:100,align:'center',formatter:deleteFormat" rowspan="2">Delete</th>
                    <th data-options="field:'RouteCode',width:80,align:'center'" rowspan="2">RC</th>
                    <th data-options="field:'StartEndPipeline',width:100,align:'right'" colspan="2">Pipline</th>
                    <th data-options="field:'RegionCode',width:60,align:'center'" rowspan="2">Region</th>
                    <th data-options="field:'DIGFrom',width:80,align:'center'" rowspan="2">Dig From</th>
                    <th data-options="field:'RiskScore',width:60,align:'center',formatter:serFormat" rowspan="2">Serverity</th>
                    <th data-options="field:'Progress',width:60,align:'center',formatter:progressFormat" rowspan="2">Progress</th>
                    <th data-options="field:'TimeLine',width:120,align:'center',formatter:timelineFormat" rowspan="2">Timeline</th>

                </tr>
                <tr>


                    <th data-options="field:'StartEndPipeline',width:100,align:'center'">Section</th>
                    <th data-options="field:'KP',width:80,align:'center'">KP</th>
                </tr>
            </thead>
            <thead>
                <tr>
                    <th colspan="4">Jan<Section></Section></th>
                    <th colspan="4">Fab<Section></Section></th>
                    <th colspan="4">Mar<Section></Section></th>
                    <th colspan="4">Apr<Section></Section></th>
                    <th colspan="4">May<Section></Section></th>
                    <th colspan="4">Jun<Section></Section></th>
                    <th colspan="4">Jul<Section></Section></th>
                    <th colspan="4">Aug<Section></Section></th>
                    <th colspan="4">Sep<Section></Section></th>
                    <th colspan="4">Oct<Section></Section></th>
                    <th colspan="4">Nov<Section></Section></th>
                    <th colspan="4">Dec<Section></Section></th>
                </tr>
            </thead>
            <thead>
                <tr>

                    <th data-options="field:'jan_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'jan_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'jan_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'jan_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>



                    <th data-options="field:'feb_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'feb_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'feb_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'feb_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>



                    <th data-options="field:'mar_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'mar_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'mar_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'mar_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>


                    <th data-options="field:'apr_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'apr_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'apr_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'apr_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>



                    <th data-options="field:'may_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'may_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'may_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'may_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>





                    <th data-options="field:'jun_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'jun_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'jun_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'jun_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>



                    <th data-options="field:'jul_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'jul_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'jul_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'jul_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>




                    <th data-options="field:'aug_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'aug_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'aug_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'aug_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>




                    <th data-options="field:'sep_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'sep_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'sep_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'sep_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>


                    <th data-options="field:'oct_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'oct_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'oct_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'oct_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>




                    <th data-options="field:'nov_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'nov_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'nov_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'nov_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>


                    <th data-options="field:'dec_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                    <th data-options="field:'dec_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                    <th data-options="field:'dec_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                    <th data-options="field:'dec_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>




                </tr>
            </thead>
        </table>


    </form>


</body>

</html>
<script>



        var
         form = $('.form'),
         cache_width = form.width(),
         a4 = [595.28, 841.89]; // for a4 size paper width and height

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
                     unit: 'px',
                     format: 'a4'
                 });
                doc.addImage(img, 'JPEG', 20, 20);
                doc.save('bhavdip-html-to-pdf.pdf');
                form.width(cache_width);
            });
        }

        // create canvas object
        function getCanvas() {
            form.width((a4[0] * 1.33333) - 80).css('max-width', 'none');
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

        $('body').scrollTop(0);
       

        getCanvas().then(function (canvas) {
            var
             img = canvas.toDataURL("image/png"),
             doc = new jsPDF({
                 unit: 'px',
                 format: 'a4'
             });
            doc.addImage(img, 'JPEG', 20, 20);
            doc.save('bhavdip-html-to-pdf.pdf');
            form.width(cache_width);
        });


    });



    function LoadTable2() {
        var formData = new FormData();
        formData.append("Action", "View");





        formData.append("AssetOwnerID","");
        formData.append("RegionID", "");
        formData.append("DIGFromID", "");
        formData.append("PipelineID", "");
        formData.append("RouteCodeID", "");
        formData.append("Year", "2018");


        // formData.append("Year",($(".ddlYear").val() == null ? currentYear : $(".ddlYear").val()));
        //  waitingDialog.show('LOADING', {dialogSize: 'lg', progressType: 'primary'});



        $.ajax({
            url: currentURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {


                var data = JSON.parse(result);



                $(".easyui-datagrid").datagrid({
                    minHeight: 150,
                    rownumbers: true,
                    singleSelect: false,
                    data: data,
                    method: 'get',
                    view: groupview,
                    groupField: 'PipelineName',
                    groupFormatter: groupRow,
                    onLoadSuccess: onLoadSuccess2

                });





                setTimeout(function () { waitingDialog.hide(); }, 1000);
            },
            error: function (ex) {
                alert(ex)
            }

        });



    }


</script>
