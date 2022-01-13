
var rc = {
    DeleteAPI: function (id) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                ajax.doGetAjax(`/Admin/Recharge/DeleteAPI?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable(`/Admin/Recharge/LoadListAPI`, `myTable`);
                    }
                });
            }
        });
    },
    ActiveAPI: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/ActiveAPI?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable(`/Admin/Recharge/LoadListAPI`, `myTable`);
            }
        });

    },
    GetAPI: function () {
        common.BindDropdown(`/Admin/Recharge/GetAPI`, 'apiId', 'Api');
    },
    GetService: function () {
        common.BindDropdown(`/Admin/Recharge/GetService`, 'ServiceId', 'Service');
    },
    GetServiceForFilter: function (area) {
        common.BindDropdown(`/` + area + `/Recharge/GetServiceForFilter`, 'ServiceId-Filter', 'Service');
    },
    GetOperatorByServiceIdForFilter: function (serviceId, area) {
        if (serviceId != 10 && serviceId != "") {
            common.BindDropdown(`/` + area + `/Recharge/GetOperatorByServiceIdForFilter?serviceId=` + serviceId, 'OperatorId-Filter', 'Operator');
            $("#divOperator").show();
            $("#divMobile").show();
            $("#divAccountNo").hide();
        }
        else if (serviceId == 10) {
            $("#divOperator").hide();
            $("#divAccountNo").show();
            $("#divMobile").hide();
        }
        else {
            $("#divOperator").hide();
            $("#divAccountNo").hide();
            $("#divMobile").hide();
        }
    },
    OperatorPopup: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/AddOperator?id=` + id, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                rc.GetService();

            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Operator');
                    }
                    else {
                        $(`#modeltitle`).text('Update Operator');
                        var serviceId = $("#hdnServiceId").val();
                        $("#ServiceId").val(serviceId);
                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteOperator: function (id) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                ajax.doGetAjax(`/Admin/Recharge/DeleteOperator?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable(`/Admin/Recharge/LoadOperatorList`, `myTable`);
                    }
                });
            }
        });
    },
    IsActiveOperator: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/ActiveOperator?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable(`/Admin/Recharge/LoadOperatorList`, `myTable`);
            }
        });

    },

    CirclePopup: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/AddCircle?id=` + id, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                rc.GetService();

            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Circle');
                    }
                    else {
                        $(`#modeltitle`).text('Update Circle');

                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteCircle: function (id) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                ajax.doGetAjax(`/Admin/Recharge/DeleteCircle?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable(`/Admin/Recharge/LoadCircleList`, `myTable`);
                    }
                });
            }
        });
    },
    IsActiveCircle: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/ActiveCircle?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable(`/Admin/Recharge/LoadCircleList`, `myTable`);
            }
        });

    },

    ServicePopup: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/AddService?id=` + id, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {


            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Service');
                    }
                    else {
                        $(`#modeltitle`).text('Update Service');

                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteService: function (id) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                ajax.doGetAjax(`/Admin/Recharge/DeleteService?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindPostTable(`/Admin/Recharge/LoadServiceList`, `myTable`);
                    }
                });
            }
        });
    },
    IsActiveService: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/ActiveService?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindPostTable(`/Admin/Recharge/LoadServiceList`, `myTable`);
            }
        });

    },
    OperatorCodePopup: function () {
        ajax.doGetAjax(`/Admin/Recharge/OperatorCode`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                rc.GetService();

            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Add / Edit Operator Code');
                    rc.GetAPI();
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    GetOperatorByAPIId: function () {
        var serviceId = $("#ServiceId option:selected").val();
        var apiId = $("#apiId option:selected").val();
        if (serviceId == "") { toastMeaasage("error", "Please Select Service"); return; }
        if (apiId == "") { toastMeaasage("error", "Please Select API"); return; }
        ajax.doGetAjax(`/Admin/Recharge/LoadOperatorCode?serviceId=` + serviceId + `&apiId=` + apiId, function (result) {
            $(`#tBody`).html('');
            $(`#tBody`).html(result)
            $(`#btn_save`).slideDown(800);
        });
    },
    SaveOperatorCode: function () {

        var table = document.getElementById("myTable");
        var tbodyRowCount = table.tBodies[0].rows.length;
        if (tbodyRowCount > 0) {
            var apiId = $("#apiId option:selected").val();
            var jsonArray = [];
            for (var i = 1; i <= tbodyRowCount; i++) {
                var json = {
                    "OperatorId": $("#OperatorId_" + i).val(),
                    "OperatorCode": $("#OperatorCode_" + i).val(),
                    "Commission": $("#Commission_" + i).val(),
                    "CommissionIsFlat": $("#CommissionIsFlat_" + i).prop("checked"),
                    "Surcharge": $("#Surcharge_" + i).val(),
                    "SurchargeIsFlat": $("#SurchargeIsFlat_" + i).prop("checked"),
                    "ApiId": apiId
                };
                jsonArray.push(json);
            }
            var data = { "prm": jsonArray };
            ajax.AjaxPost("/Admin/Recharge/OperatorCode?apiId=" + apiId, JSON.stringify(jsonArray), function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    $(`#tBody`).html('');
                    //$(`#btn_save`).css("display", "none");
                    $("#btn_save").toggle('slow');
                    $("#ServiceId").val("");
                    $("#apiId").val("");
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
    },
    CircleCodePopup: function () {
        ajax.doGetAjax(`/Admin/Recharge/CircleCode`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                rc.GetAPI();

            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Add / Edit Circle Code');
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    GetCircleByAPIId: function () {
        var apiId = $("#apiId option:selected").val();
        if (apiId == "") { toastMeaasage("error", "Please Select API"); return; }
        ajax.doGetAjax(`/Admin/Recharge/LoadCircleCode?apiId=` + apiId, function (result) {
            $(`#tBody`).html('');
            $(`#tBody`).html(result)
            $(`#btn_save`).slideDown(800);
        });
    },
    SaveCircleCode: function () {

        var table = document.getElementById("myTable");
        var tbodyRowCount = table.tBodies[0].rows.length;
        if (tbodyRowCount > 0) {
            var apiId = $("#apiId option:selected").val();
            var jsonArray = [];
            for (var i = 1; i <= tbodyRowCount; i++) {
                var json = {
                    "CircleId": $("#CircleId_" + i).val(),
                    "CircleCode": $("#CircleCode_" + i).val(),
                    "ApiId": apiId
                };
                jsonArray.push(json);
            }
            var data = { "prm": jsonArray };
            ajax.AjaxPost("/Admin/Recharge/CircleCode?apiId=" + apiId, JSON.stringify(jsonArray), function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    $(`#tBody`).html('');
                    $("#btn_save").toggle('slow');
                    $("#apiId").val("");
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
    },
    ManageCommissionPopup: function (area) {
        $('.modal_outer').css('max-width', '1300px !important');
        $('.modal-body').css('max-width', '1300px !important');

        ajax.doGetAjax(`/Admin/Recharge/ManageCommission`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                rc.GetService();
            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Manage Commission');
                    common.BindDropdown("/Admin/Utility/GetPackage", "PackageId", "Package");
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },

    GetCommissionByPackageId: function () {
        var serviceId = $("#ServiceId option:selected").val();
        var packageId = $("#PackageId option:selected").val();
        if (serviceId == "") { toastMeaasage("error", "Please Select Service"); return; }
        if (packageId == "") { toastMeaasage("error", "Please Select Package"); return; }
        ajax.doGetAjax(`/Admin/Recharge/LoadRechargeCommission?packageId=` + packageId + `&serviceId=` + serviceId, function (result) {
            $(`#tBody`).html('');
            $(`#tBody`).html(result)
            $(`#btn_save`).slideDown(800);
        });
    },
    SaveRechargeCommission: function (url) {
        var table = document.getElementById("myTable");
        var tbodyRowCount = table.tBodies[0].rows.length;
        if (tbodyRowCount > 0) {
            var packageId = $("#PackageId option:selected").val();
            var jsonArray = [];
            for (var i = 1; i <= tbodyRowCount; i++) {
                var json = {
                    "OperatorId": $("#OperatorId_" + i).val(),
                    "ActiveApi": $("#ActiveApi_" + i).val(),
                    "PackageId": packageId,
                    "sdComm": $("#sdComm_" + i).val(),
                    "sdIsFlat": $("#sdIsFlat_" + i).prop("checked"),
                    "mdComm": $("#mdComm_" + i).val(),
                    "mdIsFlat": $("#mdIsFlat_" + i).prop("checked"),
                    "dtComm": $("#dtComm_" + i).val(),
                    "dtIsFlat": $("#dtIsFlat_" + i).prop("checked"),
                    "rtComm": $("#rtComm_" + i).val(),
                    "rtIsFlat": $("#rtIsFlat_" + i).prop("checked"),
                    "gstRate": $("#gstRate_" + i).val(),
                    "tdsRate": $("#tdsRate_" + i).val(),
                };
                jsonArray.push(json);
            }
            var data = { "prm": jsonArray };
            ajax.AjaxPost(url + "?packageId=" + packageId, JSON.stringify(jsonArray), function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    $(`#tBody`).html('');
                    $("#btn_save").toggle('slow');
                    $("#PackageId").val("");
                    $("#ServiceId").val("");
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
    },
    SwitchApi: function (id) {
        ajax.doGetAjax(`/Admin/Recharge/SwitchApi?apiId=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                ajax.doGetAjax(`/Admin/Recharge/LoadApiList`, function (result) {
                    $(`#apiList`).html('');
                    $(`#apiList`).html(result);
                });
            }
        });

    },
    GetPackageWiseApi: function () {
        ajax.doGetAjax(`/Admin/Recharge/SwitchPackageWise?`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () { rc.GetAPI(); }, 200);
            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Package Wise Switch API');
                    common.BindDropdown("/Admin/Utility/GetPackage", "packageId", "Package");
                    common.LoadModelValidation();
                }, 500);
            });
        });

    },
    OperatorWiseApiPopup: function () {
        ajax.doGetAjax(`/Admin/Recharge/SwitchApiOperatorWise?`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () { rc.GetAPI(); }, 200);
            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Operator Wise Switch API');
                    rc.GetService();
                    common.LoadModelValidation();
                }, 500);
            });
        });

    },
    GetOperatorByServiceId: function () {
        var serviceId = $("#ServiceId option:selected").val();
        if (serviceId == "") { toastMeaasage("error", "Please Select Service"); return; }

        ajax.doGetAjax(`/Admin/Recharge/GetOperatorByServiceId?serviceId=` + serviceId, function (result) {
            $(`#tBody`).html('');
            $(`#tBody`).html(result)
            $(`#btn_save`).slideDown(800);
        });
    },

    SwitchApiByOperator: function () {
        var serviceId = $("#ServiceId option:selected").val();
        if (serviceId == "") { toastMeaasage("error", "Please Select Service"); return; }
        var apiId = $("#apiId option:selected").val();
        if (apiId == "") { toastMeaasage("error", "Please Select API"); return; }
        var jsonArray = [];
        $('#myTable tbody input[type=checkbox]').each(function () {
            if ($(this).prop(`checked`)) {
                var json = { "OperatorId": $(this).val(), "ApiId": apiId };
                jsonArray.push(json);
            }
        });
        if (jsonArray.length > 0) {
            var data = { "prm": jsonArray };
            ajax.AjaxPost(`/Admin/Recharge/SwitchApiOperatorWise`, JSON.stringify(jsonArray), function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    $(`#tBody`).html('');
                    $("#btn_save").toggle('slow');
                    $("#apiId").val("");
                    $("#ServiceId").val("");
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
        else {
            toastMeaasage("error", "Please Select Operator !"); return;
        }
    },


    ///****** Member Commission******///////
    MemberCommissionPopup: function () {
        ajax.doGetAjax(`/Member/Utility/ManageCommission`, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                common.BindDropdown(`/Member/Utility/GetService`, 'ServiceId', 'Service');
            }).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Manage Commission');
                    common.BindDropdown("/Member/Utility/GetPackage", "PackageId", "Package");
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },

    MemberCommissionByPackageId: function () {
        var serviceId = $("#ServiceId option:selected").val();
        var packageId = $("#PackageId option:selected").val();
        if (serviceId == "") { toastMeaasage("error", "Please Select Service"); return; }
        if (packageId == "") { toastMeaasage("error", "Please Select Package"); return; }
        ajax.doGetAjax(`/Member/Utility/LoadRechargeCommission?packageId=` + packageId + `&serviceId=` + serviceId, function (result) {
            $(`#tBody`).html('');
            $(`#tBody`).html(result)
            $(`#btn_save`).slideDown(800);
        });
    },
    SaveMemberRechargeCommission: function (url) {
        var table = document.getElementById("myTable_temp");
        var tbodyRowCount = table.tBodies[0].rows.length;
        if (tbodyRowCount > 0) {
            var packageId = $("#PackageId option:selected").val();
            var jsonArray = [];
            for (var i = 1; i <= tbodyRowCount; i++) {
                var json = {
                    "OperatorId": $("#OperatorId_" + i).val(),
                    "ActiveApi": $("#ActiveApi_" + i).val(),
                    "PackageId": packageId,
                    "Commission": $("#Commission_" + i).val(),
                    "IsFlat": $("#IsFlat_" + i).val(),
                };
                jsonArray.push(json);
            }
            var data = { "prm": jsonArray };
            ajax.AjaxPost(url + "?packageId=" + packageId, JSON.stringify(jsonArray), function (result) {
                if (result.status) {
                    toastMeaasage("success", result.message);
                    $(`#tBody`).html('');
                    $("#btn_save").toggle('slow');
                    $("#PackageId").val("");
                    $("#ServiceId").val("");
                }
                else {
                    toastMeaasage("error", result.message)
                }
            });
        }
    },
    ///******___END__________???????????????
    GetPendingRecharge: function (type) {
        var action;
        if (type == "recharge") { action = "LoadPendingRecharge" } else { action = "LoadPendingElectricity" }
        $.when(ajax.doGetAjax(`/Admin/Recharge/${action}`, function (result) {
            $(`#tbody-p-recharge`).html('');
            $(`#tbody-p-recharge`).html(result);
        })).then(function () {
            setTimeout(function () {
                table.dataTable(`myTable`);
            }, 500);
            setTimeout(function () {
                var table = document.getElementById(`myTable`);
                var tbodyRowCount = table.tBodies[0].rows.length;
                if (tbodyRowCount > 0) { $(`#dv-btn`).css(`display`, `block`); }
            }, 500);
        });
    },

    UpdateStatus: function (type, v2) {

        common.ShowLoader();
        var jsonArray = [];
        $('#myTable tbody input[type=checkbox]').each(function () {
            if ($(this).prop(`checked`)) {
                var json = { "Id": $(this).val(), "OprId": $("#oprId_" + $(this).val()).val() };
                jsonArray.push(json);
            }
        });

        debugger;
        if (jsonArray.length > 0) {

            var data = { "prm": jsonArray };
            var url = "";
            if (type == "Check Status") {
                url = `/Admin/Recharge/CheckStatus`;
            }
            if (type == "Force Failed") {
                url = `/Admin/Recharge/ForceFailed`;
            }
            if (type == "Force Success") {
                url = `/Admin/Recharge/ForceSuccess`;
            }
            if (url != "") {
                ajax.AjaxPost(url, JSON.stringify(jsonArray), function (result) {
                    if (result.status) {
                        toastMeaasage("success", result.message);
                        setTimeout(function () {
                            if ($.fn.dataTable.isDataTable('#myTable')) {
                                $('#myTable').DataTable().destroy();
                            }
                            rc.GetPendingRecharge(v2);
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
        }
        else {
            toastMeaasage("error", "Please Select Transaction !");
        }
        common.HideLoader();
    },
   
   
}