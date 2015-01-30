var garageControllers = angular.module("garageControllers", []);

garageControllers.controller("vehicleController", [
    "$scope", "$http", "$routeParams", function ($scope, $http, $routeParams) {
        $scope.id = $routeParams.vehicleId;

        $scope.update = function(vehicle) {
            $http.put(vehicleService, vehicle);
        }

        $scope.refreshMakes = function(searchTerm) {
            $scope.makes = $http.get(makeService);
        }
    }
]);

garageControllers.controller("vehiclesController", [
    "$scope", "$http", "$location", function($scope, $http, $location) {
        $http.get(vehicleService)
            .success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    $scope.vehicles.push({ Year: data[i].year });
                }
            });

        $scope.add = function () {
            $location.path("vehicle/0 ");
        }
    }
]);