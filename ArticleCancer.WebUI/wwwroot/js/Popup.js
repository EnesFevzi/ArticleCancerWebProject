document.addEventListener("DOMContentLoaded", function () {
    // Kullanıcı daha önce zaten kayıt olmuşsa, popup'u gösterme
    var isUserLoggedIn = checkUserLoggedIn(); // Bu fonksiyonun gerçek uygulamanıza uyarlanması gerekiyor
    if (!isUserLoggedIn) {
        showPopup();
    }
});

function checkUserLoggedIn() {
    var userLoggedInCookie = getCookie("ArticleCancer");

    return userLoggedInCookie === "true";
}

function getCookie(cookieName) {
    var name = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');
    for (var i = 0; i < cookieArray.length; i++) {
        var cookie = cookieArray[i];
        while (cookie.charAt(0) == ' ') {
            cookie = cookie.substring(1);
        }
        if (cookie.indexOf(name) == 0) {
            return cookie.substring(name.length, cookie.length);
        }
    }
    return "";
}


function showPopup() {
    // Overlay (örtü) elementini oluştur
    var overlayElement = document.createElement("div");
    overlayElement.style = "position: fixed; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.5); z-index: 1000;";
    document.body.appendChild(overlayElement);

    // Popup içeriğini oluştur
    var popupContent = "<p>Giriş Yapmanız Gerekmektedir.</p>";

    // Giriş Yap ve Kayıt Ol butonları
    var loginButton = document.createElement("button");
    loginButton.innerHTML = "Giriş Yap";
    loginButton.className = "popup-button"; // Stili uygula
    loginButton.addEventListener("click", function () {
        window.location.href = "/Auth/Login";
    });

    var registerButton = document.createElement("button");
    registerButton.innerHTML = "Kayıt Ol";
    registerButton.className = "popup-button"; // Stili uygula
    registerButton.addEventListener("click", function () {
        window.location.href = "/Auth/Register";
    });

    // Popup içeriğini ve butonları bir araya getir
    var popupElement = document.createElement("div");
    popupElement.innerHTML = popupContent;
    popupElement.appendChild(loginButton);
    popupElement.appendChild(registerButton);

    // Popup stilini ayarla
    var popupStyle = "position: fixed; top: 50%; left: 50%; transform: translate(-50%, -50%); padding: 20px; background-color: white; border: 1px solid #ddd; z-index: 1001;";
    popupElement.style = popupStyle;

    // Popup'ı overlay üzerine ekle
    overlayElement.appendChild(popupElement);

    // Kapatma işlemi (örneğin, tıklama) eklemek için event listener kullanabilirsiniz
    popupElement.addEventListener("click", function (event) {
        // Tıklanan element popup içeriği ise kapatma işlemi gerçekleşmez
        event.stopPropagation();
    });

    document.body.appendChild(popupElement);
}

