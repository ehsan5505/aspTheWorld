(function () {
    "use strict";
    angular.module('simpleDirect', [])
    .directive('waitCursor', waitCursor);

    function waitCursor() {
        return {
            restrict: 'E',
            scope:{
                display:"=display"
            },
            templateUrl: "/views/waitCursor.html"
        };
    }

})();