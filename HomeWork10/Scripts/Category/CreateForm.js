$('#createFormButton').on('click', function() {
    var сategoryValue;
    title = $('input[name=Title]').val();
    if (title.length === 0) {
        alert("Введите название категории");
        return;
    }


    $.ajax({
        url: '/Category/Create',
        type: 'POST',
        data: {
            Category: сategoryValue
        }
    }).done(function(response) {
        if (response.IsSuccess) {
            alert('Успешно добавлено');

            location.href = "/Category/Create";

        } else {
            alert('Не добавлено');

        }
    });
});