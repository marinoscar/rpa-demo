var mainApp = {
    onRegister: function () {
        window.location.href = './success.html';
    },
    onCancel: function () {
        window.location.href = './failed.html';
    }
}

$(document).ready(function () {
    $('#btn-register').on('click', function () {
        mainApp.onRegister();
    });
    $('#btn-cancel').on('click', function () {
        mainApp.onCancel();
    });
});