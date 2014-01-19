$(function() {
    $("button").click(function() {
        $("#addPersonModal").modal();
    });

    $("#addPerson").click(function() {
        var form = $("form");
        var text = form.serialize();
        form.find("input").val('');
        $.post('/person/add', text, function(result) {
            var html = "<tr><td>" + result.FirstName + "</td><td>" +
                result.LastName + "</td><td>" + result.Age + "</td></tr>";
            $("table").append(html);
        });
        
    });
});

