
$(document).ready(function () {

    $("#myTable").DataTable();

    $("#cancelButton").click (function () {
        formClear();
        $("#editPanel").addClass("hidden");
        $("#addButton").removeClass("hidden");
    });

    // ADD New Item
    $("#addButton").click(function ()
    {
        $("#AddNew").DataTable({
            "lengthChange": false,
            "searching": false,
            "paging": false
        });

        $("#editPanel").removeClass("hidden");
        $("#addButton").addClass("hidden");
        $("#updateButton").text("Add");
        formClear();
    });

    function formClear() {
        $("#productName").val("");
        $("#productCategory").val("");
        $("#productDescription").val("");
        $("#productYear").val("");
        $("#productPrice").val("");
    }

    // Blur input default value
            $('input.input').on('focus', function () {
                // On first focus, check to see if we have the default text saved
                // If not, save current value to data()
                if (!$(this).data('defaultText')) $(this).data('defaultText', $(this).val());

                // check to see if the input currently equals the default before clearing it
                if ($(this).val() == $(this).data('defaultText')) $(this).val('');
            });
            $('input.input').on('blur', function () {
                // on blur, if there is no value, set the defaultText
                if ($(this).val() == '') $(this).val($(this).data('defaultText'));
            });

});


   
