function convertToCSV(objArray) {
    var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;
    var str = '';

    for (var i = 0; i < array.length; i++) {
        var line = '';
        for (var index in array[i]) {
            if (line != '') line += ','

            line += array[i][index];
        }

        str += line + '\r\n';
    }

    return str;
}

function exportCSVFile(headers, items, fileTitle) {
    if (headers) {
      //  items.unshift(headers);
    }

  



    // Convert Object to JSON
    var jsonObject = JSON.stringify(items);

    var csv = this.convertToCSV(jsonObject);

    var exportedFilenmae = fileTitle + '.csv' || 'export.csv';

    var blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    if (navigator.msSaveBlob) { // IE 10+
        navigator.msSaveBlob(blob, exportedFilenmae);
    } else {
        var link = document.createElement("a");
        if (link.download !== undefined) { // feature detection
            // Browsers that support HTML5 download attribute
            var url = URL.createObjectURL(blob);
            link.setAttribute("href", url);
            link.setAttribute("download", exportedFilenmae);
            link.style.visibility = 'hidden';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    }
}



var fileTitle = 'orders'; // or 'my-unique-title'





function exportTableToCSV($table, filename) {

    var $rows = $table.find('tr:has(td)'),

    // Temporary delimiter characters unlikely to be typed by keyboard
    // This is to avoid accidentally splitting the actual contents
      tmpColDelim = String.fromCharCode(11), // vertical tab character
      tmpRowDelim = String.fromCharCode(0), // null character

    // actual delimiter characters for CSV format
      colDelim = '","',
      rowDelim = '"\r\n"',



    // Grab text from table into CSV formatted string
      csv = '"' + $rows.map(function (i, row) {
          var $row = $(row),
          $cols = $row.find('td');

          return $cols.map(function (j, col) {
              var $col = $(col),
            text = $col.text();

              return text.replace(/"/g, '""'); // escape double quotes

          }).get().join(tmpColDelim);

      }).get().join(tmpRowDelim)
      .split(tmpRowDelim).join(rowDelim)
      .split(tmpColDelim).join(colDelim) + '"';

    // Deliberate 'false', see comment below
    if (false && window.navigator.msSaveBlob) {

        var blob = new Blob([decodeURIComponent(csv)], {
            type: 'text/csv;charset=utf8'
        });

        // Crashes in IE 10, IE 11 and Microsoft Edge
        // See MS Edge Issue #10396033
        // Hence, the deliberate 'false'
        // This is here just for completeness
        // Remove the 'false' at your own risk
        window.navigator.msSaveBlob(blob, filename);

    } else if (window.Blob && window.URL) {



        var exportedFilenmae = filename + '.csv' || 'export.csv';

        var blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
        if (navigator.msSaveBlob) { // IE 10+
            navigator.msSaveBlob(blob, filename);
        } else {
            var link = document.createElement("a");
            if (link.download !== undefined) { // feature detection
                // Browsers that support HTML5 download attribute
                var url = URL.createObjectURL(blob);
                link.setAttribute("href", url);
                link.setAttribute("download", filename);
                link.style.visibility = 'hidden';
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
        }

        return;

        return;
        // HTML5 Blob        
        var blob = new Blob([csv], {
            type: 'text/csv;charset=utf-8'
        });
        var csvUrl = URL.createObjectURL(blob);

        $(this)
        .attr({
            'download': filename,
            'href': csvUrl
        });
    } else {
        // Data URI
        var csvData = 'data:application/csv;charset=utf-8,' + encodeURIComponent(csv);

        $(this)
        .attr({
            'download': filename,
            'href': csvData,
            'target': '_blank'
        });
    }
}