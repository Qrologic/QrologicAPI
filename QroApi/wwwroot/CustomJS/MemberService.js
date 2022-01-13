var svc = {
    BindOperator: function (serviceId) {
        var s1 = serviceId == 7 ? "Division" : "Operator";
        common.BindDropdown(`/Member/Home/GetOperator?serviceId=` + serviceId, `operator`, s1);
    },
    BindCircle: function () {
        common.BindDropdown(`/Member/Home/GetCircle`, `circle`, `Circle`);
    },

    ServicePopup: function (id, name) {
        $('.myservice a').each(function () {
            if (this.id != "service-" + id) {
                $(this).removeClass('active');
            }
        });
        $("#hdnServiceId").val(id);
        $(`#sp-field1`).text();
        $("#btn-bill-fatch").css("display", "none");
        $("#dv-bill-fatch").css("display", "none");
        $("#amount").removeAttr("disabled");
        if (id == 4) {
            $("#lb-field-1").empty();
            $("#lb-field-1").append("Mobile / Consumer Id");
            $("#field-1").removeAttr("placeholder");
            $("#field-1").attr("placeholder", "Mobile / Consumer Id");
            $("#lb-field-2").empty();
            $("#lb-field-2").append("Operator");
            $("#btnRecharge").css("display", "block");
        }
        else if (id == 1 || id == 3) {
            $("#lb-field-1").empty();
            $("#lb-field-1").append("Mobile");
            $("#field-1").removeAttr("placeholder");
            $("#field-1").attr("placeholder", "Mobile");
            $("#lb-field-2").empty();
            $("#lb-field-2").append("Operator");
            $("#btnRecharge").css("display", "block");
        }
        else if (id == 7) {
            $("#lb-field-1").empty();
            $("#lb-field-1").append("Consumer No");
            $("#lb-field-2").empty();
            $("#lb-field-2").append("Division");
            $("#field-1").removeAttr("placeholder");
            $("#field-1").attr("placeholder", "Consumer No");
            $("#btn-bill-fatch").css("display", "block");
            $("#dvCircle").css("display", "none");
            $("#dvcustomer-mobile").css("display", "inline-block");
            $("#btnRecharge").css("display", "none");

        }
        else {
            $("#btn-bill-fatch").css("display", "block");
        }
        $.when(svc.BindOperator(id)).then(function () {
            $(`#serviceHeader`).text(name);
            svc.BindCircle();
            $(`#serviceId`).val(id);
        });
    },
    Validation: function (serviceId) {
        var flag = true;
        var field1 = $(`#field-1`).val();
        var operator = $(`#operator option:selected`).val();
        var circle = $(`#circle option:selected`).val();
        var amount = $(`#amount`).val();
        var customermobile = $(`#customermobile`).val();
        /*    if (mobile.length < 10 || mobile.length  > 10) { $(`#sp_mobile`).text(`Invalid mobile number`); flag = false; return flag; }*/
        if (operator == "" || operator == "0") { $(`#sp_operator`).text(`Select Operator`); flag = false; return flag; }
        if (field1 == "" || field1 == "0") { $(`#sp-field1`).text(`Enter ` + $("#lb-field-1").text()); flag = false; return flag; }
        if (serviceId == 7) {
            if (customermobile == "" || customermobile == "0") { $(`#sp_customermobile`).text(`Enter Customer Mobile`); flag = false; return flag; }
        }
        else {
            if (circle == "" || circle == "0") { $(`#sp_circle`).text(`Select Circle`); flag = false; return flag; }
        }


        if (amount == "" || amount == "0") { $(`#sp_amount`).text(`Enter Amount`); flag = false; return flag; }
        return flag;
    },
    RemoveValidation: function (id, name) {
        $(`#sp_` + name).text(``);
        $("#dv-bill-fatch").css("display", "none");
        if ($("#hdnServiceId").val() != "1" && $("#hdnServiceId").val() != "4") {
            if (name != "customermobile") {
               /* $("#btn-bill-fatch").css("display", "block");*/
                if (name == "operator") {
                    ajax.doGetAjax(`/Member/Home/GetOperatorDetail?id=` + id, function (result) {
                        if (result.status) {
                            var displayName = result.results.displayName;
                            $("#lb-field-1").empty();
                            $("#lb-field-1").append(displayName);
                            $("#field-1").removeAttr("placeholder");
                            $("#field-1").attr("placeholder", result.results.displayName);
                            $("#fatchId").val(result.results.fatchId);
                        }
                    });
                }
            }
        }
    },
    RechargeProcess: function () {
        var serviceId = $(`#serviceId`).val();
        $("#btn-bill-fatch").css("display", "none");
        if (svc.Validation(serviceId)) {
            $(`#btnRecharge`).css(`display`, 'none');
            $(`#btnLoader`).css(`display`, 'block');
            if (serviceId == 7) {
                var data = {
                    "serviceId": $(`#serviceId`).val(),
                    "operatorId": $(`#operator option:selected`).val(),
                    "canumber": $(`#field-1`).val(),
                    "amount": $(`#amount`).val(),
                    "latitude": "27.2232",
                    "longitude": "78.26535",
                    "mode": "online",
                    "mobile": $(`#customermobile`).val(),
                    "bill_fetch": JSON.parse($('#hdn-billfatch').val())
                };
                ajax.doPostAjax(`/Member/Home/BillPay`, data, function (result) {

                    if (result.status && result.response_code == 1) {
                        toastMeaasage("success", result.message);
                        svc.Clear();
                        $("#btn-bill-fatch").css("display", "block");
                        $(`#btnLoader`).css(`display`, 'none');
                    }
                    else if (result.status && result.response_code == 0) {
                        toastMeaasage("warning", result.message);
                        svc.Clear();
                        $("#btn-bill-fatch").css("display", "block");
                        $(`#btnLoader`).css(`display`, 'none');
                    }
                    else {
                        toastMeaasage("error", result.message);
                        $(`#btnRecharge`).css(`display`, 'block');
                        $(`#btnLoader`).css(`display`, 'none');
                    }

                    if (result.id != 0) {
                        setTimeout(function () {
                            location.replace("/Member/Home/RechargeReciept/" + result.id);
                        }, 700);
                    }
                   
                });
            }
            else {
                var data = {
                    "ServiceId": $(`#serviceId`).val(),
                    "OperatorId": $(`#operator option:selected`).val(),
                    "CircleId": $(`#circle option:selected`).val(),
                    "Number": $(`#field-1`).val(),
                    "CANumber": "",
                    "Amount": $(`#amount`).val()
                }

                ajax.doPostAjax(`/Member/Home/RechargeProcess`, data, function (result) {

                    if (result.status) {
                        if (result.isSuccess == "Success") {
                            toastMeaasage("success", result.message);
                            svc.Clear();

                        }
                        else {
                            toastMeaasage("warning", result.message);
                            svc.Clear();
                        }
                    }
                    else {
                        toastMeaasage("error", result.message);
                    }

                    if (result.id != 0) {
                        setTimeout(function () {
                           // location.replace("/Member/Home/RechargeReciept/" + result.id);
                            wallet.Top10Transaction();
                        }, 700);
                    }
                    $(`#btnRecharge`).css(`display`, 'block');
                    $(`#btnLoader`).css(`display`, 'none');
                });
            }

        }
    },
    BillFatch: function () {
        var field1 = $(`#field-1`).val();
        var operator = $(`#operator option:selected`).val();
        if (operator == "" || operator == "0") { $(`#sp_operator`).text(`Select Operator`); flag = false; return flag; }
        if (field1 == "" || field1 == "0") { $(`#sp-field1`).text(`Enter ` + $("#lb-field-1").text()); flag = false; return flag; }
        var data = { "_operator": $("#fatchId").val(), "canumber": field1, "mode": "online" };
        $("#btn-bill-fatch").html("");
        $("#btn-bill-fatch").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-bill-fatch").attr('disabled', true);
        ajax.doPostAjax(`/Member/Home/BillFatch`, data, function (result) {
            console.log(JSON.stringify(result));
            var res = JSON.parse(result)
            if (res.status == true && res.response_code == 1) {
                $("#dv-bill-fatch").css("display", "block");
                $("#lb-bill-fatch-name").text("Name: " + res.bill_fetch.userName);//live-userName ,test-name
                $("#lb-bill-fatch-duedate").text("Due Date: " + res.bill_fetch.dueDate);//live-dueDate,test-duedate
                $("#lb-bill-fatch-dueamount").text(res.bill_fetch.billnetamount);//live-billnetamount,,test-amount
                $("#amount").val(res.bill_fetch.billnetamount);//billnetamount
                $("#amount").attr("disabled", true);
                toastMeaasage("success", res.message)
                $("#btn-bill-fatch").html("");
                $("#btn-bill-fatch").removeAttr('disabled');
                $("#btn-bill-fatch").html('Bill Fatch');
               
                $('#hdn-billfatch').val(JSON.stringify(res.bill_fetch));
                $("#btn-bill-fatch").css("display", "none");
                $("#btnRecharge").css("display", "block");
            }
            else {
                toastMeaasage("error", res.message);
                $("#btn-bill-fatch").html("");
                $("#btn-bill-fatch").removeAttr('disabled');
                $("#btn-bill-fatch").html('Bill Fatch');
            }
            //console.log(res.bill_fetch.amount);
            //console.log(res);
            //if (result.status) {
            //}
        });
    },
    Clear: function () {
        $(`#field-1`).val(``);
        $(`#operator`).val(``).trigger('change');
        $(`#circle`).val(``).trigger('change');
        $(`#amount`).val(``);
        $(`#customermobile`).val(``);
        $(`#amount`).removeAttr(`disabled`);
        $("#dv-bill-fatch").css("display", "none");

    }


}