
var css_file = document.createElement("link");
var widgetUrl = location.href;
css_file.setAttribute("rel", "stylesheet");
css_file.setAttribute("type", "text/css");
css_file.setAttribute("href", 'https://s.bookcdn.com/css/w/booked-wzs-widget-160x275.css?v=0.0.1');
document.getElementsByTagName("head")[0].appendChild(css_file);

function setWidgetData_5573(data) {
    if (typeof (data) != 'undefined' && data.results.length > 0) {
        for (var i = 0; i < data.results.length; ++i) {
            var objMainBlock = document.getElementById('m-booked-bl-simple-week-vertical-5573');
            if (objMainBlock !== null) {
                var copyBlock = document.getElementById('m-bookew-weather-copy-' + data.results[i].widget_type);
                objMainBlock.innerHTML = data.results[i].html_code;
                if (copyBlock !== null) objMainBlock.appendChild(copyBlock);
            }
        }
    } else {
        alert('data=undefined||data.results is empty');
    }
}
var widgetSrc = "https://widgets.booked.net/weather/info?action=get_weather_info;ver=7;cityID=2162;type=4;scode=124;ltid=3458;domid=w209;anc_id=46403;countday=undefined;cmetric=1;wlangID=1;color=137AE9;wwidth=255;header_color=ffffff;text_color=333333;link_color=08488D;border_form=1;footer_color=ffffff;footer_text_color=333333;transparent=0;v=0.0.1";
widgetSrc += ';ref=' + widgetUrl;
widgetSrc += ';rand_id=5573';
var weatherBookedScript = document.createElement("script");
weatherBookedScript.setAttribute("type", "text/javascript");
weatherBookedScript.src = widgetSrc;
document.body.appendChild(weatherBookedScript)