# ASP.MVC5 的Summernote的插入圖片


##Summer Note
[https://summernote.org/](https://summernote.org/)

## 編譯環境
- Visual Studio 2017
- Windows 10

##MVC5
- 接收檔案的Action: `/Home/UploadImage`  
- 示範的Action: `/Home/Index`


##關鍵的Js Script

多數人卡在這邊:

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

