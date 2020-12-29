/// <reference path="../lib/initializedata.js" />
/// <reference path="../lib/initializedata.js" />
var ordering = null;
var paging = 1;
var EF = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
//************** Product *****************
function FilterSearch(filterByPrice = false) {
    showLoading()
    var TitleSerch = $("#ProductTitle").val();
    var Maxprice = (filterByPrice) ? $("#input-with-keypress-1").val() : 0;
    var Minprice = (filterByPrice)? $("#input-with-keypress-0").val() : 0;
    var immediat = $("input[name='immediatesending']:checked").length > 0;
    var Avilable = $("input[name='isAvilable']:checked").length > 0;
    paging = (filterByPrice) ? 1 : paging;
    var cat1 = $("#cat1").val();
    var cat2 = $("#cat2").val();
    var brands = $("input[name='brand']:checked").map(function () {
        return parseInt(this.value);
    }).get();
    var Attr = $("input[name='attr']:checked").map(function () {
        return parseInt(this.value);
    }).get();

    $.ajax({
        url: '/Products/' + cat1 + '/gtrhy/' + cat2,
        data: {
            isajax: true,
            TitleSerch: TitleSerch,
            Order: ordering,
            Brand: brands,
            attribute: Attr,
            fast: immediat,
            maxprice: Maxprice,
            minprice: Minprice,
            isAvilable: Avilable,
            page: paging,
        },
        method:'POST',
        dataType: "html",
        success: function (res) {

            $("#listproduct").html(res);
            hideLoading()
        },

        error: function (a, b, c) { console.error(a,b,c); }
    });
}
function FilterOrder(order = null) {
    ordering = order;
    paging = 1;
    FilterSearch();
}
function Pagination(page = 1) {
    paging = page;
    FilterSearch();
}
function FilterName() {
    paging = 1;
    ordering = null;
    FilterSearch();
}
function Attribute() {
    paging = 1;
    ordering = null;
    FilterSearch();
}
function PaginationComment(page = 1) {
    var prodid = $("#ProdId").val();
    $.ajax({
        url: '/GetProductComments',
        data: {
            id: prodid,
            page: paging
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {
            $("#listcomment").html(res);
 
        },
        error: function (a, b, c) { console.error(a, b, c); }
    });
}
function ChangePrice(Id) {
    var c = $("input[name='colorProd']:checked").val();
    var w = $("input[name='garanty']:checked").val();
    $.ajax({
        url: '/Products/GetPriceAjax/',
        data: {
            id: Id,
            garanty: w,
            color:c
        },
        method: 'POST',
        dataType: "json",
        success: function (res) {
            console.warn(res)
            $("#PriceAjax").html(res.data.price)
            $("#discountAjax").html(res.data.discounted)
        },
        error: function (a, b, c) { console.error(a, b, c); }
    });
}
//************ End Product ***************


//************** Comment *****************
function SubmitComment() {
    var Eid = $("#E");
    var Et = $("#T");
    var N = $("input[name='User']");
    var E = $("input[name='Email']");
    var M = $("textarea[name='Msg']");
    if (N.val() == "" || N.val() == null) {
        ErrorDialog("نام و نام خانوادگی الزامی میباشد");
        return;
    }
    if (E.val() == "" || E.val() == null) {
        ErrorDialog("پست الکترونیکی الزامی میباشد");
        return;
    }
    if (!EF.test(E.val())) {
        ErrorDialog("پست الکترونیکی نامعتبر میباشد");
        return;
    }
    if (M.val() == "" || M.val() == null) {
        ErrorDialog("متن پیام الزامی میباشد");
        return;
    }
    var Model = {};
    Model.User = N.val();
    Model.Email = E.val();
    Model.Msg = M.val();
    Model.EntityId = Eid.val();
    Model.EntityType = Et.val();
    axios.post('/api/cpanel/feedback/addcomment', Model).then(function (res) {
        var data = res.data;
        if (data.status) {
            SuccessDialog('نظر شما یا موفقیت ارسال شد');
            N.val("");
            E.val("");
            M.val("");
        }
        else {
            ErrorDialog(data.msg);
        }
    }).catch(function (err) { });
}
async function RegisterContactus() {
    let frm = "contactusfrm";
    if (await ValidateForm(frm)) {
        return false;
    }
    var enc = await InitilizeForm(frm);
    $("#registerBtn").addClass("active");
    await axios.post('/api/cpanel/PublicForm/AddPublicFroms', {}, {
        headers: {
            'PublicFormData': enc
        }
    }).then(function (res) {
        let data = res.data;
        console.info(res);
        $("#registerBtn").removeClass("active");
        if (data.status) {
            SuccessDialog(data.msg);
            $(`#${frm}`).get(0).reset();
            $("#typeRow").remove();
        }
        else {
            ErrorDialog(data.msg);
        }

    }).catch(function (err) {
        console.error(err);
        $("#registerBtn").removeClass("active");
    });

}
$("select").on('change', function () {
    if ($(this).next(".input-error").hasClass('active')) {
        $(this).next(".input-error").removeClass("active");
    }
});
$("input").on('keydown', function () {
    if ($(this).next(".input-error").hasClass('active')) {
        $(this).next(".input-error").removeClass("active");
    }
});
$("textarea").on('keydown', function () {
    if ($(this).next(".input-error").hasClass('active')) {
        $(this).next(".input-error").removeClass("active");
    }
});
function ErrorDialog(msg) {
    swal.fire({
        icon: 'error',
        title: 'خطا',
        text: msg
    });
}
function SuccessDialog(msg) {
    swal.fire({
        icon: 'success',
        title: 'عملیات موفق',
        text: msg
    });
}

//************ End Comment ***************


//************** Brand *****************

function brandproductsearch(filterByPrice = false) {
    showLoading()
    var TitleSerch = $("#ProductTitle").val();
    var Id = $("#brandid").val();
    var catid = $("#catid").val();
    var immediat = $("input[name='immediatesending']:checked").length > 0;
    var Avilable = $("input[name='isAvilable']:checked").length > 0;
    var Maxprice = (filterByPrice) ? $("#input-with-keypress-1").val() : 0;
    var Minprice = (filterByPrice) ? $("#input-with-keypress-0").val() : 0;
    paging = (filterByPrice) ? 1 : paging;
    $.ajax({
        url: '/Brand/' + Id + '/gtrhy/',
        data: {
            isajax: true,
            TitleSerch: TitleSerch,
            Order: ordering,
            id: Id,
            fast: immediat,
            maxprice: Maxprice,
            minprice: Minprice,
            isAvilable: Avilable,
            page: paging,
            catid: catid
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {

            $("#listbrandproduct").html(res);
            hideLoading()
        },

        error: function (a, b, c) { console.error(a, b, c); }
    });
}
function Paginationbrand(page = 1) {
    $.ajax({
        url: '/Brands/',
        data: {
            isajax: true,
            TitleSerch: TitleSerch,
            Order: ordering,
            Brand: brands,
            fast: immediat,
            maxprice: Maxprice,
            minprice: Minprice,
            isAvilable: Avilable,
            page: paging,
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {
            $("#listproduct").html(res);
            hideLoading()
        },
        error: function (a, b, c) { console.error(a, b, c); }
    });
}
function FilterNamebrand() {
    paging = 1;
    ordering = null;
    brandproductsearch();
}
function FilterOrderbrand(order = null) {
    ordering = order;
    paging = 1;
    brandproductsearch();
}
function PaginationProductbrand(page = 1) {
    paging = page;
    brandproductsearch();
}
//******** *** End Brand ***************

//************ Country ***************

function Countryproductsearch(filterByPrice = false) {
    showLoading()
    var TitleSerch = $("#ProductTitle").val();
    var Id = $("#Countryid").val();
    var catid = $("#catid").val();
    var immediat = $("input[name='immediatesending']:checked").length > 0;
    var Avilable = $("input[name='isAvilable']:checked").length > 0;
    var Maxprice = (filterByPrice) ? $("#input-with-keypress-1").val() : 0;
    var Minprice = (filterByPrice) ? $("#input-with-keypress-0").val() : 0;
    paging = (filterByPrice) ? 1 : paging;
    $.ajax({
        url: '/Products/Country/' + Id + '/gtrhy/',
        data: {
            isajax: true,
            TitleSerch: TitleSerch,
            Order: ordering,
            id: Id,
            fast: immediat,
            maxprice: Maxprice,
            minprice: Minprice,
            isAvilable: Avilable,
            page: paging,
            catid: catid
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {

            $("#listbrandproduct").html(res);
            hideLoading()
        },

        error: function (a, b, c) { console.error(a, b, c); }
    });
}
function PaginationCountry(page = 1) {
    paging = page;
    Countryproductsearch();
}
function FilterOrderCountry(order = null) {
    ordering = order;
    paging = 1;
    Countryproductsearch();
}
function FilterNameCountry() {
    paging = 1;
    ordering = null;
    Countryproductsearch();
}
//*********  End Country *************


//************ Gallery ***************
function GalleryCatPaging(Page = 1) {
    $.ajax({
        url: '/VideoGallery/',
        data: {
            isajax: true,
            page: Page,
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {
            $("#gallerylist").html(res);
            hideLoading()
        },
        error: function (a, b, c) { console.error(a, b, c); }
    });
}
//*********** End Gallery ************

//***********  Compare **************

function addTocompare(Id, reload = false) {
    $.ajax({
        url: '/AddToCompare/' + Id,
        data: {
            id: Id,
        },
        method: 'POST',
        dataType: "json",
        success: function (res) {
            if (res.status) {
                closeModal();
                SuccessDialog(res.msg);
                if (reload)
                    window.location.reload();
            } else {
                ErrorDialog(res.msg);
            }
        },
        error: function (a, b, c) { console.error(a, b, c); }
    });

}
function GetCategorylvl2() {
    var Id = $("#comparecatlvl1").val();
    var Model = {};
    Model.Id = Id;
    axios.post("/api/cpanel/product/Category/GetCategoryChildsById", Model).then(function (res) {
        var data = res.data;
        if (data.status) {
            var html = "<option value='0'>انتخاب نمایید</option>";
            data.data.childs.forEach(function (item) {
                html += `<option value="${item.pC_Id}">${item.pC_Title}</option>`;
                console.warn(item);
            });
            $("#SelectCatLevel2").html(html);

        }
        else {
            $("#SelectCatLevel2").html("<option value='0'>انتخاب نمایید</option>");
        }
    }).catch(
        function (error) {
            console.error(error);
        }
    )
}
async function CompareSearch() {

    var title = $("#comparesearchtitle").val();
    var cat2 = $("#SelectCatLevel2").val();
    var brand = $("#brandcompare").val();

    $.ajax({
        url: "/CompareSerch",
        data: { title, cat2, brand }, dataType: "json", method: "POST", success: function (res) {
            console.warn("REQUEST DATA RETURNED", res);
            if (res.status) {
                $("#productcontent").html(res.data);
            }

        },
        error: function (err) { console.error("Error Vermishte", err); },
        complete: function () {

            $(".productcontent").mCustomScrollbar({
                axis: "y",
                theme: "dark-3",
                scrollButtons: {
                    enable: true
                },
            });
        }
    });



}

//************ End Compare ***************

//************ Favorit ***************
async function AddToFavorite(e) {
    var pid = e;
    var type = 1;
    if (typeof (type) == "undefined") {
        ErrorDialog("Invalid Access");
        window.location.href = window.location.href;
        return;
    }
    if (typeof (type) == "undefined") {
        ErrorDialog("Invalid Access");
        window.location.href = window.location.href;
        return;
    }
    var Model = {};
    Model.F_EntityId = parseInt(pid);
    Model.F_EntityType = type;
    Model.F_UserId = 0;
    await axios.post('/User/AddFavorite', Model).then(function (res) {
        let data = res.data;
        if (data.status) {
            SuccessDialog("Entity added to your favorites list.");
            $("#FavoriteView").addClass("active");
            $("#FavoriteView").attr("data-flag",1);

        }
        else {
            ErrorDialog(data.msg);
        }

    }).catch(function (err) {
        console.error(err);
    });
}
async function RemoveFavorite(p) {
    await axios.post('/User/RemoveFavorite/' + p, {}).then(function (res) {
        let data = res.data;
        console.info(res);
        if (data.status) {
            SuccessDialog("Entity removed from your favorites list.");
            $("#FavoriteView").removeClass("active");
            $("#FavoriteView").attr("data-flag", 2);
        }
        else {
            ErrorDialog(data.msg);
        }

    }).catch(function (err) {
        console.error(err);
    });
}
async function RemoveFavoriteUser(p) {
    await axios.post('/User/RemoveFavoriteUser/' + p, {}).then(function (res) {
        let data = res.data;
        console.info(res);
        if (data.status) {
            SuccessDialog("Entity removed from your favorites list.");
        }
        else {
            ErrorDialog(data.msg);
        }
    }).catch(function (err) {
        console.error(err);
    });
}
async function Favoriteprod(id) {
    var flag = $("#FavoriteView").attr("data-flag");
    alert(flag)
    if (flag == 1) {
        AddToFavorite(id);
    } else {
        RemoveFavorite(id);
    }
}
//************ End favorit ***************

//************ More Product ***************
function Moreproductsearch(filterByPrice = false) {
    showLoading()
    var TitleSerch = $("#ProductTitle").val();
    var typevalue = $("#typevalue").val();
    var Id = $("#productid").val();
    //var catid = $("#catid").val();
    var immediat = $("input[name='immediatesending']:checked").length > 0;
    var Avilable = $("input[name='isAvilable']:checked").length > 0;
    var Maxprice = (filterByPrice) ? $("#input-with-keypress-1").val() : 0;
    var Minprice = (filterByPrice) ? $("#input-with-keypress-0").val() : 0;
    var brands = $("input[name='brand']:checked").map(function () {
        return parseInt(this.value);
    }).get();
    paging = (filterByPrice) ? 1 : paging;
    $.ajax({
        url: '/Products/More/' + Id +'/'+ typevalue + '/gtrhy/',
        data: {
            isajax: true,
            TitleSerch: TitleSerch,
            Order: ordering,
            Brand: brands,
            fast: immediat,
            maxprice: Maxprice,
            minprice: Minprice,
            isAvilable: Avilable,
            page: paging
            //catid: catid
        },
        method: 'POST',
        dataType: "html",
        success: function (res) {
            $("#listmoredproduct").html(res);
            hideLoading()
        },

        error: function (a, b, c) { console.error(a, b, c); }
    });
}
function FilterNameMore() {
    paging = 1;
    ordering = null;
    Moreproductsearch();
}
function FilterOrderMore(order = null) {
    ordering = order;
    paging = 1;
    Moreproductsearch();
}
function PaginationMore(page = 1) {
    paging = page;
    Moreproductsearch();
}
//************ End More Product ***********

//************ NewsLatter ***********
async function RegisterNewsLetter() {
    var el = $("#nlEmail");
    if (el.val() == "" || el.val() == null) {
        el.next("div").html("Email is required.").addClass("active");
        return false;
    }
    if (!EF.test(el.val())) {
        el.next("div").html("Email format not correct.").addClass("active");
        return false;
    }
    var enc = await InitilizeElement(el.val(), "Entity");
    await axios.post('api/cpanel/publicform/AddNewsLetter', {}, {
        headers: {
            'NewsLetter': enc
        }
    }).then(function (res) {
        var data = res.data;
        if (data.status) {
            SuccessDialog(data.msg);
            el.val("");
        }
        else {
            ErrorDialog(data.msg);
        }

    }).catch(function (err) {
        console.error(err);
    });
}
async function IntilizeData(data) {
    var key = CryptoJS.enc.Utf8.parse('8080808080808080');
    var iv = CryptoJS.enc.Utf8.parse('8080808080808080');

    var initialized = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(data), key,
        {
            keySize: 128 / 8,
            iv: iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        });



    return initialized;
}

async function InitilizeForm(frm, setJson = false) {
    var data = {};
    $(`#${frm} input,#${frm} select,#${frm} textarea`).each(function (i, el) {
        data[$(el).attr("name")] = $(el).val();
    });
    return await IntilizeData(JSON.stringify(data));
}
async function InitilizeElement(val, name) {
    var data = {};
    data[name] = val;
    return await IntilizeData(JSON.stringify(data));
}
//************ End NewsLatter ********