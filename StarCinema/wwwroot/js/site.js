function GetComments(id, page, movieName) {
    console.log('ABIBABA');

    var data = {}
    data.MovieId = id;
    data.Page = page;

    if (!page) {
        page = 1;
    }

    $.ajax({
        url: "/Movie/MovieComments",
        method: "post",
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(data)
    }).done(function (res) {
        $('#commentsModalTitle').text("Comments added to " + movieName);
        $('#commentsTableBody tr').remove();
        var table = document.getElementById("commentsTableBody");
        for (var i = 0; i < res.length;i++) {
            var comment = res[i];

            var row = table.insertRow(i);

            var numberCell = row.insertCell(0);
            var dateCell = row.insertCell(1);
            var userCell = row.insertCell(2);
            var commentCell = row.insertCell(3);
            var actionsCell = row.insertCell(4);

            numberCell.innerHTML = i + 1;
            dateCell.innerHTML = new Date(comment.addedDate).toDateString();
            userCell.innerHTML = comment.username;
            commentCell.innerHTML = comment.comment;
            actionsCell.innerHTML = '<button type="submit" class="btn btn-xs btn-danger app-form-table-submit"><i class="glyphicon glyphicon-remove"></i> DELETE</button>'
        }


    });
}