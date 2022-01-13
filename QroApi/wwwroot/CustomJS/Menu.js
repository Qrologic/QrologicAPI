var tree;
var menu = {

    GetRoleForRights: function () {
        common.BindDropdown(`/Admin/Utility/GetRoleForRights`, 'UserRole', 'Role');

    },
    ShowParentMenu: function (level) {
        if (level == 2) {
            $("#ParentId").attr("data-val", "true").attr("data-val-required", "The Select Menu field is required.");
            menu.BindFirstLevel();
        }
        else {
            $("#ParentId").removeAttr("data-val").removeAttr("data-val-required");
        }
    },
    BindFirstLevel: function () {
        ajax.doGetAjax(`/Admin/Menu/GetFirstLevelMenu`, function (result) {

            if (result.status) {
                $('#ParentId').html("");
                $('#ParentId').append('<option value="0" selected>Select Menu</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.menuName, val.id);
                    $('#ParentId').append(opt);
                })
            }

        });
    },
    Validation: function () {
        var flag = true;
        $('.form-control').each(function () {
            flag = true;
            if ($(this).val() == "" || $(this).val() == "0") {
                if ($(this).attr('data-val-required')) {
                    $(this).focus();
                    toastMeaasage('error', $(this).attr('data-val-required'));
                    flag = false;
                }

                return flag;
            }
        });
        return flag;
    },
    GetAdminMenuList: function () {
        table.BindPostTable("/Admin/Menu/GetMenuList", 'myTable');
    },
    SaveAdminMenu: function (sringArray) {
        if (menu.Validation()) {
            common.ShowLoader();
            var data = {};
            $(".form-control").each(function () {
                data[`${this.id}`] = $(this).val();
            });

            ajax.doPostAjax(`/Admin/Menu/AdminMenu`, data, function (result) {
                common.HideLoader();
                if (result.status) {
                    $.when(menu.GetAdminMenuList()).then(function () {
                        $('#closepopup').trigger("click");
                        toastMeaasage('success', result.message);
                        menu.EmptyValue();
                    });
                }
                else {
                    toastMeaasage('error', result.message)
                }
            });

        }
    },
    AdminMenuPopup: function (id) {
        ajax.doGetAjax(`/Admin/Menu/CallMenuPartial?id=` + id + `&type=Admin`, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                menu.BindFirstLevel();

            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Menu')
                        $("#ParentId").removeAttr("data-val").removeAttr("data-val-required");
                        $("#MenuId").removeAttr("data-val").removeAttr("data-val-required");
                        $("#hdnParentId").removeAttr("data-val").removeAttr("data-val-required");
                    }
                    else {
                        $(`#modeltitle`).text('Update Menu')
                    }

                    var parentId = $("#hdnParentId").val();
                    $("#ParentId").val(parentId);
                }, 500);
            });
        });
    },
    DeleteAdminMenu: function (id) {
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
                ajax.doGetAjax(`/Admin/Menu/DeleteAdminMenu?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        menu.GetAdminMenuList();
                    }
                });
            }
        });
    },
    IsActiveAdminMenu: function (id) {
        ajax.doGetAjax(`/Admin/Menu/ActiveAdminMenu?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                menu.GetAdminMenuList();
            }
        });

    },
    BindAdminMenu: function () {
       
        var menu = $("#menu");
        ajax.doGetAjax(`/Admin/Menu/BindAdminMenu`, function (result) {
            menu.html("");
            menu.append(result);
           
        });
        
    },
    FillMenuHtml: function () {
      
        var menu = $("#menu");
        sessionStorage.setItem("menu", menu.html());
    },

    BindMenuTree: function (id) {
        if (id > 0) {
            $('#btnSave').show();
            $('#treemenu').tree().destroy();
            tree = $('#treemenu').tree({
                primaryKey: 'id',
                uiLibrary: 'bootstrap',
                dataSource: '/Admin/Menu/GetMenuTree?roleID=' + id,
                checkboxes: true,
            });
        }
        else {
            $('#btnSave').hide();
            $('#treemenu').tree().destroy();
        }

    },
    SaveCheckedTreeNodes: function () {
        var strUser = $('#UserRole').val();
        var checkedIds = tree.getCheckedNodes();
        if (strUser == "0") {
            toastMeaasage('error', "Select Role !");
        }
        else if (checkedIds.length == 0) {
            toastMeaasage('error', "Select Menu !");
        }
        else {
            common.ShowLoader();
            var data = { checkedIds: checkedIds, RoleID: strUser };
            ajax.doPostAjax(`/Admin/Menu/SaveCheckedTreeNodes`, data, function (result) {
                common.HideLoader();
                if (result.status) {
                    toastMeaasage('success', result.message);
                    $('#UserRole').val("");
                    $('#treemenu').tree().destroy();
                    tree = $('#treemenu').tree({
                        primaryKey: 'id',
                        uiLibrary: 'bootstrap',
                        dataSource: '/Admin/Menu/GetMenuTree?roleID=0',
                        checkboxes: true,
                    });
                }
                else {
                    toastMeaasage('error', result.message);
                }
            });
        }
    },



    EmptyValue: function (callback) {

        $('.form-control').each(function () {
            if ($(this).attr("type") == 'select') {
                $(this).val("0");
            }
            else {
                $(this).val("");
            }

        });

    },
    SetMenuInCookie: function (id) {
        var menu = $("#menu");
        ajax.doGetAjax(`/Admin/Menu/SetMenuInCookie?menuId=` + id, function (result) {
            //menu.html("");
            //menu.append(result);           
        });
    },
    SubMenuActive: function (id, firstLevelMenuName, secondLevelMenuName, menuicon) {
        sessionStorage.setItem("ActiveSubMenu", id);
        sessionStorage.setItem("firstLevelMenuName", firstLevelMenuName);
        sessionStorage.setItem("secondLevelMenuName", secondLevelMenuName);
        sessionStorage.setItem("menuicon", menuicon);
    },


    ShowMemberParentMenu: function (level) {
        if (level == 2) {
            $("#ParentId").attr("data-val", "true").attr("data-val-required", "The Select Menu field is required.");
            menu.BindMemberFirstLevel();
        }
        else {
            $("#ParentId").removeAttr("data-val").removeAttr("data-val-required");
        }
    },
    BindMemberFirstLevel: function () {
        ajax.doGetAjax(`/Admin/Menu/MemberFirstLevelMenu`, function (result) {

            if (result.status) {
                $('#ParentId').html("");
                $('#ParentId').append('<option value="0" selected>Select Menu</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.menuName, val.id);
                    $('#ParentId').append(opt);
                })
            }

        });
    },
    GetMemberMenuList: function () {

        table.BindPostTable("/Admin/Menu/GetMemberMenuList", 'myTable');

    },
    SaveMemberMenu: function (sringArray) {
        if (menu.Validation()) {
            common.ShowLoader();
            var data = {};
            $(".form-control").each(function () {
                data[`${this.id}`] = $(this).val();
            });

            ajax.doPostAjax(`/Admin/Menu/MemberMenu`, data, function (result) {
                common.HideLoader();
                if (result.status) {
                    $.when(menu.GetMemberMenuList()).then(function () {
                        $('#closepopup').trigger("click");
                        toastMeaasage('success', result.message);
                        menu.EmptyValue();
                    });
                }
                else {
                    toastMeaasage('error', result.message)
                }
            });

        }
    },
    MemberMenuPopup: function (id) {
        ajax.doGetAjax(`/Admin/Menu/MemberMenuPartial?id=` + id + `&type=Admin`, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                menu.BindMemberFirstLevel();

            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Menu')
                        $("#ParentId").removeAttr("data-val").removeAttr("data-val-required");
                        $("#MenuId").removeAttr("data-val").removeAttr("data-val-required");
                        $("#hdnParentId").removeAttr("data-val").removeAttr("data-val-required");

                    }
                    else {
                        $(`#modeltitle`).text('Update Menu')
                    }

                    var parentId = $("#hdnParentId").val();
                    $("#ParentId").val(parentId);
                }, 500);
            });
        });
    },
    DeleteMemberMenu: function (id) {
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
                ajax.doGetAjax(`/Admin/Menu/DeleteMemberMenu?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        menu.GetMemberMenuList();
                    }
                });
            }
        });
    },
    IsActiveMemberMenu: function (id) {
        ajax.doGetAjax(`/Admin/Menu/ActiveMemberMenu?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                menu.GetMemberMenuList();
            }
        });

    },
    BindRoleTable: function () {
        ajax.doGetAjax(`/Admin/Menu/BindRoleTable`, function (result) {
            $(`#tableRole`).html('');
            $(`#tableRole`).html(result);
        });
    },
    RolePopup: function (id) {
        ajax.doGetAjax(`/Admin/Menu/AddRole?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                utility.GetRoleForRights();
            }).then(function () {
                setTimeout(function () {
                    if (id == 0) {
                        $(`#modeltitle`).text('Add Role');
                    }
                    else {
                        $(`#modeltitle`).text('Update Role')
                        $("#UserRole").val($("#hdnId").val());
                    }
                    common.LoadModelValidation();
                }, 500);
            });
        });
    },
    DeleteRole: function (id) {
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
                ajax.doGetAjax(`/Admin/Menu/DeleteRole?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        menu.BindRoleTable();
                    }
                });
            }
        });
    },
    IsActiveRole: function (id) {
        ajax.doGetAjax(`/Admin/Menu/ActiveRole?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                menu.BindRoleTable();
            }
        });
    },
    BindBreadCrumb: function (IsLogin) {
      
        if (IsLogin==1) {
            sessionStorage.setItem("firstLevelMenuName", "Dashboard");
            sessionStorage.setItem("secondLevelMenuName", "");
            sessionStorage.setItem("menuicon", "fa fa-dashboard");
        }

        var firstLevelMenuName = sessionStorage.getItem("firstLevelMenuName");
        var secondLevelMenuName = sessionStorage.getItem("secondLevelMenuName");
        var menuicon = sessionStorage.getItem("menuicon");

        var url = window.location.pathname;
        var segments = url.split('/');
        if (firstLevelMenuName == null) {
            firstLevelMenuName = segments[2];
        }
        if (secondLevelMenuName == null) {
            secondLevelMenuName = segments[3];
        }
       

        var breadcrumb = `<h1> <i class="${menuicon} opacity-6"></i>&nbsp;${secondLevelMenuName}</h1>`;
        if (secondLevelMenuName == "") {
            breadcrumb = `<h1> <i class="${menuicon} opacity-6"></i>&nbsp;${firstLevelMenuName}</h1>`;
        }
        if (secondLevelMenuName != "") {
            breadcrumb += `<ol class="breadcrumb">
                                <li><a href="javascript:void(0);"><i class="${menuicon}"></i>${firstLevelMenuName}</a></li>
                                <li class="active">${secondLevelMenuName}<li>
                            </ol>`;
        }
        $('#breadcrumb').html("");
        $('#breadcrumb').append(breadcrumb);
    }
}