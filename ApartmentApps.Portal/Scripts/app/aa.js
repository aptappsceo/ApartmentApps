
/*
AA Modal AutoForm controller
See usage in AutoForm.cshtml

*/

(function() {

    $('.row').on("click", ".modal-link", function (event) {
        event.preventDefault();
        event.stopPropagation();
        var href = $(this).attr('href');
        AAControls.ModalForm.loadForm(href);
    });

    var controls = window.AAControls;
    if (!controls) controls = window.AAControls = {};

    function ModalFormController() {

        var that = this;

        this.modalId = "#modal";
        this.loadingContent =
            "<div style='height: 200px;padding-top: 70px;'>" +
                "<div class='sk-spinner sk-spinner-wave'>" +
                            "<div class='sk-rect1'></div> " +
                            "<div class='sk-rect2'></div> " +
                            "<div class='sk-rect3'></div> " +
                            "<div class='sk-rect4'></div> " +
                            "<div class='sk-rect5'></div>" +
                "</div>" +
            "<h2 style='margin-top: 30px' class='text-muted text-center'>Please, wait...</h2>" +
            "</div>";
        this.$modal = $('#modal');

        this.$modalContent = $('#modal .modal-content');

        this.$modal.on("click", ".close-link", function () {
            that.close();
        });


        this.close = function() {
            that.$modal.removeClass('in');
            that.$modal.modal('hide');
        }

        this.loadForm = function (href) {

            that.$modal.modal({
                backdrop: true,
                keyboard: true
            });

            that.setLoading();

            $.ajax({
                type: "GET",
                url: href,
                success: function (msg) {
                    that.$modal.removeClass('in');
                    that.$modalContent.html(msg);
                },
                error: function () {
                    alert("Unable to load form: " + href);
                    that.close();
                }
            });

        }

        this.onContentLoaded = function(formId, postUrl, submitButtonId) {
            $("#" + submitButtonId).click(function (e) {
                event.preventDefault();
                event.stopPropagation();
                that.sendForm(formId, postUrl);
            });

        }

        this.setLoading = function()
        {
            that.setContent(this.loadingContent);
        }
        

        this.sendForm = function(formId, postUrl) {

            var form = $("#" + formId);
            var serialize = form.serialize();
            that.setLoading();
            $.ajax({
                type: "POST",
                url: postUrl, //process to mail
                data: serialize,
                success: function (msg) {
                    if (msg.update) {
                        if (EQ && EQ.view && EQ.view.grid) EQ.view.grid.applyFilter();
                        that.close(); //be friendly and show message
                    } else if (msg.redirect) {
                        window.location = msg.redirect;
                    } else
                    {
                        that.setContent(msg);
                        //you can show other stuff
                    }

                },
                error: function (msg) {
                    that.setContent(msg.responseText);
                }
            });

        }

        this.setContent = function(html) {
            that.$modalContent.html(html);
            that.$modal.modal('handleUpdate')
        }


    };

    controls.ModalForm = new ModalFormController();

})();

