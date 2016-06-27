(function (angular, app) {
    'use strict';

    app.controller('EmployeeDiscountsCtrl', function ($scope, $location, api) {
        var type = $location.search().t;

        api.employeeDiscounts.search({ type: type }, function (result) {
            $scope.employeeDiscounts = result;
        });

        switch (type) {
        case '0':
            $scope.type = '衣';
            break;
        case '1':
            $scope.type = '食';
            break;
        case '2':
            $scope.type = '住';
            break;
        case '3':
            $scope.type = '行';
            break;
        case '4':
            $scope.type = '健';
            break;
        }
    });

})(angular, window.app);