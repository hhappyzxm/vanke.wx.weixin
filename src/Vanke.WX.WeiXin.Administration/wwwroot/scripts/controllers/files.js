(function (angular, app) {
    'use strict';

    app.controller('FilesCtrl', function ($rootScope, $scope, Upload, authService, sweetAlert) {
        
        function uploadUsing$http(file) {
            file.upload = Upload.http({
                url: 'http://localhost:54843/api/files',
                //method: 'POST',
                //headers:
                //  {
                //      'Content-Type': 'multipart/form-data'//file.type
                //  },
                data: {file: file}
            });

            file.upload.then(function (response) {
                file.result = response.data;
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            });

            //file.upload.progress(function (evt) {
            //    file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            //});
        }

        $scope.upload = uploadUsing$http;
    });

})(angular, app);