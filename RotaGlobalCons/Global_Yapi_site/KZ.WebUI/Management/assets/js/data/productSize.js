function GetAllProductSize(id) {
    $.getJSON("/api/size/" + id.toString() + "/getAllProductSize",
        function (data) {
            $('#selectedSizeList').empty();
            $.each(data, function (key, val) {

                var secili = "";
                if (val.IsDefaultSelected) {
                    secili = "<br/><b>(Varsayılan Seçili)</b>";
                }

                var satir = '<tr><td>' + val.Name + ' ' + secili + ' </td><td><input type="text" id="cp_' + val.Id + '" name="cp_' + val.Id + '" value=' + val.PriceText + ' class="form-control" onkeypress="return isPrice(event);" /> </td><td><input type="text" id="cop_' + val.Id + '" name="cop_' + val.Id + '" value=' + val.Old_PriceText + ' class="form-control" onkeypress="return isPrice(event);" /> </td><td><input type="text" id="hvl_' + val.Id + '" name="hvl_' + val.Id + '" value=' + val.Havale_PriceText + ' class="form-control" onkeypress="return isPrice(event);" /> </td><td><input type="text" id="dt_' + val.Id + '" name="dt_' + val.Id + '" value="' + val.DeliveryTime + '" class="form-control" /> </td><td><a onclick="defaultSelectedProductSize(' + val.SizeId + ', ' + val.ProductId + ');"><img src="assets/images/checked.png" /></a></td><td><a onclick="updateProductSize(' + val.Id + ');"><img src="assets/images/edit.png" /></a></td><td><a onclick="deleteSizeDialogBox(' + val.Id + ');"><img src="assets/images/delete.png" /></a></td></tr>';
                $('#selectedSizeList').append(satir);  //satir içindekileri ekliyor
            });
        });
}

function deleteProductSize(id) {
    $.getJSON("/api/size/" + id.toString() + "/deleteProductSize",
        function (data) {
            if (data == "1") {
                swal("Silindi!", "İlgili kaydınız başarılı bir şekilde silinmiştir.", "success");
                GetAllProductSize($('#hfProductId').val());

            } else
                swal("Hata!", "İlgili kaydı silme sırasında hata meydana geldi.", "error");
        });
}

function defaultSelectedProductSize(id, productId) {
    $.getJSON("/api/size/" + id.toString() + "/defaultSelectedProductSize?productId=" + productId + "",
        function (data) {
            if (data == "1") {
                swal("Güncellendi!", "İlgili ölçü varsayılan seçili olarak ayarlanmıştır.", "success");
                GetAllProductSize($('#hfProductId').val());

            } else
                swal("Hata!", "İlgili kaydı silme sırasında hata meydana geldi.", "error");
        });
}

function updateProductSize(id) {

    var txtPrice = $('#cp_' + id);
    var txtOldPrice = $('#cop_' + id);
    var txtHavalePrice = $('#hvl_' + id);
    var txtDeliveryTime = $('#dt_' + id);



    if (txtPrice.val() == '') {
        txtPrice.css({
            "border": "1px solid red",
            "background": "#FFCECE"
        });
        return false;
    } else {
        txtPrice.css({
            "border": "",
            "background": ""
        });
    }

    if (txtOldPrice.val() == '') {
        txtOldPrice.css({
            "border": "1px solid red",
            "background": "#FFCECE"
        });
        return false;
    } else {
        txtOldPrice.css({
            "border": "",
            "background": ""
        });
    }

    if (txtHavalePrice.val() == '') {
        txtHavalePrice.css({
            "border": "1px solid red",
            "background": "#FFCECE"
        });
        return false;
    } else {
        txtHavalePrice.css({
            "border": "",
            "background": ""
        });
    }

    if (txtDeliveryTime.val() == '') {
        txtDeliveryTime.css({
            "border": "1px solid red",
            "background": "#FFCECE"
        });
        return false;
    } else {
        txtDeliveryTime.css({
            "border": "",
            "background": ""
        });
    }

    $.getJSON("/api/size/" + id.toString() + "/updateProductSize?&price=" + txtPrice.val() + "&oldPrice=" + txtOldPrice.val() + "&havalePrice=" + txtHavalePrice.val() + "&deliveryTime=" + txtDeliveryTime.val(),
        function (data) {
            if (data == "1") {
                swal("Güncellendi!", "İlgili kaydınız başarılı bir şekilde güncellenmiştir.", "success");
                GetAllProductSize($('#hfProductId').val());

            } else
                swal("Hata!", "İlgili kaydı güncelleme sırasında hata meydana geldi.", "error");
        });
}

function deleteSizeDialogBox(id) {
    swal({
        title: "Emin misiniz ?",
        text: "İlgili kaydı silmek istediğinize emin misiniz ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-success",
        confirmButtonText: "Evet",
        cancelButtonText: "Vazgeç",
        closeOnConfirm: false
    },
        function () {
            deleteProductSize(id);
        });
}


function clearAddProductSize() {
    $('#ddlSizeList').val('0');
    $('#txtSizePrice').val('');
    $('#txtOldSizePrice').val('');
    $('#txtHavaleSizePrice').val('');
    $('#txtDeliveryTime').val('');
}

$("#btnSaveSize").click(function () {
    var isValid = true;

    $('#txtSizePrice, #txtOldSizePrice, #txtHavaleSizePrice, #ddlSizeList, #txtDeliveryTime').each(function () {
        if ($.trim($(this).val()) == '' || $.trim($(this).val()) == '0') {

            isValid = false;

            $(this).css({
                "border": "1px solid red",
                "background": "#FFCECE"
            });
        }
        else {
            $(this).css({
                "border": "",
                "background": ""
            });

        }
    });

    if (isValid == false) {
        return false;
    }
    else {
        var productId = $('#hfProductId').val();
        var ddlSize = $('#ddlSizeList').val();
        var txtSizePrice = $('#txtSizePrice').val();
        var txtOldSizePrice = $('#txtOldSizePrice').val();
        var txtHavaleSizePrice = $('#txtHavaleSizePrice').val();
        var txtDeliveryTime = $('#txtDeliveryTime').val();

        $.getJSON("/api/size/" + ddlSize + "/getBySizeId?productId=" + productId,
        function (data) {
            if (data == "0") {
                $.getJSON("/api/size/" + productId + "/addProductSize?" + "&sizeId=" + ddlSize + "&price=" + txtSizePrice + "&oldPrice=" + txtOldSizePrice + "&havalePrice=" + txtHavaleSizePrice + "&deliveryTime=" + txtDeliveryTime,
                function (data) {
                    if (data == "1") {
                        swal("Başarılı!", "İlgili kaydınız başarılı bir şekilde eklenmiştir.", "success");
                        GetAllProductSize(productId);
                        clearAddProductSize();
                    }
                    else
                        swal("Hata!", "İlgili kaydı ekleme sırasında hata meydana geldi.", "error");
                });

            }
            else {
                swal("Uyarı!", "Aynı ölçü üründe bulunmaktadır.", "info");
            }

        });
    }
});

