// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function AddCharacteristic() {

    $('#CharacteristicValidation').hide();
    //Préparation des données de formulaire
    let form = new FormData();
    form.append('Name', $('#CharacteristicName').val());
    //envoi du formulaire
    $.ajax({
        url: "/Category/AddCharacteristic",
        type: "POST",
        data: form,
        cache: false,
        contentType: false,
        processData: false,
        //Réception et Affichage du tableu en cas de succès
        success: function (data) {
            $('#Characteristics').html(data);
            $('#CharacteristicName').val("");
        },
        //Réception et affichage de l'erreur au cas ou le formulaire ne serait pas bon
        error: function (data) {
            $('#CharacteristicValidation').html("");
            $('#CharacteristicValidation').show();
            let json = jQuery.parseJSON(data.responseText)
            
            $.each(json, function (index, value) {
                $('#CharacteristicValidation').append("<ul>");
                $('#CharacteristicValidation').append("<lh>" + value["PropertyName"] + " : </lh>");
                $.each(value["Errors"], function (index, value) {
                    $('#CharacteristicValidation').append("<li>" + value + "</li>");
                });
                $('#CharacteristicValidation').append("</ul>");
            });            
        }
    });
}

function RemoveCharacteristic(index) {
    $.ajax({
        url: "/Category/RemoveCharacteristic/" + index,
        dataType: "html",
        type: "get",
        //Réception et Affichage du tableu en cas de succès
        success: function (data) {
            $('#Characteristics').html(data);
        },
        //Réception et affichage de l'erreur au cas ou le formulaire ne serait pas bon
        error: function (data) {
            $('#CharacteristicValidation').show();
            $('#CharacteristicValidation').html("<p class=\"alert-danger\">Bad request...</p>");
        }
    });
}