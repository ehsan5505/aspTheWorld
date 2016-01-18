(function () {
    "use strict";

    //this is the module of the core
    var app = angular.module("app-trips");

    app.controller("tripController", tripController);

    function tripController() {
        var vm = this;
        vm.test = "Ehsan involve in the test";

        vm.trips = [
            {
                "name": "US Trip",
                "date": new Date()
            },
            {
                "name": "World Trip",
                "date": new Date()
            }
        ];

        vm.newTrip = {};

        vm.addTrip = function () {
            vm.trips.push({
                "name": vm.newTrip.name,
                "date": new Date()
            });

            vm.newTrip = {}; // clear the trip
            //alert(vm.newTrip.name);
        }

    }

})();