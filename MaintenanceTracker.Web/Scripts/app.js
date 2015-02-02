var app = angular.module("garage", ["ngRoute", "garageControllers", 'ui.select', 'ngSanitize']);

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

app.config(function (uiSelectConfig) {
    uiSelectConfig.theme = 'bootstrap';
});

app.filter('range', function () {
    return function (input, min, max) {
        min = parseInt(min);
        max = parseInt(max);
        for (var i = min; i < max; i++)
            input.push(i);
        return input;
    };
});