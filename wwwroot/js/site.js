// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

let textareaCounters = document.querySelectorAll('.js-textarea-count');
textareaCounters.forEach((element) => {
    UpdateTextareaCount(element);
    element.addEventListener('keyup', (event) => UpdateTextareaCount(event.target));
});

function UpdateTextareaCount(textareaElem) {
    let areaLength = textareaElem.value.length;
    let currentCountElem = textareaElem.nextElementSibling.querySelector('.js-current-count');
    currentCountElem.innerHTML = areaLength;
}