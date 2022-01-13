
var utility = {
    GetRoleForRegistration: function (id, ddlId, area) {
        common.BindDropdown(`/` + area + `/Utility/GetRoleForRegistration?id=` + id, ddlId, 'Role');
    },
    GetRoleForEmployee: function (id) {
        common.BindDropdown(`/Admin/Utility/GetRoleForEmployee?id=` + id, 'UserRole', 'Role');

    },
    GetCountry: function () {
        common.BindDropdown(`/Admin/Utility/GetCountry`, 'CountryId', 'Country');
    },
    GetState: function (countryId) {
        common.BindDropdown(`/Admin/Utility/GetState?countryId=` + countryId, 'StateId', 'State');
    },
    StatePopup: function (id) {
        ajax.doGetAjax(`/Admin/Utility/AddState?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                utility.GetCountry();
            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add State');
                    }
                    else {
                        $(`#modeltitle`).text('Update State')
                        var stateId = $("#hdnStateId").val();
                        $("#StateId").val(stateId);
                        var countryId = $("#hdnCountryId").val();
                        $("#CountryId").val(countryId);
                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteState: function (id) {
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
                ajax.doGetAjax(`/Admin/Utility/DeleteState?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable("/Admin/Utility/GetStateList", 'myTable');
                    }
                });
            }
        });
    },
    IsActiveState: function (id) {
        ajax.doGetAjax(`/Admin/Utility/ActiveState?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable("/Admin/Utility/GetStateList", 'myTable');
            }
        });

    },

    GetCity: function (stateId) {
        var data = { "stateId": stateId }
        ajax.doPostAjax(`/Admin/Utility/GetCity`, data, function (result) {
            if (result.status) {
                $('#CityId').html("");
                $('#CityId').append('<option value="" selected>Select City</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.name, val.id);
                    $('#CityId').append(opt);
                });
            }
        });
    },
    CityPopup: function (id) {
        ajax.doGetAjax(`/Admin/Utility/AddCity?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                utility.GetState(0);
            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add City');
                    }
                    else {
                        $(`#modeltitle`).text('Update City')
                        var CityId = $("#hdnCityId").val();
                        $("#CityId").val(CityId);
                        var stateId = $("#hdnStateId").val();
                        $("#StateId").val(stateId);
                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteCity: function (id) {
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
                ajax.doGetAjax(`/Admin/Utility/DeleteCity?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable("/Admin/Utility/GetCityList", 'myTable');
                    }
                });
            }
        });
    },
    IsActiveCity: function (id) {
        ajax.doGetAjax(`/Admin/Utility/ActiveCity?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable("/Admin/Utility/GetCityList", 'myTable');
            }
        });

    },


    //*********Package***********//
    //GetPackage: function () {      
    //    ajax.doGetAjax(`/Admin/Utility/GetPackage`,  function (result) {
    //        if (result.status) {
    //            $('#CityId').html("");
    //            $('#CityId').append('<option value="" selected>Select City</option>');
    //            $(result.results).each(function (index, val) {
    //                var opt = new Option(val.name, val.id);
    //                $('#CityId').append(opt);
    //            });
    //        }
    //    });
    //},
    GetPackage: function (area, ddlId) {
        // $("#" + ddlId).html('');
        common.BindDropdown(`/` + area + `/Utility/GetPackage`, ddlId, 'Package');
    },
    PackagePopup: function (id, area) {
        ajax.doGetAjax(`/` + area + `/Utility/AddPackage?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Package');
                    }
                    else {
                        $(`#modeltitle`).text('Update Package')

                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeletePackage: function (id, area) {
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
                ajax.doGetAjax(`/` + area + `/Utility/DeletePackage?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindTable(`/` + area + `/Utility/GetPackageList`, 'myTable');
                    }
                });
            }
        });
    },
    IsActivePackage: function (id, area) {
        ajax.doGetAjax(`/` + area + `/Utility/ActivePackage?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindTable(`/` + area + `/Utility/GetPackageList`, 'myTable');
            }
        });

    },
    //*********End Package********//
    //*********Assign Service********//
    GetAssignedService: function (id) {
        ajax.doGetAjax(`/Admin/Utility/GetServiceByPackage?packageId=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Assign Service');
                }, 500);
            });
        });
    },
    GetAssignedServiceByMsrNo: function (id) {
        ajax.doGetAjax(`/Admin/Utility/GetServiceByMsrNo?MsrNo=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () {
                    $(`#modeltitle`).text('Assign Service');
                }, 500);
            });
        });
    },
    AssignService: function () {
        var packageId = $(`#packageId`).val();
        if (packageId == "" || packageId == undefined) { toastMeaasage(`error`, `Something Went Wrong`); return; }
        var jsonArray = [];
        $(`#serviceList input[type=checkbox`).each(function () {
            if ($(this).prop(`checked`)) {
                var json = { "ServiceId": $(this).val(), "PackageId": packageId };
                jsonArray.push(json);
            }
        })

        if (jsonArray.length == 0) { toastMeaasage(`error`, `Minimum One Service Is Mandatory`); return; }
        var data = { "prm": jsonArray };
        ajax.AjaxPost("/Admin/Utility/AssignService?packageId=" + packageId, JSON.stringify(jsonArray), function (result) {
            if (result.status) {
                toastMeaasage("success", result.message);
                setTimeout(function () {
                    $(`.close`).trigger(`click`);
                }, 2000);
            }
            else {
                toastMeaasage("error", result.message)
            }
        });

    },
    AssignServiceByMsrNo: function () {
        var MsrNo = $(`#MsrNo`).val();
        if (MsrNo == "" || MsrNo == undefined) { toastMeaasage(`error`, `Something Went Wrong`); return; }
        var jsonArray = [];
        $(`#serviceList input[type=checkbox`).each(function () {
            if ($(this).prop(`checked`)) {
                var json = { "ServiceId": $(this).val(), "MsrNo": MsrNo };
                jsonArray.push(json);
            }
        })
        if (jsonArray.length == 0) { toastMeaasage(`error`, `Minimum One Service Is Mandatory`); return; }
        var data = { "prm": jsonArray };
        ajax.AjaxPost("/Admin/Utility/AssignServiceByMsrNo?MsrNo=" + MsrNo, JSON.stringify(jsonArray), function (result) {
            if (result.status) {
                toastMeaasage("success", result.message);
                setTimeout(function () {
                    $(`.close`).trigger(`click`);
                }, 2000);
            }
            else {
                toastMeaasage("error", result.message)
            }
        });

    },
    GetBank: function (area) {
        common.BindDropdown(`/` + area + `/Utility/GetBank`, 'BankId', 'Bank');
    },
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
                $("#MsrNo").val(i.item.val);
                //alert(i.item.label);
                utility.GetAssignedServiceByMsrNo(i.item.val);
                // wallet.GetBalance(i.item.val, area);
            },
            minLength: 3
        });
    },

    GetQueryStringValue: function GetQueryStringParameterValues(param) {
        var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < url.length; i++) {
            var urlparam = url[i].split('=');
            if (urlparam[0] == param) {
                return urlparam[1];
            }
        }
    },
    SupportPopup: function (id, area) {
        ajax.doGetAjax(`/` + area.trim() + `/Utility/CreateTicket?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Create Ticket');
                        $('#divSubject').show();
                    }
                    else {
                        $(`#modeltitle`).text('Message');
                        $('#Subject').attr("readonly", true);
                        $('#divSubject').css("display", "none");
                        $('#Message').val('');
                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },


    ChatMessageBind: function (area) {
        
      var id = location.pathname.substring(location.pathname.lastIndexOf("/") + 1);
       // var id = $('#hdnId').val();
        ajax.doGetAjax(`/` + area.trim() + `/Utility/ChatMessage?id=` + id, function (result) {
            $(`#divChat-Message`).html('');
            $(`#divChat-Message`).html(result);
           /* $(`#hdnId`).val(id);*/
        });
    },
    SaveMessage: function (area) {
        if (true) {
            debugger;
            var data = {};
            //var id = location.pathname.substring(location.pathname.lastIndexOf("/") + 1);
            //$(`#hdnId`).val(id);
            $(".form-control").each(function () {
                data[`${this.id}`] = $(this).val();
            });
            ajax.doPostAjax(`/` + area+`/Utility/SaveMessage`, data, function (result) {
                if (result.status) {
                    $.when(utility.ChatMessageBind(area)).then(function () {
                        $(`#Message`).val("");
                    });
                }
                else {
                    toastMeaasage('error', result.message)
                }
            });
        }
    },
    GetPriority: function (ddlId) {
        common.BindDropdown(`/Member/Utility/GetPriority`, ddlId, 'Priority');
    },
    GetDepartment: function (ddlId) {
        common.BindDropdown(`/Member/Utility/GetDepartment`, ddlId, 'Department');
    },
    IsCloseTicket: function (id) {
        ajax.doGetAjax(`/Admin/Utility/CloseTicket?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                var data = {};
                common.Filter("Admin", "Utility", "GetSupportList", data, "myTable");
            }
        });
    },
}
