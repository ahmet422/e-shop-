$(document).ready(function () {

    var theForm = $("#theForm");
    theForm.hide();

    var buyButton = $("#buyButton");
    buyButton.on('click', function () {
        // console.log("Buying item");
        //theForm.toggle();
    });

    var productInfo = $(".product-props li");
    productInfo.on('click', function () {
        console.log("Clicked " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on('click', function () {
        $popupForm.toggle(1000);
    })



});
