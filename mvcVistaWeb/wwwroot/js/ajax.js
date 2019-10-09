$("#buscarUsuario").click(function () {

    var usuarioId = parseInt($("#usuarioIdConAjax").val());

    console.log(usuarioId);

    var json = {}
    json["id"] = usuarioId;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarUsuarioConAjax",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#usuario").html("" +
                "<p><h3>Usuario encontrado sin AJAX</h3></p>" +
                "<p><b>ID: </b>" + response["id"] + "</p>" +
                "<p><b>Email: </b>" + response["email"] + "</p>" +
                "<p><b>Direccion: </b>" + response["direccion"] + "</p>" +
                "<p><b>Puntos: </b>" + response["puntos"] + "</p>" +
            "");

        }

    })

});