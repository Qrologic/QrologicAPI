var setting =
{
    GetMemberBankList: function (area) {
        table.BindPostTable(`/` + area + `/Settings/GetMemberBankList`, 'myTable');
    },
    MemberBankPopup: function (id, area) {
        ajax.doGetAjax(`/` + area + `/Settings/AddMemberBank?id=` + id, function (result) {
            $(`#model_body`).html('');
            $.when($(`#model_body`).html(result))
                .then(function () {
                    utility.GetBank(area);
                })
                .then(function () {
                    setTimeout(function () {
                        if (id == 0) {
                            $(`#modeltitle`).text('Add Bank');
                        }
                        else {
                            $(`#modeltitle`).text('Update Bank')
                            $("#BankId").val($("#hdnBankId").val());
                        }
                        common.LoadModelValidation();
                    }, 500);
                });
        });
    },
    DeleteMemberBank: function (id,area) {
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
                ajax.doGetAjax(`/` + area + `/Settings/DeleteMemberBank?id=` + id, function (result) {
                    if (result.status);
                    {
                        toastMeaasage('success', result.message);
                        table.BindPostTable(`/` + area + `/Settings/GetMemberBankList`, 'myTable');
                    }
                });
            }
        });
    },
    IsActiveMemberBank: function (id,area) {
        ajax.doGetAjax(`/` + area + `/Settings/ActiveMemberBank?id=` + id, function (result) {
            if (result.status);
            {
                toastMeaasage('success', result.message);
                table.BindPostTable(`/` + area + `/Settings/GetMemberBankList`, 'myTable');
            }
        });

    },
    CompanyPopup: function (area) {
        ajax.doGetAjax(`/` + area + `/Settings/GetCompany`, function (result) {
            $(`#modeltitle`).text('Company Detail');
            $(`#model_body`).html('');
            $(`#model_body`).html(result);
            common.LoadModelValidation();
        });
    },

}