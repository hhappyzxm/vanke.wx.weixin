(function (angular, app) {
    'use strict';

    app.controller('DinnerRegisterCtrl', function ($scope, $window, $filter, api) {
        api.account.getUserInfo(function (result) {
            $scope.isExternalPersonnelDiningManager = result.IsExternalPersonnelDiningManager;
        });

        api.dinnerTypes.query(function (result) {
            $scope.dinnerTypes = result;
        });

        api.dinnerPlaces.query(function (result) {
            $scope.dinnerPlaces = result;
        });

        api.dinnerRegister.getOwnHistories(function (result) {
            $scope.hasHistories = result.length > 0;
        });

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.dinnerRegister.save($scope.data, function () {
                    $window.location.href = "/weixin/dinnerregisterhistories#?isown=true";
                });
            }
        };
    });

})(angular, window.app);