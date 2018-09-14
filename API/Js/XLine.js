/// <reference path="Kinect.d.ts" />

var Draw_Line = (function () {

    function Draw_Line() { }

    Draw_Line.prototype.Line = function () {

        var stage = new Kinetic.Stage({

            container: 'canvas',

            width: 578,

            height: 200

        });

        var layer = new Kinetic.Layer();

        var redLine = new Kinetic.Line({

            points: [

                73,

                70,

                340,

                23,

                450,

                60,

                500,

                20

            ],

            stroke: '#339966',

            strokeWidth: 15,

            lineCap: 'round',

            lineJoin: 'round'

        });

        // dashed line

        var greenLine = new Kinetic.Line({

            points: [

                73,

                70,

                340,

                23,

                450,

                60,

                500,

                20

            ],

            stroke: '#3333FF',

            strokeWidth: 2,

            lineJoin: 'round',

            dashArray: [

                33,

                10

            ]

        });

        // complex dashed and dotted line

        var blueLine = new Kinetic.Line({

            points: [

                73,

                70,

                340,

                23,

                450,

                60,

                500,

                20

            ],

            stroke: '#993333',

            strokeWidth: 10,

            lineCap: 'round',

            lineJoin: 'round',

            dashArray: [

                29,

                20,

                0.001,

                20

            ]

        });

        greenLine.move(0, 5);

        blueLine.move(0, 55);

        redLine.move(0, 105);

        layer.add(redLine);

        layer.add(greenLine);

        layer.add(blueLine);

        stage.add(layer);

    };

    return Draw_Line;

})();