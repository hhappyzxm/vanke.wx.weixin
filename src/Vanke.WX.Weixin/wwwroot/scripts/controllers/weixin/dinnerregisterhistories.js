(function (angular, app) {
    'use strict';

    app.controller('DinnerRegisterHistoriesCtrl', function ($scope, api) {
        api.dinnerRegister.getOwnHistories(function (result) {
            $scope.histories = result;
        });
    });

})(angular, window.app);