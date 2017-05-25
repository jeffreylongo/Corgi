let searchNews = () => {
    var _data = {
        needle: $("#needle").val()
    };
    console.log("searching...");
    $.ajax({
        url: '/HotNews/Search',
        type: "POST",
        data: JSON.stringify(_data),
        contentType: "application/json",
        dataType: "html",
        success: (results) => {
            $("#results").html(results);
        }
    });
}