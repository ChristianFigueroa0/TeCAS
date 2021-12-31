/**
 * Customer module
 * */
var customer = customer || (function () {
    /**
     * Send request to server to get view with form to create customer
     * */
    function newCustomer() {
        fetch("/customer/add")
            .then(async (response) => {
                if (response.ok) {
                    var htmlResponse = await response.text();
                    document.querySelector('#js-modal-container').innerHTML = htmlResponse;
                    $('.modal').modal("show");
                    $.validator.unobtrusive.parse(document.querySelector('#js-customer-form'));
                    document.querySelector('#js-save-customer').addEventListener("click", saveCustomer);
                }
            });
    }
    /**
     * Send request to server to store a new customer
     * */
    function saveCustomer() {
        let form = document.querySelector('#js-customer-form');
        if (!$(form).valid())
            return;
        fetch('/customer/add', {
            method: "POST",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: $('#js-customer-form').serialize()
        })
            .then(async response => {
                if (response.ok) {
                    var customerId = await response.text();
                    window.location = `/savingaccount/${customerId}`;
                }
            });
    }

    /**
     * Initialize module
     * */
    function init() {
        document.querySelector('#js-new-customer').addEventListener("click", newCustomer);
    }

    return {
        init
    }
})();