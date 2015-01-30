var app = angular.module("garage", ["ngRoute", "garageControllers"]);

app.config([
    "$routeProvider",
    function($routeProvider) {
        $routeProvider.
            when("/vehicle/:vehicleId", {
                templateUrl: "scripts/templates/vehicle.html",
                controller: "vehicleController"
            })
            .when("/vehicles", {
                templateUrl: "scripts/templates/vehicles.html",
                controller: "vehiclesController"
            })
            .otherwise({
                redirectTo: "/vehicles"
            });
    }
]);