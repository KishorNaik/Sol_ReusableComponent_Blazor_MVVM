/// <reference path="lib/jquery-3.6.0.min.js" />
export function onCancel() {
    $("#txtUserName").val('');
    $("#txtPassword").val('');

    $("#txtUserName").focus();
}