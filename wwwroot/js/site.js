function getUserId() {
    return getCookie("UserId");
}

function deleteUserId() {
    document.cookie = "UserId=; expires=-1; path=/";
}

function setUserId(id) {
    document.cookie = "UserId=" + id + "; path=/";
}

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}