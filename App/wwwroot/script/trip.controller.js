(function () {
    "use strict";

    //this is the module of the core
    var app = angular.module("app-trips");

    app.controller("tripController", tripController);

    function tripController($http) {
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

        //getting the service        
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips")
            .success(function (data) {
                angular.copy(data, vm.trips);
                //console.log(data[0]);
            })
            .error(function (err) {
                vm.errorMessage = "Error in loading the data " + err;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        //posting the service
        vm.addTrip = function () {
            //vm.trips.push({
            //    "name": vm.newTrip.name,
            //    "date": new Date()
            //});
            vm.errorMessage = "";
            vm.isBusy = true;

            $http.post("/api/trips", vm.newTrip)
                .success(function (data) {
                    vm.trips.push(data);
                }).error(function (err) {
                    vm.errorMessage = err;
                }).finally(function () {
                    vm.isBusy = false;
                })
            vm.newTrip = {}; // clear the trip
        }

    }

})();