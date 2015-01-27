angular.module("garage", [])
    .controller("garageController", ["$scope", "$http", function ($scope, $http) {
        $scope.vehicles = $http.get(vehicleService);

        $scope.add = function() {
            alert = ('add vehcile');
        }
}])