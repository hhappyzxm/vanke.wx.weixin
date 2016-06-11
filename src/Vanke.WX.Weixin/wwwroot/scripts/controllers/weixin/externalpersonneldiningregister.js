(function (angular, app) {
    'use strict';

    app.controller('ExternalPersonnelDiningRegisterCtrl', function ($scope, api) {
        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.externalPersonnelDiningRegister.save($scope.data, function () {
                    //$state.go('settings.dinnerplaces');
                });
            }
        };
    });

})(angular, window.app);