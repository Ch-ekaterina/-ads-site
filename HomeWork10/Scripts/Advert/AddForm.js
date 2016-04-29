$('#addFormButton').on('click', function () {
    var title, desсription;
    title = $('input[name=Title]').val();
    desсription = $('input[name=Desсription]').val();

    if (title.length === 0 || desсription.length === 0) {
        alert("Заполните форму");
        return;
    }

   
    $.ajax({
        url: '/advert/add',
        type: 'POST',
        data: {
            Title: title,
            Desсription: desсription
        }
    }).done(function (response) {
        
        if (response.IsSuccess) {
            alert("Успешно добавили.");

            location.href = "/advert/view/" + response.AdvertId;

        } else {
            alert("Все плохо");
        }
    });


});