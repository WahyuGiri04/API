var link = [];
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/",
    success: function (hasil) {
        var dataPokemon = [];
        var key = [];
        var name = [];
        var foto = [];
        var linkPoke = [];

        $.each(hasil.results, function (key, val) {
            link.push(val.url);
            $.ajax({
                url : val.url,
                success: function (foto) {
                    dataPokemon.push( `<tr>
                                <td>${foto.order}</td>
                                <td>${val.name}</td>
                                <td><img src="${foto.sprites.front_default}" alt="" class="img-thumbnail"></td>
                                <td><button onclick="detailPokemon('${val.url}');" type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">Detail <i class="fa fa-info"></i></button></td>
                              </tr>`);
                    $('#tabelPokemon').html(dataPokemon);
                }
            })
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
                    typePokemon.push(`<span class="badge badge-poison"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'grass'){
                    typePokemon.push(`<span class="badge badge-grass"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'fire') {
                    typePokemon.push(`<span class="badge badge-danger"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'normal') {
                    typePokemon.push(`<span class="badge badge-normal"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'flying') {
                    typePokemon.push(`<span class="badge badge-flying"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'bug') {
                    typePokemon.push(`<span class="badge badge-bug"> ${data.types[i].type.name}</span>`);
                }
                else if (data.types[i].type.name == 'water') {
                    typePokemon.push(`<span class="badge badge-water"> ${data.types[i].type.name}</span>`);
                }
                else {
                    typePokemon.push(`<span class="badge badge-succes"> ${data.types[i].type.name}</span>`);
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