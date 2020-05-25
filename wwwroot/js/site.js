function getUserId() {
    return getCookie("UserId")
}

function deleteUserId() {
    document.cookie = "UserId=; expires=-1";
}

function setUserId(id) {
    document.cookie = "UserId=" + id;
}

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}