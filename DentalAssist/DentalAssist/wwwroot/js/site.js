$("#editDentalOperationModal").on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var dentalOperation = button.data('whatever') // Extract info from data-* attributes

    var modal = $(this)
    $("#notes").val(dentalOperation.Notes)
})