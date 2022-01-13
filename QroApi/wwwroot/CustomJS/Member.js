var member = {
    MemberPopup: function (id,area) {
        ajax.doGetAjax(`/` + area.trim()+`/Member/AddMember?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                $.when(utility.GetRoleForRegistration(id, 'UserRole', area.trim())).then(function () {
                    if (area.toLowerCase()=="admin") {
                        utility.GetPackage(area, 'PackageId')
                    }
                }).then(function () {
                    utility.GetCountry();
                }).then(function () {
                    utility.GetState();
                }).then(function () {
                    utility.GetCity();
                }).then(function () {
                    setTimeout(function () {
                        if (id == 0) {
                            $(`#modeltitle`).text('Add Member');
                         
                            //$(`#PackageId`).val('0');
                        }
                        else {
                            $(`#modeltitle`).text('Update Member');
                            $("#UserRole").attr("disabled", true);
                            $("#PackageId").attr("disabled", true);
                            $("#Password").val($("#hdnPassword").val());
                            $("#divPassword").hide();
                            $("#UserRole").val($("#hdnUserRole").val());
                            $("#PackageId").val($("#hdnPackageId").val());
                            $("#CountryId").val($("#hdnCountryId").val());
                            $("#StateId").val($("#hdnStateId").val());
                            $("#CityId").val($("#hdnCityId").val());
                        }
                        common.LoadModelValidation();
                    }, 500);
                });
            });
        });
    },
    IsActiveMember: function (id) {
        ajax.doGetAjax(`/Admin/Member/ActiveMember?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                var data = {};
                common.Filter("Admin", "Member", "GetMemberList", data, "myTable");
            }
        });

    },

    EmployeePopup: function (id) {
        ajax.doGetAjax(`/Admin/Member/AddEmployee?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                $.when(utility.GetRoleForEmployee(id)).then(function () {
                    utility.GetPackage(`Admin`)
                }).then(function () {
                    utility.GetCountry();
                }).then(function () {
                    utility.GetState();
                }).then(function () {
                    utility.GetCity();
                }).then(function () {
                    setTimeout(function () {
                        if (id == 0) {
                            $(`#modeltitle`).text('Add Employee');
                        }
                        else {
                            $(`#modeltitle`).text('Update Employee');
                           $("#UserRole").attr("readonly", true);
                            $("#UserRole").attr("style", "pointer-events:none;");
                            $("#UserId").attr("readonly", true);
                            $("#UserId").attr("style", "pointer-events:none;");
                        

                            $("#Password").val($("#hdnPassword").val());
                            $("#divPassword").hide();
                            $("#UserRole").val($("#hdnUserRole").val());
                            $("#CountryId").val($("#hdnCountryId").val());
                            $("#StateId").val($("#hdnStateId").val());
                            $("#CityId").val($("#hdnCityId").val());
                        }
                        common.LoadModelValidation();
                    }, 500);
                });
            });
        });
    },
    IsActiveEmployee: function (id) {
        ajax.doGetAjax(`/Admin/Member/ActiveEmployee?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindPostTable("/Admin/Member/GetEmployeeList", 'myTable');
            }
        });

    },
    ViewDetail: function (id,area) {
        ajax.doGetAjax(`/${area}/Member/MemberDetail?id=` + id, function (result) {
            $(`#member-detail`).html(``);             
            $(`#member-detail`).html(result);
        });
    },
    ViewDetailEmployee: function (id, area) {
       
       
        ajax.doGetAjax(`/${area}/Member/EmployeeDetail?id=` + id, function (result) {
            $("#modeltitle-2").text("Employee Detail");
            $(`#member-detail`).html(``);
            $(`#member-detail`).html(result);
        });
    },
    ChangeMemberPassword: function (id,area) {
        var password = $(`#password`).val();      
        if (password == "") { toastMeaasage(`error`, `Enter New Password !`); return; }
        var data = { "NewPassword": password, "MsrNo": id };
        ajax.doPostAjax(`/${area}/Member/ChangeMemberPassword`,data, function (result) {
            if (result.status)
            {
                toastMeaasage('success', result.message);
                $(`#password`).val("");
                $(`#change-password`).removeClass(`show`);
                member.ViewDetail(id, area);
            }
            else
            {
                toastMeaasage('error', result.message);
            }
        });

    },
    ChangeMemberTPassword: function (id, area) {
        var tpassword = $(`#tpassword`).val();
        if (tpassword == "") { toastMeaasage(`error`, `Enter New T Password !`); return; }
        var data = { "NewTPassword": tpassword, "MsrNo": id };
        ajax.doPostAjax(`/${area}/Member/ChangeMemberTPassword`, data, function (result) {
            if (result.status) {
                toastMeaasage('success', result.message);
                $(`#tpassword`).val("");
                $(`#change-tpass`).removeClass(`show`);
                member.ViewDetail(id, area);
            }
            else {
                toastMeaasage('error', result.message);
            }
        });

    },
    ChangeEmployeePassword: function (id, area) {
        var password = $(`#password`).val();
        if (password == "") { toastMeaasage(`error`, `Enter New Password !`); return; }
        var data = { "NewPassword": password, "MsrNo": id };
        ajax.doPostAjax(`/${area}/Member/ChangeEmployeePassword`, data, function (result) {
            if (result.status) {
                toastMeaasage('success', result.message);
                $(`#password`).val("");
                $(`#change-password`).removeClass(`show`);
                member.ViewDetailEmployee(id, area);
            }
            else {
                toastMeaasage('error', result.message);
            }
        });

    },
    ChangeEmployeeTPassword: function (id, area) {
        var tpassword = $(`#tpassword`).val();
        if (tpassword == "") { toastMeaasage(`error`, `Enter New T Password !`); return; }
        var data = { "NewTPassword": tpassword, "MsrNo": id };
        ajax.doPostAjax(`/${area}/Member/ChangeEmployeeTPassword`, data, function (result) {
            if (result.status) {
                toastMeaasage('success', result.message);
                $(`#tpassword`).val("");
                $(`#change-tpass`).removeClass(`show`);
                member.ViewDetailEmployee(id, area);
            }
            else {
                toastMeaasage('error', result.message);
            }
        });

    },

    ChangePassword: function ( area) {
        var oldpassword = $(`#OldPassword`).val();
        var newpassword = $(`#NewPassword`).val();
        if (oldpassword == "") { toastMeaasage(`error`, `Enter Old Password !`); return; }
        if (newpassword == "") { toastMeaasage(`error`, `Enter New Password !`); return; }
        var data = { "NewPassword": newpassword, "OldPassword": oldpassword };
        ajax.doPostAjax(`/${area}/Member/ChangePassword`, data, function (result) {
            if (result.status) {
               
                toastMeaasage('success', result.message);
                $(`#OldPassword`).val("");
                $(`#NewPassword`).val(``);
               // $(".close").click();
            }
            else {
                toastMeaasage('error', result.message);
            }
        });

    }
}

