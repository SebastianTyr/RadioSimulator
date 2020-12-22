document.forms[0].onsubmit = function() {
    if ($(this).valid()) {
        let formData = new FormData(document.forms[0]);
        let alertEl = document.getElementById('success-alert');
        fetch('/Radio/Register', {
            method: 'POST',
            body: new URLSearchParams(formData)
        })
            .then(() => {
                alertEl.style.display = 'flex';
            });
    } else {
        let errorEl = document.getElementById('error-alert')
        errorEl.style.display = 'flex';
    }
    return false;
};