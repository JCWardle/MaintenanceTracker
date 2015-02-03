var garageControllers = angular.module("garageControllers", []);

garageControllers.controller("vehicleController", [
    "$scope", "$http", "$routeParams", function($scope, $http, $routeParams) {
        $scope.vehicle = {
            id: $routeParams.vehicleId
        };
        $scope.modelSelectActive = false;
        $scope.models = [];

        $scope.update = function(vehicle) {
            $http.put(vehicleService, vehicle);
        }

        $http.get(makeService)
            .success(function(data) {
                $scope.makes = data;
            });

        $scope.modelSelect = function(model) {
            $scope.model = model;
        };

        $scope.yearSelect = function (year) {
            $scope.vehicle.Year = year;
        };

        $scope.makeSelect = function (make) {
            $scope.modelSelectActive = true;
            $scope.make = make;
            $scope.models = [];
            $scope.model = {};
            $http.get(modelService + "?make=" + make.Name)
            .success(function(data) {
                for (var i = 0; i < data.length; i++) {
                    $scope.models.push(data[i]);
                }
            });
        };
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

        $scope.add = function() {
            $location.path("vehicle/0 ");
        };
    }
]);