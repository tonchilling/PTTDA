var widthAll = [180, 270, 0, 90];

$(document).ready(function () {


    $('.checkSelect').on("click", function (e) {
        var val = "";

        if (selectObj != null) {


            selectObj = selectObj.sort(function (a, b) {
                return (a.Id > b.Id) ? 1 : -1;
            });

            $.each(selectObj, function (key, item) {
                val += "Item:" + item.Id + ">>" + item.Select + "\n";
            });


        }
    });



    $('.btnPreview').on("click", function (e) {

        PreviewPoint();

        $('html, body').animate({
            scrollTop: $(".divPoint").offset().top
        }, 1000);




    });









    DragDrop();







});


function PreviewPoint() {
    var row = $('.txtHolidayTest').val();



    $('.draggable').remove();
    selectObj = null;
    selectObj = [];

    var riskscoreArr = $('.ddlRiskScore').toArray();
    var txtWidth = $('.txtDisWidth').toArray();
    var txtLength = $('.txtDisLength').toArray();


    var repairLength = $('.txtRepairLength').val();
    var scalLength = 0;
    var scalWidth = 0;

    var divPoint;



    for (var i = 1; i <= row; i++) {


        var selectItem = riskscoreArr[i - 1];
        var selectWidth = txtWidth[i - 1];
        var selectLength = txtLength[i - 1];

        var riskScore = $(selectItem).find(":selected").text();



        if (riskScore != "") {

             divPoint = $("<div id=\"select" + i + "\" val=\"" + i + "\" class=\"draggable drag-drop level" + riskScore + " yes-drop text-center\" data-x='0'  data-y='0' style=\"position:absolute\">" + (i) + " </div>");


            if (repairLength <= 1) {
                scalLength = $(selectLength).val() * 10;


            } else {
                scalLength = $(selectLength).val();

            }

            scalWidth = $(selectWidth).val();

            // alert(scalLength)
            var td = $('td[class=dropzone][val="' + scalWidth.toString() + '_' + parseInt(scalLength).toString() + '"]');
            td.append(divPoint);

            if (td.offset() != null) {

                var length = scalLength - parseInt(scalLength);

                // divPoint.css('left', (divPoint.offset().left - td.width())+ (length * td.width()));
                //  divPoint.css('left', (divPoint.offset().left - (td.width() - ((td.width()*8)/100))) + (length * td.width()));
            }

            divPoint.dragMoveListener = dragMoveListener;
        }
    }


}

function UpdatePosition(postionNumber,WidthLength) {


    $txtDisWidth = $('.divDefectTable> table').find('.txtItemNo[value=' + postionNumber + ']').closest('tr').find('.txtDisWidth');
    $txtDisLength = $('.divDefectTable > table').find('.txtItemNo[value=' + postionNumber + ']').closest('tr').find('.txtDisLength');

    var repairLength = $('.txtRepairLength').val();


    if (repairLength <= 1) {

        $txtDisWidth.val(WidthLength.split('_')[0] );
        $txtDisLength.val(WidthLength.split('_')[1] / 10);


    } else {


        $txtDisWidth.val(WidthLength.split('_')[0]);


        if (parseInt($txtDisWidth.val()) != parseInt(WidthLength.split('_')[1]))
        {
        $txtDisLength.val(WidthLength.split('_')[1]);
        }

    }


      // $txtDisWidth.val(WidthLength);
}

function GetRiskScoreColor(level) {

}

