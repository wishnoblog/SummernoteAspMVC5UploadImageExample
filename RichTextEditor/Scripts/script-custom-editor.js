$(document).ready(function () {
    // Initialize Editor   
    $('.textarea-editor').summernote(
    {
        height: ($(window).height() - 300),         // set editor height  
        minHeight: null,       // set minimum height of editor  
        maxHeight: null,       // set maximum height of editor  
        focus: true,         
        callbacks: {
            onImageUpload: function (image) {
                editor = $(this);
                uploadImage(image[0], editor);
            }
        }
    });
});


function uploadImage(file, editor) {
    var data = new FormData();
    data.append("image", file);
    $.ajax({
        url: '/Home/UploadImage',
        cache: false,
        contentType: false,
        processData: false,
        data: data,
        type: "post",
        success: function (url) {
            editor.summernote('insertImage', 'http://' + url,'');
        },
        error: function(data) {
            console.log(data);
        }
    });
}
