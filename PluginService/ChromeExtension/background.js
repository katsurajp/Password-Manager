chrome.runtime.onMessage.addListener(
    function (request, sender, sendResponse) {
        if (request.contentScriptQuery == "queryCredential") {
            var url = "http://localhost:9000/PwApi/Pw?u=" + encodeURIComponent(request.uri);

            $.get(url, function (response) {
                chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
                    chrome.tabs.sendMessage(tabs[0].id, { credentialData: response }, function (response) {
                        ;
                    });
                });
            });
        }
    }
);