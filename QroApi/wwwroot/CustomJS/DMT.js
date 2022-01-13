var dmt = {
    ChargePopup: function (id, area) {
        ajax.doGetAjax(`/${area}/Services/AddEditApiSurcharge?id=` + id, function (result) {

            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result)).then(function () {
                utility.GetPackage("Admin", "PackageId");
            }).then(function () {
                setTimeout(function () {
                    dmt.GetAPI(area, 'ApiId');
                    if (id == 0) {
                        $(`#modeltitle`).text('Add New DMT Charge');
                    }
                    else {
                        $(`#modeltitle`).text('Update DMT Charge');
                        var packageId = $("#hdnPackage").val();
                        $(`#PackageId`).val(packageId);
                    }
                    common.LoadModelValidation();
                }, 500);
            }).then(function () {
                if (id != 0) {
                    setTimeout(function () {
                        var apiId = $("#hdnApi").val();
                        $(`#ApiId`).val(apiId);
                    }, 700);
                }
            });
        });
    },
    GetAPI: function (area, ddlId) {
        common.BindDropdown(`/` + area + `/Services/GetAPI`, ddlId, 'API');
    },
    GetApiChagreByApi: function (id, area) {
        ajax.doGetAjax(`/${area}/Services/GetDMTApiChargeByApiId?id=` + id, function (result) {
            $("#tbody-dmt-surcharge").html("");
            $("#tbody-dmt-surcharge").html(result);
        });
    },
    GetApiChargeById: function (id, area) {
        ajax.doGetAjax(`/${area}/Services/GetApiChargeById?id=` + id, function (result) {

            $("#Id").val(result.id);
            $("#ApiId").val(result.apiId);
            $("#FromAmount").val(result.fromAmount);
            $("#ToAmount").val(result.toAmount);
            $("#Surcharge").val(result.surcharge);
            $("#IsFlat").prop("checked", result.isFlat);
            $("#gstRate").val(result.gstRate);
            $("#tdsRate").val(result.tdsRate);
        });
    },

}