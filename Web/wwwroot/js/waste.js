
$(document).ready(function () {
    GetAll();
});
function GetAll() {
    common.ajax("get", "/waste/listresult", null, 'json', GetAllOnSuccess);
}
function GetAllOnSuccess(response) {
    if (response.status) {
        CreateDataTable(response.data);
    }
    else {
        common.showErrorMessage(response.errorMessage, "Hata");
    }
}
function CreateDataTable(data) {
    $('#WasteList').DataTable({
        destroy: true,
        data: data,
        language: common.turkishDatatable,
        columns: [
            { data: "id" },
            { data: "wasteDateString" },
            { data: "monthString" },
            { data: "store.name" },
            { data: "wasteType.name" },
            { data: "wasteKind.name" },
            { data: "quantity" },
            { data: "unit.name" },
            { data: "company.name" },
            {
                "render": function (data, type, row) {
                    var editButton = "<button class='btn btn-success btn-sm' onclick='AddOrEdit(" + row.id + ");'>Düzenle</button>";
                    var deleteButton = "<button class='btn btn-danger btn-sm' onclick='Delete(" + row.id + ");'>Sil</button>";

                    return editButton + " " + deleteButton;
                }
            }
        ]
    });
}
function AddOrEdit(id) {
    common.ajax("get", "/waste/Get", { id }, 'html', AddOrEditOnSuccess);
}
function AddOrEditOnSuccess(response) {
    $('#wasteModal').html(response);
    $('#wasteModal').show();
}
function Delete(id) {
    common.ajax("get", "/waste/delete", { id }, 'json', DeleteOnSuccess);
}
function DeleteOnSuccess(response) {
    if (response.status) {
        common.showSuccessMessage("İşlem Başarılı", "Ok");
        GetAll();
    }
    else {
        common.showErrorMessage(response.errorMessage, "Hata");
    }
}

function Save() {

    common.ajax("post", "/waste/AddOrEdit", $('#waste_form').serialize(), 'json', SaveOnSuccess);

}
function SaveOnSuccess(response) {
    if (response.status) {
        common.showSuccessMessage("İşlem Başarılı", "Ok");
        GetAll();
        $('#wasteModal').hide();
    }
    else {
        common.showErrorMessage(response.errorMessage, "Hata");
    }
}