function DragDrop() {


    // target elements with the "draggable" class
    interact('.draggable')
  .draggable({
      // enable inertial throwing
      inertia: true,
      // keep the element within the area of it's parent
      restrict: {
          // restriction: "parent",
          endOnly: true,
          elementRect: { top: 0, left: 0, bottom: 1, right: 1 }
      },
      // enable autoScroll
      autoScroll: true,

      // call this function on every dragmove event
      onmove: dragMoveListener,





      /*
      var objSelect=$(event.relatedTarget)
      var target=$(event.target)
      var resultAarray;

      alert(objSelect)
      if(selectObj!=null)
      {
      $.each(selectObj,function (key,item){
     
      if(item!=null && item.Id==objSelect.attr('id'))
      {
         
      selectObj=$.grep(selectObj,function(itemAll){
      return  itemAll.Id!=item.Id;});
      }
     
      });

      }*/


      // call this function on every dragend event
      onend: function (event) {



          var textElX = $('.lbPositionX');
          var textElY = $('.lbPositionY');

          var objSelect = $(event.relatedTarget);
          var target = $(event.target)

          //  alert(target.attr('val'))  position  11,12
          //  alert(target.attr('val'))  //point  1,2

          if (objSelect.attr('class') == 'dropzone') {
              UpdatePosition(target.attr('val'), objSelect.attr('val'));
          }
          else if (objSelect.attr('class') != 'dropzone') {


              var resultAarray;

              if (selectObj != null) {


                  // alert(target.attr('id'))
                  $.each(selectObj, function (key, item) {


                      if (item != null && item.Id == target.attr('id')) {


                          selectObj = $.grep(selectObj, function (itemAll) {
                              return itemAll.Id != item.Id;
                          });
                      }

                  });

              }
          } else {


          }


          textElX.val(event.pageX)
          textElY.val(event.pageY)


          //textElX.val(event.pageX - event.x0)
         // textElY.val(event.pageY - event.y0)
        /*textEl.val((Math.sqrt(Math.pow(event.pageX - event.x0, 2) +
                     Math.pow(event.pageY - event.y0, 2) | 0))
            .toFixed(2) + 'px';)*/
       /* 'moved a distance of '
        + (Math.sqrt(Math.pow(event.pageX - event.x0, 2) +
                     Math.pow(event.pageY - event.y0, 2) | 0))
            .toFixed(2) + 'px';*/
      }
  });

    function dragMoveListener(event) {
        var target = event.target,
        // keep the dragged position in the data-x/data-y attributes
        x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
        y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;


        //    alert( x)
        // translate the element
        target.style.webkitTransform =
    target.style.transform =
      'translate(' + x + 'px, ' + y + 'px)';

        // update the posiion attributes
        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);
    }

    // this is used later in the resizing and gesture demos
    window.dragMoveListener = dragMoveListener;




    /* The dragging code for '.draggable' from the demo above
    * applies to this demo as well so it doesn't have to be repeated. */

    // enable draggables to be dropped into this
    interact('.dropzone').dropzone({
        // only accept elements matching this CSS selector
        accept: '.yes-drop',
        // Require a 75% element overlap for a drop to be possible
        overlap: 0.75,

        // listen for drop related events:

        ondropactivate: function (event) {
            // add active dropzone feedback
            //  event.target.classList.add('drop-active');
        },
        ondragenter: function (event) {
            var draggableElement = event.relatedTarget,
        dropzoneElement = event.target;

            // feedback the possibility of a drop
            //  dropzoneElement.classList.add('drop-target');
            //  draggableElement.classList.add('can-drop');
            // draggableElement.textContent = 'Dragged in';
        },
        ondragleave: function (event) {
            // remove the drop feedback style
            // event.target.classList.remove('drop-target');
            // event.relatedTarget.classList.remove('can-drop');
            //  event.relatedTarget.textContent = 'Dragged out';

            if (selectObj != null) {
                var resultAarray = $.grep(selectObj, function (row, item) {
                    return (item.Select == $(event.target).closest('td,th').attr('val'));


                });


                // alert(resultAarray)

                if (resultAarray != null && resultAarray.length == 0) {
                    //  event.target.classList.remove('drop-target');
                }


                CollectData(event);


            }



        },
        ondrop: function (event) {



            CollectData(event);
            //  event.relatedTarget.textContent = 'Dropped';
        },
        ondropdeactivate: function (event) {
            // remove active dropzone feedback
            // event.target.classList.remove('drop-active');
            //  event.target.classList.remove('drop-target');
        }
    });
}


function ReloadFile(files, section) {
    var fileTable = section == '1' ? $("#filename1 tbody") : $("#filename2 tbody");
    fileTable.empty();
    var fileid = 0;
    files.forEach(function (f) {
        fileTable.append("<tr id='" + fileid + "_row' data ='" + fileid + "'>" +
                                    "<td class='filename'>" + f.name + "</td>" +
                                    "<td class='filesize'>" + f.size + "</td>" +
                                    "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
        fileid++;
    });
}


function CollectData(event) {

    var objSelect = $(event.relatedTarget)
    var target = $(event.target)
    var resultAarray;
    if (selectObj != null) {
        $.each(selectObj, function (key, item) {

            if (item != null && item.Id == objSelect.attr('id')) {

                selectObj = $.grep(selectObj, function (itemAll) {
                    return itemAll.Id != item.Id;
                });
            }

        });







        selectObj.push({ 'Id': objSelect.attr('Id'), 'Select': target.closest('td,th').attr('val') });
    }


}
