
$(function () {
    //anh1
    $('#anh1btn').click(function () {
        $('#anh1file').trigger('click');
    });
    $('#anh1file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh1file').get(0);
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
                    $('#ImgAnh1').attr('src', url); 
                    $('#DataImg1').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
    //anh2
    $('#anh2btn').click(function () {
        $('#anh2file').trigger('click');
    });
    $('#anh2file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh2file').get(0);
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
                    $('#ImgAnh2').attr('src', url);
                    $('#DataImg2').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
    //anh3
    $('#anh3btn').click(function () {
        $('#anh3file').trigger('click');
    });
    $('#anh3file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh3file').get(0);
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
                    $('#ImgAnh3').attr('src', url);
                    $('#DataImg3').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
    //anh5
    $('#anh5btn').click(function () {
        $('#anh5file').trigger('click');
    });
    $('#anh5file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh5file').get(0);
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
                    $('#ImgAnh5').attr('src', url);
                    $('#DataImg5').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
    //anh6
    $('#anh6btn').click(function () {
        $('#anh6file').trigger('click');
    });
    $('#anh6file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh6file').get(0);
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
                    $('#ImgAnh6').attr('src', url);
                    $('#DataImg6').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });
    //anh7
    $('#anh7btn').click(function () {
        $('#anh7file').trigger('click');
    });
    $('#anh7file').change(function () {
        if (window.FormData !== undefined) {
            var fileupload = $('#anh7file').get(0);
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
                    $('#ImgAnh7').attr('src', url);
                    $('#DataImg7').attr('value', url);
                },
                error: function (err) {
                    alert('Có Lỗi');
                }
            });
        }
    });

    $('.ChonChungLoai').click(function(){
        var vl = $(this).data('id');
        $('#chungLoaiSanPham').attr('value', vl);
    });
});