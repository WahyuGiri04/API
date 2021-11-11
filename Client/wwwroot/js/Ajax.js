$.ajax({
    url: "https://swapi.dev/api/people/",
    success: function (hasil) {
        console.log(hasil.results);
        var listOrang = "";
        $.each(hasil.results, function (key, val) {
            listOrang += `<tr>
                            <td>${key + 1}</td>
                            <td>${val.name}</td>
                            <td>${val.height} cm</td>
                            <td>${val.mass} Kg</td>
                            <td>${val.gender}</td>
                            <td><button onclick="alertData('${val.url}');" class="tombol btn btn-success text-center"> Detail <i class="fa fa-info"></i></button></td>
                          </tr>`;
        });
        $('#tabelOrang').html(listOrang);
    }
})
function alertData(url) {
    Swal.fire(
        'Hore Berhasil :)',
        url,
        'success'
    )
}