document.getElementById("ganti-warna").addEventListener('click', ubahwarna)
document.getElementById("reset-warna").addEventListener('click', resetwarna)
function ubahwarna() {
    var bg_warna = document.getElementById("warna-bg");
    bg_warna.style.backgroundColor = 'yellow';
    bg_warna.style.color = 'darkblue';
};
function resetwarna() {
    var bg_reset = document.getElementById("warna-bg");
    bg_reset.style.backgroundColor = 'blue';
    bg_reset.style.color = 'white';
};

// jquery
$('#ubah-font').change(function () {
    $('#font').css("font-family", $(this).val());
});

function alert() {
    swal.fire(
        'hore berhasil :)',
        'akhrinya berhasil juga',
        'success'
    )
}

const hitung1 = (num1, num2) => num1 + num2;
const hitung2 = (num1, num2) => {
    const hasil = num1 + num2;
    return hasil;
}

console.log(hitung1(12, 14));
console.log(hitung2(12, 14));

const animals = [
    { name: 'Nemo', species: 'fish', class: { name: 'invertebrata' } },
    { name: 'Simba', species: 'Cat', class: { name: 'Mamalia' } },
    { name: 'Dory', species: 'fish', class: { name: 'invertebrata' } },
    { name: 'Panther', species: 'Cat', class: { name: 'Mamalia' } },
    { name: 'Budi', species: 'Cat', class: { name: 'Mamalia' } }
]

/*Tugas 1*/
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == 'fish') {
        animals[i].class.name = 'Pisces';     
    }
}

console.log(animals);

/*Tugas 2*/
const iniKucing = [];
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == 'Cat') {
        iniKucing.push(animals[i]);
    }
}
console.log(iniKucing);

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


