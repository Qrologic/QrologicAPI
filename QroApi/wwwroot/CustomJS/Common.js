var ajax = {
    doPostAjax: function (url, data, callback) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            success: function (result) {
                return callback(result);
            }
        });
    },
    doGetAjax: function (url, callback) {
        $.ajax({
            type: 'Get',
            url: url,
            success: function (result) {
                return callback(result);
            }
        });
    },
    AjaxPost: function (url, data, callback) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                return callback(result);
            }
        });
    },

}
var common = {
    isNumberKey: function (evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    },
    SelectAllCheckBox: function (id) {
        var checked = $(`#` + id).prop(`checked`);
        $('input[type=checkbox]').each(function () {
            if (checked) {
                $(this).prop(`checked`, true);
            }
            else {
                $(this).prop(`checked`, false);
            }
        });
    },
    OpenPopup: function () {
        //$(`#exampleModal`).addClass('show');
        $("#exampleModal").modal();

    },
    CloseModal: function () {
        $('#closepopup').trigger("click");
    },

    LoadModelValidation: function () {
        $.validator.unobtrusive.parse("form");
    },
    ChangeUrl: function (controller, action) {

        var new_url = "/" + controller + "/" + action;
        window.history.pushState("data", "Title", new_url);
        document.title = action;

    },
    BindDropdown: function (url, id, select) {
        ajax.doGetAjax(url, function (result) {
            var selectOption = "";

            if (select != undefined) {
                selectOption = select;
            }
            $('#' + id).html("");
            $('#' + id).append('<option value="" selected>Select ' + selectOption + '</option>');
            if (result.status) {

                $(result.results).each(function (index, val) {
                    var opt = new Option(val.name, val.id);
                    $('#' + id).append(opt);
                })
            }
        });
    },

    GetCompanyLogo: function (area, controller) {
        var url = "";
        if (area != "") {
            url = `/${area}/${controller}/GetCompanyLogo`;
        }
        else {
            url = `/${controller}/GetCompanyLogo`;
        }
        ajax.doGetAjax(url, function (result) {
            if (result.status) {
                $(`#company-logo`).removeAttr(`src`);
                $(`#company-logo`).attr(`src`, result.results.companyLogo);
                $(`.company-name`).text(result.results.companyName);
            }
        });


    },
    BindRole: function () {
        ajax.doGetAjax(`/Account/GetRole`, function (result) {

            if (result.status) {
                $('#UserRole').html("");
                $('#UserRole').append('<option value="0" selected>Select Role</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.roleName, val.id);
                    $('#UserRole').append(opt);
                })
            }
        });
    },
    BindPackage: function () {
        ajax.doGetAjax(`/Account/GetPackage`, function (result) {
            if (result.status) {
                $('#PackageId').html("");
                $('#PackageId').append('<option value="0" selected>Select Package</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.packageName, val.id);
                    $('#PackageId').append(opt);
                })
            }
        });
    },
    BindCountry: function () {
        ajax.doGetAjax(`/Account/GetCountry`, function (result) {
            if (result.status) {
                $('#CountryId').html("");
                $('#CountryId').append('<option value="0" selected>Select Country</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.countryName, val.id);
                    $('#CountryId').append(opt);
                });
                common.BindState(0);
            }
        });
    },
    BindState: function (countryId) {
        var data = { "countryId": countryId }
        ajax.doPostAjax(`/Account/GetState`, data, function (result) {
            if (result.status) {
                $('#StateId').html("");
                $('#StateId').append('<option value="0" selected>Select State</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.stateName, val.id);
                    $('#StateId').append(opt);
                });
                common.BindCity(0);
            }
        });
    },
    BindCity: function (stateId) {
        var data = { "stateId": stateId }
        ajax.doPostAjax(`/Account/GetCity`, data, function (result) {
            if (result.status) {
                $('#CityId').html("");
                $('#CityId').append('<option value="0" selected>Select City</option>');
                $(result.results).each(function (index, val) {
                    var opt = new Option(val.cityName, val.id);
                    $('#CityId').append(opt);
                })
            }
        });
    },
    ShowLoader: function () {
        //$('#cover-spin').show(0);
        $('#cover-spin').css("display", "block");
    },
    HideLoader: function () {
        //$('#cover-spin').hide(0);
        $('#cover-spin').css("display", "none");
    },
    AddEditLayout: function (item, type, area) {
        debugger;
        if (type == `Side`) {
            var data = { "SidebarClass": $(item).attr(`data-class`), "Type": type }
        }
        if (type == `Top`) {
            var data = { "TopbarClass": $(item).attr(`data-class`), "Type": type }
        }
        ajax.doPostAjax(`/` + area + `/Home/AddEditLayout`, data, function (result) {
            if (result.status) {

            }
        });
    },
    GetLayout: function (area) {
        ajax.doGetAjax(`/` + area + `/Home/GetLayout`, function (result) {
            if (result.status) {
                $(`.app-header`).addClass(result.results.topbarClass);
            }
        });
    },
    Filter: function (area, controller, action, data, tblId, IsButtonClick = 0) {

        var start;
        var end;
        start = moment().subtract(29, 'days');
        end = moment();
        function cb(start, end) {
            if (IsButtonClick == 0) {
                $('#reportrange span').html(start.format('MMM D, YYYY') + ' - ' + end.format('MMM D, YYYY'));
                data["fromDate"] = start.format('D-MMM-YYYY');
                data["toDate"] = end.format('D-MMM-YYYY');
            }
            table.BindPostTable(`/${area}/${controller}/${action}`, tblId, data);
        }
        $('#reportrange').daterangepicker({
            startDate: start,
            endDate: end,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            },

        }, cb);
        cb(start, end);
    },
    printDiv: function (divId) {
        var printContents = document.getElementById(divId).innerHTML;
        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;

        window.print();

        document.body.innerHTML = originalContents;
    }
}

var SweetAlert = {
    SwalSuccessAlert: function (title, text, showCancelButton, confirmButtonText, allowOutsideClick) {
        Swal.fire({
            title: title,
            text: text,
            icon: 'success',
            showCancelButton: showCancelButton,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: confirmButtonText,
            allowOutsideClick: allowOutsideClick
        })
    },
    SwalAlert: function (title, text, icon, showCancelButton, confirmButtonColor, cancelButtonColor, confirmButtonText, allowOutsideClick) {
        Swal.fire({
            title: title,
            text: text,
            icon: icon,
            showCancelButton: showCancelButton,
            confirmButtonColor: confirmButtonColor,
            cancelButtonColor: cancelButtonColor,
            confirmButtonText: confirmButtonText,
            allowOutsideClick: allowOutsideClick
            //title: 'Are you sure?',
            //text: "You won't be able to revert this!",
            //icon: 'warning',
            //showCancelButton: true,
            //confirmButtonColor: '#3085d6',
            //cancelButtonColor: '#d33',
            //confirmButtonText: 'Yes, delete it!',
            //allowOutsideClick: false
        })
    },

}

