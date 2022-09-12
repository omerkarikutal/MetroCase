var common = {
    ajax: function (httpMethod, url, data, type, successCallBack) {
        var obj = $.ajax({
            type: httpMethod,
            url: url,
            data: data,
            dataType: type,
            success: successCallBack,
            error: function (err, type, httpStatus) {
                console.log('Error occured in ajax call ' + err.status + '-' + err.responseText + '-' + httpStatus);
                common.showErrorMessage('Sistemsel bir hata meydana geldi', 'Hata');
            }
        });
    },
    ajaxWithBody: function (httpMethod, url, data, type, successCallBack) {
        var obj = $.ajax({
            type: httpMethod,
            url: url,
            data: data,
            dataType: type,
            contentType: "application/json; charset=utf-8",
            success: successCallBack,
            error: function (err, type, httpStatus) {
                console.log('Error occured in ajax call ' + err.status + '-' + err.responseText + '-' + httpStatus);
                common.showErrorMessage('Sistemsel bir hata meydana geldi', 'Hata');
            }
        });
    },
    showSuccessMessage: function (message, title) {
        return toastr.success(message, title, {
            showMethod: 'fadeIn',
            showDuration: 300,
            showEasing: 'swing',
            hideMethod: 'fadeOut',
            hideDuration: 1000,
            hideEasing: 'swing',
            positionClass: 'toast-top-right',
            timeOut: 5000
        });
    },
    showSwalSuccessWithReturnUrl: function (text, confirmButtonText, customClassLocation) {
        return Swal.fire(
            {
                text: text,
                icon: "success",
                buttonsStyling: !1,
                confirmButtonText: confirmButtonText,
                customClass: { confirmButton: "btn btn-primary" }
            }).then(function () { window.location.href = customClassLocation; })
    },
    showSwallError: function (text, confirmButtontext) {
        return Swal.fire(
            {
                text: text,
                icon: "error",
                confirmButtonText: confirmButtontext,
                customClass: { confirmButton: "btn btn-primary" }
            }
        )
    },
    showErrorMessage: function (message, title) {
        return toastr.error(message, title, {
            showMethod: 'fadeIn',
            showDuration: 300,
            showEasing: 'swing',
            hideMethod: 'fadeOut',
            hideDuration: 1000,
            hideEasing: 'swing',
            positionClass: 'toast-top-right',
            timeOut: 5000
        });
    },
    turkishDatatable: {
        "sDecimal": ",",
        "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
        "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
        "sInfoEmpty": "Kayıt yok",
        "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "Sayfada _MENU_ kayıt göster",
        "sLoadingRecords": "Yükleniyor...",
        "sProcessing": "İşleniyor...",
        "sSearch": "Ara:",
        "sZeroRecords": "Eşleşen kayıt bulunamadı",
        "oPaginate": {
            "sFirst": "İlk",
            "sLast": "Son",
            "sNext": "Sonraki",
            "sPrevious": "Önceki"
        },
        "oAria": {
            "sSortAscending": ": artan sütun sıralamasını aktifleştir",
            "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
        },
        "select": {
            "rows": {
                "_": "%d kayıt seçildi",
                "0": "",
                "1": "1 kayıt seçildi"
            }
        }
    },
    closeModal: function (id) {
        $('#' + id).hide();
    },
    searchFilter: function (tableId, value, append = false) {
        $('#' + tableId + ' tr').each(function (index) {
            if (index != 0) {
                $(this).find("td").each(function () {
                    var id = $(this).text().toLowerCase().trim();
                    var not_found = (id.indexOf(value) == -1);
                    $(this).closest('tr').toggle(!not_found);

                    if (append == true) {
                        if (!not_found) {
                            $(this).closest('tr').attr('data-search', 1);
                        }
                        else {
                            $(this).closest('tr').removeAttr('data-search');
                        }
                    }
                    return not_found;
                })
            }
        });
    },
    chosenSelect: function (id) {
        $('#' + id).chosen({ width: "100%" });
    }
}