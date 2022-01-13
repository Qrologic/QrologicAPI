var dmtv2 = {
    RemitterDetails: function () {
        var rem_mobile = $("#remitter-mobile").val();
        if (rem_mobile == "") { $("#sp-rem-mobile").text("Please enter mobile number"); return; }
        var data = { "mobile": rem_mobile };
        $("#btn-rem").html("");
        $("#btn-rem").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-rem").attr('disabled', true);
        ajax.doPostAjax("/Member/Services/RemitterDetail", data, function (result) {
            if (result.status == false && result.response_code == 0) {
                $("#field-1").css("display", "none");
                $("#field-2").slideDown(700);//.css("display", "block");
                $("#hdn-reg-rem-mobile").val(rem_mobile);
                $("#stateresp").val(result.stateresp);
                toastMeaasage("success", result.message);
                $("#rem-reg-mobile").text(rem_mobile);
                //SweetAlert.SwalAlert("", result.message, "warning", false, "#3085d6", "", "Ok", false);
            }
            else if (result.status == true && result.response_code == 1) {
                $("#btn-rem").html("");
                $("#btn-rem").removeAttr('disabled');
                $("#btn-rem").html('<i class="fa fa-chevron-right"></i>');

                $("#field-1").css("display", "none");
                $("#field-2").css("display", "none");
                $("#field-3").slideDown(700);//.css("display", "block");
                $("#dv-rem-detail").css("display", "block");
                $("#sp-reg-rem-name").text(result.data.fname + " " + result.data.lname);
                $("#sp-reg-rem-mobile").text(result.data.mobile);
                $("#reg-rem-total-limit").text(result.remitter_limit);
                /* $("#reg-rem-avl-limit").text(result.data.bank1_limit);*/
                $("#hdn-reg-rem-name").val(result.data.fname + " " + result.data.lname);
                $("#hdn-reg-rem-mobile").val(result.data.mobile);


                $.when(common.BindDropdown("/Member/Services/GetBank", "reg-bene-bank", "Bank")).then(function () {
                    dmtv2.FetchBeneficiary();
                })
            }
            else {
                $("#btn-rem").html("");
                $("#btn-rem").removeAttr('disabled');
                $("#btn-rem").html('<i class="fa fa-chevron-right"></i>');
                SweetAlert.SwalAlert("", result.message, "warning", false, "#3085d6", "", "Ok", false);
            }
        });
    },
    ResetValidation: function (id) {
        $("#" + id).text("");
    },
    RemitterRegistration: function () {
        var rem_mobile = $("#hdn-reg-rem-mobile").val();
        var rem_fname = $("#rem-fname").val();
        if (rem_fname == "") { $("#sp-rem-fname").text("Please enter first name"); return; }
        var rem_lname = $("#rem-lname").val();
        if (rem_lname == "") { $("#sp-rem-lname").text("Please enter last name"); return; }

        var rem_address = $("#rem-address").val();
        if (rem_address == "") { $("#sp-rem-address").text("Please enter address"); return; }
        var rem_pincode = $("#rem-pincode").val();
        if (rem_pincode == "") { $("#sp-rem-pincode").text("Please enter pincode"); return; }
        var rem_otp = $("#rem-otp").val();
        if (rem_otp == "") { $("#sp-rem-otp").text("Please enter otp"); return; }
        var year = $("#rem-year option:selected").val();
        var month = $("#rem-month option:selected").val();
        var day = $("#rem-day option:selected").val();
        var rem_dob = year + "-" + month + "-" + day;

        $("#btn-rem-reg").html("");
        $("#btn-rem-reg").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-rem-reg").attr('disabled', true);

        var data = {
            "mobile": rem_mobile,
            "firstname": rem_fname,
            "lastname": rem_lname,
            "address": rem_address,
            "otp": rem_otp,
            "pincode": rem_pincode,
            "dob": rem_dob,
            "stateresp": $("#stateresp").val()
        };

        ajax.doPostAjax("/Member/Services/RemitterRegistration", data, function (result) {
            if (result.status == true && result.response_code == 1) {
                toastMeaasage("success", result.message);
                dmtv2.RemitterDetails();
            }
            else {
                $("#btn-rem-reg").html("");
                $("#btn-rem-reg").removeAttr('disabled');
                $("#btn-rem-reg").html('<i class="fa fa-check"></i> Add Customer');
                SweetAlert.SwalAlert("", result.message, "warning", false, "#3085d6", "", "Ok", false);
            }
        });

    },
    FetchBeneficiary: function () {
        $(".loader-center").css("display", "block");
        var rem_mobile = $("#hdn-reg-rem-mobile").val();//$("#remitter-mobile").val();
        var data = {
            "mobile": rem_mobile,
        };
        ajax.doPostAjax("/Member/Services/FetchBeneficiary", data, function (result) {
            $(".loader-center").css("display", "none");
            $("#bene-list").html("");
            if (result.data.length > 0) {
                $(result.data).each(function () {
                    var isVerifySign = this.verified == "1" ? `led-green` : `led-yellow`;
                    var isVerifytitle = this.verified == "1" ? `Verified` : `Unverified`;
                    var isVerifyShow = this.verified == "1" ? `display:none;` : `display:inline-block;`;
                    bene_list = `<tr>
                                     <td>
                                          <div id="lblbenecolour-${this.bene_id}" class="${isVerifySign}" title="${isVerifytitle}"></div>
                                     </td>
                                     <td><label id="lblbenename-${this.bene_id}">${this.name}</label><input type="hidden" id="hdn-bene-name-${this.bene_id}" value="${this.name}"/></td>
                                     <td>${this.bankname} <input type="hidden" id="hdn-bene-bankname-${this.bene_id}" value="${this.bankname}"/>
                                           <input type="hidden" id="hdn-bene-bankid-${this.bene_id}" value="${this.bankid}"/>
                                        | ${this.ifsc}<input type="hidden" id="hdn-bene-ifsc-${this.bene_id}" value="${this.ifsc}"/></td>
                                     <td>${this.accno}<input type="hidden" id="hdn-bene-accno-${this.bene_id}" value="${this.accno}"/></td>
                                     <td>
                                          <a href="javascript:void(0)" id="btn-verify-${this.bene_id}" onclick="dmtv2.VerifyBeneficiary(${this.bene_id})" class="btn btn-warning" style="padding: 3px 10px;${isVerifyShow}" title="Verify Beneficiary"> <i class="fa fa-check"></i></a>

                                     <a href="javascript:void(0)" onclick="dmtv2.showSendMoneyDialog(${this.bene_id})" class="btn btn-info" style="padding: 3px 10px; margin-left: 5px;" title="Send Money"> <i class="fa fa-send-o"></i></a>

                                    <a href="javascript:void(0)" id="delete_${this.bene_id}" onclick="dmtv2.DeleteBeneficiary(${this.bene_id})" class="btn btn-danger" style="padding: 3px 10px; margin-left: 5px;" title="Delete Beneficiary"><i class="fa fa-trash"></i></a>
                                    </td>
                               </tr>`;


                    $("#bene-list").append(bene_list);
                });
            }
            else {

                var bene_list = `<tr><td colspan="5" class="text-center">Beneficiary Not Available</td></tr>`;
                $("#bene-list").append(bene_list);
            }
        });
    },
    RegisterBeneficiary: function () {
        var rem_mobile = $("#hdn-reg-rem-mobile").val();//$("#remitter-mobile").val();
        var bene_name = $("#reg-bene-name").val();
        if (bene_name == "") { $("#sp-val-benename").text("Please enter beneficiary name"); return; }
        var bene_bank = $("#reg-bene-bank option:selected").val();
        if (bene_bank == "") { $("#sp-val-benebank").text("Please select your bank"); return; }
        var bene_ifsc = $("#reg-bene-ifsc").val();
        if (bene_ifsc == "") { $("#sp-val-beneifsc").text("Please enter ifsc code"); return; }

        var bene_account = $("#reg-bene-account").val();
        if (bene_account == "") { $("#sp-val-beneaccount").text("Please enter account number"); return; }
        var bene_account_c = $("#reg-bene-account-confirm").val();
        if (bene_account_c == "") { $("#sp-val-beneaccount-confirm").text("Please enter confirm account number"); return; }

        if (bene_account != bene_account_c) {
            $('#message').html('Not Matching').css('color', 'red');
        }



        var bene_address = "Jaipur";
        var bene_pincode = "302033";
        var bene_dob = "2000-02-01";//year + "-" + month + "-" + day;

        $("#btn-bene-reg").html("");
        $("#btn-bene-reg").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-bene-reg").attr('disabled', true);
        var data = {
            "mobile": rem_mobile,
            "benename": bene_name,
            "bankid": bene_bank,
            "accno": bene_account,
            "ifsccode": bene_ifsc,
            "address": bene_address,
            "pincode": bene_pincode,
            "dob": bene_dob,
        };

        ajax.doPostAjax("/Member/Services/BeneficiaryRegistration", data, function (result) {
            if (result.status == true && result.response_code == 1) {
                toastMeaasage("success", result.message);
                $(".loader-center").css("display", "block");
                $("#bene-list").html("");
                dmtv2.FetchBeneficiary();
                $("#btn-bene-reg").html("");
                $("#btn-bene-reg").removeAttr('disabled');
                $("#btn-bene-reg").html('Add Beneficiary');
                dmtv2.ClearBeneficiary();
                $("#addBeneficiaryDiv").slideUp(700);
                $('.button--trigger').css("display", "inline-block");
            }
            else {
                $("#btn-bene-reg").html("");
                $("#btn-bene-reg").removeAttr('disabled');
                $("#btn-bene-reg").html('Add Beneficiary');
                SweetAlert.SwalAlert("", result.message, "warning", false, "#3085d6", "", "Ok", false);
            }
        });
    },
    VerifyBeneficiary: function (id) {
        var rem_mobile = $("#hdn-reg-rem-mobile").val();//$("#remitter-mobile").val();
        $("#btn-verify-" + id).html("");
        $("#btn-verify-" + id).html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-verify-" + id).attr('disabled', true);
        var data = {
            "mobile": rem_mobile,
            "benename": $("#hdn-bene-name-" + id).val(),
            "bankid": $("#hdn-bene-bankid-" + id).val(),
            "accno": $("#hdn-bene-accno-" + id).val(),
            "ifsccode": $("#hdn-bene-ifsc-" + id).val(),
            "address": "Jaipur",
            "pincode": "302033",
            "dob": "01-02-2000",
            "bene_id": id,
            "remname": $("#sp-reg-rem-name").text(),
            "bankname": $("#hdn-bene-bankname-" + id).val()
        };

        ajax.doPostAjax("/Member/Services/BeneficiaryVerify", data, function (result) {

            if (result.status) {
                var message = 'Beneficiary Name : ' + result.results.benename;
                SweetAlert.SwalAlert("Transaction Successfull", message, "success", false, "green", "", "Ok", false);
                $("#lblbenename-" + id).text(result.results.benename);
                $("#lblbenecolour-" + id).addClass("led-green");
                $("#btn-verify-" + id).html("");
                $("#btn-verify-" + id).removeAttr('disabled');
                $("#btn-verify-" + id).html('<i class="fa fa-check"></i>');
                $("#btn-verify-" + id).css("display", "none");
            }
            else {
                $("#btn-verify-" + id).html("");
                $("#btn-verify-" + id).removeAttr('disabled');
                $("#btn-verify-" + id).html('<i class="fa fa-check"></i>');
                SweetAlert.SwalAlert("Account Verification Failed", "Failed", "warning", false, "#3085d6", "", "Ok", false);
            }
        });
    },
    DeleteBeneficiary: function (id) {
        var rem_mobile = $("#remitter-mobile").val();
        var data = {
            "mobile": rem_mobile,
            "bene_id": id,
        };
        $("#delete_" + id).html("");
        $("#delete_" + id).html('<i class="fa fa-circle-o-notch fa-spin"></i>');
        $("#delete_" + id).attr('disabled', true);
        ajax.doPostAjax("/Member/Services/BeneficiaryDelete", data, function (result) {
            if (result.status == true && result.response_code == 1) {
                toastMeaasage("success", result.message);
                dmtv2.FetchBeneficiary();
            }
            else {
                SweetAlert.SwalAlert("", result.message, "warning", false, "#3085d6", "", "Ok", false);
                $("#delete_" + id).html("");
                $("#delete_" + id).html('<i class="fa fa-trash-o"></i>');
                $("#delete_" + id).attr('disabled', true);
            }
        });
    },
    SelectBeneficiary: function (id) {
        $("#field-1").css("display", "none");
        $("#field-2").css("display", "none");
        $("#field-3").css("display", "none");
        $("#field-4").slideDown(700);
        var name = $(`#hdn-bene-name-${id}`).val(); $("#p-b-name").text(name); $("#hdn-b-name").val(name);
        var accno = $(`#hdn-bene-accno-${id}`).val(); $("#p-b-accno").text(accno); $("#hdn-b-accno").val(accno);
        var bank = $(`#hdn-bene-bankname-${id}`).val(); $("#p-b-bank").text(bank); $("#hdn-b-bank").val(bank);
        var ifsc = $(`#hdn-bene-ifsc-${id}`).val(); $("#p-b-ifsc").text(ifsc); $("#hdn-b-ifsc").val(ifsc);
    },
    GetIfsc: function (id) {
        dmtv2.ResetValidation('sp-val-benebank');
        ajax.doGetAjax("/Member/Services/GetIFSC?id=" + id, function (result) {
            if (result.status) {
                $("#reg-bene-ifsc").val(result.results.ifsc);
            }
        });
    },

    ClearBeneficiary: function () {
        $("#reg-bene-account-confirm").val("");
        $("#reg-bene-account").val("");
        $("#reg-bene-bank").val("");
        $("#reg-bene-ifsc").val("");
        $("#reg-bene-name").val("");
        $("#reg-bene-dob").val("");
        $("#reg-bene-address").val("");
        $("#reg-bene-pincode").val("");
    },

    GetSurchargeByPackage: function (id, area) {
        ajax.doGetAjax(`/${area}/Settings/GetDMTSurchargeByPackageId?id=` + id, function (result) {
            $("#tbody-dmt-surcharge").html("");
            $("#tbody-dmt-surcharge").html(result);
        });
    },
    GetSurchargeById: function (id, area) {
        ajax.doGetAjax(`/${area}/Settings/GetDMTSurchargeById?id=` + id, function (result) {
            $("#Id").val(result.id);
            $("#PackageId").val(result.packageId);
            $("#FromAmount").val(result.fromAmount);
            $("#ToAmount").val(result.toAmount);
            $("#Surcharge").val(result.surcharge);
            $("#IsFlat").prop("checked", result.isFlat);
        });
    },
    FindNewCustomer: function () {
        $.when($("#remitter-mobile").val(""), $("#field-2").slideUp(500), $("#field-3").slideUp(500))
            .then(function () { $("#field-1").slideDown(800); });
    },
    showSendMoneyDialog: function (beneId) {
        document.getElementById("beneId").value = beneId;
        var x = document.getElementById("sendMoneyModel");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }

    },
    showSendMoneyConfirmationDialog: function () {
        var amount = document.getElementById("txnAmount").value;
        if (amount == "") {
            toastMeaasage("error", "Invalid amount. Amount must be at least 100 !");
            return;
        }
        if (parseFloat(amount) < 100) {
            toastMeaasage("error", "Invalid amount. Amount must be at least 100 !");
            return;
        }
        if (parseFloat(amount) > 25000) {
            toastMeaasage("error", "Invalid Amount !");
            return;
        }
        var x = document.getElementById("sendMoneyConfirmationModel");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
        dmtv2.SenderAndRecieverDetail();
    },
    verifyBeneficiary: function () {
        var x = document.getElementById("verif-alert");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    },
    deleteBeneficiary: function () {
        var x = document.getElementById("delete-alert");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    },

    SenderAndRecieverDetail: function () {
        var beneId = $("#beneId").val();
        $("#lblSenderName").text($("#hdn-reg-rem-name").val());
        $("#lblSenderMobile").text($("#hdn-reg-rem-mobile").val());
        $("#lblReceiverName").text($("#hdn-bene-name-" + beneId).val());
        $("#lblReceiverAccountNumber").text($("#hdn-bene-accno-" + beneId).val());
        $("#lblBankName").text($("#hdn-bene-bankname-" + beneId).val());
        $("#lblIfscCode").text($("#hdn-bene-ifsc-" + beneId).val());
        $("#lblTxnAmount").text($("#txnAmount").val());
        $("#imps").prop("checked", true);
    },
    ConfirmTransaction: function () {
        var beneId = $("#beneId").val();
        var txnmode = "";
        if ($("#imps").prop("checked")) {
            txnmode = $("#imps").val();
        }
        if ($("#neft").prop("checked")) {
            txnmode = $("#neft").val();
        }
        if (txnmode == "") {
            toastMeaasage("error", "Select Transfer Type !");
            return;
        }
        var amount = parseFloat($("#txnAmount").val()).toFixed(2);
       
        

        var bankName = $("#hdn-bene-bankname-" + beneId).val();
        var ifsc = $("#hdn-bene-ifsc-" + beneId).val();
        if (bankName.toUpperCase() == "ICICI BANK LIMITED") {
            txnmode = "TPA";
            ifsc = "ICIC0000011";
        }

        var data = {
            "mobile": $("#hdn-reg-rem-mobile").val(),
            "benename": $("#hdn-bene-name-" + beneId).val(),
            "bankid": $("#hdn-bene-bankid-" + beneId).val(),
            "accno": $("#hdn-bene-accno-" + beneId).val(),
            "ifsccode": ifsc,
            "address": "Jaipur",
            "pincode": "302033",
            "dob": "01-02-2000",
            "bene_id": beneId,
            "remname": $("#hdn-reg-rem-name").val(),
            "bankname": $("#hdn-bene-bankname-" + beneId).val(),
            "txntype": txnmode,
            "amount": amount
        };

        $("#btn-confirm-transaction").html("");
        $("#btn-confirm-transaction").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-confirm-transaction").attr('disabled', true);
        ajax.doPostAjax("/Member/Services/ConfirmTransaction", data, function (result) {
            if (result.response_code) {
                location.replace('/Member/Services/dmtReciept');
            }
            else {
                SweetAlert.SwalAlert("Transaction Failed", result.message, "warning", false, "#3085d6", "", "Ok", false);
                $("#btn-confirm-transaction").html("");
                $("#btn-confirm-transaction").removeAttr('disabled');
                $("#btn-confirm-transaction").html('Confirm');
            }
            //if (result.status) {

            //   // SweetAlert.SwalAlert("Transaction Successfull", "Success", "success", false, "green", "", "Ok", false);
            //    $("#btn-confirm-transaction").html("");
            //    $("#btn-confirm-transaction").removeAttr('disabled');
            //    $("#btn-confirm-transaction").html('Confirm');
            //    dmtv2.showSendMoneyDialog(0);
            //    dmtv2.showSendMoneyConfirmationDialog();
            //}
            //else {
            //    $("#btn-confirm-transaction").html("");
            //    $("#btn-confirm-transaction").removeAttr('disabled');
            //    $("#btn-confirm-transaction").html('Confirm');                
            //    SweetAlert.SwalAlert("Transaction Failed", result.message, "warning", false, "#3085d6", "", "Ok", false);
            //}
        });
    },
    GetPending: function () {
        $.when(ajax.doGetAjax(`/Admin/Services/loaddmtPending`, function (result) {
            $(`#tbody-p-dmt`).html('');
            $(`#tbody-p-dmt`).html(result);
        })).then(function () {
            setTimeout(function () {
                //if ($.fn.dataTable.isDataTable('#myTable')) {
                //    $('#myTable').DataTable().destroy();
                //}
                table.dataTable(`myTable`);
            }, 500);
            //setTimeout(function () {
            //    var table = document.getElementById(`myTable`);
            //    var tbodyRowCount = table.tBodies[0].rows.length;
            //    if (tbodyRowCount > 0) { $(`#dv-btn`).css(`display`, `block`); }
            //}, 500);
        });
    },
    GetSuccessDMT: function () {
        $.when(ajax.doGetAjax(`/Admin/Services/loaddmtSuccess`, function (result) {
            $(`#tbody-p-dmt`).html('');
            $(`#tbody-p-dmt`).html(result);
        })).then(function () {
            setTimeout(function () {
                //if ($.fn.dataTable.isDataTable('#myTable')) {
                //    $('#myTable').DataTable().destroy();
                //}
                table.dataTable(`myTable`);
            }, 500);
            //setTimeout(function () {
            //    var table = document.getElementById(`myTable`);
            //    var tbodyRowCount = table.tBodies[0].rows.length;
            //    if (tbodyRowCount > 0) { $(`#dv-btn`).css(`display`, `block`); }
            //}, 500);
        });
    },

    TransactionEnquiry: function (id, txnid, apiId, type) {

        common.ShowLoader();

        var url = "";
        if (type == "Status Enquiry") {
            url = `/Admin/Services/TransactionEnquiry`;
        }
        if (type == "Failed") {
            url = `/Admin/Services/ForceFailed`;
        }
        if (type == "Success") {
            url = `/Admin/Services/ForceSuccess`;
        }
        var data = {
            "apiId": apiId,
            "id": id,
            "referenceId": txnid
        };

        if (url != "") {
            ajax.doPostAjax(url, data, function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    setTimeout(function () {
                        if ($.fn.dataTable.isDataTable('#myTable')) {
                            $('#myTable').DataTable().destroy();
                        }
                        dmtv2.GetPending();
                        $(`#chk-select-all`).prop(`checked`, false);
                    }, 100);
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
        else {
            toastMeaasage("error", "Something Went Wrong !");
        }
        common.HideLoader();
    },
    SwitchAPI: function (id) {
        ajax.doGetAjax(`/Admin/Services/SwitchApi?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable(`/Admin/Services/loaddmtApiList`, `myTable2`)
            }
        });
    },
    FindTransaction: function () {
        var txnId = $("#txReferenceId").val();
        if (txnId == "") { toastMeaasage("error", "Please enter transaction id"); return; }
        ajax.doGetAjax(`/Admin/Services/loaddmtRefund?id=` + txnId, function (result) {
            $("#tbody-dmt-refund").html("");
            $("#tbody-dmt-refund").html(result);
        });
    },
    SendRefundOTP: function () {
        var id = $("#hdn-id").val();
        if (id == "" || id == undefined) { toastMeaasage("error", "Please find transaction !"); return; }

        var txnId = $("#hdn-txnid").val();
        if (txnId == "" || txnId == undefined) { toastMeaasage("error", "Please find transaction !"); return; }
        var apiTxnId = $("#hdn-apitxnid").val();
        var data = {
            "apitxnId": apiTxnId,
            "id": id,
            "referenceId": txnId
        };

        $(".refund-find").html("");
        $(".refund-find").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $(".refund-find").attr('disabled', true);

        ajax.doPostAjax(`/Admin/Services/SendOTPForRefund`, data, function (result) {
            if (result.status == true && result.response_code == 1) {
                $(".refund-find").html("");
                $(".refund-find").removeAttr('disabled');
                $(".refund-find").html('Refund');
                $('.refund-transaction').toggleClass('show');
            }
            else {
                $(".refund-find").html("");
                $(".refund-find").removeAttr('disabled');
                $(".refund-find").html('Refund');
                toastMeaasage("error", result.message);
            }
        });
    },

    RefundTransaction: function () {
        var otp = $("#txt-refund-otp").val();
        if (otp == "") { toastMeaasage("error", "Please enter otp !"); return; }
        var id = $("#hdn-id").val();
        if (id == "") { toastMeaasage("error", "Please find transaction !"); return; }
        var txnId = $("#hdn-txnid").val();
        if (txnId == "") { toastMeaasage("error", "Please find transaction !"); return; }
        var apiTxnId = $("#hdn-apitxnid").val();
        var data = {
            "apitxnId": apiTxnId,
            "id": id,
            "referenceId": txnId,
            "otp": otp
        };

        $("#btn-submit-otp").html("");
        $("#btn-submit-otp").html('<i class="fa fa-circle-o-notch fa-spin"></i>&nbsp;Processing');
        $("#btn-submit-otp").attr('disabled', true);

        ajax.doPostAjax(`/Admin/Services/RefundTransaction`, data, function (result) {
            if (result.status == true && result.response_code == 1) {
                $("#btn-submit-otp").html("");
                $("#btn-submit-otp").removeAttr('disabled');
                $("#btn-submit-otp").html('Submit');
                $('.refund-transaction').removeClass('show');
            }
            else {
                $("#btn-submit-otp").html("");
                $("#btn-submit-otp").removeAttr('disabled');
                $("#btn-submit-otp").html('Submit');
                toastMeaasage("error", result.message);
            }
        });
    },
    ForceUpdate: function (id, type) {
        ajax.doGetAjax(`/Admin/Services/dmtForceUpdate?id=${id}&type=${type}`, function (result) {
            if (result.status) {
                $.when(toastMeaasage("success", result.message)).then(function () {
                    if ($.fn.dataTable.isDataTable('#myTable')) {
                        $('#myTable').DataTable().destroy();
                    }
                    dmtv2.GetPending();
                });
            }
            else {
                toastMeaasage("error", result.message);
            }
        });
    },
    DeductTdsDmt: function (id,area) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, deduct tds!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                ajax.doGetAjax(`/` + area+`/Services/DeductTdsDmt?id=${id}`, function (result) {
                    if (result.status) {
                        $.when(toastMeaasage("success", result.message)).then(function () {
                            var data = {};
                            common.Filter(area, "Services", "ListMonthlyDmtCommission", data, "myTable");
                        });
                    }
                    else {
                        toastMeaasage("error", result.message);
                    }
                });
            }
        });
    },
    GetAPI: function (area, ddlId) {
        common.BindDropdown(`/` + area + `/Services/GetAPI`, ddlId, 'API');
    },

}