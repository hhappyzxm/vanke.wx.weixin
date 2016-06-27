(function (angular, app) {
    'use strict';

    app.controller('EmployeeDiscountEditCtrl', function ($scope, $state, $stateParams, api, Upload, sweetAlert) {
        $scope.data = {
            ImagePath : '',
            OriginalImagePath: ''
        }

        api.employeeDiscounts.getTypes(function(result) {
            $scope.types = result;
        });

        if (!angular.isUndefined($stateParams.id)) {
            api.employeeDiscounts.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;

                $scope.uploadedFile = '/Upload/' + $scope.data.ImagePath;
            });
        }

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.employeeDiscounts.save($scope.data, function () {
                    $state.go('query.employeediscounts');
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

    app.filter('EmployeeDiscountEditCtrl_convert_type', function() {
        return function(input, capitalize_index, specified_char) {
            var output = '';

            switch (input) {
            case 0:
                output = '衣';
                break;
            case 1:
                output = '食';
                break;
            case 2:
                output = '住';
                break;
            case 3:
                output = '行';
                break;
            case 4:
                output = '健';
                break;
            }

            return output;
        }
    });
})(angular, app);