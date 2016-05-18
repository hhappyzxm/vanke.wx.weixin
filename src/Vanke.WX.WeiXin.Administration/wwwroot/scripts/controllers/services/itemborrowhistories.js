(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowHistoriesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        api.itemBorrow.query(function (result) {
            $scope.itemBorrowHistories = result;
        });

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(2).notSortable()
        ];

        $scope.cancel = function (id) {
            sweetAlert.confirm(
                "你将取消这条数据!",
                function(resover) {
                    api.itemBorrowHistories.remove({ id: id }, function () {
                        for (var i = 0; i < $scope.itemBorrowHistories.length; i++) {
                            if ($scope.itemBorrowHistories[i].ID === id) {
                                $scope.itemBorrowHistories.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);