
var link = [];
var i = 1;
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/",
    success: function (hasil) {
        var dataPokemon = [];

        $.each(hasil.results, function (key, val) {
            dataPokemon.push(`<tr>
                                <td>${key+1}</td>
                                <td>${val.name}</td>
                                <td><button onclick="detailPokemon('${val.url}');" type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">Detail <i class="fa fa-info"></i></button></td>
                              </tr>`);
            $('#tabelPokemon').html(dataPokemon);
        });
    }
})


function detailPokemon(url) {
    console.log(url);
    $.ajax({
        url: url,
        success: function (data) {
            console.log(data);
            var gambarPokemon = "";
            var namaPokemon = "";
            var heightPokemon = "";
            var weightPokemon = "";
            var abilityPokemon = [];
            var typePokemon = [];
            $.each(data, function (k, v) {
                gambarPokemon = `<img class="card-img" src="${data.sprites.other.home.front_default}"/>`;
                namaPokemon = data.name;
                heightPokemon = `${data.height} Ft`;
                weightPokemon = `${data.weight} Lbs`;
            });
            for (var i = 0; i < data.abilities.length; i++) {
                abilityPokemon.push(`${data.abilities[i].ability.name}<br>`);
            }
            for (var i = 0; i < data.types.length; i++) {
                if (data.types[i].type.name == 'poison') {
                    typePokemon.push(`<a href="#" class="btn btn-poison btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'grass') {
                    typePokemon.push(`<a href="#" class="btn btn-grass btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'fire') {
                    typePokemon.push(`<a href="#" class="btn btn-danger btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'normal') {
                    typePokemon.push(`<a href="#" class="btn btn-normal btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'flying') {
                    typePokemon.push(`<a href="#" class="btn btn-flying btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'bug') {
                    typePokemon.push(`<a href="#" class="btn btn-bug btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else if (data.types[i].type.name == 'water') {
                    typePokemon.push(`<a href="#" class="btn btn-water btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
                else {
                    typePokemon.push(`<a href="#" class="btn btn-succes btn-icon-split"><span class="icon text-white-50"><i class="fas fa-plus"></i></span><span class="text">${data.types[i].type.name}</span></a>`);
                }
            }
            console.log(typePokemon);
            $('#namaPokemon').html(namaPokemon);
            $('#gambarPokemon').html(gambarPokemon);
            $('#heightPokemon').html(heightPokemon);
            $('#weightPokemon').html(weightPokemon);
            $('#abilityPokemon').html(abilityPokemon);
            $('#typePokemon').html(typePokemon);
        }
    })
}

$(document).ready(function () {
    $('#tabelPoke').DataTable();
});


