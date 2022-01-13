function OnBegin() {
    common.ShowLoader();
}

function OnFailure(response) {
    toastMeaasage("error", "Error occured.")
}
function OnSuccess(response) {  
    if (response.status) {
        $.when(toastMeaasage("success", response.message)).then(function () {
            if (response.isRedirect) {
                setTimeout(function () {
                    location.replace(response.redirectUrl);
                }, 2000);
            }
            else {                
                common.CloseModal();
                if (response.isPost) {
                    table.BindPostTable(response.redirectUrl, 'myTable');
                }
                else {
                    table.BindTable(response.redirectUrl, 'myTable');
                }
                
            }
        });       
    }
    else {
        toastMeaasage("error", response.message)
    }
}
function OnComplete() {
    common.HideLoader();
}