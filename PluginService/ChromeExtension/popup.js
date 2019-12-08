
'use strict';

let inputUsername = document.getElementById('inputUsername');
let inputPassword = document.getElementById('inputPassword');

inputUsername.onclick = function (element) {
    chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
        chrome.tabs.executeScript({ file: 'jquery.js' }, function () {
            chrome.tabs.executeScript(
                tabs[0].id,
                { file: "InputUsername.js" }
            )
        });
    });
};

inputPassword.onclick = function (element) {
    chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
        chrome.tabs.executeScript({ file: 'jquery.js' }, function () {
            chrome.tabs.executeScript(
                tabs[0].id,
                { file: "inputPassword.js" }
            )
        });
    });
};