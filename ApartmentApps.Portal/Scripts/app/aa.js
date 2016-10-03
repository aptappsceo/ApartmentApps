
$('.row').on("click", ".modal-link", function (event) {
    event.preventDefault();
    event.stopPropagation();

    // console.log("MODAL LINK", index,  href);

    var href = $(this).attr('href');
    $('#modal').show();
    $('.modal-content').html("<div class='sk-spinner sk-spinner-rotating-plane'></div>");
    $('.modal-content').load(href, function () {
      
        $('#modal').addClass('in');
        $('#modal .close-link').click(function () {
            $('#modal').hide();
            $('#modal').removeClass('in');
        });
    });

});

