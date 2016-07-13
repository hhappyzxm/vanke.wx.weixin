(function (angular, app) {
    'use strict';

    app.controller('StaffsCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder, Upload) {
        $scope.isImporting = false;
        $scope.importState = "导入";

        api.staffs.query(function (result) {
            $scope.staffs = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(3).notSortable()
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
                api.staffs.import({ FileName: response.data[0] },
                    function(result) {
                        var successed = result.Successed;
                        sweetAlert.success("导入成功" + successed + "个新账户");
                        $scope.isImporting = false;
                        $scope.importState = "导入";
                    },
                    function() {
                        $scope.isImporting = false;
                        $scope.importState = "导入";
                    });
            });
        };

        $scope.remove = function (id) {
            sweetAlert.confirm(
                "你将删除这条数据!",
                function(resover) {
                    api.staffs.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.staffs.length; i++) {
                            if ($scope.staffs[i].ID === id) {
                                $scope.staffs.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);