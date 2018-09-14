var widthAll = [180, 270, 0, 90];
var colorShades = ["green", "#5ff774", "#fafb8d", "#f9d855", "red"];

$(document).ready(function () {




    $('.btnPreview').on("click", function (e) {

        PreviewPoint();



        $('html, body').animate({
            scrollTop: $(".divPoint").offset().top
        }, 1000);




    });



   








    // DragDrop();







});



function AddPointToCavas() {

    var scal = 0
    var row = $('.txtDefectNumber').val();
    var riskscoreArr = $('.ddlRiskScore').toArray();
    var txtWidth = $('.txtDegreePosition').toArray();
    var txtLength = $('.txtLength').toArray();

    var left = 0, top = 0;

    var c = document.querySelector('#mycanvas');
    var ctx = c.getContext("2d");

    scal = 0;

    if (RepairLength <= 10) {
        scal = parseFloat(RepairLength / 100).toFixed(2);
    } else {
        scal = parseFloat(RepairLength / 100).toFixed(1);
    }


    for (var i = 1; i <= row; i++) {



        var selectItem = riskscoreArr[i - 1];
        var selectWidth = txtWidth[i - 1];
        var selectLength = txtLength[i - 1];

        var riskScore = $(selectItem).find(":selected").text();






        scalLength = $(selectLength).val();


        scalLength = (1000 / RepairLength) * (parseFloat(scalLength) - scal) + 10;

        scalWidth = $(selectWidth).val();





        ctx.beginPath();
        ctx.arc(scalLength, CalculateDegreeToWidth(scalWidth), 10, 0, 2 * Math.PI);

        ctx.fillStyle = colorShades[riskScore - 1];
        ctx.lineWidth = 3;
        ctx.strokeStyle = "#ffffff";
        ctx.stroke();
        ctx.fill();
        ctx.fillStyle = "#000";
        ctx.font = "12px Arial";
        ctx.fillText(i, scalLength - 4, CalculateDegreeToWidth(scalWidth) + 4);
        ctx.closePath();


    }



}

function PreviewPoint() {
    var row = $('.txtDefectNumber').val();


    var isCanMove = '0'



    if (objMain != null && objMain.IsSave != null) {
        isCanMove = objMain.IsSave;  // Plan is not 100% or confirm
    }


   $('.box').remove();
    selectObj = null;
    selectObj = [];

    var riskscoreArr = $('.ddlRiskScore').toArray();
    var txtWidth = $('.txtDegreePosition').toArray();
    var txtLength = $('.txtLength').toArray();


    var repairLength = RepairLength;
    var scalLength = 0;
    var scalWidth = 0;

    var divPoint;



    for (var i = 1; i <= row; i++) {


        var selectItem = riskscoreArr[i - 1];
        var selectWidth = txtWidth[i - 1];
        var selectLength = txtLength[i - 1];

        var riskScore = $(selectItem).find(":selected").text();



        if (riskScore != "") {

             divPoint = $("<div id=\"select" + i + "\" val=\"" + i + "\" class=\"box text-center level" + riskScore + " \" data-x='0'  data-y='0' style=\"position:absolute\">" + (i) + " </div>");

             var scal = parseFloat(repairLength  / 100).toFixed(2);


             if (RepairLength <= 10) {
                 scal = parseFloat(repairLength / 100).toFixed(2);
             } else {
                 scal = parseFloat(repairLength / 100).toFixed(1);
             }

           
             scalLength = $(selectLength).val();


             scalLength = (1000 / RepairLength) * (parseFloat(scalLength) - scal);

             scalWidth = $(selectWidth).val();



             if (isCanMove == '0') {
                 divPoint = $("<div val=\"" + i + "\" class='boxunmove  text-center level" + riskScore + "' style=\"position:absolute\">" + (i) + "</div>");
             }
             else {
                 divPoint = $("<div val=\"" + i + "\" class='box  text-center level" + riskScore + "' style=\"position:absolute\">" + (i) + "</div>");
             }


         //   divPoint = $("<div val=\"" + i + "\" class='box text-center level" + riskScore + "' style=\"position:absolute\">" + (i) + "</div>");
            $('.canvas').append(divPoint);

            divPoint.css("left", scalLength);
            divPoint.css("top", CalculateDegreeToWidth(scalWidth));

          

          
        }
    }


    var lDegree = 135, lLength = 8, wLength = 0;



    lDegree = $('.txtDegree').val();
    lLength = $('.txtDegreeLength').val();


    DrawTable(lDegree, lLength, wLength);



    DrageDropReload('.Result');


}

function UpdatePosition(postionNumber,top,left) {


   
    $txtDisWidth = $('.divDefectTable> table').find('.txtItemNo[value=' + postionNumber + ']').closest('tr').find('.txtDegreePosition');
    $txtDisLength = $('.divDefectTable > table').find('.txtItemNo[value=' + postionNumber + ']').closest('tr').find('.txtLength');

    var repairLength = RepairLength;

  
    $txtDisWidth.val(top);
    $txtDisLength.val(left);


      // $txtDisWidth.val(WidthLength);
}


