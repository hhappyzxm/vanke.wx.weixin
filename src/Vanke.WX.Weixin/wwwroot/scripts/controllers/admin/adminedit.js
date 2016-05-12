(function (angular) {
    'use strict';

    angular
        .module('architecture')
        .controller('AdminEditCtrl', function ($scope, api, sweetAlert) {
            $scope.data = {};

            $scope.save = function(isValid) {
                if(isValid) {
                    api.createAdmin($scope.data, function () {

                    });
                }
            };
        });

})(angular);