angular.module("vehicles", [])
    .controller("vehiclesController", ["$scope", "$http", function($scope, $http) {
        $scope.vehicles = $http.get()
    }])