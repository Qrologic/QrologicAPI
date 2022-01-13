

var user =
{
    GetRagistrationHtml: function () {
        ajax.doGetAjax(`/Register/UserRegistration`, function (result) {
            common.ChangeUrl("Register", "Registration");
            $('#_body').html("");
            $('#_body').html(result);
        });
    },
    Validation: function (callback) {
        var flag = true;
        $('.form-control').each(function () {
            flag = true;
            if ($(this).val() == "" || $(this).val() == "0") {
                           
                $(this).focus();
                toastMeaasage('error', $(this).attr('data-val-required'));             
                flag = false;
                return flag;
            }
        });
        return flag;
    },
    SaveMemberData: function () {
        if (user.Validation()) {
            common.ShowLoader();
            var data = {};
            $(".form-control").each(function () {
                data[`${this.id}`] = $(this).val();
            });

            ajax.doPostAjax(`/Account/MemberRegistration`, data, function (result) {
                common.HideLoader();
                if (result.status) {
                    toastMeaasage('success', result.message)
                    user.EmptyValue();
                }
                else {
                    console.log("hii");
                    toastMeaasage('error', result.message)
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
       
    }


}