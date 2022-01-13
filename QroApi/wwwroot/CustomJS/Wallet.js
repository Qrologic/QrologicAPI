var wallet = {
    SearchMember: function () {
        var area = $(`#hdnArea`).val();
        $("#MemberId").autocomplete({

            source: function (request, response) {
                var data = { "prefix": request.term }
                ajax.doPostAjax(`/` + area + `/Member/SearchMember`, data, function (result) {
                    if (result.status) {
                        response($.map(result.results, function (item, index) {
                            return {
                                label: item.memberName,
                                val: item.msrNo
                            }
                        }));
                    }
                });
            },
            select: function (e, i) {
                $("#ToMsrNo").val(i.item.val);
                wallet.GetBalance(i.item.val, area);
            },
            minLength: 3
        });
    },
    AddFundPopup: function (fector, area) {
        $(`#hdnArea`).val(area);
        ajax.doGetAjax(`/` + area + `/Wallet/AddDeductBalance?fector=` + fector, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                $.when(
                    //common.BindRole()
                ).then(function () {
                    setTimeout(function () {
                        if (fector == `Cr`) {
                            $(`#modeltitle`).text('Credit Balance');
                        }
                        else {
                            $(`#modeltitle`).text('Debit Balance');
                        }
                        common.LoadModelValidation();
                        wallet.SearchMember();
                    }, 500);
                });
            });
        });
    },
    GetBalance: function (id, area) {
        //id = $("#hdnMsrNo").val();

        ajax.doGetAjax(`/` + area + `/Wallet/GetBalance?id=` + id, function (result) {
            if (id > 0) {
                $("#Balance").val(result.balance);
            }
            else {
                $("#sp-balance").text(parseFloat(result.balance).toFixed(2));
            }
        });
    },

    GetBankForRequest: function () {
        common.BindDropdown(`/Member/Wallet/GetBankForRequest`, `ToBank`, `Bank`);
    },
ManageRequestValidation(item) {
    if (item == `Cash`) {
        $("#ToBank").prop("disabled", true);
        /* $("#ChequeNumber").prop("disabled", true);*/
        $("#RefNo").prop("disabled", true);
    }
    else //if (item == `Cheque` || item == `Demand Draft(DD)`)
    {

        $("#ToBank").prop("disabled", false);
        /* $("#ChequeNumber").prop("disabled", false);*/
        $("#RefNo").prop("disabled", false);

    }
    //else if (item == `Online` || item == `Net Banking`) {

    //    $("#ToBank").prop("disabled", false);
    //    /*$("#ChequeNumber").prop("disabled", true);*/
    //    $("#RefNo").prop("disabled", false);

    //}
},
OpenRequestPopup: function (id) {

    ajax.doGetAjax(`/Member/Wallet/AddEditBalanceRequest?id=` + id, function (result) {
        $(`#model_body`).html('');
        $.when($(`#model_body`).html(result)).then(function () {
            setTimeout(function () {
                wallet.GetBankForRequest();
                if (id == `0`) {
                    $(`#modeltitle`).text('New Request');
                }
                else {
                    $(`#modeltitle`).text('Update Request');
                    var toBank = $("#hdnToBank").val();
                    $(`#ToBank`).val(toBank);
                }

            }, 500);
            setTimeout(function () {
                if (id != `0`) {
                    var toBank = $("#hdnToBank").val();
                    $(`#ToBank`).val(toBank);
                    var paymentMode = $("#PaymentMode option:selected").val();
                    wallet.ManageRequestValidation(paymentMode);
                }
            }, 800);
            common.LoadModelValidation();
        });
    });
},
CancelRequest: function (id) {
    ajax.doGetAjax(`/Member/Wallet/CancelRequest?id=` + id, function (result) {
        if (result.status);
        {
            toastMeaasage('success', result.message);
            table.BindPostTable("/Member/Wallet/LoadBalanceRequest", 'myTable');
        }
    });

},
ApproveRequest: function (id, area) {
    ajax.doGetAjax(`/` + area + `/Wallet/ApproveRequest?id=` + id, function (result) {
        if (result.status);
        {
            toastMeaasage('success', result.message);
            table.BindPostTable(`/` + area + `/Wallet/LoadDownlineBalanceRequest`, 'myTable2');
        }
    });

},
CancelRequestByParent: function (id, area) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        input: 'text',
        inputPlaceholder: "Remark",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, cancel it!',
        allowOutsideClick: false,
        inputValidator: (value) => {
            return !value && 'You need to write something!'
        }
    }).then((result) => {

        if (result.value) {
            ajax.doGetAjax(`/` + area + `/Wallet/CancelRequestByParent?id=` + id + `&remark=` + result.value, function (result) {
                if (result.status);
                {
                    toastMeaasage('success', result.message);
                    table.BindPostTable(`/` + area + `/Wallet/LoadDownlineBalanceRequest`, 'myTable2');
                }
            });
        }

    });
},
ViewReceiptPopup: function (id, area) {

    $(`#model_body`).html('');
    ajax.doGetAjax(`/` + area + `/Wallet/TransactionDetail?id=` + id, function (result) {
        $(`#modeltitle`).text('Transaction Detail');
        $(`#model_body`).html(result);
    });
},
Top10Transaction: function () {
    ajax.doGetAjax(`/Member/Wallet/Top10Transaction`, function (result) {
        $(`#top-10-txn`).html('');
        $(`#top-10-txn`).html(result);
    });
}
}