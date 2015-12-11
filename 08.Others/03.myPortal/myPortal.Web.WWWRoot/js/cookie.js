function setCookie(name, value, hours){
	var expireDate=new Date(new Date().getTime()+hours*3600000);
	document.cookie = name + "=" + escape(value) + "; expires=" + expireDate.toGMTString() ;
}
function delCookie(name) {
	var expireDate=new Date(new Date().getTime());
	document.cookie = name + "= ; expires=" + expireDate.toGMTString() ;
}
function getCookie(name) {
	var search = name + "=";
	var offset = document.cookie.indexOf(search);
	if (offset != -1) {
		offset += search.length;
		var end = document.cookie.indexOf(";", offset);
		if (end == -1)
			end = document.cookie.length;
		return unescape(document.cookie.substring(offset, end));
	}
	else return "";
}
function _getCookie(name){
	return (document.cookie.match(new RegExp("(^"+name+"| "+name+")=([^;]*)"))==null)?"":decodeURIComponent(RegExp.$2);
}