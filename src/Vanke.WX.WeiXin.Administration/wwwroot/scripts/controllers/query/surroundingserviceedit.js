(function (angular, app) {
    'use strict';

    app.controller('SurroundingServiceEditCtrl', function ($scope, $state, $stateParams, api, Upload) {
        if (!angular.isUndefined($stateParams.id)) {
            api.surroundingServices.get({ id: $stateParams.id }, function (result) {
                $scope.data = result;
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

        function uploadUsing$http(file) {
            Upload.upload({
                url: 'http://localhost:54843/api/files',
                //method: 'POST',
                //headers:
                //  {
                //      'Content-Type': 'multipart/form-data'//file.type
                //  },
                data: { file: file }
            });

            //file.upload.then(function (response) {
            //    file.result = response.data;
            //}, function (response) {
            //    if (response.status > 0)
            //        $scope.errorMsg = response.status + ': ' + response.data;
            //});

            //file.upload.progress(function (evt) {
            //    file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            //});
        }

        $scope.upload = uploadUsing$http;
    });

})(angular, app);