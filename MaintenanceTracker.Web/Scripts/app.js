var app = angular.module("garage", ["ngRoute", "garageControllers", 'ngSanitize']);

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

app.filter('range', function () {
    return function (input, min, max) {
        min = parseInt(min);
        max = parseInt(max);
        for (var i = min; i < max; i++)
            input.push(i);
        return input;
    };
});

app.directive("autoCompleteSelector", ["$http", function ($http) {
    function link(scope, element, attrs) {
        scope.value = attrs.binding;
        
        if (attrs.characterCount)
            scope.characterCount = attrs.searchCount;
        else
            scope.characterCount = 3;

        scope.url = attrs.url;

        scope.options = $http.get(scope.url).success(function (data) {
            for (var i = 0; i < data.length; i++) {
                scope.options.push(data[i]);
            }
            alert(scope.options[0]);
        });
    };

    return {
        restrict: 'AE',
        templateUrl: "scripts/templates/AutoCompleteSelector.html",
        scope: true,
        link: link
    };
}]);