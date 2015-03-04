Param_Printer = {
    printParam: function (param) {
        var $this = this;
        var type = param.type;
        if (type == "text") {
            return $this._printText(param)
        } else if (type == "radio" || type == "gridradio") {
            return $this._printRadio(param)
        } else if (type == "password") {
            return $this._printPassword(param)
        } else if (type == "image") {
            return $this._printText(param)
        } else if (type == "united") {
            return $this._printHidden(param)
        }
        return param
    },
    _printText: function (param) {
        var html = "<input type=\"text\"" + this.__pintCommantProp(param);
        html += "/>";
        param.self = html;
        return param
    },
    _printPassword: function (param) {
        var html = "<input type=\"password\"" + this.__pintCommantProp(param);
        html += "/>";
        param.self = html;
        return param
    },
    _printRadio: function (param) {
        var html = "<select" + this.__pintCommantProp(param) + ">";
        var keyvalues = param.values.split(",");
        for (var i = 0; i < keyvalues.length; i++) {
            var keyvalue = keyvalues[i].split("=");
            html += "<option value=\"" + keyvalue[1] + "\"" + (keyvalue[1] == param["default"] ? " selected" : "") + ">" + keyvalue[0];
            html += "</option>"
        }
        html += "</select>";
        param.self = html;
        return param
    },
    _printImage: function (param) {
        var html = "<input type=\"text\"" + this.__pintCommantProp(param);
        html += "/>";
        param.self = html;
        return param
    },
    _printHidden: function (param) {
        var html = "<input type=\"hidden\"" + this.__pintCommantProp(param);
        if (param.getvalue) {
            html += " getvalue=\"" + param.getvalue + "\"";
            html += " class=\"getvalue\""
        }
        html += "/>";
        param.self = html;
        return param
    },
    __pintCommantProp: function (param) {
        var result = " name=\"" + param.name + "\" id=\"" + param.name + "\" title=\"" + param.title + "\" ";
        if (param.cssStyle && param.cssStyle.length > 0) {
            result += "style=\"" + param.cssStyle + "\" "
        }
        if (param.cssClass && param.cssClass.length > 0) {
            result += "class=\"" + param.cssClass + "\" "
        }
        if (param.maxlength && param.maxlength.length > 0) {
            result += "maxlength=\"" + param.maxlength + "\" "
        }
        return result
    }
};
PAGE_UTIL = {
    isMuniciplity: function (code) {
        return /^((11)|(12)|(31)|(50)|(81)|(82))\d{4}$/.test(code)
    },
    ajaxError: function (xhr, ajaxOptions, thrownError) {
        $("#progress-img").hide();
        PAGE_UTIL.alert("Http status: " + xhr.status + " " + xhr.statusText + "\najaxOptions: " + ajaxOptions + "\nthrownError:" + thrownError + "\n" + xhr.responseText)
    },
    alert: function (message) {
        $("#error").html(message).hide().fadeIn("slow")
    },
    obj2str: function (o) {
        if (o == undefined) {
            return ""
        }
        var r = [];
        if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
        if (typeof o == "object") {
            if (!o.sort) {
                for (var i in o) r.push("\"" + i + "\":" + PAGE_UTIL.obj2str(o[i]));
                if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                    r.push("toString:" + o.toString.toString())
                }
                r = "{" + r.join() + "}"
            } else {
                for (var i = 0; i < o.length; i++) r.push(PAGE_UTIL.obj2str(o[i]));
                r = "[" + r.join() + "]"
            }
            return r
        }
        return o.toString().replace(/\"\:/g, '":""')
    },
    goAjax: function (options) {
        var opts = $.extend({
            type: "post",
            dataType: "json",
            cache: false,
            async: true
        },
        options);
        $.ajax({
            type: opts.type,
            url: opts.url,
            async: opts.async,
            data: opts.data,
            dataType: opts.dataType,
            cache: opts.cache,
            success: function (json) {
                if (json && json.statusCode && json.statusCode == "300") {
                    PAGE_UTIL.alert(json.msg);
                    if ($.isFunction(opts.errBack)) {
                        opts.errBack(json)
                    }
                    return
                }
                if ($.isFunction(opts.callback)) {
                    opts.callback(json)
                }
            },
            error: PAGE_UTIL.ajaxError
        })
    }
};
var context = {};
PAGE_RENDER = {
    defaults: {
        carNum: {
            label: "车牌号码",
            cssStyle: "",
            cssClass: "",
            template: "<dl><dt>{label}：</dt><dd>{self}</dd></dl>",
            html: ""
        },
        ecarBelong: {
            label: "",
            cssStyle: "",
            cssClass: "s3",
            template: "{self}",
            html: ""
        },
        ecarPart: {
            maxlength: "6",
            template: "<label class=\"placeholder\"><span class=\"text\">请输入您的车牌号码</span>{self}</label>",
            validation: {
                reg: "^[A-Za-z0-9]{6}$",
                message: "请输入6位车牌号码"
            }
        },
        engineNum: {
            template: "<dl><dt>{title}：</dt><dd><label class=\"placeholder\"><span class=\"text\">请输入您的发动机号</span>{self}</label></dd></dl>"
        },
        evin: {
            label: "识别代号",
            template: "<dl><dt>{label}：</dt><dd><label class=\"placeholder\"><span class=\"text\">请输入您的车辆识别代号</span>{self}</label></dd></dl>"
        },
        ecarinfo2: {
            label: "手&nbsp;机&nbsp;号",
            template: "<dl><dt>{label}：</dt><dd><label class=\"placeholder\"><span class=\"text\">请输入您的手机号</span>{self}</label></dd></dl>"
        },
        epassword: {
            label: "密&nbsp;&nbsp;&nbsp;&nbsp;码",
            template: "<dl><dt>{label}：</dt><dd><label class=\"placeholder\"><span class=\"text\">请输入密码</span>{self}</label></dd></dl>"
        },
        ecarinfo5: {
            label: "驾驶证号",
            template: "<dl><dt>{label}：</dt><dd><label class=\"placeholder\"><span class=\"text\">请输入驾驶证号</span>{self}</label></dd></dl>"
        },
        euserName: {
            label: "用&nbsp;户&nbsp;名",
            template: "<dl><dt>{label}：</dt><dd><label class=\"placeholder\"><span class=\"text\">输入您在交管局网站注册的用户信息</span>{self}</label></dd></dl>"
        },
        yzm: {
            label: "验&nbsp;证&nbsp;码",
            cssStyle: "width:90px",
            template: "<dl><dt>{label}：</dt><dd class=\"p10000\">{self}<a class=\"btn btn-gray\" id=\"yzm_btn\" title=\"点击获取验证码\" href=\"#\">获取验证码</a><span id=\"yzm_info\"><img id=\"loading_yzm\" align=\"middle\"/><span id=\"yzm_refresh_button\" style=\"cursor: pointer\">看不清，换一张</span><input type=\"hidden\" id=\"cookie\" name=\"cookie\"/></span></dd></dl>"
        },
        yzm110000: {
            label: "验&nbsp;证&nbsp;码",
            cssStyle: "width:90px",
            template: "<dl><dt>{label}：</dt><dd>{self}<a class=\"btn btn-gray\" id=\"yzm_btn\" title=\"点击获取验证码\" href=\"#\">获取验证码</a><span id=\"yzm_info\"><span class=\"numtip\">输入图片中的变形文字</span><span id=\"yzm_info110000\"><img id=\"loading_yzm\" align=\"middle\"/><span id=\"yzm_refresh_button\" style=\"cursor: pointer\">看不清，换一张</span><input type=\"hidden\" id=\"cookie\" name=\"cookie\"/></span></span></dd></dl>"
        },
        common: {
            label: "",
            cssStyle: "",
            cssClass: "",
            template: "<dl><dt>{title}：</dt><dd>{self}</dd></dl>",
            html: ""
        }
    },
    format: function (context, wraper) {
        var result = wraper;
        for (key in context) {
            var reg = new RegExp("({" + key + "})", "g");
            result = result.replace(reg, context[key])
        }
        return result
    },
    wrapParam: function (param) {
        var currentCity = COMM_DATA.currentCity;
        if (this.defaults[param.name + currentCity]) {
            return $.extend(param, this.defaults[param.name + currentCity])
        }
        if (this.defaults[param.name]) {
            return $.extend(param, this.defaults[param.name])
        }
        return $.extend(param, this.defaults.common)
    },
    init: function () {
        context = {};
        for (var i = 0; i < COMM_DATA.basicParam.length; i++) {
            var content = Param_Printer.printParam(this.wrapParam(COMM_DATA.basicParam[i]));
            context[content.name] = content
        }
        for (paramName in context) {
            var p = context[paramName];
            this.genHtml(context, p)
        }
    },
    render: function (paramsData) {
        PAGE_RENDER.init();
        if (paramsData && paramsData.length > 0) {
            var pdata = "," + paramsData + ",";
            var html = "";
            for (name in context) {
                if (pdata.indexOf("," + context[name]["id"] + ",") != -1) {
                    html += context[name]["html"]
                }
            }
            $("#main_content").html(html);
            this.renderBack(pdata)
        }
    },
    renderBack: function (pdata) {
        if (pdata.indexOf("," + context["carNum"]["id"] + ",") != -1) {
            $("#ecarBelong").val($("#city").val().substring(0, 2))
        }
        if ($("#yzm_btn", "#main_content").length > 0) {
            $("#yzm_btn", "#main_content").bind("click", PAGE_RENDER.getYzm);
            $("#yzm_refresh_button").bind("click", PAGE_RENDER.getYzm)
        }
        $('label.placeholder').click(function () {
            var display = $(this).parent().parent().parent().css("display");
            if (display == "block") $(this).find('input')[0].focus()
        });
        $('label.placeholder>input').focusin(function () {
            $(this).parent().addClass('placeholder-focus')
        }).focusout(function () {
            $(this).val() == '' && $(this).parent().removeClass('placeholder-focus')
        })
    },
    getYzm: function () {
        $("#yzm_btn").css("display", "none");
        $("#yzm_info").css("display", "inline");
        $("#loading_yzm").attr("src", COMM_DATA.contextPath + "/pub/images/loading.gif");
        PAGE_UTIL.goAjax({
            url: COMM_DATA.contextPath + "/validImage.at?cityCode=" + $("#city").val(),
            callback: function (json) {
                if (json.status == "1") {
                    $("#loading_yzm").attr("src", COMM_DATA.contextPath + "/codeImage.at?path=" + json.picPath);
                    if (json.cookies) $("#cookie").val(json.cookies);
                    if (json.other) {
                        $("#yzm_refresh_button").after(json.other)
                    }
                    $("#yzm").val("").focus()
                }
            },
            errBack: function (json) {
                $("#yzm_btn").css("display", "");
                $("#yzm_info").css("display", "none")
            }
        })
    },
    genHtml: function (context, param) {
        if (param.getvalue && param.getvalue.length > 0) {
            var getValue = param.getvalue.split("+");
            var self = param.self;
            for (var i = 0; i < getValue.length; i++) {
                var name = getValue[i];
                if (context[name]) {
                    var getValueHtml = context[name]["html"];
                    if (getValueHtml && getValueHtml.lenght > 0) {
                        self += getValueHtml
                    } else {
                        PAGE_RENDER.genHtml(context, context[name]);
                        self += context[name]["html"]
                    }
                }
            }
            param.self = self
        }
        param.html = PAGE_RENDER.format(param, param.template)
    }
};
PAGE_FORM = {
    validate: function () {
        var errMsg = "";
        $("#form1 input[type=text]").each(function () {
            var name = $(this).attr("name");
            if (context[name]) {
                if ($(this).val().length == 0) {
                    errMsg += "请填写" + context[name]["title"] + "<br/>";
                    return false
                }
                if (context[name]["validation"]) {
                    var reg = new RegExp(context[name]["validation"]["reg"]);
                    if (!reg.test($(this).val())) {
                        errMsg += context[name]["validation"]["message"];
                        return false
                    }
                }
            }
        });
        if (errMsg.length == 0) {
            $("#form1 input[type=password]").each(function () {
                var name = $(this).attr("name");
                if (context[name]) {
                    if ($(this).val().length == 0) {
                        errMsg += "请填写" + context[name]["title"] + "<br/>";
                        return false
                    }
                }
            })
        }
        if (errMsg.length > 0) {
            PAGE_UTIL.alert(errMsg);
            return false
        }
        return true
    },
    submit: function () {
        if (this.validate()) {
            PAGE_UTIL.alert("");
            PAGE_FORM.remCarInfo();
            $("#form1").find("input[type=hidden][class=getvalue]").each(function () {
                var getvalues = $(this).attr("getvalue").split("+");
                var realValue = "";
                for (var i = 0; i < getvalues.length; i++) {
                    if ($("#" + getvalues[i]).is("select")) {
                        realValue += $("#" + getvalues[i]).find("option:selected").text()
                    } else {
                        realValue += $("#" + getvalues[i]).val()
                    }
                }
                $(this).val(realValue)
            });
            var formFields = $("#form1").serializeArray();
            $("#progress-img").show();
            $("#submitBtn").text("正在查询...");
            PAGE_UTIL.goAjax({
                url: $("#form1").attr("action"),
                data: formFields,
                callback: PAGE_FORM.queryBack,
                errBack: function () {
                    $("#progress-img").hide();
                    $("#submitBtn").text("查询")
                }
            })
        }
    },
    queryBack: function (json) {
        $("#progress-img").hide();
        $("#submitBtn").text("查询");
        if (json.STATUS == "1") {
            PAGE_UTIL.alert(json.ERRMSG);
            if ($("#yzm_refresh_button").length > 0) {
                $("#yzm_refresh_button").click()
            }
            return
        }
        $("#redirectParam").val(PAGE_UTIL.obj2str(json));
        $("#form2_province").val($("#province").val());
        $("#form2_city").val($("#city").val());
        document.getElementById("form2").submit()
    },
    remCarInfo: function () {
        var rem = $("#remCarInfo").is(":checked");
        if (rem) {
            $.cookie("remMe", "true", {
                expires: 365
            });
            $.cookie("city", $("#city").val(), {
                expires: 365
            });
            var saveJson = {};
            $("#main_content").find("input[type=text]").each(function () {
                var name = $(this).attr("name");
                if (name != "yzm") {
                    saveJson[name] = $(this).val()
                }
            });
            $("#main_content").find("select").each(function () {
                var name = $(this).attr("name");
                if (name != "yzm") {
                    saveJson[name] = $(this).val()
                }
            });
            var saveStr = PAGE_UTIL.obj2str(saveJson);
            $.cookie("car_info", saveStr, {
                expires: 365
            })
        } else {
            $.cookie("remMe", "false", {
                expires: 365
            })
        }
    }
};
CITY_CTR = {
    initLocation: function () {
        var remMe = $.cookie("remMe");
        if (remMe == "true") {
            $("#remCarInfo").attr("checked", true);
            var city = $.cookie("city");
            COMM_DATA.selected = city;
            return
        }
        var selected = COMM_DATA.defaultArea;
        if (selected == "") {
            var _cn = sohu_IP_Loc;
            if (_cn != "unknow" && _cn != "unknown" && _cn != "undefined") {
                if (_cn.length >= 8) {
                    selected = _cn.substring(2)
                } else {
                    selected = _cn
                }
            }
        }
        COMM_DATA.selected = selected
    },
    initCity: function (cb) {
        var cityElement = $("#city").empty();
        var provinceCode = $("#province").val();
        var cities = COMM_DATA["cities"][provinceCode];
        var selected = COMM_DATA.selected;
        for (var i = 0; i < cities.length; i++) {
            var cityCode = cities[i].cityCode;
            var cityname = cities[i].cityName;
            var opSelect = "";
            if (cityCode === selected || cityCode === selected.substring(0, 4) + '00' || (PAGE_UTIL.isMuniciplity(cityCode) && cityCode === selected.substring(0, 2) + '0000')) {
                opSelect = " selected"
            }
            $("<option value='" + cityCode + "'" + opSelect + ">" + cityname + "</option>").appendTo(cityElement)
        }
        CITY_CTR.cityChange(cb)
    },
    cityChange: function (cb) {
        PAGE_UTIL.alert("");
        var cityCode = $("#city").val();
        COMM_DATA.currentCity = cityCode;
        PAGE_UTIL.goAjax({
            url: COMM_DATA.contextPath + "/front/getCityShowParam.at",
            data: {
                cityCode: cityCode
            },
            callback: function (json) {
                if (json.statusCode === "200") {
                    if (json.autoBreakFlag) {
                        $("#form1").attr("action", COMM_DATA.contextPath + "/common/api/queryByCity.at?appKey=pc")
                    } else {
                        $("#form1").attr("action", COMM_DATA.contextPath + "/queryByCity.at")
                    }
                    PAGE_RENDER.render(json.params);
                    if ($.isFunction(cb)) {
                        cb()
                    }
                } else if (json.statusCode === "300") {
                    PAGE_UTIL.alert(json.message)
                } else {
                    PAGE_UTIL.alert(PAGE_UTIL.obj2str(json))
                }
            }
        })
    },
    init: function () {
        this.initLocation();
        $("#province").val(COMM_DATA.selected.substring(0, 2) + '0000');
        $("#province").bind("change",
        function () {
            CITY_CTR.initCity(CITY_CTR.setDefaultValue)
        });
        $("#city").bind("change",
        function () {
            CITY_CTR.cityChange(CITY_CTR.setDefaultValue)
        });
        this.initCity(CITY_CTR.setDefaultValue)
    },
    setDefaultValue: function () {
        var remMe = $.cookie("remMe");
        if (remMe == "true") {
            var carInfoStr = $.cookie("car_info");
            if ((typeof carInfoStr) == "string" && carInfoStr.length > 0) {
                var carInfoJson = eval("(" + carInfoStr + ")");
                for (var fkey in carInfoJson) {
                    $("#" + fkey).focus().val(carInfoJson[fkey]).focusout()
                }
            }
        }
        $("#submitBtn").focus()
    }
};
$("document").ready(function () {
    CITY_CTR.init();
    var cityCount = 0;
    for (provCode in COMM_DATA.cities) {
        cityCount += COMM_DATA["cities"][provCode].length
    }
    $("#cityCount").html(cityCount);
    $(document).keydown(function (e) {
        if (e.which == 13) {
            PAGE_FORM.submit()
        }
    });
    $(document.body).click(function (e) {
        if (e.srcElement && e.srcElement.tagName != "A") {
            $("#more_city_tip").hide()
        }
    })
});


