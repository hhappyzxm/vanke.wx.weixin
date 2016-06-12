(function (angular, app) {
    'use strict';

    app.controller('ExternalPersonnelDiningRegisterHistoriesCtrl', function ($scope, api) {
        api.externalPersonnelDiningRegister.getOwnHistories(function (result) {
            $scope.histories = result;
        });
    });

})(angular, window.app);