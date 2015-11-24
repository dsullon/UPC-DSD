$(function () {
$('#NumeroRuc').keypress(function (event) {

    cantidad = $('#NumeroRuc').val().length;
    valruc = $('#NumeroRuc').val();
    key = "PROYUPC";

    if (cantidad == 10){
        url = "http://ws.razonsocialperu.com/rest/index.php";

        $.ajax(url, {
            type: "POST",
            data: {"key": key ,"funct":"RUC", "doc":valruc},
            dataType: "jsonp",
            success: function (results) {
                
                $('#RazonSocial').val(results[0]['razoc']);

            },
            error: function (data) {
                console.log(data);
            }
        });

    } else if (cantidad < 11) {
        console.log('es menor');
    } else if (cantidad > 11) {
        console.log('es mayor');
    } else {

    }

    }
);
});