var url = encodeURIComponent(window.location.origin);

chrome.runtime.sendMessage(
    {
        contentScriptQuery: "queryCredential",
        uri: url
    },
    function (response) {
        ;
    }
);

chrome.runtime.onMessage.addListener(
    function DoIt(request, sender, sendResponse) {
        chrome.runtime.onMessage.removeListener(DoIt);

        var element = $(document.activeElement);

        if (element.is('input')) {
            document.execCommand('insertText', false, request.credentialData.Password);
        }
    }
);