function coordinates(element, elResult) {

    var elementJ = $(element);
    var top = elementJ.position().top;
    var left = elementJ.position().left;

    if (left > 990) {
        elementJ.css("left", 990);
    } else if (left < 0) {
        elementJ.css("left", 0);

    }

    if (top > 300) {
        elementJ.css("top", 300);
    } else if (top < 0) {
        elementJ.css("top", 0);

    }
    top = elementJ.position().top;
    left = elementJ.position().left;


    left = left / 100;

    left = (left * RepairLength) / 10;
    //  left = Math.round(left * 100) / 100

    //left = Math.round(left * 100) / 100
    top = Math.round(top * 100) / 100

    var top = CalculateWidthToDegree(top);

    var scal = RepairLength / 100;
    left = left + scal;
    if (RepairLength <= 1) {

        left = left.toFixed(2);
    } else {
        left = left.toFixed(1);
    }


    $(elResult).text('Length :' + left + ' ' + 'Width(degree):' + top);
    UpdatePosition(elementJ.attr('val'), top, left);
}




function Drawwalkness(WallThicknessLength,repairlength) {


    WallThicknessLength = parseInt(WallThicknessLength);

   
    var width = 750 / WallThicknessLength;
    var position = repairlength / (WallThicknessLength+1);
    var img = new Image;

  
  
    
    var c = document.getElementById("canvaswalkness");
    var ctx = c.getContext("2d");

    ctx.beginPath();
    ctx.rect(0, 0, 1070, 360);
    ctx.fillStyle = "#ffffff";

    ctx.fill();


    img.onload = function () {
        ctx.drawImage(img, 0, 0); // Or at whatever offset you like
       

      


        ctx.beginPath();            // canvas path is initilia
        ctx.moveTo(70, 52);
        ctx.lineTo(70, 280);
        ctx.lineWidth = 3;
        ctx.font = "18px Arial";
        ctx.fillStyle = "#000";       // fill color
        ctx.fillText("0", 70, 40);
        ctx.fill();                 // fill method
        ctx.strokeStyle = "#8a8787";     // stroke color
        ctx.stroke();


        ctx.beginPath();            // canvas path is initilia
        ctx.moveTo((1000) / 2, 52);
        ctx.lineTo((1000) / 2, 280);
        ctx.lineWidth = 3;
        ctx.font = "18px Arial";
        ctx.fillStyle = "#000";       // fill color
        ctx.fillText((repairlength / 2).toFixed(2), (1000) / 2, 40);
        ctx.fill();
        ctx.strokeStyle = "#8a8787";     // stroke color
        ctx.stroke();              // fill method


        ctx.moveTo(940, 52);
        ctx.lineTo(940, 280);
        ctx.lineWidth = 3;
        ctx.font = "18px Arial";
        ctx.fillStyle = "#000";       // fill color
        ctx.fillText(repairlength, 940, 40);
        ctx.fill();                 // fill method


        ctx.strokeStyle = "#8a8787";     // stroke color
        ctx.stroke();     
       // width = width + 70;
        for (var i = 1; i <= WallThicknessLength; i++) {
            ctx.beginPath();            // canvas path is initilia
            ctx.moveTo(70+(width * i), 52);
            ctx.lineTo(70 + (width * i), 280);
            ctx.lineWidth = 3;
            ctx.fillStyle = "#ffffff"        // fill color
            ctx.fill();                 // fill method
            ctx.strokeStyle = "#000";     // stroke color
            ctx.stroke();

            ctx.beginPath();
            ctx.font = "18px Arial";
            ctx.fillStyle = "#000";
            ctx.fillText((position * i).toFixed(2), 70 + (width * i), 40);
            ctx.fill();

            // stroke method
        }



        ctx.closePath();

    };

    img.src = ImgWalkness + "?ver=33333";

  


    
}

