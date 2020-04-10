$(function () {
    $('#nhanthinhansogi').click(function () {
        $('#file').trigger('click');
    });
    $('#file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#file').get(0);
            var files = fileupload.files;
            var form = new FormData();
            form.append('fileeeee', files[0]);
            $.ajax({
                url: '/Login/loadAnh',
                type: 'Post',
                contentType: false,
                processData: false,
                data: form,
                success: function (url) {
                    $('#anhcuano').attr('src', url);
                    $('.ggghykl').attr('value',url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
});