$('#phuimg6').click(function () {
    $('#anhChinh').attr('src', $('#phuimg6').attr('src'));
});
$('#phuimg5').click(function () {
    $('#anhChinh').attr('src', $('#phuimg5').attr('src'));
});
$('#phuimg4').click(function () {
    $('#anhChinh').attr('src', $('#phuimg4').attr('src'));
});
$('#phuimg3').click(function () {
    $('#anhChinh').attr('src', $('#phuimg3').attr('src'));
});
$('#phuimg2').click(function () {
    $('#anhChinh').attr('src', $('#phuimg2').attr('src'));
});
$('#phuimg1').click(function () {
    $('#anhChinh').attr('src', $('#phuimg1').attr('src'));
});
$('#phuimg7').click(function () {
    $('#anhChinh').attr('src', $('#phuimg7').attr('src'));
});
var sosao = 3;
$('#sao1').click(function () {
    $('#sao1').css('color', 'gold');
    $('#sao2').css('color', 'black');
    $('#sao3').css('color', 'black');
    $('#sao4').css('color', 'black');
    $('#sao5').css('color', 'black');
    sosao = 1;
});
$('#sao2').click(function () {
    $('#sao1').css('color', 'gold');
    $('#sao2').css('color', 'gold');
    $('#sao3').css('color', 'black');
    $('#sao4').css('color', 'black');
    $('#sao5').css('color', 'black');
    sosao = 2;
});
$('#sao3').click(function () {
    $('#sao1').css('color', 'gold');
    $('#sao2').css('color', 'gold');
    $('#sao3').css('color', 'gold');
    $('#sao4').css('color', 'black');
    $('#sao5').css('color', 'black');
    sosao = 3;
});
$('#sao4').click(function () {
    $('#sao1').css('color', 'gold');
    $('#sao2').css('color', 'gold');
    $('#sao3').css('color', 'gold');
    $('#sao4').css('color', 'gold');
    $('#sao5').css('color', 'black');
    sosao = 4;
});
$('#sao5').click(function () {
    $('#sao1').css('color', 'gold');
    $('#sao2').css('color', 'gold');
    $('#sao3').css('color', 'gold');
    $('#sao4').css('color', 'gold');
    $('#sao5').css('color', 'gold');
    sosao = 5;

});
$('.Repcl').click(() => {
    $('.NoidungBinhLuan').data('comment')
});
$('#GuiDuaLieu').click(() => {
    var noidung = $('#layComMent').val();
    var sosaochon = sosao;
    var idsanpham = $('#GuiDuaLieu').data('id');
    $.ajax({
        url: '/Product/CapNhatDanhGia',
        type: 'Post',
        data: { noidung: noidung, sosaochon: sosaochon, idsanpham: idsanpham },
        dataType: 'Json',
        success: function (sd) {
            if (sd == "0") {

                location.reload();
            }
            else {
                alert("Bạn Cần Đăng Nhập");
            }

        },
        error: () => {
            alert("Có Biến Rồi Đại Vương");
        }

    });
});
$('.Repcl').click(function () {
    var idCuaDanhGia = $(this).data('id');
    var ma = "CommentDanhGia_" + idCuaDanhGia;
    var trangThai = $('#' + ma).css('display');
    if (trangThai == "block") {
        $('#' + ma).css('display', 'none');
    }
    else {
        $('#' + ma).css('display', 'block');
    }
});

$('.GuiCommentDanhGia').click(function () {
    var idsanpham = $(this).data('id');
    var ma = "CommentCuaDanhGia_" + idsanpham;
    var noidung = $('#' + ma + '').val();

    $.ajax({
        url: '/Product/CapNhatComment',
        type: 'Post',
        data: { noidung: noidung, idsanpham: idsanpham },
        dataType: 'Json',
        success: function (sd) {
            if (sd == "0") {

                location.reload();
            }
            else {
                alert("Bạn Cần Đăng Nhập");
            }

        },
        error: () => {
            alert("Có Biến Rồi Đại Vương");
        }

    });
});
$('.Thichcl').click(function () {
    var idsanpham = $(this).data('id');
    $.ajax({
        url: '/Product/SuLyThichDanhGia',
        type: 'Post',
        data: { idsanpham: idsanpham },
        dataType: 'Json',
        success: function (sd) {
            if (sd == "4") {
                alert('Bạn Đã Like Rồi');
            }
            else if (sd == "3") {
                location.reload();
                alert('Đã chuyển  DisLike Thành Like');
            } else if (sd == "2") {
                location.reload();
            }
            else {
                alert("Bạn Cần Đăng Nhập Hoặc Có Lỗi Sảy Ra");
            }

        },
        error: () => {
            alert("Có Biến Rồi Đại Vương");
        }

    });
});
$('.DisThichcl').click(function () {
    var idsanpham = $(this).data('id');
    $.ajax({
        url: '/Product/SuLyKoThichDanhGia',
        type: 'Post',
        data: { idsanpham: idsanpham },
        dataType: 'Json',
        success: function (sd) {
            if (sd == "4") {
                alert('Bạn Đã Like Rồi');
            }
            else if (sd == "3") {
                location.reload();
                alert('Đã chuyển  Like Thành DisLike');
            } else if (sd == "2") {
                location.reload();
            }
            else {
                alert("Bạn Cần Đăng Nhập Hoặc Có Lỗi Sảy Ra");
            }

        },
        error: () => {
            alert("Có Biến Rồi Đại Vương");
        }

    });
});

$('.MuaSanPham').click(function () {
    var idsanpham = $(this).data('id');
    var soLuong = $('#SoLuong_' + idsanpham).val();
    var MaGiamGia = $('#MaGiamGia_' + idsanpham).val();
    if (idsanpham == undefined || soLuong == undefined) {
        alert('Nhập số lượng đầy đủ');
    }
    else {
        $.ajax({
            url: '/MyCart/MuaSanPham',
            data: { idsanpham: idsanpham, soluong: soLuong, MaGiamgia: MaGiamGia },
            success: function () {
                Location.reload();
            }
        });
    }
    
});