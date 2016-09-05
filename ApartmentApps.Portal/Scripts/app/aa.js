$(function() {
    $('.modal-link').each(function(index, item) {
        var href = $(item).attr('href');
       // console.log("MODAL LINK", index,  href);
        $(item).click(function() {
            $('#modal').show();
            $('.modal-content').html("<div class='sk-spinner sk-spinner-rotating-plane'></div>");
            $('.modal-content').load(href, function() {
              
                $('#modal').addClass('in');
                $('#modal .close-link').click(function() {
                    $('#modal').hide();
                    $('#modal').removeClass('in');
                });
            });
            return false;
        });
    });
});
