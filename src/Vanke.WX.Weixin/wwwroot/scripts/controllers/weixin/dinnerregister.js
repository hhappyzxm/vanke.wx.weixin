(function (angular, app) {
    'use strict';

    app.controller('DinnerRegisterCtrl', function ($scope, api, sweetAlert) {
        api.dinnerTypes.query(function (result) {
            $scope.dinnerTypes = result;
        });

        api.dinnerPlaces.query(function (result) {
            $scope.dinnerPlaces = result;
        });

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.dinnerRegister.save($scope.data, function () {
                    sweetAlert.success('提交成功');
                    form.$submitted = false;
                    $scope.data = null;
                });
            }
        };
    });

})(angular, window.app);