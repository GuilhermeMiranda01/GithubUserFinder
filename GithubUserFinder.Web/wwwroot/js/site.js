var firstSearch = true;

$('#search-button').click(function () {
    var username = $('#name');
    $('#error-message').hide();

    if (!isValidInput(username.val())) {
        username.css("border-color", "red");
        $('#error-text').show();
        return;
    } else {
        username.css("border-color", "black");
        $('#error-text').hide();
    }


    $.ajax({
        url: "Home/GetUserByUsername",
        method: "GET",
        data: { username: username.val() },
        success: function (data) {

            if (firstSearch) {
                $('#github-initial').fadeOut(300, function () {
                    $('#user-info').html(data);
                    $('#user-info').fadeIn(300);
                });
                firstSearch = false;
            }

            else {
                $('#user-info').fadeOut(300, function () {
                    $('#user-info').html(data);
                    $('#user-info').fadeIn(300);
                });
            }
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
})

$('#name').keypress(function (e) {
    var key = e.which;
    if (key == 13) {
        $('#search-button').click();
        return false;
    }
});


function isValidInput(input) {
    return input && input.trim()
}