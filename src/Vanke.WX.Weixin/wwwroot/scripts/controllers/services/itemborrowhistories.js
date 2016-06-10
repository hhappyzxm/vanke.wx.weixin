(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowHistoriesCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        $scope.filterStatus = '0';

        var loadData = function() {
            api.itemBorrow.search({ status: $scope.filterStatus }, function (result) {
                $scope.itemBorrowHistories = result;
            });
        }

        loadData();

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(6).notSortable()
        ];

        $scope.cancel = function (id) {
            sweetAlert.confirm(
                "你将取消这条数据!",
                function(resover) {
                    api.itemBorrow.cancel({ id: id }, function () {
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

        $scope.search = function() {
            loadData();
        }
    });

})(angular, window.app);