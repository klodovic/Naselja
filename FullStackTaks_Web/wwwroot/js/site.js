$(document).ready(function () {
    $(".edit-btn").click(function () {
        let id = $(this).data("id");
        let naziv = $(this).data("naziv");
        let postanskiBroj = $(this).data("postanskibroj");
        let drzava = $(this).data("drzava");

        $("#naseljeId").val(id);
        $("#naziv").val(naziv);
        $("#postanskiBroj").val(postanskiBroj);
        $("#drzava").val(drzava);
    });

    $("#editNaseljeForm").submit(function (e) {
        e.preventDefault();

        let updatedNaselje = {
            Id: $("#naseljeId").val(),
            Naziv: $("#naziv").val(),
            PostanskiBroj: $("#postanskiBroj").val(),
            Drzava: { Naziv: $("#drzava").val() }
        };

        $.ajax({
            url: "/Home/Update",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(updatedNaselje),
            success: function (response) {
                location.reload(); // Osvježi stranicu nakon uspješnog ažuriranja
            },
            error: function () {
                alert("Greška prilikom spremanja.");
            }
        });
    });
});

