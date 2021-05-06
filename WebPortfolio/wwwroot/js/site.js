// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

// Email Notification 
function showLoadingSpinner() {
    $('#loading_button').prop('disabled', true);
    $('#loading_button').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>  Loading...');
}

function showNotification() {
    $('#loading_button').prop('disabled', false);
    $('#loading_button').html('Submitted');
    $('.toast').toast('show');
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

// Header Animation
var tl = anime.timeline();

var fill_with_squares = function () {
    var quantity = 400;

    for (var i = 0; i < quantity; i++) {
        $('.background_container').append('<div class="smaller_square"  style="width:' + 5 + '%; height:' + 5 + '%"></div>');
    }
};

tl
    .add({
        targets: '.staggering',
        translateY: '50vh',
        delay: anime.stagger(150, { easing: 'easeOutQuad' })
    }).add({
        targets: '.staggering',
        easing: 'easeInOutQuad',
        opacity: 0
    }).add({
        targets: '.background_container #svgGroup path',
        strokeDashoffset: [anime.setDashoffset, 0],
        easing: 'easeInOutSine',
        duration: 3000,
        direction: 'alternate',
        begin: function () {
            document.querySelector('.background_container').style.display = 'block';
        }
    }).add({
        targets: '.background_container',
        complete: fill_with_squares(),
        background: ['#fff', '#F8F8FF'],
    }).add({
        targets: '.background_container .smaller_square',
        scale: [
            { value: .1, easing: 'easeOutSine', duration: 500 },
            { value: 1, easing: 'easeInOutQuad', duration: 1200 }
        ],
        delay: anime.stagger(300, { grid: [20, 20], from: 'center' }),
        complete: function (anim) { anim.reverse(); anim.restart(); }
    });