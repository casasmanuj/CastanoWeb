$.extend(
    $.fn.dataTable.defaults, {
        "language": {
            "url": "/js/datatables/datatables.json"
        },
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
        dom:
	        "<'row'<'col-sm-4'l><'col-sm-4'f><'col-sm-4'B>>" +
		    "<'row'<'col-sm-12'tr>>" +
		    "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        renderer: 'bootstrap'
    }
);