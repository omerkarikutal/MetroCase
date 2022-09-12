"use strict"; var KTSigninGeneral = function () {
    var e, t, i; return {
        init: function () {
            e = document.querySelector("#kt_sign_in_form"),
                t = document.querySelector("#kt_sign_in_submit"),
                i = FormValidation.formValidation(e,
                    {
                        fields:
                        {
                            Username: { validators: { notEmpty: { message: "Username address is required" } } }, Password: {
                                validators: {
                                    notEmpty: { message: "The Password is required" },
                                    callback: {
                                        message: "Please enter valid password",
                                        callback: function (e) { if (e.value.length > 0) return _validatePassword() }
                                    }
                                }
                            }
                        }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
                    }),
                t.addEventListener("click", (function (n) {
                    n.preventDefault(),
                        i.validate().then((function (i) {
                            "Valid" == i ?
                                (
                                    t.setAttribute("data-kt-indicator", "on"), t.disabled = !0, setTimeout((function () {
                                        t.removeAttribute("data-kt-indicator"), t.disabled = !1
                                        var form = $("#kt_sign_in_form");
                                        var url = form.attr('action');

                                        $.ajax({
                                            type: "POST",
                                            url: url,
                                            data: form.serialize(), // serializes the form's elements.
                                            dataType: 'json',
                                            success: function (data) {
                                                if (data.status) {
                                                    Swal.fire({ text: "BASARILI", icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam, devam et", customClass: { confirmButton: "btn btn-primary" } }).then(function () { window.location.href = '/Form/Index'; });
                                                }
                                                else {
                                                    debugger;
                                                    if (data.recapthaError) {
                                                        $('#recaptchaError').show();
                                                        $('#recaptchaError span').text(data.errorMessage);
                                                    } else {
                                                        Swal.fire({ text: data.errorMessage, icon: "error" });
                                                    }
                                                    
                                                }

                                            }
                                        });
                                    }), 2e3)) : Swal.fire({ text: "Bir sorun oluþtu tekrar kontrol edin", icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam", customClass: { confirmButton: "btn btn-primary" } })
                        }))
                }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTSigninGeneral.init() })); //