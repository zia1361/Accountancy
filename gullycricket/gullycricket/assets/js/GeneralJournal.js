
var ENTRY_TEMPLATE = "<tr id='[:Id]'>" +
        "<td>[:ElementType]</td>" +
        "<td>[:Amount]</td>" +
        "<td><a href='javascript:void(0)' onclick='[:fnName](this)' class='btn btn-danger btn-sm' data-bs-toggle='tooltip' data-bs-placement='top' title='Delete'><i class='bi bi-trash'></i></a></td></tr>";

var debitCounter = 0;
var creditCounter = 0;

function AddDebitEntry() {
    var transactionDate = document.getElementById("transactionDate");
    if (transactionDate.value == null || transactionDate.value == "") {
        $('#errorText').text("Kindly select date");
        $('#errorMessage').show(100);
        return false;
    }

    var ElementListDebit = document.getElementById("ElementListDebit");
    if (ElementListDebit.value <= 0) {
        $('#errorText').text("Kindly select financial element type");
        $('#errorMessage').show(100);
        return false;
    }

    var debitAmount = document.getElementById("debitAmount");
    if (debitAmount.value == null || debitAmount.value == "") {
        $('#errorText').text("Kindly provide amount");
        $('#errorMessage').show(100);
        return false;
    }

    var debitList = JSON.parse(document.getElementById("debitList").value);
    console.log(debitList);
    debitList.push({
        Id: debitCounter,
        TypeId: ElementListDebit.value,
        Amount: debitAmount.value
    });
    document.getElementById("debitList").value = JSON.stringify(debitList);
    document.getElementById("debitTbl").innerHTML += ENTRY_TEMPLATE.replace("[:Id]", debitCounter).replace("[:ElementType]", $("#ElementListDebit option:selected").text())
        .replace("[:Amount]", debitAmount.value).replace("[:fnName]", "deleteDebit");
    $('#errorMessage').hide(0);
    ElementListDebit.value = "0";
    debitAmount.value = "";
    debitCounter++;
  


}

function deleteDebit(element) {
    var debitList = JSON.parse(document.getElementById("debitList").value);
    var updatedList = [];
    debitList.forEach((item) => {
        if (item.Id != element.parentElement.parentElement.id) {
            updatedList.push(item);
        }
    });
    element.parentElement.parentElement.remove();
    document.getElementById("debitList").value = JSON.stringify(updatedList);
    console.log(updatedList);
}

function AddCreditEntry() {
    var transactionDate = document.getElementById("transactionDate");
    if (transactionDate.value == null || transactionDate.value == "") {
        $('#errorText').text("Kindly select date");
        $('#errorMessage').show(100);
        return false;
    }

    var ElementListcredit = document.getElementById("ElementListCredit");
    if (ElementListcredit.value <= 0) {
        $('#errorText').text("Kindly select financial element type");
        $('#errorMessage').show(100);
        return false;
    }

    var creditAmount = document.getElementById("creditAmount");
    if (creditAmount.value == null || creditAmount.value == "") {
        $('#errorText').text("Kindly provide amount");
        $('#errorMessage').show(100);
        return false;
    }

    var creditList = JSON.parse(document.getElementById("creditList").value);
    console.log(creditList);
    creditList.push({
        Id: creditCounter,
        TypeId: ElementListcredit.value,
        Amount: creditAmount.value
    });
    document.getElementById("creditList").value = JSON.stringify(creditList);
    document.getElementById("creditTbl").innerHTML += ENTRY_TEMPLATE.replace("[:Id]", creditCounter).replace("[:ElementType]", $("#ElementListCredit option:selected").text())
        .replace("[:Amount]", creditAmount.value).replace("[:fnName]", "deleteCredit");
    $('#errorMessage').hide(0);
    ElementListcredit.value = "0";
    creditAmount.value = "";
    creditCounter++;



}

function deleteCredit(element) {
    var creditList = JSON.parse(document.getElementById("creditList").value);
    var updatedList = [];
    creditList.forEach((item) => {
        if (item.Id != element.parentElement.parentElement.id) {
            updatedList.push(item);
        }
    });
    element.parentElement.parentElement.remove();
    document.getElementById("creditList").value = JSON.stringify(updatedList);
    console.log(updatedList);
}

function VerifyEntry() {
    var transactionDate = document.getElementById("transactionDate");
    if (transactionDate.value == null || transactionDate.value == "") {
        $('#errorText').text("Kindly select date");
        $('#errorMessage').show(100);
        return false;
    }

    var creditList = JSON.parse(document.getElementById("creditList").value);
    var debitList = JSON.parse(document.getElementById("debitList").value);
    var creditSum = 0;
    creditList.forEach((item) => {
        creditSum += Number(item.Amount);
    });
    var debitSum = 0;
    debitList.forEach((item) => {
        debitSum += Number(item.Amount);
    });
    console.log(debitSum);
    console.log(creditSum);
    if (creditSum == debitSum) {
        return true;
    } else {
        $('#errorText').text("Debit and Credit should be equal");
        $('#errorMessage').show(100);
        return false;
    }
    return false;
}