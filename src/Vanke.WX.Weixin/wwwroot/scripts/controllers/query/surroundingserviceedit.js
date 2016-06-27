(function (angular, app) {
    'use strict';

    app.controller('SurroundingServiceEditCtrl', function ($scope, $state, $stateParams, api, Upload, sweetAlert) {
        $scope.data = {
            ImagePath: '',
            OriginalImagePath: ''
        }

        if (!angular.isUndefined($stateParams.id)) {
            api.surroundingServices.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;

                $scope.uploadedFile = '/Upload/' + $scope.data.ImagePath;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.surroundingServices.save($scope.data, function () {
                    $state.go('query.surroundingservices');
                });
            }
        };

        $scope.upload = function (file) {
            Upload.upload({
                url: '/api/files',
                data: { file: file }
            }).then(function (response) {
                $scope.data.OriginalImagePath = $scope.data.ImagePath;
                $scope.data.ImagePath = response.data[0];
                $scope.uploadedFile = '/Temp/' + $scope.data.ImagePath;
                sweetAlert.success('上传成功');
            });
        };
    });

})(angular, app);