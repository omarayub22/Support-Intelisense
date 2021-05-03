var popup, dataTable;
$(document).ready(function () {
    var applicationUserId = $('#Id').val();
    dataTable = $('#gridOrganization').DataTable({
        "ajax": {
            "url": "/api/organization/" + applicationUserId,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "srNo",},
            { "data": "name",},
            { "data": "discription",},
            {
                "data": "mentionDate",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            {
                "data": "organizationId",
                "render": function (data) {
                    var view = "<a class='btn btn-default btn-xs' href='/Logs?org=" + data + "'><i class='fa fa-eye'></i></a>";
                    var edit = "<a class='btn btn-default btn-xs'  style= 'margin-left:1px' onclick=ShowPopup('/Organizations/AddEditOrganization/" + data + "')><i class='fa fa-pencil'></i></a>";
                    var del = "<a class='btn btn-default btn-xs' onclick=Delete('" + data + "')><i class='fa fa-trash'></i></a>";
                    return view + edit + del;
                }
            }
        ],
        "dom": "Bfrtip",
        "buttons": [
            'excel',
            'csv',
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "lengthChange": true,
        "paging": true,
        "pageLength":true,
    });
});

function ShowPopup(url) {
    var modalId = 'modalDefault';
    var modalPlaceholder = $('#' + modalId + ' .modal-dialog .modal-content');
    $.get(url)
        .done(function (response) {
            modalPlaceholder.html(response);
            popup = $('#' + modalId + '').modal({
                keyboard: false,
                backdrop: 'static'
            });
        });
}


function SubmitAddEdit(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var data = $(form).serializeJSON();
        data = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/api/organization',
            data: data,
            contentType: 'application/json',
            success: function (data) {
                if (data.success) {
                    popup.modal('hide');
                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                } else {
                    ShowMessageError(data.message);
                }
            }
        });

    }
    return false;
}

function Delete(id) {
    swal({
        title: "Are you sure want to Delete?",
        text: "You will not be able to restore the data!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dd4b39",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: '/api/organization/' + id,
            success: function (data) {
                if (data.success) {
                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                } else {
                    ShowMessageError(data.message);
                }
            }
        });
    });


}




