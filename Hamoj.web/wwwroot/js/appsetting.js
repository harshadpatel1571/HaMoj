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
