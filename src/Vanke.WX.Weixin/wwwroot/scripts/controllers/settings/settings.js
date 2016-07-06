(function (angular, app) {
    'use strict';

    app.controller('SettingsCtrl', function ($scope, api, sweetAlert) {
        api.settings.get(function (result) {
            $scope.data = result;
        });

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.settings.save($scope.data, function () {
                    sweetAlert.success("保存成功");
                });
            }
        };
    });

})(angular, window.app);