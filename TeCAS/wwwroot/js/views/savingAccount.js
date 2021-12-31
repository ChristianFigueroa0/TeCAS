/**
 * Saving account module
 * */
var savingAccount = savingAccount || (function () {

    /**
     * Send request to server to store new saving account
     * */
    function saveSavingAccount() {
        let form = document.querySelector('#js-saving-account-form');
        if (!$(form).valid()) {
            return;
        }
        fetch('/SavingAccount/add', {
            method: "POST",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: $(form).serialize()
        })
            .then(async response => {
                if (response.ok) {
                    var htmlResponse = await response.text();
                    document.querySelector('#js-saving-container').insertAdjacentHTML("beforeend", htmlResponse);
                    $('.modal').modal("hide");
                }
            });
    }

    /**
     * Send request to server to get form to create new saving account
     * */
    function addSavingAccount() {
        fetch(`/savingaccount/${this.dataset.customerId}/add`)
            .then(async (response) => {
                if (response.ok) {
                    var htmlResponse = await response.text();
                    document.querySelector('#js-modal-container').innerHTML = htmlResponse;
                    $('.modal').modal("show");
                    $.validator.unobtrusive.parse(document.querySelector('#js-saving-account-form'));
                    document.querySelector('#js-save-saving-account').addEventListener("click", saveSavingAccount);
                }
            });
    }
    /**
     * Send request to server to get form to create new transaction
     * */
    function addTransaction() {
        const type = this.dataset.type;
        const accountId = this.dataset.accountId;
        fetch(`/savingaccount/${accountId}/transaction/${type}/add`)
            .then(async (response) => {
                if (response.ok) {
                    var htmlResponse = await response.text();
                    document.querySelector('#js-modal-container').innerHTML = htmlResponse;
                    $.validator.unobtrusive.parse(document.querySelector('#js-transaction-form'));
                    $('.modal').modal("show");
                }
            });
    }

    /**
     * Send request to server to store new saving account
     * */   
    function saveTransaction() {
        let form = document.querySelector('#js-transaction-form');
        if (!$(form).valid()) {
            return;
        }
        fetch('/SavingAccount/Transaction/add', {
            method: "POST",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: $(form).serialize()
        })
            .then(async response => {
                if (response.ok) {
                    let amount = await response.text();
                    var accountId = form.querySelector('#AccountId').value;
                    document.querySelector(`.js-account-${accountId} .js-amount-container`).innerHTML = amount;
                    $('.modal').modal("hide");
                }
            });
    }
    /**
     * Module initializer
     * */
    function init() {
        document.querySelector('#js-new-saving-account').addEventListener("click", addSavingAccount);
        $(document).on('click', '.js-add-transaction', addTransaction);
        $(document).on('click', '#js-save-transaction', saveTransaction);
    }
    return {
        init
    }
})();