"basicParam": [{
    "name": "carNum",
    "title": "车牌号",
    "type": "united",
    "getvalue": "ecarBelong+ecarPart",
    "id": "1"
},
{
    "name": "ecarBelong",
    "type": "gridradio",
    "title": "车牌号",
    "values": "京=11,津=12,冀=13,晋=14,蒙=15,辽=21,吉=22,黑=23,沪=31,苏=32,浙=33,皖=34,闽=35,赣=36,鲁=37,豫=41,鄂=42,湘=43,粤=44,桂=45,琼=46,渝=50,川=51,贵=52,云=53,藏=54,陕=61,甘=62,青=63,宁=64,新=65,台=71",
    "default": "11",
    "line": "1",
    "id": "2"
},
{
    "name": "ecarPart",
    "title": "车牌号码",
    "type": "text",
    "hint": "所有英文字母大写",
    "line": "1",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "请输入正确车牌号"
    },
    {
        "matcher": "^[A-Z0-9]+",
        "desc": "请输入正确车牌号"
    },
    {
        "matcher": "^[\\w]{6}$",
        "desc": "请输入正确车牌号"
    }],
    "id": "3"
},
{
    "name": "ecarType",
    "type": "radio",
    "title": "车辆类型",
    "values": "大型汽车=01,小型汽车=02,两三轮摩托车=07,轻便摩托车=08,其它=99",
    "default": "02",
    "id": "5"
},
{
    "name": "engineNum",
    "title": "发动机号",
    "type": "text",
    "hint": "请输入正确发动机号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "请输入正确发动机号"
    },
    {
        "matcher": "^[\\w]{5,24}$",
        "desc": "请输入正确发动机号"
    }],
    "id": "4"
},
{
    "name": "evin",
    "type": "text",
    "title": "车架号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "请输入正确车架号"
    },
    {
        "matcher": "^[\\w]{17}$",
        "desc": "请输入正确车架号"
    }],
    "id": "6"
},
{
    "name": "ecarOwner",
    "type": "text",
    "title": "车主姓名",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "车主姓名不能为空并且不能包含空格"
    }],
    "id": "7"
},
{
    "name": "euserName",
    "type": "text",
    "title": "用户名",
    "upperlower": "2",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "用户名不能为空"
    }],
    "id": "8"
},
{
    "name": "epassword",
    "type": "password",
    "title": "密码",
    "upperlower": "2",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "密码不能为空"
    }],
    "id": "9"
},
{
    "name": "ecarinfo1",
    "type": "text",
    "title": "登记证书编号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "请输入正确登记证书编号"
    }],
    "id": "10"
},
{
    "name": "ecarinfo2",
    "type": "text",
    "title": "手机号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "手机号不能为空并且不能包含空格"
    }],
    "id": "11"
},
{
    "name": "ecarinfo3",
    "type": "text",
    "title": "证件号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "证件号不能为空并且不能包含空格"
    }],
    "id": "12"
},
{
    "name": "ecarinfo4",
    "type": "text",
    "title": "查询密码",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "查询密码不能为空并且不能包含空格"
    }],
    "id": "13"
},
{
    "name": "ecarinfo5",
    "type": "text",
    "title": "驾驶证号",
    "regulars": [{
        "matcher": "^[\\S]+$",
        "desc": "驾驶证号不能为空并且不能包含空格"
    }],
    "id": "14"
},
{
    "name": "yzm",
    "type": "image",
    "title": "验证码",
    "id": "15"
}]
