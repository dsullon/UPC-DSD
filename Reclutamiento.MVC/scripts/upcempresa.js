// Javascript Object for the ProductEdit panel
var editarEmpresa = new function () {
    var _currentProductId = null,

    loadProduct = function (productId) {
        // Show the product edit div
        $('#productEdit').show();

        // Hide the success message
        $('#productEdit .success').hide();

        var loadingPanel = new LoadingPanel($('#productEdit'));
        loadingPanel.show();

        // Load the product details into the product edit template
        var url = '/Products/Details?id=' + productId;

        $.ajax(url, {
            type: "GET",
            dataType: "html",
            success: function (results) {
                $('#productEdit').html(results);

                loadingPanel.hide();
                $('#productEdit').attr('data-display-mode', 'loaded');

                _currentProductId = productId;
            },
            error: function (data) {
                loadingPanel.hide();
                $('#productEdit').attr('data-display-mode', 'loaded');
            }
        });
    },

    // Send the user input to the service
    crearEmpresa = function () {
        //var loadingPanel = new LoadingPanel($('#productEdit'));
        //loadingPanel.show();

        var clave = $('#Clave').val();
        var email = $('#EmailContacto').val();
        var ruc = $('#NumeroRuc').val();
        var razonSocial = $('#RazonSocial').val();
        var rubro = $('#Rubro').val();

        var empresa = {
            Clave: clave,
            EmailContacto: email,
            NumeroRuc: ruc,
            RazonSocial: razonSocial,
            Rubro: rubro,
        };

        var url = 'Empresa/Registrar';

        $.ajax(url, {
            type: "POST",
            data: empresa,
            dataType: "json",
            success: function (data) {
                if (data.Success == true) {
                    // The update operation has succeeded
                    $('.success').show();
                    $('.alert.alert-error').hide();
                }
                else {
                    // The update operation has failed - display the error message
                    $('.success').hide();
                    $('.alert.alert-error').show();

                    var message = '';
                    for (var i = 0; i < data.Messages.length; i++) {
                        if (i > 0)
                            message += '</br>';

                        message += data.Messages[i];
                    }
                    $('.errorMessage').html(message);
                }

                //loadingPanel.hide();
            },
            error: function (data) {
                //loadingPanel.hide();
            }
        });
    };

    return {
        loadProduct: loadProduct,
        crearEmpresa: crearEmpresa
    }
}();

$('[data-dismiss=modal]').on('click', function (e) {
    var $t = $(this),
        target = $t[0].href || $t.data("target") || $t.parents('.modal') || [];

    $(target)
      .find("input,textarea,select")
         .val('')
         .end()
      .find("input[type=checkbox], input[type=radio]")
         .prop("checked", "")
         .end()
      .find(".alert.alert-error")
         .css("display", "none")
         .end();
})