function BindGrid(pURL, pColumns, pdfColumn, excelColumn, printColumn, isPaging = true, isSearching = true) {
    $('#dataGrid').DataTable().destroy();
    $('#dataGrid').DataTable({
        paging: isPaging,
        lengthChange: true,
        searching: isSearching,
        ordering: true,
        lengthMenu: [[10, 25, 50, 75, 100, 250], [10, 25, 50, 75, 100, 250]],
        info: true,
        autoWidth: true,
        responsive: true,
        processing: true,
        filter: true,
        ajax: pURL,
        columns: pColumns,
    });

    restrictSearchFilter();
}

function restrictSearchFilter() {
    const table = $('#dataGrid').DataTable();
    $('.dataTables_filter input')
        .unbind()
        .bind('input', function (e) {
            if (this.value.length >= 3 || e.keyCode === 13) {
                table.search(this.value).draw();
            }
            if (this.value === "") {
                table.search("").draw();
            }
        });
}

function toaster(type, message) {

    var options = {
        timeOut: 1000,
        closeButton: !0,
        debug: !1,
        newestOnTop: !0,
        progressBar: !0,
        positionClass: "toast-top-right",
        preventDuplicates: !0,
        onclick: null,
        showDuration: "300",
        hideDuration: "1000",
        extendedTimeOut: "1000",
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut",
        tapToDismiss: !1
    };

    switch (type) {
        case 'success':
            toastr.success(message, "Success", options);
            break;
        case 'warning':
            toastr.warning(message, "Warning", options);
            break;
        case 'error':
            toastr.error(message, "Error", options);
            break;
        default:
            toastr.info(message, "Info", options);
    }
}

//// Example usage:
//toaster('success', 'This is a success message');
//toaster('warning', 'This is a warning message');
//toaster('error', 'This is an error message');

function BindGridWithFilter(pURL, pColumns, isPaging = true, isSearching = true, pSearch = null, pfooterCallback = null, pName = 'grid') {
    $(`#${pName}`).DataTable().destroy();
    $(`#${pName}`).DataTable({
        paging: isPaging,
        lengthChange: true,
        searching: isSearching,
        ordering: true,
        lengthMenu: [[10, 25, 50, 75, 100, 250], [10, 25, 50, 75, 100, 250]],
        info: false,
        autoWidth: false,
        responsive: false,
        processing: true,
        serverSide: true,
        filter: true,
        ajax: {
            url: pURL,
            type: "POST",
            datatype: "json",
            data: pSearch
        },
        columnDefs: [{
            targets: [0],
            visible: false,
            searchable: false
        }],
        footerCallback: pfooterCallback,
        columns: pColumns,
    });

    restrictSearchFilter();
}