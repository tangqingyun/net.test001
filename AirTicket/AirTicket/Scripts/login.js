function checkempty(value) {
    if ('用户名／邮箱' == value) {
        return false;
    }
    if (value == null || "" == value) {
        return false;
    }
    return true;
}

function checkPassLength() {
    return ($("#password").val().length >= 6);
}

function checkUserName() {

    if (/^[A-Za-z]{1}([A-Za-z0-9]|[_]){0,29}$/.test($("#UserName").val())) {
        return true;
    }
    if (/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test($("#UserName").val())) {
        return true;
    }
    return false;
    // return /^[A-Za-z]{1}([A-Za-z0-9]|[_]){0,29}$/.test($("#UserName").val());
}

function checkNumOrChar(value) {
    if (value != "") {
        return (/^[a-zA-Z0-9]+$/.test(value));
    }
    return true;
}

$(document).ready(function () {

    // 设置username初值
    if ($("#UserName").val() == "" || $("#UserName").val() == '用户名／邮箱' || $("#UserName").val() == null) {
        UserName_class_gray();
        $("#UserName").val("用户名／邮箱");
    }


    // 清空检索文本框的默认值
    $("#UserName").focus(function () {
        var search = $("#UserName").val();
        if (search == '用户名／邮箱') {
            UserName_class_plain();
            $("#UserName").val("");
        }
    });

    // 显示检索文本框的默认值
    $("#UserName").blur(function () {
        var search = $("#UserName").val();
        if (search == '') {
            UserName_class_gray();
            $("#UserName").val("用户名／邮箱");
        }
    });

    if ($("#nameErrorFocus").val() == "focus") {
        $("#UserName").focus();
    }
    if ($("#passwordErrorFocus").val() == "focus") {
        $("#password").focus();
    }
    if ($("#randErrorFocus").val() == "focus") {
        $("#randCode").focus();
    }

    $(document).keyup(function (e) {
        if (/^13$/.test(e.keyCode)) {
            if (checkempty($("#UserName").val())
                    && checkempty($("#password").val())
                     && checkempty($("#randCode").val())
                     && checkPassLength($("#password").val())
                     && checkUserName()) {
                checkAysnSuggest();
            }
        }

    });
});


// 文本框样式：正常样式
function UserName_class_plain() {
    $("#UserName").removeClass("input_gray");
    $("#UserName").addClass("input_txt");
}

// 文本框样式：灰色字体
function UserName_class_gray() {
    $("#UserName").removeClass("input_txt");
    $("#UserName").addClass("input_gray");
}

function subForm() {
    if (checkName() && checkPassword() && checkRandCode()) {
        if ($("#UserName").val() != "" && $("#password").val() != "" && $("#randCode").val() != "" && $("#password").val().length > 5) {
            var form = document.getElementById("loginForm");
            if (('undefind' != $("[name='refundLoginCheck']")) && ($("[name='refundLoginCheck']").attr("checked") == true)) {
                $("#refundLogin").val('Y');
            } else {
                $("#refundLogin").val('N');
            }
            form.submit();
        }
    }
}

//自定义的回调函数result
function result(data) {
    //我们就简单的获取apple搜索结果的第一条记录中url数据
    alert("ee");
}

function checkAysnSuggest() {

    subForm();
    return false;
    //https://dynamic.12306.cn/otsweb/loginAction.do?method=loginAysnSuggest&callback
    try {
        var url = 'http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=apple&callback=?';
        $.getJSON(url, function (data) {
            // alert(eval("(" + data + ")"));
            alert(data.responseData.results[0].unescapedUrl);
        });
    } catch (e) {
        alert(e.message);
    }

    //subForm();
    return false;
    $.ajax({
        //ctx +
        url: 'https://dynamic.12306.cn/otsweb/loginAction.do?method=loginAysnSuggest',
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.randError != 'Y') {
                refreshImg();
                alert(data.randError);
                $("#password").val("");
                $("#password").focus();
                $("#randCode").val("");
                $("#loginRand").val(data.loginRand);
                return false;
            } else {
                $("#loginRand").val(data.loginRand);
                subForm();
            }
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("网络忙，请稍后重试");
            return false;
        }

    });

}

function checkName() {
    $("#nameSpan").empty();
    if (!checkempty($("#UserName").val())) {
        $("#nameSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>登录名必须填写!</span>");
        $("#UserName").focus();
        return false;
    } else if (!checkUserName()) {
        $("#nameSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>登录名格式不正确，请重新输入!</span>");
        $("#UserName").focus();
        return false;
    } else {
        $("#nameSpan").empty();
        return true;
    }

}


function checkPassword() {
    $("#passwordSpan").empty();
    if (!checkempty($("#password").val())) {
        $("#passwordSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>密码必须填写,且不少于6位!</span>");
        $("#password").focus();
        return false;
    } else if (!checkPassLength()) {
        $("#passwordSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>密码长度不能少于6位!</span>");
        $("#password").focus();
        return false;
    } else {

        $("#passwordSpan").empty();
        return true;
    }

}

function checkRandCode() {
    $("#randCodeSpan").empty();
    $("#randErr").empty();
    if (!checkempty($("#randCode").val())) {
        // $("#randCodeSpan").append("* 验证码须填写!");
        $("#randCodeSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>验证码不能为空!</span>");
        $("#randCode").focus();
        return false;
    } else if ($("#randCode").val().length != 4) {
        $("#randCodeSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>验证码长度为4位!</span>");
        $("#randCode").focus();
        return false;
    } else if (!checkNumOrChar($("#randCode").val())) {
        $("#randCodeSpan").html("<img src='https://dynamic.12306.cn/otsweb/images/er/tools_ico2.gif' width='16' height='16' /><span>验证码只能由数字或字母组成!</span>");
        $("#randCode").focus();
        return false;
    } else {
        $("#randCodeSpan").empty();
        return true;
    }
}

function refreshImg() {
    $("#img_rrand_code").attr("src", "passCodeAction.do?rand=sjrand" + '&' + Math.random());

}
