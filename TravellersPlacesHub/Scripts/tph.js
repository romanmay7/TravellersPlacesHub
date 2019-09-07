$(function () {


    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()//data to post to the server
        };
        //making an asynchronous call to the server
        //passing to it a callback function object ,which will be called
        //with data recieved from the server
        //after recieving a response from a server
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-tph-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");//make an effect on the replaced data
        });

        return false;
    };

    var submitAutocompleteForm = function (event, ui) {
        var $input=$(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();

    };
        var createAutocomplete = function () {
            var $input = $(this);
            var options = {
                source: $input.attr("data-tph-autocomplete"),//tells autocomplete where to get data
                select:submitAutocompleteForm
            };

            $input.autocomplete(options);//invoke autocomplete method,passin it 'options' object
        };

        var getPage = function () {
            var $a = $(this);

            var options = {
                url: $a.attr("href"),
                type:"get"
                //data: $("form").serialize()
            };

            $.ajax(options).done(function (data) {
                var target = $a.parents("div.pagedList").attr("data-tph-target");
                $(target).replaceWith(data);

            });
            return false;

        };

    
    $("form[data-tph-ajax='true']").submit(ajaxFormSubmit);//ajaxFormSubmit needs to be written
    $("input[data-tph-autocomplete]").each(createAutocomplete);//find those inputs which have 'data-tph-autocomplete' attribute and add to each of them 'createAutocomplete' widget
   // $(".main-content").on("click", ".pagedList a", getPage);

});