function DrawTable(lDegree, lLength) {

    var yValue = 0, tempY = 0, tempDegree = 0, tempLength = 0;
    var c = document.querySelector('#mycanvas');
    var ctx = c.getContext("2d");

    var degreeList = [180, 270, 0, 90, 180];

    tempLength = (1000 / RepairLength) * (lLength == '' ? 1 : lLength);


    var scal = 0

    if (RepairLength <= 10) {
        scal = parseFloat(RepairLength / 10).toFixed(2);
    } else {
        scal = parseFloat(RepairLength / 100).toFixed(1);
    }


    scal = parseFloat(RepairLength / 10).toFixed(2);


    ctx.clearRect(0, 0, 1070, 360);

    ctx.beginPath();
    ctx.rect(0, 0, 1070, 360);
    ctx.fillStyle = "#ffffff";

    ctx.fill();


    ctx.beginPath();
    ctx.rect(0, 0, 1000, 320);
    ctx.fillStyle = "#524e4e";
    ctx.fill();




    for (var i = 1; i <= 10; i++) {
        ctx.beginPath();            // canvas path is initilia
        ctx.moveTo(100 * i, 1);
        ctx.lineTo(100 * i, 320);
        ctx.lineWidth = 3;
        ctx.fillStyle = "#ffffff"        // fill color
        ctx.fill();
        ctx.font = "18px Arial";
        ctx.fillStyle = "#000";
        ctx.fillText(parseFloat(scal * i).toFixed(1), 100 * i, 350);               // fill method



        //  ctx.fillStyle = "#0d51c2";
        //    ctx.fillText("Seam weld", 100 * i, 320);               // fill method

        ctx.strokeStyle = "#ffffff";     // stroke color
        ctx.stroke();               // stroke method

    }

    for (var i = 0; i <= 4; i++) {
        ctx.beginPath();            // canvas path is initilia
        ctx.moveTo(1, 80 * i);
        ctx.lineTo(1000, 80 * i);
        ctx.lineWidth = 3;
        ctx.fillStyle = "#ffffff"        // fill color
        ctx.fill();                 // fill method

        ctx.font = "18px Arial";
        ctx.fillStyle = "#000";
        ctx.fillText(degreeList[i] + "°", 1010, i == 0 ? 20 : (80 * i));               // fill method


        ctx.strokeStyle = "#ffffff";     // stroke color
        ctx.stroke();               // stroke method
    }

    // save orientation again
    ctx.save();

    // hold top-right hand corner when rotating
    ctx.translate(1050, 0);

    // rotate 270 degrees
    ctx.rotate(Math.PI / 2);

    ctx.font = "24px Arial";
    ctx.fillStyle = "#000"; // blue
    ctx.textAlign = "left";

    // draw relative to translate point
    ctx.fillText("Degree Position", 80, 0);

    ctx.restore();

    // Round rectangle
    ctx.beginPath();
    ctx.lineWidth = "6";
    ctx.strokeStyle = "#000";
    ctx.rect(0, 0, 1000, 320);
    ctx.stroke();





    // write Y axis


    if (lDegree != "") {
        if (lDegree > 270) {
            tempY = 80;
            tempDegree = lDegree - 270;

        }
        else if (lDegree > 180 && lDegree <= 270) {
            tempY = 0;
            tempDegree = lDegree - 180;
        }
        else if (lDegree >= 90 && lDegree <= 180) {

            tempY = 240;
            tempDegree = lDegree - 90
        }
        else if (lDegree >= 0 && lDegree < 90) {
            tempY = 160;

            tempDegree = lDegree;

        }

        yValue = tempY + (tempDegree * 0.9)




        //Seam weld
        ctx.beginPath();
        ctx.moveTo(3, yValue);
        // ctx.lineTo(tempLength, yValue);
        ctx.lineTo(1000, yValue);
        ctx.lineWidth = 8;
        ctx.fillStyle = "#ffffff"
        ctx.fill();
        ctx.strokeStyle = "#0d51c2";

        ctx.stroke();


        ctx.beginPath();
        ctx.font = "24px Arial";
        ctx.fillStyle = "#ffffff";
        ctx.fillText("Seam weld", 10, yValue + 30);
        //  ctx.fillText("Degree:" + lDegree + ",length:" + lLength, 1, yValue + 30);
        ctx.fill();




        //Girth weld
        ctx.beginPath();
        ctx.moveTo(tempLength, 1);
        ctx.lineTo(tempLength, 320);

        ctx.lineWidth = 8;
        ctx.fillStyle = "#ffffff";
        ctx.fillText("Girth weld", tempLength + 10, 50);
        ctx.fill();                 // fill method
        ctx.strokeStyle = "#1c6cf0";     // stroke color
        ctx.stroke();               // stroke method

    }


    ctx.closePath();


}




function CalculateWidthToDegree(top) {


    if (top >= 0 && top <= 60) {
        top = 180;
    } else if (top >= 60 && top <= 139) {
        top = 270;

    }

    else if (top >= 140 && top <= 220) {
        top = 0;

    }
    else if (top > 220 && top <= 300) {
        top = 90;

    }

    return top;

}

function CalculateDegreeToWidth(top) {


    if (top ==180) {
        top = 30;
    } else if (top ==270) {
        top = 100;

    }

    else if (top ==0) {
        top = 180;

    }
    else if (top ==90) {
        top = 260;

    }

    return top;

}



function DrageDropReload(desElementName) {

    $('.box').draggable({
        revert: 'invalid',
        accept: '.canvas',
        start: function () {
            coordinates(this, desElementName);

        },
        stop: function () {

            coordinates(this, desElementName);

        }
    });

    $('.canvas').droppable({
        accept: '.box',
        drop: function (event, ui) { }
    });

}





