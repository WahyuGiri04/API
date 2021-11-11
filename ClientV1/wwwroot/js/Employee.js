$(document).ready(function () {
    var tabel = $('#tabelEmployee').DataTable({
        'ajax': {
            'url': "https://localhost:44364/API/Employees/",
            'dataType': 'json',
            'dataSrc': 'result'
        },
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        'columnDefs': [{

            'targets': [6], /* column index */

            'orderable': false, /* true or false */

        }],
        'columns': [
            {
                "data": "nik"
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
                    var date = row['birthDate'].substr(0, 10);
                    return date;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['phone'].search(0) == 0) {
                        return row['phone'].replace('0', '+62');
                    } else {
                        return '+62' + row['phone'];
                    }
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var angka = row['salary'];
                    var reverse = angka.toString().split('').reverse().join(''),
                        ribuan = reverse.match(/\d{1,3}/g);
                    ribuan = ribuan.join('.').split('').reverse().join('');
                    return 'Rp. ' + ribuan;
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
                    var btn = '<button onclick="Delete(' + row['nik'] + ');" class="btn btn-danger btn-circle"><i class="fa fa-trash"></i></button><button onclick="Get(' + row['nik'] + ');" id="btnEdit" data-toggle="modal" data-target="#formEdit" class="btn btn-warning btn-circle"><i class="fa fa-exclamation-triangle"></i></button>';
                    return btn;
                }
            }
        ],
        buttons: [
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: ' fa fa-download btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6]
                }
            }
        ],
    });

    $("#exportExcel").on('click', function (e) {
        tabel.buttons('.buttons-excel').trigger();
    });

    $("#EmployeeForm").validate({
        rules: {
            "NIK": {
                required: true
            },
            "firstName": {
                required: true
            },
            "lastName": {
                required: true
            },
            "birthDate": {
                required: true
            },
            "phone": {
                required: true
            },
            "salary": {
                required: true
            },
            "email": {
                required: true,
                email: true
            },
            "gender": {
                required: true,
            },
            "degree": {
                required: true
            },
            "GPA": {
                required: true
            },
            "role": {
                required: true
            },
            "university": {
                required: true
            },
            "password": {
                required: true
            }
        },
        errorPlacement: function (error, element) { },
        highlight: function (element) {
            $(element).closest('.form-control').addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).closest('.form-control').removeClass('is-invalid');
            $(element).closest('.form-control').addClass('is-valid ');
        }
    });

    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        if ($("#EmployeeForm").valid() == true) {
            Insert();
        }
    });

    $('#btnEdit').click(function (e) {
        Edit();
    })

    $("#NIK").keypress(function (data) {
        if (data.which != 8 && data.which != 0 && (data.which < 48 || data.which > 57)) {
            $('#NIK').addClass('is-invalid');
            $("#pesanNik").html("Nik Harus Berupa Angka !!!").show();
            return false;
        }
        else {
            $('#inputNik').css('border-color', 'Green');
            $("#pesanNik").hide();
            return true;
        }
    });
});


// get university
$.ajax({
    url: "https://localhost:44364/API/University",
    success: function (result) {
        var univ = [`<option value="">Choose...</option>`];
        var data = result.result.length;
        for (var i = 0; i < data; i++) {
            univ.push(`<option value="${result.result[i].universityId}">${result.result[i].name}</option>`);
        }
        $('#university').html(univ);
    }
})

// get role
$.ajax({
    url: "https://localhost:44364/API/Roles",
    success: function (result) {
        var role = [`<option value="">Choose...</option>`];
        var data = result.result.length;
        for (var i = 0; i < data; i++) {
            role.push(`<option value="${result.result[i].roleId}">${result.result[i].roleName}</option>`);
        }
        $('#role').html(role);
    }
})

function Insert() {

    var obj = new Object();

    obj.NIK = $("#NIK").val();
    obj.FirstName = $("#firstName").val();
    obj.LastName = $("#lastName").val();
    obj.Phone = $("#phone").val();
    obj.BirthDate = $("#birthDate").val();
    obj.Salary = $("#salary").val();
    obj.Gender = $("#gender").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.Degree = $("#degree").val();
    obj.GPA = $("#GPA").val();
    obj.UniversityId = $("#university").val();
    obj.RoleId = $("#role").val();

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
        $("#tambahData").modal("hide");
    }).fail((error) => {
        swal.fire(
            'Gagal :(',
            `${error.responseJSON.messege}`,
            'error'
        )
    })
}

function Get(nik) {
    $.ajax({
        url: "https://localhost:44364/API/employees/" + nik,
        success: function (result) {
            $('#eNIK').val(result.data.nik);
            $('#eFirstName').val(result.data.firstName);
            $('#eLastName').val(result.data.lastName);
            $('#ePhone').val(result.data.phone);
            var tanggal = result.data.birthDate.substr(0, 10);
            $('#eBirthDate').val(tanggal);
            $('#eSalary').val(result.data.salary);
            $('#eEmail').val(result.data.email);
            if (result.data.gender === "Male") {
                $('#eGender').val(0);
            } else {
                $('#eGender').val(1);
            }
        }
    })
}

function Edit() {

    var nik = $("#eNIK").val();
    var obj = new Object();

    obj.NIK = $("#eNIK").val();
    obj.FirstName = $("#eFirstName").val();
    obj.LastName = $("#eLastName").val();
    obj.Phone = $("#ePhone").val();
    obj.BirthDate = $("#eBirthDate").val();
    obj.Salary = $("#eSalary").val();
    obj.Gender = $("#eGender").val();
    obj.Email = $("#eEmail").val();

    $.ajax({
        url: "https://localhost:44364/API/Employees/" + nik,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'PUT',
        'data': JSON.stringify(obj),
        'dataType': 'json'
    }).done((result) => {
        console.log(result);
        swal.fire(
            'hore berhasil :)',
            `${result.messege}`,
            'success'
        );
        $('#tabelEmployee').DataTable().ajax.reload();
        $("#formEdit").modal("hide");
    }).fail((error) => {
        console.log(error);
        swal.fire(
            'Gagal :(',
            `${error.messege}`,
            'error'
        )
    })
}

function Delete(nik) {

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#55B354',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "https://localhost:44364/API/Employees/Hapus?nik=" + nik,
                type: "Delete"
            }).then((result) => {
                if (result.status == 200) {
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                    $('#tabelEmployee').DataTable().ajax.reload();
                } else {
                    Swal.fire(
                        'Error!',
                        'Gagal Hapus',
                        'error'
                    )
                }
            })
        }
    })
}