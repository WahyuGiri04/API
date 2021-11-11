
$(document).ready(function () {
    $('#tabelEmployee').DataTable({
        'ajax': {
            'url': "https://localhost:44364/API/Employees/",
            'dataType' : 'json',
            'dataSrc' : 'result'
        },
        'columnDefs': [{

            'targets': [6], /* column index */

            'orderable': false, /* true or false */

        }],
        'columns': [
            {
                "data" : "nik"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + ' ' + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['phone'].search(0) == 0) {
                        return row['phone'].replace('0', '+62');
                    } else {
                        return row['phone'];
                    }
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return 'Rp. ' + row['salary'];
                }
            },
            {
                "data": "gender"
            },
            {
                "data": "email"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var button = '<button onclick="deleteData(' + row['nik'] + ');" class="tombol btn btn-danger text-center" data-toggle="modal" data-target="#myModal"> Delete <i class="fa fa-trash"></i></button>';
                    return button;
                }
            }
        ]
    });
});

$.ajax({
    url: "https://localhost:44364/API/University",
    success: function (result) {
        var univ = [];
        var data = result.result.length;
        console.log(data);
        for (var i = 0; i < data; i++) {
            univ.push(`<option value="${result.result[i].universityId}">${result.result[i].name}</option>`);
        }
        $('#inputUniversity').html(univ);
    }
})

$.ajax({
    url: "https://localhost:44364/API/Roles",
    success: function (result) {
        var role = [];
        var data = result.result.length;
        console.log(data);
        for (var i = 0; i < data; i++) {
            role.push(`<option value="${result.result[i].roleId}">${result.result[i].roleName}</option>`);
        }
        $('#inputRole').html(role);
    }
})

function alert() {
    swal.fire(
        'hore berhasil :)',
        'akhrinya berhasil juga',
        'error'
    )
}

$(document).ready(function () {
    $("#inputNik").keypress(function (data) {
        if (data.which != 8 && data.which != 0 && (data.which < 48 || data.which > 57)) {
            $('#inputNik').css('border-color', 'Red');
            $("#pesanNik").html("Nik Harus Berupa Angka !!!").show();
            return false;
        }
        else {
            $('#inputNik').css('border-color', 'Green');
            $("#pesanNik").hide();
            return true;
        }
    });

    //$("#formEmployee").validate({
    //    rules: {
    //        "inputNik": {
    //            required: true
    //        },
    //        "inputFirstName": {
    //            required: true
    //        },
    //        "inputLastName": {
    //            required: true
    //        }
    //    },
    //    errorPlacement: function (error, element) { },
    //    highlight: function (element) {
    //        $(element).closest('.form-control').addClass('is-invalid');
    //    },
    //    unhighlight: function (element) {
    //        $(element).closest('.form-control').removeClass('is-invalid');
    //    }
    //});
});

function Insert() {

    $(document).ready(function () {
        $("#formEmployee").validate({
            rules: {
                'inputNik': {
                    required: true
                }
            },
            errorPlacement: function (error, element) { },
            highlight: function (element) {
                $(element).closest('.form-control').addClass('is-invalid');
            },
            unhighlight: function (element) {
                $(element).closest('.form-control').removeClass('is-invalid');
            }
        });
    });

    //if ($('#inputNik').val() == "") {
    //    $('#inputNik').css('border-color', 'Red');
    //    return false;
    //}if ($('#inputFirstName').val() == ""){
    //    $('#inputFirstName').css('border-color', 'Red');
    //    return false;
    //}
    //else {
        var obj = new Object();

        obj.NIK = $("#inputNik").val();
        obj.FirstName = $("#inputFirstName").val();
        obj.LastName = $("#inputLastName").val();
        obj.Phone = $("#inputPhone").val();
        obj.BirthDate = $("#inputBirthdate").val();
        obj.Salary = $("#inputSalary").val();
        obj.Gender = $("#inputGender").val();
        obj.Email = $("#inputEmail").val();
        obj.Password = $("#inputPassword").val();
        obj.Degree = $("#inputDegree").val();
        obj.GPA = $("#inputGPA").val();
        obj.UniversityId = $("#inputUniversity").val();
        obj.RoleId = $("#inputRole").val();

        console.log(obj);

        $.ajax({
            url: "https://localhost:44364/API/Employees/Register",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'type': 'POST',
            'data': JSON.stringify(obj),
            'dataType': 'json'
        }).done((result) => {
            swal.fire(
                'hore berhasil :)',
                'akhrinya berhasil juga',
                'success'
            );
            $('#tabelEmployee').DataTable().ajax.reload();
        }).fail((error) => {
            swal.fire(
                'Gagal :(',
                `${error.responseJSON.messege}`,
                'error'
            )
        })
    //}  
}



