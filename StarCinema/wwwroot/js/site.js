function GetComments(id, page) {
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
    }).done(function(res) {
        consol.log(res);
    });
}