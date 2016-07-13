(function (angular, app) {
    'use strict';

    app.controller('IdleAssetsCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder, Upload) {
        $scope.isImporting = false;
        $scope.importState = "导入";

        var loadData = function () {
            api.idleAssets.query(function (result) {
                $scope.idleAssets = result;
            });
        };

        loadData();

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(6).notSortable()
        ];

        $scope.selectFile = function (file) {
            if (file == null) {
                return;
            }
            $scope.isImporting = true;
            $scope.importState = "导入中...";
            Upload.upload({
                url: '/api/files',
                data: { file: file }
            }).then(function (response) {
                api.idleAssets.import({ FileName: response.data[0] },
                    function () {
                        sweetAlert.success("导入成功");
                        $scope.isImporting = false;
                        $scope.importState = "导入";
                        loadData();
                    },
                    function () {
                        $scope.isImporting = false;
                        $scope.importState = "导入";
                    });
            });
        };

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function (resover) {
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