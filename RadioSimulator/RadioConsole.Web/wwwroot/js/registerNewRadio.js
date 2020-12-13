document.forms[0].onsubmit = () => {
    let formData = new FormData(document.forms[0]);
    let alertEl = document.getElementById('success-alert');
    let errorEl = document.getElementById('error-alert');
    fetch('/Radio/Register', {
        method: 'POST',
        body: new URLSearchParams(formData)
    })
        .then(() => {
            alertEl.style.display = 'flex';
        })
        .catch(() => {
            errorEl.style.display = 'flex';
        });
    return false;
};
//$("#formdata").submit(function (e) {
//    let alertEl = $('success-alert');
//    let errorEl = $('error-alert');
//    e.preventDefault();
//    var form = $(this);
//    $.ajax(
//        {
//            type: "POST",
//            url: "/Radio/Register",
//            data: form.serialize(),
//            success: () => { alertEl.style.display = 'flex'; },
//            error: () => { errorEl.style.display = 'flex'; }
//        });
//});