(function (angular, app) {
    'use strict';

    app.controller('IdleAssetsCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder, Upload) {
        api.idleAssets.query(function (result) {
            $scope.idleAssets = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(6).notSortable()
        ];

        $scope.selectFile = function(file) {
            Upload.upload({
                url: '/api/files',
                data: { file: file }
            }).then(function (response) {
                var fileName = response.data[0];
            });
        };

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.idleAssets.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.idleAssets.length; i++) {
                            if ($scope.idleAssets[i].ID === id) {
                                $scope.idleAssets.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);