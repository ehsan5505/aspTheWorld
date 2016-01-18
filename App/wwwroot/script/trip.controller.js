(function () {
    "use strict";

    //this is the module of the core
    var app = angular.module("app-trips");

    app.controller("tripController", tripController);

    function tripController() {
        var vm = this;
        vm.name = "Ehsan involve in the test";
    }

})();