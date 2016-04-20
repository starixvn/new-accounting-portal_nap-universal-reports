(function ($) {
    'use strict';

    angular
        .module('app.core')
        .run(reCheckIn);

    reCheckIn.$inject = ['$interval', 'legacyService'];
    function reCheckIn($interval, legacyService) {
        $interval(callback, 60000);

        function callback() {
            var url = legacyService.resolveUrl('/UserLogin/Login/ReCheckLogin');
            $.post(url, function (result) {
                if (result.IsKickedOut === "1") {
                    alert('Another session has been logged in or your session is expired. Forced to logout!');
                    window.location.href = legacyService.resolveUrl('/UserLogin/Login/LogOut');
                } else if (result.IsKickedOut === "-1") {
                    window.location.href = legacyService.resolveUrl('/UserLogin/Common/Offline');
                }
            });
        }
    }
})(jQuery);