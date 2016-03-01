(function () {
    'use strict';

    angular
        .module('app.core')
        .run(reCheckIn);

    reCheckIn.$injector = ['$http', '$interval', 'config'];
    function reCheckIn($http, $interval, config) {
        $interval(callback, 60000);

        function callback() {
            var url = config.legacyPath + "/UserLogin/Login/ReCheckLogin";
            $http.post(url).then(function (result) {
                if (result.IsKickedOut === "1") {
                    alert('Another session has been logged in or your session is expired. Forced to logout!');
                    window.location.href = config.legacyPath + "/UserLogin/Login/LogOut";
                } else if (result.IsKickedOut === "-1") {
                    window.location.href = config.legacyPath + "/UserLogin/Common/Offline";
                }
            });
        }
    }
})();